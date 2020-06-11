using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVision.InteractiveROI
{
    public partial class FrmInteractiveROI : Form
    {
        protected internal bool _isCtrlKeyPressed, _isAltKeyPressed;
        protected ProVision.InteractiveROI.ROIManager _ROIManager;
        protected ProVision.InteractiveROI.HWndCtrller _HwndCtrller;
        protected HalconDotNet.HObject _hoImage;
        protected HalconDotNet.HObject _hoBrushRegion, _hoRawRegion, _hoResultRegion, _selectedRegn;
        protected bool _isErasingRegion, _isObtainedResultRegion, _isTransmitRegion, _isErasedRegion;//是否在擦除区域,是否获取到待擦除区域,是否传入待擦除区域,是否完成擦除
        protected double _brushZoomFactor;
        protected string _brushColor, _resultRegionColor, _selectedRegionColor;
        protected HalconDotNet.HTuple _imgWidth, _imgHeight;

        public ProVision.Communal.Language LanguageVersion { protected set; get; }


        private FrmInteractiveROI()
        {
            InitializeComponent();

            this.Load += FrmInteractiveROI_Load ;
            this.SizeChanged += FrmInteractiveROI_SizeChanged;
            this.FormClosing += FrmInteractiveROI_FormClosing;
            this.KeyDown += FrmInteractiveROI_KeyDown;
            this.KeyUp += FrmInteractiveROI_KeyUp;
        }

    
        public FrmInteractiveROI(ProVision.Communal.Language lan):this()
        {
            LanguageVersion = lan;
        }

        public FrmInteractiveROI(ProVision.Communal.Language lan,HalconDotNet.HObject hoImg) : this()
        {
            LanguageVersion = lan;
            _hoImage = hoImg;
            this.btnLoadImage.Enabled = false;
        }


        public FrmInteractiveROI(ProVision.Communal.Language lan, HalconDotNet.HObject hoImg, HalconDotNet.HObject region):this(lan,hoImg)
        {
            _hoResultRegion = region;
            _isTransmitRegion = true;
        }


        protected internal virtual void FrmInteractiveROI_Load(object sender, EventArgs e)
        {
            InitFieldAndProperty();
            UpdateControl();

            if(_hoImage!=null
                && _hoImage.IsInitialized())
            {
                _HwndCtrller.AddHobjEntity(_hoImage);
                _HwndCtrller.Repaint();//ROI--传递图像,重新渲染图形
            }
        }

        protected internal virtual void FrmInteractiveROI_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.WindowState)
                {
                    case FormWindowState.Maximized:
                    case FormWindowState.Normal:
                        if (_hoImage != null
                            && _hoImage.IsInitialized())
                        {
                            if (_HwndCtrller != null)
                                _HwndCtrller.Repaint();//ROI交互--窗体尺寸改变,重新绘图
                        }
                        break;
                }

            }
            catch (HalconDotNet.HalconException hex)
            {

            }
        }

        protected internal virtual void FrmInteractiveROI_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
            if (!_isErasedRegion)
            {
                string txt = isChs ? "擦除区域未完成!\r\n是否离开?" : "Erasing area not finished!\r\n Exit now ?";
                string caption = isChs ? "询问信息" : "Question Message";

                if (!(ProVision.Communal.FrmMsgBox.Show(txt, caption,
                    ProVision.Communal.MyButtons.YesNo, ProVision.Communal.MyIcon.Question, isChs) == DialogResult.Yes))
                    e.Cancel = true;
            }
            else
            {
                string txt = isChs ? "擦除区域完成!" : "Erasing area finished!";
                string caption = isChs ? "提示信息" : "Prompt Message";
                ProVision.Communal.FrmMsgBox.Show(txt, caption,
                    ProVision.Communal.MyButtons.OK, ProVision.Communal.MyIcon.Information, isChs);
            }
        }

        protected internal virtual void FrmInteractiveROI_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Modifiers)
            {
                case Keys.Alt:
                    _isAltKeyPressed = false;
                    this.rdbtnMove.Checked = _isAltKeyPressed;
                    break;
                case Keys.Control:
                    _isCtrlKeyPressed = false;
                    this.rdbtnZoom.Checked = _isCtrlKeyPressed;
                    break;
                default:
                    break;
            }
        }

        protected internal virtual void FrmInteractiveROI_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Modifiers)
            {
                case Keys.Alt:
                    _isAltKeyPressed = true;
                    this.rdbtnMove.Checked = _isAltKeyPressed;
                    break;
                case Keys.Control:
                    _isCtrlKeyPressed = true;
                    this.rdbtnZoom.Checked = _isCtrlKeyPressed;
                    break;
                default:
                    break;
            }
        }


        protected internal virtual void InitFieldAndProperty()
        {
            _isCtrlKeyPressed = false;
            _isAltKeyPressed = false;
            this.rdbtnNone.Checked = false;
            this.rdbtnNone.Checked = true;

            _ROIManager = new ProVision.InteractiveROI.ROIManager();
            _HwndCtrller = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay);
            _HwndCtrller.RegisterHwndCtrlMouseEvents();
            _HwndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);
            _HwndCtrller.RegisterROICtroller(_ROIManager);
            _ROIManager.SetActiveROISign(ProVision.InteractiveROI.ROIManager.ROI_MODE_POS);

            //引用变量复位           
            _hoRawRegion = null;
            _hoBrushRegion = null;
            _hoResultRegion = null;
            _imgWidth = null;
            _imgHeight = null;
            _brushColor = "white";
            _resultRegionColor = "yellow";
            _selectedRegionColor = "green";

            _isErasingRegion = false;
            _isErasedRegion = false;
            _isObtainedResultRegion = false;
            _brushZoomFactor = 15.0d;
        }

        protected internal virtual void UpdateControl()
        {
            try
            {
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;              
                this.KeyPreview = true; //窗体相应按键

                //恢复初态
                this.rdbtnNone.Checked = false;
                this.rdbtnNone.Checked = true;

                bool isChs = (LanguageVersion == ProVision.Communal.Language.Chinese);
                string str = this.Tag.ToString();
                this.Text = isChs ? ProVision.Properties.Resources.ResourceManager.GetString("chs_" + str) : ProVision.Properties.Resources.ResourceManager.GetString("en_" + str);

                UpdateGroupBox(this.grpbOperation, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateGroupBox(this.grpbShapeOption, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateGroupBox(this.grpbViewOption, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

                UpdateButton(this.btnLoadImage, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnDeleteActiveROI, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnResetWindow, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnDeleteAllROI, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

                UpdateButton(this.btnLine, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnCircle, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnAnnulus, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnRectangle1, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnRectangle2, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateButton(this.btnCircularArc, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

                UpdateRadioButton(this.rdbtnNone, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateRadioButton(this.rdbtnMove, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateRadioButton(this.rdbtnZoom, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
                UpdateRadioButton(this.rdbtnManify, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

                this.cmbROIList.SelectedIndexChanged += CmbROIList_SelectedIndexChanged;

                HalconDotNet.HOperatorSet.SetSystem("tsp_height", 10000);
                HalconDotNet.HOperatorSet.SetSystem("tsp_width", 10000);
                HalconDotNet.HOperatorSet.SetDraw(this.hWndcDisplay.HalconWindow, "margin");
                HalconDotNet.HOperatorSet.SetColor(this.hWndcDisplay.HalconWindow, "blue");  //加载区域的显示颜色
                HalconDotNet.HOperatorSet.SetLineWidth(this.hWndcDisplay.HalconWindow, 1.5);

            }
            catch (HalconDotNet.HalconException hex)
            { }           
        }    

        protected internal virtual void UpdateGroupBox(System.Windows.Forms.GroupBox grpb,ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (grpb != null
               && grpb.Tag != null)
            {
                if (resourceManager != null)
                {
                    bool isChs = (lan == ProVision.Communal.Language.Chinese);
                    string str = grpb.Tag.ToString();
                    grpb.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
            }
        }

        protected internal virtual void UpdateRadioButton(System.Windows.Forms.RadioButton rdbtn, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (rdbtn != null
               && rdbtn.Tag != null)
            {
                if (resourceManager != null)
                {
                    rdbtn.CheckedChanged -= Rdbtn_CheckedChanged;
                    bool isChs = (lan == ProVision.Communal.Language.Chinese);
                    string str = rdbtn.Tag.ToString();
                    rdbtn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                    rdbtn.CheckedChanged += Rdbtn_CheckedChanged;
                }
            }
        }

        protected internal virtual void Rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rdbtn = sender as System.Windows.Forms.RadioButton;
            if(rdbtn!=null
                && rdbtn.Tag!=null)
            {
                switch(rdbtn.Tag.ToString())
                {
                    case "RDBTN_NONE":
                        if(rdbtn.Checked)
                        {
                            _HwndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);
                            _HwndCtrller.ResetAll();
                            _HwndCtrller.Repaint();//ROI交互--删除全部ROI,重新绘图
                        }                      
                        break;
                    case "RDBTN_MOVE":
                        if (rdbtn.Checked)
                            _HwndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MOVE);
                        break;
                    case "RDBTN_ZOOM":
                        if (rdbtn.Checked)
                            _HwndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_ZOOM);
                        break;
                    case "RDBTN_MAGNIFY":
                        if (rdbtn.Checked)
                            _HwndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MAGNIFY);
                        break;
                    default: break;
                }
            }
        }

        protected internal virtual void UpdateButton(System.Windows.Forms.Button btn, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (btn != null
               && btn.Tag != null)
            {
                if (resourceManager != null)
                {
                    btn.Click -= Btn_Click;
                    bool isChs = (lan == ProVision.Communal.Language.Chinese);
                    string str = btn.Tag.ToString();
                    btn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                    btn.Click += Btn_Click;
                }
            }
        }

        protected internal virtual void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if(btn!=null
                && btn.Tag!=null)
            {
                switch(btn.Tag.ToString())
                {
                    case "BTN_LOADIMAGE":
                        this.LoadImage();
                        break;
                    case "BTN_LINE":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROILine()); //定义区域时,矢量线段不响应;主要用在定义测量
                        break;
                    case "BTN_RECTANGLE1":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROIRectangle1());
                        break;
                    case "BTN_RECTANGLE2":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROIRectangle2());
                        break;
                    case "BTN_CIRULARARC":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROICircularArc()); //定义区域时,有向圆弧不响应;主要用在定义测量
                        break;
                    case "BTN_CIRCLE":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROICircle());
                        break;
                    case "BTN_ANNULUS":
                        _ROIManager.SetROIShape(new ProVision.InteractiveROI.ROIAnnulus());
                        break;
                    case "BTN_DELETEACTIVEROI":
                        _ROIManager.RemoveActiveROI();
                        break;
                    case "BTN_DELETEALLROI":
                        _HwndCtrller.ResetAll();
                        _HwndCtrller.Repaint();//ROI交互--删除全部ROI,重新绘图
                        break;
                    case "BTN_RESETWINDOW":
                        _HwndCtrller.ResetWindow();
                        _HwndCtrller.Repaint();//ROI交互--重置窗口,重新绘图
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 获取ROI区域列表
        /// </summary>
        /// <returns></returns>  
        public System.Collections.ArrayList ROIList { get { return _ROIManager.ROIList; } }

        protected void LoadImage()
        {
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            string filter = isChs ? "图像文件" : "Image Files";
            ofd.Filter = filter+"(*.BMP,*.JPG,*.JPEG,*.TIF)|*.bmp;*.jpg;*.jpeg;*.tif";
            string title = isChs ? "请选择一张图像文件" : "Select an image file";

            ofd.FilterIndex = 0;
            ofd.Title = title;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_hoImage != null
                         && _hoImage.IsInitialized())
                        _hoImage.Dispose();

                    HalconDotNet.HOperatorSet.ReadImage(out _hoImage, ofd.FileName);
                    _HwndCtrller.AddHobjEntity(_hoImage);
                    _HwndCtrller.Repaint();//ROI--加载图像,重新渲染图形
                }
                catch (HalconDotNet.HalconException hex)
                {
                    string txt = isChs ? "加载图像失败!\r\n" : "Load image failed !\r\n";
                    string caption = isChs ? "错误信息" : "Error message";
                    ProVision.Communal.FrmMsgBox.Show(txt+ hex.GetErrorMessage(), caption, isChs);
                }
            }
        }

        /// <summary>
        /// ROI列表选项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void CmbROIList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GetImageSize(HalconDotNet.HObject img, out HalconDotNet.HTuple wdth, out HalconDotNet.HTuple hgh)
        {
            wdth = null;
            hgh = null;
            if (img != null
                && img.IsInitialized())
            {
                HalconDotNet.HOperatorSet.GetImageSize(img, out wdth, out hgh);
            }
        }
    }
}
