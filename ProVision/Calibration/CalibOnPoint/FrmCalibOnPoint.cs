using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProVision.Calibration
{
    public partial class FrmCalibOnPoint : System.Windows.Forms.Form
    {
        public ProVision.Communal.Language LanguageVersion { protected set; get; }

        protected internal ProVision.InteractiveROI.HWndCtrller _hWndCtrller;
        protected internal ProVision.InteractiveROI.ROIManager _ROIManager;              
        protected internal ProVision.InteractiveROI.ROICross _ROICross;

        protected internal ProVision.MatchModel.ShapeModelAssistant _matchModelAssistant;
        protected internal bool[] _isCirclePointUpdated;

        //xyz-----------------基于特征点的标定助手---------------------
        protected internal ProVision.Calibration.CalibOnPointAssistant _calAssistant;
        //--------------------------------------------------------xyz

        protected internal HalconDotNet.HObject _img;
        protected internal bool _isAutoCalibrate, _isGrabbedImage, _isCalibrating, _isCalibratedOK;//是否自动标定,是否采集到图像,是否正在标定,是否标定完成
        protected internal double _positionStep,_angleStep;
        protected internal HalconDotNet.HTuple _imgWidth, _imgHeight, _row, _col, _crossRow, _crossCol;
      

        private FrmCalibOnPoint()
        {
            InitializeComponent();
        }

        protected internal FrmCalibOnPoint(ProVision.Communal.Language lan):this()
        {
            this.Load += FrmCalibratePointBased_Load;
            this.FormClosing += FrmCalibratePointBased_FormClosing;
        }

        protected internal virtual void FrmCalibratePointBased_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
           
        }

        protected internal virtual void FrmCalibratePointBased_Load(object sender, EventArgs e)
        {
            InitFieldAndProperty();
            UpdateControl();
        }

        protected internal virtual void InitFieldAndProperty()
        {
            _ROIManager = new InteractiveROI.ROIManager();
            _hWndCtrller = new InteractiveROI.HWndCtrller(this.hWndcDisplay);
            _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, new HalconDotNet.HTuple("yellow"));
            _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, new HalconDotNet.HTuple(2));

            _hWndCtrller.RegisterROICtroller(_ROIManager);
            _hWndCtrller.RegisterHwndCtrlMouseEvents();

            _matchModelAssistant = new ProVision.MatchModel.ShapeModelAssistant();

            _img = new HalconDotNet.HObject();
            _isAutoCalibrate = false;
            _isGrabbedImage = false;
            _isCalibrating = false;
            _isCalibratedOK = false;
            _positionStep = 0;
            _angleStep = 0;
            _isCirclePointUpdated = new bool[] { false,false,false};
        }

        protected internal virtual void UpdateControl()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            bool isChs = (LanguageVersion == ProVision.Communal.Language.Chinese);
            string str = this.Tag.ToString();

            this.Text = isChs ? ProVision.Properties.Resources.ResourceManager.GetString("chs_" + str) : ProVision.Properties.Resources.ResourceManager.GetString("en_" + str);

            UpdateGroupBox(this.grpbFeaturePoint, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateGroupBox(this.grpbCalibrateResult, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            UpdateChekBox(this.chkbAcquisitionMode, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateChekBox(this.chkbEnableVerifyCross, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateChekBox(this.chkbEnableToolOffset, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            UpdateRadioButton(this.rdbtnFixedFeaturePoint, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateRadioButton(this.rdbtnMobileFeaturePoint, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            UpdateLabel(this.lblPositionStep, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblPixelCoordPrompt, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblMechCoordPrompt, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblHorizontalScale, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblVerticalScale, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblRotateAngle, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblChamferAngle, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblHorizontalTranslate, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblVerticalTranslate, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblCalibratePixelError, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            UpdateLabel(this.lblAngleStep, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblCirclePointPrompt1, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblCirclePointPrompt2, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblCirclePointPrompt3, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblToolOffsetPrompt, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblXPrompt, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateLabel(this.lblYPrompt, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            UpdateButton(this.btnAcquireImage, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnSetMatchModel, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnMatchLocation, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnCalculateCalibration, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnVerifyCalibration, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnAddCalibrationSolution, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnToolOffset, LanguageVersion, ProVision.Properties.Resources.ResourceManager);
            UpdateButton(this.btnExitCalibration, LanguageVersion, ProVision.Properties.Resources.ResourceManager);

            this.lblImgPositionR.TextChanged -= LblImgPosition_TextChanged;
            this.lblImgPositionR.TextChanged += LblImgPosition_TextChanged;           

            this.lblImgPositionC.TextChanged -= LblImgPosition_TextChanged;
            this.lblImgPositionC.TextChanged += LblImgPosition_TextChanged;
        }

        /// <summary>
        /// 十字中心像素坐标改变,显示对应的机械坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected internal virtual void LblImgPosition_TextChanged(object sender, EventArgs e)
        {
        }

        protected internal virtual void TransPixelToWorld(double row, double col,out double x, out double y)
        {
            x = 0.0;y = 0.0;
        }

        /// <summary>
        /// 更新GroupBox控件
        /// </summary>
        /// <param name="grpb"></param>
        /// <param name="lan"></param>
        /// <param name="resourceManager"></param>
        protected void UpdateGroupBox(System.Windows.Forms.GroupBox grpb, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (grpb != null
              && grpb.Tag != null)
            {
                if (resourceManager != null)
                {
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = grpb.Tag.ToString();
                    grpb.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
            }
        }

        /// <summary>
        /// 更新CheckBox控件
        /// </summary>
        /// <param name="chkb"></param>
        /// <param name="lan"></param>
        /// <param name="resourceManager"></param>
        protected void UpdateChekBox(System.Windows.Forms.CheckBox chkb, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (chkb != null
               && chkb.Tag != null)
            {
                if (resourceManager != null)
                {
                    chkb.CheckedChanged -= Chkb_CheckedChanged;
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = chkb.Tag.ToString();
                    chkb.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                    chkb.CheckedChanged += Chkb_CheckedChanged;
                }
            }
        }

        /// <summary>
        /// 切换图像采集模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chkb_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox chkb = sender as System.Windows.Forms.CheckBox;
            if (chkb != null
                && chkb.Tag != null)
            {
                switch (chkb.Tag.ToString())
                {
                    case "CHKB_ACQUIRECONTINUE":
                        if (chkb.Checked)
                            SetContinueAcquire();
                        else
                            SetSoftTriggerAcquire();
                        break;
                    case "CHKB_ENABLETOOLOFFSET":
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 设置采集模式为连续触采集
        /// </summary>
        protected internal virtual void SetContinueAcquire() { }

        /// <summary>
        /// 设置采集模式为软触发采集
        /// </summary>
        protected internal virtual void SetSoftTriggerAcquire() { }

        /// <summary>
        /// 更新RadioButton控件
        /// </summary>
        /// <param name="rdbtn"></param>
        /// <param name="lan"></param>
        /// <param name="resourceManager"></param>
        protected void UpdateRadioButton(System.Windows.Forms.RadioButton rdbtn, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (rdbtn != null
                && rdbtn.Tag != null)
            {
                if (resourceManager != null)
                {
                    rdbtn.CheckedChanged -= Rdbtn_CheckedChanged;
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = rdbtn.Tag.ToString();
                    rdbtn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                    rdbtn.CheckedChanged += Rdbtn_CheckedChanged;
                }
            }
        }

        private void Rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rdbtn = sender as System.Windows.Forms.RadioButton;
            if (rdbtn != null
                && rdbtn.Tag != null)
            {
                switch (rdbtn.Tag.ToString())
                {
                    case "RDBTN_FIXEDPOINT":
                        if (rdbtn.Checked)
                        {
                            _isAutoCalibrate = false;
                            this.nmupdwnPositionStep.Enabled = false;                          
                        }
                        break;
                    case "RDBTN_MOBILEPOINT":
                        if (rdbtn.Checked)
                        {
                            //标定过程中无效
                            if (!_isCalibrating)
                            {
                                _isAutoCalibrate = true;
                                this.nmupdwnPositionStep.Enabled = true;                               
                            }
                        }
                        break;
                    default: break;
                }
            }

            //自动标定模式下,不允许操作数据表
            this.dtgrdvPointPairList.Enabled = !_isAutoCalibrate;
        }

        /// <summary>
        /// 更新Lable控件
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="lan"></param>
        /// <param name="resourceManager"></param>
        protected void UpdateLabel(System.Windows.Forms.Label lbl, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (lbl != null
               && lbl.Tag != null)
            {
                if (resourceManager != null)
                {
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = lbl.Tag.ToString();
                    lbl.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
            }
        }

        /// <summary>
        /// 更新Button控件
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="lan"></param>
        /// <param name="resourceManager"></param>
        protected void UpdateButton(System.Windows.Forms.Button btn, ProVision.Communal.Language lan, System.Resources.ResourceManager resourceManager)
        {
            if (btn != null
             && btn.Tag != null)
            {
                if (resourceManager != null)
                {
                    btn.Click -= Btn_Click;
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = btn.Tag.ToString();
                    btn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (btn != null
             && btn.Tag != null)
            {
                bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
                string txt = isChs ? "触发采图" : "Grabbing image";
                string caption = isChs ? "警告信息" : "Warning Message";

                switch (btn.Tag.ToString())
                {
                    case "BTN_ACQUIREIMAGE":
                        if (!_isCalibrating)
                        {
                            AcquireImage();
                        }
                        else
                        {
                            txt = isChs ? "正在进行标定,不允许采图!" : "Calibrating,grabbing forbidden !";                           
                            ProVision.Communal.FrmMsgBox.Show(txt, caption, 
                                ProVision.Communal.MyButtons.OK, ProVision.Communal.MyIcon.Warning, isChs);
                        }
                        break;
                    case "BTN_SETMATCHMODEL":
                        SetMatchModel();
                        break;
                    case "BTN_MATCHLOCATION":
                        MatchLocation();
                        break;
                    case "BTN_CALCULATECALIBRATION":
                        CalculateCalibration();
                        break;
                    case "BTN_VARIFYCALIBRATION":
                        VerifyCalibration();
                        break;
                    case "BTN_ADDCALIBRATIONSOLUTION":
                        AddCalibration();
                        break;                 
                    case "BTN_TOOLOFFSET":
                        CalculateToolOffset();
                        break;
                    case "BTN_EXITCALIBRATION":
                        ExitCalibration();
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 采集图像
        /// </summary>
        protected internal virtual void AcquireImage() { }

        /// <summary>
        /// 设置匹配模型
        /// </summary>
        protected internal virtual void SetMatchModel() { }

        /// <summary>
        /// 通过模板匹配模型定位并更新标定数据表
        /// </summary>
        protected internal virtual void MatchLocation() { }

        /// <summary>
        /// 计算标定结果
        /// </summary>
        protected internal virtual void CalculateCalibration() { }

        /// <summary>
        /// 验证标定结果
        /// </summary>
        protected internal virtual void VerifyCalibration() { }

        /// <summary>
        /// 添加标定方案
        /// </summary>
        protected internal virtual void AddCalibration() { }      

        /// <summary>
        /// 计算工具坐标系相对描述坐标系的偏移
        /// </summary>
        protected internal virtual void CalculateToolOffset() { }

        /// <summary>
        /// 退出标定
        /// </summary>
        protected internal virtual void ExitCalibration() { }
    }
}
