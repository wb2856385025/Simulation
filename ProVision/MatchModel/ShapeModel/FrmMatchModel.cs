using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProVision.MatchModel
{
    public partial class FrmMatchModel : Form
    {
        protected HalconDotNet.HObject _currentImage;
        protected HalconDotNet.HObject _modelRegion;      //模板区域
        protected HalconDotNet.HObject _modelContour;     //模板轮廓
        protected HalconDotNet.HObject _instanceContour;  //匹配模板的实例轮廓
        protected System.Drawing.Color _createModelColor; //显示训练图像时窗体的背景颜色
        protected System.Drawing.Color _trainModelColor;  //显示测试图像时的窗体背景颜色

        protected string ModelPath;

        protected bool _locked;                 //锁定标记       
        protected bool _specifiedModelPara;     //是否指定模型参数标记
        protected bool _isOnCreateExtractRegion; //当前操作为创建模板提取区域标记
        protected bool _isOnCreateSearchRegion;  //当前操作为创建模板搜索区域标记
        protected bool _isCreatedModelOriginCross;//是否创建模板原点偏移十字

        protected bool _isOnEraseExtractRegion;  //当前操作为擦除模板提取区域标记
        protected bool _isOnEraseSearchRegion;   //当前操作为擦除模板搜索区域标记
        protected bool _isOnEraseModelRegion;    //当前操作为擦书模板区域或轮廓标记


        protected bool _isOnFreeDraw;           //当前操作为自由绘制标记
        protected System.Windows.Forms.OpenFileDialog _ofdTrainImg;  //加载训练图像对话框
        protected System.Windows.Forms.OpenFileDialog _ofdTestImgs;  //加载测试图像对话框      

        protected System.Windows.Forms.FolderBrowserDialog _fbdModelFolder; //加载或者保存模板匹配模型文件夹对话框
        protected string _imgExtention="jpg"; //图像文件的扩展名
        protected System.Windows.Forms.Timer _timer; //定时器

        protected ProVision.MatchModel.ShapeModelOpt _matchModelOpt;                  //形状匹配模型优化基类
        protected ProVision.MatchModel.ShapeModelOptAccuracy _matchModelOptAccuracy;  //形状匹配模型精度优化类
        protected ProVision.MatchModel.ShapeModelOptResults _matchModelOptResults;    //形状匹配模型优化结果类
        public ProVision.MatchModel.ShapeModelAssistant MatchAssistant;      //形状匹配模型助手

        protected string _modelRegionColor;           //模板区域颜色
        protected string _modelContourColor;          //模板轮廓颜色
        protected string _instanceContourColor;       //匹配实例轮廓颜色
        protected string _activeInstanceContourColor; //活动的匹配实例颜色
        private HalconDotNet.HObject _crossContour;

   
        protected int _modelContourLineWidth;        //模板轮廓线宽
        protected int _instanceContourLineWidth;     //匹配实例轮廓线宽
        protected int _activeInsContourIdx;          //活动的匹配实例索引

        protected string _extractRegionColor;        //模板提取区域颜色
        protected string _searchRegionColor;         //搜索区域颜色
        protected string _maskRegionColor;           //掩膜区域颜色

        protected ProVision.Communal.DrawMode _drawMode; //绘制模式:填充模式,擦除模式
        protected int _brushSize;

        public ProVision.InteractiveROI.HWndCtrller HWndCtrller; //图形窗口控制器
        public ProVision.InteractiveROI.ROIManager ROIMgr;       //ROI管理器
        public ProVision.Communal.DotMatriceMask GrdMsk;         //网点掩膜


        /// <summary>
        /// 模板提取区域
        /// [注:通过ROI交互定义]
        /// </summary>
        public HalconDotNet.HObject ExtractRegion { private set; get; }

        /// <summary>
        /// 模板匹配模型句柄
        /// </summary>
        public HalconDotNet.HTuple ModelID { private set; get; }

        /// <summary>
        /// 模板的位姿
        /// [注:ModelPose[0]-模板行坐标Row,
        /// ModelPose[1]-模板列坐标Column,
        /// ModelPose[2]-模板参考角,
        /// ModelPose[3]-模板类型(0-区域形状模型,1-轮廓形状模型,2-NCC模型)]
        /// </summary>
        public HalconDotNet.HTuple ModelPose { private set; get; }

        /// <summary>
        /// 缓存的模板位姿
        /// [注:CatchModelPose[0]-模板行坐标Row,
        /// CatchModelPose[1]-模板列坐标Column,
        /// CatchModelPose[2]-模板参考角,
        /// CatchModelPose[3]-模板类型(0-区域形状模型,1-轮廓形状模型,2-NCC模型)]
        /// </summary>
        public HalconDotNet.HTuple CatchModelPose { private set; get; }


        /// <summary>
        /// 模板搜索区域
        /// </summary>
        public HalconDotNet.HObject SearchRegion { set; get; }

        /// <summary>
        /// 是否首次更新标记
        /// </summary>
        private bool _isFirstUpdate;

        public FrmMatchModel()
        {
            InitializeComponent();
            InitFieldAndProperty();
            _isFirstUpdate = true;
            this.Load += FrmMatchModel_Load;
        }
        /// <summary>
        /// 传入用于制作模板图像
        /// </summary>
        /// <param name="trainImage"></param>
        public FrmMatchModel(HalconDotNet.HObject trainImage):this()
        {
            TransmitTrainImg(trainImage);
        }
        /// <summary>
        /// 传入一个保存模板路径和用于制作模板图像
        /// </summary>
        /// <param name="trainImage"></param>
        /// <param name="Path"></param>
        public FrmMatchModel(HalconDotNet.HObject trainImage,string Path) : this()
        {
            TransmitTrainImg(trainImage);
            ModelPath = Path;
        }
        /// <summary>
        /// 传入一个保存模板路径
        /// </summary>
        /// <param name="Path"></param>
        public FrmMatchModel(string Path) : this()
        {
            ModelPath = Path;
        }

        

        /// <summary>
        /// 传入训练图像--03
        /// </summary>
        /// <param name="trainImg"></param>
        private void TransmitTrainImg(HalconDotNet.HObject trainImg)
        {
            _locked = true;
            if (_instanceContour != null
               && _instanceContour.IsInitialized())
            {
                _instanceContour.Dispose();
                _instanceContour = null;
            }

            trkbDisplayLevel.Enabled = false;
            trkbDisplayLevel.Value = 1;
            numUpDwnDisplayLevel.Enabled = false;
            numUpDwnDisplayLevel.Value = 1;
            _locked = false;

            this.chkbAlwaysFind.Checked = false;

            //设置传入的图像为训练图像
            if (!MatchAssistant.SetTrainImage(trainImg))
                return;

            //显示窗口显示区域复位且显示内容清空
            HWndCtrller.ResetAll();

            if (MatchAssistant.OnExternalModelID)
                _modelContour = MatchAssistant.GetTrainInstanceContour(); //此时获取的是匹配模板的实例轮廓(已经加载过模板匹配模型)

            if (this.tabControlModel.SelectedIndex != 0)
            {
                this.tabControlModel.SelectedIndex = 0;
            }
            else
            {
                DisplayTrainImage();
            }          
        }

        /// <summary>
        /// 初始化字段和属性--08
        /// </summary>
        /// <param name="matchModelPara"></param>
        private void InitFieldAndProperty(ProVision.Communal.ShapeModelParameter matchModelPara = null)
        {
            HalconDotNet.HOperatorSet.SetSystem("tsp_height", 10000);
            HalconDotNet.HOperatorSet.SetSystem("tsp_width", 10000);

            string imgPathDefault = (string)HalconDotNet.HSystem.GetSystem("image_dir").TupleSplit(";");
            _ofdTrainImg = new OpenFileDialog();
            _ofdTrainImg.InitialDirectory = imgPathDefault;

            _ofdTestImgs = new OpenFileDialog();
            _ofdTestImgs.InitialDirectory = imgPathDefault;        

            _fbdModelFolder = new FolderBrowserDialog();
            _fbdModelFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            _fbdModelFolder.ShowNewFolderButton = true;

            _createModelColor = Color.RoyalBlue;
            _trainModelColor = Color.Chartreuse;

            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += Timer_Tick;

            ModelID = new HalconDotNet.HTuple(-1);
            ModelPose = new HalconDotNet.HTuple();

            ROIMgr = new ProVision.InteractiveROI.ROIManager();
            ROIMgr.SetActiveROISign(ProVision.InteractiveROI.ROIManager.ROI_MODE_POS);
            ROIMgr.IconicUpdatedDel += new ProVision.InteractiveROI.IconicUpdatedDelegate(OnIconicUpdated);

            HWndCtrller = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay);
            HWndCtrller.RegisterROICtroller(ROIMgr);
            HWndCtrller.IconicUpdatedEvt += new ProVision.InteractiveROI.IconicUpdatedDelegate(OnIconicUpdated);
            HWndCtrller.RegisterHwndCtrlMouseEvents();                          //控件的鼠标事件(单击按下，单击抬起，移动，滑动)
            HWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);

            this.hWndcDisplay.HMouseDown += HWndcDisplay_HMouseDown;//控件的鼠标按下事件再注册
            this.hWndcDisplay.HMouseMove += HWndcDisplay_HMouseMove;//控件的鼠标移动事件再注册
            this.hWndcDisplay.HMouseUp += HWndcDisplay_HMouseUp;    //控件的鼠标抬起事件再注册
            this.hWndcDisplay.SizeChanged += HWndcDisplay_SizeChanged;

            GrdMsk = new Communal.DotMatriceMask();
            _drawMode = ProVision.Communal.DrawMode.Fill;

            if (matchModelPara == null)
            {
                MatchAssistant = new ProVision.MatchModel.ShapeModelAssistant(new Communal.ShapeModelParameter());
                _specifiedModelPara = false;
            }
            else
            {
                MatchAssistant = new ProVision.MatchModel.ShapeModelAssistant(matchModelPara);
                _specifiedModelPara = true;
            }

            _isOnCreateExtractRegion = false;
            _isOnCreateSearchRegion = false;
            _isCreatedModelOriginCross = false;

            MatchAssistant.ModelMatchedDel = new ProVision.MatchModel.ModelMatchedDelegate(OnModelMatched);
            MatchAssistant.AutoParameterizedDel = new ProVision.MatchModel.AutoParameterizedDelegate(OnAutoParameterized);

            _matchModelOptAccuracy = new ProVision.MatchModel.ShapeModelOptAccuracy(MatchAssistant);
            _matchModelOptAccuracy.RecoginzedAndStatisticedDel = new ProVision.MatchModel.RecognizedAndStatisticedDelegate(OnRecognizedAndStatisticed);

            _matchModelOptResults = new ProVision.MatchModel.ShapeModelOptResults(MatchAssistant);
            _matchModelOptResults.RecoginzedAndStatisticedDel = new ProVision.MatchModel.RecognizedAndStatisticedDelegate(OnRecognizedAndStatisticed);

            
            _modelRegionColor = "coral";
            _modelContourColor = "coral";

            _instanceContourColor = "red";
            _activeInstanceContourColor = "green";

            _extractRegionColor = "magenta";
            _searchRegionColor = "cyan";
            _maskRegionColor = "blue";

            _modelContourLineWidth = 1;
            _instanceContourLineWidth = 1;
            _activeInsContourIdx = -1;

            _brushSize = 10;

        }

        /// <summary>
        /// 初始化控件--14
        /// </summary>
        protected virtual void UpdateControls()
        {
            //xyz--------------------------
            //*****************************
            //*后续改成中英文切换的处理
            //*****************************
            //--------------------------xyz

            this.numUpDwnNumLevels.Value = 5; //金字塔最大等级数
            this.numUpDwnMinContrast.Maximum = this.numUpDwnContrast.Value;
            this.trkbMinContrast.Maximum = (int)this.numUpDwnContrast.Value;
            this.cmbMetric.SelectedIndex = 0;
            this.cmbOptimization.SelectedIndex = 0;
            this.cmbSubPixel.SelectedIndex = 2;
            this.cmbRecogRateOption.SelectedIndex = 0;
            this.cmbOptionLevel.SelectedIndex = 0;           

            OnOperationLevelChanged(this.cmbOptionLevel.SelectedIndex);
            OnModelTypeChanged(this.cmbModelType.SelectedIndex);
            OnEraseOptionChanged(this.cmbEraseOption.SelectedIndex);

            //鼠标右键事件
            this.tlstrpmiLoadImage.Click -= Tlstrpmi_Click;
            this.tlstrpmiLoadImage.Click += Tlstrpmi_Click;

            this.tlstrpmiLoadModel.Click -= Tlstrpmi_Click;
            this.tlstrpmiLoadModel.Click += Tlstrpmi_Click;

            this.tlstrpmiROILine.Click -= Tlstrpmi_Click;
            this.tlstrpmiROILine.Click += Tlstrpmi_Click;

            this.tlstrpmiROIRectangle1.Click -= Tlstrpmi_Click;
            this.tlstrpmiROIRectangle1.Click += Tlstrpmi_Click;

            this.tlstrpmiROIRectangle2.Click -= Tlstrpmi_Click;
            this.tlstrpmiROIRectangle2.Click += Tlstrpmi_Click;

            this.tlstrpmiROICircle.Click -= Tlstrpmi_Click;
            this.tlstrpmiROICircle.Click += Tlstrpmi_Click;

            this.tlstrpmiROICircularArc.Click -= Tlstrpmi_Click;
            this.tlstrpmiROICircularArc.Click += Tlstrpmi_Click;

            this.tlstrpmiROIAnnulus.Click -= Tlstrpmi_Click;
            this.tlstrpmiROIAnnulus.Click += Tlstrpmi_Click;

            this.tlstrpmiROIFreeDraw.Click -= Tlstrpmi_Click;
            this.tlstrpmiROIFreeDraw.Click += Tlstrpmi_Click;

            this.tlstrpmiVIEWNone.Click -= Tlstrpmi_Click;
            this.tlstrpmiVIEWNone.Click += Tlstrpmi_Click;

            this.tlstrpmiVIEWMove.Click -= Tlstrpmi_Click;
            this.tlstrpmiVIEWMove.Click += Tlstrpmi_Click;

            this.tlstrpmiVIEWZoom.Click -= Tlstrpmi_Click;
            this.tlstrpmiVIEWZoom.Click += Tlstrpmi_Click;

            this.tlstrpmiVIEWMagnify.Click -= Tlstrpmi_Click;
            this.tlstrpmiVIEWMagnify.Click += Tlstrpmi_Click;

            this.tlstrpmiVIEWClearROI.Click -= Tlstrpmi_Click;
            this.tlstrpmiVIEWClearROI.Click += Tlstrpmi_Click;

            this.tlstrpmiSetModelOrigin.Click -= Tlstrpmi_Click;
            this.tlstrpmiSetModelOrigin.Click += Tlstrpmi_Click;

            this.tlstrpmiConfirmModelOrigin.Click -= Tlstrpmi_Click;
            this.tlstrpmiConfirmModelOrigin.Click += Tlstrpmi_Click;

            this.tlstrpmiRecoverModelOrigin.Click -= Tlstrpmi_Click;
            this.tlstrpmiRecoverModelOrigin.Click += Tlstrpmi_Click;

            //界面按钮事件
            this.btnGenerateSearchRegion.Click -= Btn_Click;
            this.btnGenerateSearchRegion.Click += Btn_Click;

            this.btnGenerateExtractRegion.Click -= Btn_Click;
            this.btnGenerateExtractRegion.Click += Btn_Click;

            this.btnCreateMatchModel.Click -= Btn_Click;
            this.btnCreateMatchModel.Click += Btn_Click;

            this.btnSaveMatchModel.Click -= Btn_Click;
            this.btnSaveMatchModel.Click += Btn_Click;

            this.btnEraseRegion.Click -= Btn_Click;
            this.btnEraseRegion.Click += Btn_Click;

            this.btnApplyModel.Click -= Btn_Click;
            this.btnApplyModel.Click += Btn_Click;

            this.btnClearModel.Click -= Btn_Click;
            this.btnClearModel.Click += Btn_Click;           

            this.btnLoadImageList.Click -= Btn_Click;
            this.btnLoadImageList.Click += Btn_Click;

            this.btnDeleteImage.Click -= Btn_Click;
            this.btnDeleteImage.Click += Btn_Click;

            this.btnClearImageList.Click -= Btn_Click;
            this.btnClearImageList.Click += Btn_Click;

            this.btnDisplayImage.Click -= Btn_Click;
            this.btnDisplayImage.Click += Btn_Click;

            this.btnFindModel.Click -= Btn_Click;
            this.btnFindModel.Click += Btn_Click;

            this.btnOptimize.Click -= Btn_Click;
            this.btnOptimize.Click += Btn_Click;

            this.btnStatistic.Click -= Btn_Click;
            this.btnStatistic.Click += Btn_Click;

            this.cmbOptionLevel.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbOptionLevel.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.cmbModelType.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbModelType.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.cmbEraseOption.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbEraseOption.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.cmbMetric.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbMetric.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.cmbOptimization.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbOptimization.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.cmbSubPixel.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
            this.cmbSubPixel.SelectedIndexChanged += Cmb_SelectedIndexChanged;

            this.chkbBrushOnOff.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbBrushOnOff.CheckedChanged += Chkb_CheckedChanged;

            this.chkbBrushShape.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbBrushShape.CheckedChanged += Chkb_CheckedChanged;

            this.chkbFillErase.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbFillErase.CheckedChanged += Chkb_CheckedChanged;

            this.chkbContrast.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbContrast.CheckedChanged += Chkb_CheckedChanged;

            this.chkbScaleStep.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbScaleStep.CheckedChanged += Chkb_CheckedChanged;

            this.chkbAngleStep.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbAngleStep.CheckedChanged += Chkb_CheckedChanged;

            this.chkbNumLevel.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbNumLevel.CheckedChanged += Chkb_CheckedChanged;

            this.chkbOption.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbOption.CheckedChanged += Chkb_CheckedChanged;

            this.chkbMinContrast.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbMinContrast.CheckedChanged += Chkb_CheckedChanged;

            this.chkbAlwaysFind.CheckedChanged -= Chkb_CheckedChanged;
            this.chkbAlwaysFind.CheckedChanged += Chkb_CheckedChanged;

            this.numUpDwnDisplayLevel.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnDisplayLevel.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnContrast.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnContrast.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnMinScale.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMinScale.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnMaxScale.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMaxScale.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnScaleStep.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnScaleStep.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnStartAngle.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnStartAngle.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnAngleExtent.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnAngleExtent.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnAngleStep.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnAngleStep.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnNumLevels.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnNumLevels.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnMinContrast.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMinContrast.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnMinScore.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMinScore.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnNumToMatch.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnNumToMatch.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnGreediness.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnGreediness.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnMaxOverlap.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMaxOverlap.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnLastLevel.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnLastLevel.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnSpecifiedNum.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnSpecifiedNum.ValueChanged += NumUpDwn_ValueChanged;

            this.numUpDwnRecogRate.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnRecogRate.ValueChanged += NumUpDwn_ValueChanged;           

            this.numUpDwnMaxNumMatch.ValueChanged -= NumUpDwn_ValueChanged;
            this.numUpDwnMaxNumMatch.ValueChanged += NumUpDwn_ValueChanged;

            this.trkbDisplayLevel.Scroll -= Trkb_Scroll;
            this.trkbDisplayLevel.Scroll += Trkb_Scroll;

            this.trkbContrast.Scroll -= Trkb_Scroll;
            this.trkbContrast.Scroll += Trkb_Scroll;

            this.trkbMinScale.Scroll -= Trkb_Scroll;
            this.trkbMinScale.Scroll += Trkb_Scroll;

            this.trkbMaxScale.Scroll -= Trkb_Scroll;
            this.trkbMaxScale.Scroll += Trkb_Scroll;

            this.trkbScaleStep.Scroll -= Trkb_Scroll;
            this.trkbScaleStep.Scroll += Trkb_Scroll;

            this.trkbStartAngle.Scroll -= Trkb_Scroll;
            this.trkbStartAngle.Scroll += Trkb_Scroll;

            this.trkbAngleExtent.Scroll -= Trkb_Scroll;
            this.trkbAngleExtent.Scroll += Trkb_Scroll;

            this.trkbAngleStep.Scroll -= Trkb_Scroll;
            this.trkbAngleStep.Scroll += Trkb_Scroll;

            this.trkbNumLevels.Scroll -= Trkb_Scroll;
            this.trkbNumLevels.Scroll += Trkb_Scroll;

            this.trkbMinContrast.Scroll -= Trkb_Scroll;
            this.trkbMinContrast.Scroll += Trkb_Scroll;

            this.trkbMinScore.Scroll -= Trkb_Scroll;
            this.trkbMinScore.Scroll += Trkb_Scroll;

            this.trkbNumToMatch.Scroll -= Trkb_Scroll;
            this.trkbNumToMatch.Scroll += Trkb_Scroll;

            this.trkbGreediness.Scroll -= Trkb_Scroll;
            this.trkbGreediness.Scroll += Trkb_Scroll;

            this.trkbMaxOverlap.Scroll -= Trkb_Scroll;
            this.trkbMaxOverlap.Scroll += Trkb_Scroll;

            this.trkbLastLevel.Scroll -= Trkb_Scroll;
            this.trkbLastLevel.Scroll += Trkb_Scroll;

            this.trkbRecogRate.Scroll -= Trkb_Scroll;
            this.trkbRecogRate.Scroll += Trkb_Scroll;

            this.lstbTestImages.SelectedIndexChanged -= Lstb_SelectedIndexChanged;
            this.lstbTestImages.SelectedIndexChanged += Lstb_SelectedIndexChanged;

            this.dgvMatchResult.RowEnter += DgvMatchResult_RowEnter;
        }

        /// <summary>
        /// 匹配结果数据表行入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DgvMatchResult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateActiveResultObject(e.RowIndex);
        }

        /// <summary>
        /// 更新显示活动的匹配模板实例
        /// </summary>
        /// <param name="rowIdx"></param>
        protected virtual void UpdateActiveResultObject(int rowIdx)
        {
            _activeInsContourIdx = rowIdx;
            SetInstanceGraphic();
            HWndCtrller.Repaint();
        }

        /// <summary>
        /// NumberUpDown值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void NumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numUpDwn = sender as NumericUpDown;
            if (numUpDwn != null)
            {
                int val = (int)numUpDwn.Value;
                switch (numUpDwn.Tag.ToString())
                {
                    case "NUMUPDWN_DISPLAYLEVEL":
                        {
                            trkbDisplayLevel.Value = val;
                            HWndCtrller.SetROIPaintMode(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_INCLUDE_ROI);

                            if (!_locked)
                                MatchAssistant.SetDisplayLevel(val);//显示指定的金字塔图层
                        }
                        break;
                    case "NUMUPDWN_CONTRAST":
                        {
                            this.trkbContrast.Value = val;
                            this.trkbMinContrast.Maximum = val;
                            this.numUpDwnMinContrast.Maximum = val;

                            if (!_locked)
                                MatchAssistant.SetContrast(val);
                        }
                        break;
                    case "NUMUPDWN_MINSCALE":
                        {
                            this.trkbMinScale.Value = val;
                            if (val > (int)this.numUpDwnMaxScale.Value)
                                this.numUpDwnMaxScale.Value = val;

                            if (!_locked)
                                MatchAssistant.SetMinScale((double)val / 100.0);
                        }
                        break;
                    case "NUMUPDWN_MAXSCALE":
                        {
                            this.trkbMaxScale.Value = val;
                            if (val < (int)this.numUpDwnMinScale.Value)
                                this.numUpDwnMinScale.Value = val;

                            if (!_locked)
                                MatchAssistant.SetMaxScale((double)val / 100.0);
                        }
                        break;
                    case "NUMUPDWN_SCALESTEP":
                        {
                            this.trkbScaleStep.Value = val;

                            if (!_locked)
                                MatchAssistant.SetScaleStep((double)val / 1000.0);
                        }
                        break;
                    case "NUMUPDWN_STARTANGLE":
                        {
                            this.trkbStartAngle.Value = val;

                            if (!_locked)
                                MatchAssistant.SetStartAngle((double)val * System.Math.PI / 180.0);
                        }
                        break;
                    case "NUMUPDWN_ANGLEEXTENT":
                        {
                            this.trkbAngleExtent.Value = val;

                            if (!this._locked)
                                this.MatchAssistant.SetAngleExtent((double)val * System.Math.PI / 180.0);
                        }
                        break;
                    case "NUMUPDWN_ANGLESTEP":
                        {
                            this.trkbAngleStep.Value = val;

                            if (!_locked)
                                MatchAssistant.SetAngleStep((double)val / 10.0 * System.Math.PI / 180.0);
                        }
                        break;
                    case "NUMUPDWN_NUMLEVELS":
                        {
                            this.trkbNumLevels.Value = val;

                            if (!_locked)
                                MatchAssistant.SetNumLevels(val);
                        }
                        break;
                    case "NUMUPDWN_MINCONTRAST":
                        {
                            this.trkbMinContrast.Value = val;

                            if (!_locked)
                                MatchAssistant.SetMinContrast(val);
                        }
                        break;
                    case "NUMUPDWN_MINSCORE":
                        {
                            this.trkbMinScore.Value = val;
                            if (!_locked)
                            {
                                if (this.lstbTestImages.Items.Count != 0
                                    && this.chkbAlwaysFind.Checked)
                                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);
                                MatchAssistant.SetMinScore((double)val / 100.0);
                            }
                        }
                        break;
                    case "NUMUPDWN_NUMTOMATCH":
                        {
                            this.trkbNumToMatch.Value = val;
                            this.numUpDwnMaxNumMatch.Value = val;
                            if (!this._locked)
                            {
                                if (this.lstbTestImages.Items.Count != 0
                                   && this.chkbAlwaysFind.Checked)
                                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                                if (val == 0)
                                {
                                    if (this.rdbtnMaxNum.Checked)
                                        this.rdbtnAtLeastOne.Checked = true;

                                    this.rdbtnMaxNum.Enabled = false;
                                }
                                else { this.rdbtnMaxNum.Enabled = true; }

                                MatchAssistant.SetNumToMatch(val);
                            }
                        }
                        break;
                    case "NUMUPDWN_GREEDINESS":
                        {
                            this.trkbGreediness.Value = val;
                            if (!this._locked)
                            {
                                if (this.lstbTestImages.Items.Count != 0
                                  && this.chkbAlwaysFind.Checked)
                                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                                MatchAssistant.SetGreediness((double)val / 100.0);
                            }
                        }
                        break;
                    case "NUMUPDWN_MAXOVERLAP":
                        {
                            this.trkbMaxOverlap.Value = val;
                            if (!this._locked)
                            {
                                if (this.lstbTestImages.Items.Count != 0
                                  && this.chkbAlwaysFind.Checked)
                                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                                MatchAssistant.SetMaxOverlap((double)val / 100.0);
                            }
                        }
                        break;
                    case "NUMUPDWN_LASTLEVEL":
                        {
                            this.trkbLastLevel.Value = val;
                            if (!this._locked)
                            {
                                if (this.lstbTestImages.Items.Count != 0
                                  && this.chkbAlwaysFind.Checked)
                                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                                MatchAssistant.SetLastPyramidLevel(val);
                            }
                        }
                        break;
                    case "NUMUPDWN_RECOGRATE":
                        {
                            this.trkbRecogRate.Value = val;
                            MatchAssistant.SetRecogRate(val);
                        }
                        break;
                    case "NUMUPDWN_SPECIFIEDNUM":
                        {
                            if (!_locked)
                                MatchAssistant.SetRecogSpecifiedMatchNum(val);
                        }
                        break;
                    case "NUMUPDWN_MAXNUMTOMATCH":
                        {
                            if (val != (int)this.numUpDwnNumToMatch.Value)
                                this.numUpDwnNumToMatch.Value = val;
                        }
                        break;
                    case "NUMUPDWN_ALPHA":
                        MatchAssistant.Alpha = (float)this.numUpDwnFilterAlpha.Value;
                        if(this.cmbModelType.SelectedIndex==1)
                            if ((ExtractRegion != null
                               && ExtractRegion.IsInitialized()))
                                {
                                    //更新模板提取区域后重新提取模板信息
                                    ROIMgr.IconicUpdatedDel(ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI);
                                }
                        break;
                    case "NUMUPDWN_HYSTERESISHIGH":                     
                        MatchAssistant.HysteresisHigh = (int)this.numUpDwnHysteresisHigh.Value;
                        if (this.cmbModelType.SelectedIndex == 1)
                            if ((ExtractRegion != null
                               && ExtractRegion.IsInitialized()))
                            {
                                //更新模板提取区域后重新提取模板信息
                                ROIMgr.IconicUpdatedDel(ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI);
                            }
                        break;
                    case "NUMUPDWN_HYSTERESISLOW":                       
                        MatchAssistant.HysteresisLow = (int)this.numUpDwnHysteresisLow.Value;
                        if (this.cmbModelType.SelectedIndex == 1)
                            if ((ExtractRegion != null
                               && ExtractRegion.IsInitialized()))
                            {
                                //更新模板提取区域后重新提取模板信息
                                ROIMgr.IconicUpdatedDel(ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI);
                            }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// TrackBar拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Trkb_Scroll(object sender, EventArgs e)
        {
            TrackBar trkb = sender as TrackBar;
            if (trkb != null
                && trkb.Tag != null)
            {
                int val = (int)trkb.Value;
                switch (trkb.Tag.ToString())
                {
                    case "TRKB_DISPLAYLEVEL":
                        {
                            this.numUpDwnDisplayLevel.Value = val;
                            this.numUpDwnDisplayLevel.Refresh();
                        }
                        break;
                    case "TRKB_CONTRAST":
                        {
                            this.numUpDwnContrast.Value = val;
                            this.numUpDwnContrast.Refresh();
                        }
                        break;
                    case "TRKB_MINSCALE":
                        {
                            this.numUpDwnMinScale.Value = val;
                            this.numUpDwnMinScale.Refresh();
                        }
                        break;
                    case "TRKB_MAXSCALE":
                        {
                            this.numUpDwnMaxScale.Value = val;
                            this.numUpDwnMaxScale.Refresh();
                        }
                        break;
                    case "TRKB_SCALESTEP":
                        {
                            this.numUpDwnScaleStep.Value = val;
                            this.numUpDwnScaleStep.Refresh();
                        }
                        break;
                    case "TRKB_STARTANGLE":
                        {
                            this.numUpDwnStartAngle.Value = val;
                            this.numUpDwnStartAngle.Refresh();
                        }
                        break;
                    case "TRKB_ANGLEEXTENT":
                        {
                            this.numUpDwnAngleExtent.Value = val;
                            this.numUpDwnAngleExtent.Refresh();
                        }
                        break;
                    case "TRKB_ANGLESTEP":
                        {
                            this.numUpDwnAngleStep.Value = val;
                            this.numUpDwnAngleStep.Refresh();
                        }
                        break;
                    case "TRKB_NUMLEVELS":
                        {
                            this.numUpDwnNumLevels.Value = val;
                            this.numUpDwnNumLevels.Refresh();
                        }
                        break;
                    case "TRKB_MINCONTRAST":
                        {
                            this.numUpDwnMinContrast.Value = val;
                            this.numUpDwnMinContrast.Refresh();
                        }
                        break;
                    case "TRKB_MINSCORE":
                        {
                            this.numUpDwnMinScore.Value = val;
                            this.numUpDwnMinScore.Refresh();
                        }
                        break;
                    case "TRKB_NUMTOMATCH":
                        {
                            this.numUpDwnNumToMatch.Value = val;
                            this.numUpDwnNumToMatch.Refresh();
                        }
                        break;
                    case "TRKB_GREEDINESS":
                        {
                            this.numUpDwnGreediness.Value = val;
                            this.numUpDwnGreediness.Refresh();
                        }
                        break;
                    case "TRKB_MAXOVERLAP":
                        {
                            this.numUpDwnMaxOverlap.Value = val;
                            this.numUpDwnMaxOverlap.Refresh();
                        }
                        break;
                    case "TRKB_LASTLEVEL":
                        {
                            this.numUpDwnLastLevel.Value = val;
                            this.numUpDwnLastLevel.Refresh();
                        }
                        break;
                    case "TRKB_RECOGRATE":
                        {
                            this.numUpDwnRecogRate.Value = val;
                            this.numUpDwnRecogRate.Refresh();
                        }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// ListBox选择项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Lstb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTestImage();
            UpdateResultListBox();
        }

        /// <summary>
        /// CheckBox选择状态改变--20
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
                    case "CHKB_BRUSHONOFF":
                        {
                            if (chkb.Checked)
                            {
                                chkb.Text = "笔刷启用";
                                //非自由绘制情形下,启用笔刷时则清空ROIList,即不再允许改变基本形状(移动或缩放)
                                if (!_isOnFreeDraw)
                                {
                                    //ROIList非空(有基本形状),获取基本形状,作为当前的模板提取区域或者模板搜索区域,然后清空ROIList
                                    if (ROIMgr.CalculateSyntheticalRegion())
                                    {
                                        if (_isOnCreateSearchRegion
                                            || _isOnEraseSearchRegion)
                                            SearchRegion = ROIMgr.GetSyntheticalRegion();

                                        if(_isOnCreateExtractRegion
                                            || _isOnEraseExtractRegion)
                                            ExtractRegion = ROIMgr.GetSyntheticalRegion();

                                        ROIMgr.ROIList.Clear();
                                    }
                                }
                            }
                            else
                            {
                                chkb.Text = "笔刷禁用";
                            }
                        }
                        break;
                    case "CHKB_BRUSHSHAPE":
                        {
                            if (chkb.Checked)
                            {
                                chkb.Text = "方形笔刷";
                            }
                            else
                            {
                                chkb.Text = "圆形笔刷";
                            }
                        }
                        break;
                    case "CHKB_FILLERASE":
                        {
                            if (chkb.Checked)
                            {
                                _drawMode = ProVision.Communal.DrawMode.Erase;
                                chkb.Text = "擦除模式";
                            }
                            else
                            {
                                _drawMode = ProVision.Communal.DrawMode.Fill;
                                chkb.Text = "填充模式";
                            }
                        }
                        break;                  
                    case "CHKB_CONTRAST":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_CONTRAST);
                                this.numUpDwnContrast.Enabled = false;
                                this.trkbContrast.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_CONTRAST);
                                this.numUpDwnContrast.Enabled = true;
                                this.trkbContrast.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_SCALESTEP":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_SCALE_STEP);
                                this.numUpDwnScaleStep.Enabled = false;
                                this.trkbScaleStep.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_SCALE_STEP);
                                this.numUpDwnScaleStep.Enabled = true;
                                this.trkbScaleStep.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_ANGLESTEP":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_ANGLE_STEP);
                                this.numUpDwnAngleStep.Enabled = false;
                                this.trkbAngleStep.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_ANGLE_STEP);
                                this.numUpDwnAngleStep.Enabled = true;
                                this.trkbAngleStep.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_NUMLEVELS":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_NUM_LEVELS);
                                this.numUpDwnNumLevels.Enabled = false;
                                this.trkbNumLevels.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_NUM_LEVELS);
                                this.numUpDwnNumLevels.Enabled = true;
                                this.trkbNumLevels.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_OPTIMIZATION":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_OPTIMIZATION);
                                this.cmbOptimization.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_OPTIMIZATION);
                                this.cmbOptimization.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_MINCONTRAST":
                        {
                            if (chkb.Checked)
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);
                                this.numUpDwnMinContrast.Enabled = false;
                                this.trkbMinContrast.Enabled = false;
                                chkb.Text = "自动适配";
                            }
                            else
                            {
                                if (MatchAssistant != null)
                                    MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);
                                this.numUpDwnMinContrast.Enabled = true;
                                this.trkbMinContrast.Enabled = true;
                                chkb.Text = "手动调整";
                            }
                        }
                        break;
                    case "CHKB_ALWAYSFIND":
                        {

                        }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// ComboBox选项值改变--21
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = sender as System.Windows.Forms.ComboBox;
            if(cmb!=null
                && cmb.Tag!=null)
            {
                switch(cmb.Tag.ToString())
                {
                    case "CMB_OPTIONLEVEL":
                        OnOperationLevelChanged(cmb.SelectedIndex);
                        break;
                    case "CMB_MODELTYPE":
                        OnModelTypeChanged(cmb.SelectedIndex);
                        break;
                    case "CMB_ERASEOPTION":
                        OnEraseOptionChanged(cmb.SelectedIndex);
                        break;
                    case "METRIC":
                        OnMetricChanged(cmb.SelectedIndex);
                        break;
                    case "OPTIMIZATION":
                        OnOpimizationChanged(cmb.SelectedIndex);
                        break;
                    case "SUBPIXEL":
                        OnSubpixelChanged(cmb.SelectedIndex);
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// ToolStripMenuItem单击事件--17
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Tlstrpmi_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem tlstrpmi = sender as System.Windows.Forms.ToolStripMenuItem;
            if(tlstrpmi!=null
                && tlstrpmi.Tag!=null)
            {
                switch (tlstrpmi.Tag.ToString())
                {
                    case "TLSTRPMI_LOADIMAGE":
                        LoadTrainImage();
                        break;
                    case "TLSTRPMI_LOADMODEL":
                        LoadModel();
                        break;
                    case "TLSTRPMI_LINE":
                        {
                            if (_currentImage != null
                                && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROILine());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                //ProVision.Communal.FrmMsgBox.Show(txt, caption,
                                //ProVision.Communal.MyButtons.OK, ProVision.Communal.MyIcon.Warning, isChs);
                            }
                        }
                        break;
                    case "TLSTRPMI_RECTANGLE1":
                        {
                            if (_currentImage != null
                               && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROIRectangle1());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else { System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
                        break;
                    case "TLSTRPMI_RECTANGLE2":
                        {
                            if (_currentImage != null
                               && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROIRectangle2());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else { System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
                        break;
                    case "TLSTRPMI_CIRCLE":
                        {
                            if (_currentImage != null
                               && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROICircle());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else { System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
                        break;
                    case "TLSTRPMI_CIRCULARARC":
                        {
                            if (_currentImage != null
                               && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROICircularArc());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else { System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
                        break;                  
                    case "TLSTRPMI_ANNULUS":
                        {
                            if (_currentImage != null
                               && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROIAnnulus());
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = false;
                                _isOnFreeDraw = false;
                            }
                            else { System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                        }
                        break;
                    case "TLSTRPMI_FREEDRAW":
                        {
                            if (_currentImage != null
                              && _currentImage.IsInitialized())
                            {
                                ResetRegionAndHWndCtrller();
                                HWndCtrller.AddHobjEntity(_currentImage);
                                HWndCtrller.Repaint();
                                this.chkbBrushOnOff.Checked = true;
                                _isOnFreeDraw = true;
                            }
                        }
                        break;
                    case "TLSTRPMI_NONE":
                        {
                            HWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);
                            HWndCtrller.ResetWindow();
                            HalconDotNet.HObject obj = _modelRegion;

                            HWndCtrller.Repaint();
                        }
                        break;
                    case "TLSTRPMI_MOVE":
                        {
                            if (_currentImage != null
                              && _currentImage.IsInitialized())
                            {
                                this.tlstrpmiVIEWNone.Checked = false;
                                this.tlstrpmiVIEWMove.Checked = false;
                                this.tlstrpmiVIEWZoom.Checked = false;
                                this.tlstrpmiVIEWMagnify.Checked = false;
                                tlstrpmi.Checked = true;
                                HWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MOVE);
                            }
                            else
                            {
                                this.tlstrpmiVIEWNone.Checked = true;
                                System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        break;
                    case "TLSTRPMI_ZOOM":
                        {
                            if (_currentImage != null
                              && _currentImage.IsInitialized())
                            {
                                this.tlstrpmiVIEWNone.Checked = false;
                                this.tlstrpmiVIEWMove.Checked = false;
                                this.tlstrpmiVIEWZoom.Checked = false;
                                this.tlstrpmiVIEWMagnify.Checked = false;
                                tlstrpmi.Checked = true;
                                HWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_ZOOM);
                            }
                            else
                            {
                                this.tlstrpmiVIEWNone.Checked = true;
                                System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        break;
                    case "TLSTRPMI_MAGNIFY":
                        {
                            if (_currentImage != null
                              && _currentImage.IsInitialized())
                            {
                                this.tlstrpmiVIEWNone.Checked = false;
                                this.tlstrpmiVIEWMove.Checked = false;
                                this.tlstrpmiVIEWZoom.Checked = false;
                                this.tlstrpmiVIEWMagnify.Checked = false;
                                tlstrpmi.Checked = true;
                                HWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MAGNIFY);
                            }
                            else
                            {
                                this.tlstrpmiVIEWNone.Checked = true;
                                System.Windows.Forms.MessageBox.Show("未加载图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        break;
                    case "TLSTRPMI_CLEAR":
                        {
                            if (_currentImage != null
                              && _currentImage.IsInitialized())
                            {
                                HWndCtrller.ResetAll();
                                HWndCtrller.ClearEntities();
                                if (GrdMsk.MaskRegion != null
                                && GrdMsk.MaskRegion.IsInitialized())
                                {
                                    GrdMsk.MaskRegion.Dispose();
                                    GrdMsk.MaskRegion = null;
                                }
                                HWndCtrller.AddHobjEntity(_currentImage);
                                HWndCtrller.Repaint();
                            }
                        }
                        break;
                    case "TLSTRPMI_SETMODELORIGIN":
                        {
                            if (_currentImage != null
                             && _currentImage.IsInitialized())
                            {
                                if (MatchAssistant.ModelID.TupleNotEqual(new HalconDotNet.HTuple(-1)))
                                {
                                    if (!_isCreatedModelOriginCross)
                                    {
                                        ROIMgr.SetROIShape(new ProVision.InteractiveROI.ROICross());
                                        HWndCtrller.Repaint();
                                        _isCreatedModelOriginCross = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("未创建模板匹配模型!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        break;
                    case "TLSTRPMI_CONFIRMMODELORIGIN":
                        {
                            if(_isCreatedModelOriginCross)
                            {
                                CatchModelPose = ModelPose;
                                HalconDotNet.HTuple modelData,row, col;
                                //获取十字中心坐标
                                modelData=((ProVision.InteractiveROI.ROICross)ROIMgr.ROIList[0]).GetModelData();

                                row = modelData[0]- ModelPose[0];
                                col = modelData[1] - ModelPose[1];
                                HalconDotNet.HOperatorSet.SetShapeModelOrigin(MatchAssistant.ModelID, row, col);

                                ModelPose[0] = modelData[0];
                                ModelPose[1] = modelData[1];
                                MatchAssistant.ModelPose = ModelPose;

                                MatchAssistant.Result.Row = ModelPose[0];
                                MatchAssistant.Result.Col = ModelPose[1];                            

                                SetInstanceGraphic();
                                HWndCtrller.Repaint();
                            }
                        }
                        break;
                    case "TLSTRPMI_RECOVERMODELORIGIN":
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 重置模板搜索或提取区域和窗体管理器--18
        /// </summary>
        private void ResetRegionAndHWndCtrller()
        {
            if(_isOnCreateSearchRegion)
            {
                if (SearchRegion != null
                    && SearchRegion.IsInitialized())
                    SearchRegion.Dispose();

                SearchRegion = null;
            }

            if(_isOnCreateExtractRegion)
            {
                if (ExtractRegion != null
                    && ExtractRegion.IsInitialized())
                    ExtractRegion.Dispose();
                ExtractRegion = null;
            }           
          
            HWndCtrller.ResetAll();
            HWndCtrller.ClearEntities();
        }

        /// <summary>
        /// Button单击事件--16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (btn != null
                && btn.Tag != null)
            {
                switch (btn.Tag.ToString())
                {
                    case "BTN_GENERATESEARCHREGION":
                        {
                            this.chkbBrushOnOff.Checked = false;
                            this.chkbBrushOnOff.Enabled = true;
                            this.chkbFillErase.Checked = false;
                            this.chkbFillErase.Enabled = true;

                            ROIMgr.ROIList.Clear();
                            _isOnCreateSearchRegion = true;
                            _isOnCreateExtractRegion = false;
                            _isOnEraseSearchRegion = false;
                            _isOnEraseExtractRegion = false;
                            _isOnEraseModelRegion = false;
                        }
                        break;
                    case "BTN_GENERATEEXTRACTREGION":
                        {
                            this.chkbBrushOnOff.Checked = false;
                            this.chkbBrushOnOff.Enabled = true;
                            this.chkbFillErase.Checked = false;
                            this.chkbFillErase.Enabled = true;

                            ROIMgr.ROIList.Clear();
                            _isOnCreateSearchRegion = false;
                            _isOnCreateExtractRegion = true;
                            _isOnEraseSearchRegion = false;
                            _isOnEraseExtractRegion = false;
                            _isOnEraseModelRegion = false;
                        }
                        break;
                    case "BTN_ERASEREGION":
                        this.chkbBrushOnOff.Checked = true;
                        this.chkbBrushOnOff.Enabled = false;
                        this.chkbFillErase.Checked = true;
                        this.chkbFillErase.Enabled = false;

                        OnEraseOptionChanged(this.cmbEraseOption.SelectedIndex);

                        break;                   
                    case "BTN_CREATEMATCHMODEL":
                        CreateModel();
                        break;
                    case "BTN_APPLYMATCHMODEL":
                        ApplyModel();
                        break;
                    case "BTN_CLEARMATCHMODEL":
                        ClearModel();
                        break;
                    case "BTN_RECREATEMATCHMODEL":
                        CreateModel();
                        break;
                    case "BTN_SAVEMATCHMODEL":
                        SaveModel();
                        break;
                    case "BTN_LOADTESTIMAGES":
                        LoadTestImages();
                        break;
                    case "BTN_DELETETESTIMAGE":
                        DeleteTestImage();
                        break;
                    case "BTN_CLEARTESTIMAGES":
                        ClearTestImages();
                        break;
                    case "BTN_DISPLAYTESTIMAGE":
                        DisplayTestImage();
                        break;
                    case "BTN_FINDMODEL":
                        FindModel();
                        break;
                    case "BTN_OPTIMIZE":
                        RunOptimize();
                        break;
                    case "BTN_STATISTIC":
                        RunStatistic();
                        break; 
                    default: break;
                }
            }
        }     

        #region Button单击事件函数

        /// <summary>
        /// 创建模板匹配模型
        /// [在模板提取区域内,
        /// 指定的参数下匹配模板;
        /// 并显示定位中心]
        /// </summary>
        protected virtual void CreateModel()
        {
            _isOnCreateExtractRegion = false;
            _isOnCreateSearchRegion = false;
            _isOnEraseExtractRegion = false;
            _isOnEraseSearchRegion = false;

            if (ExtractRegion != null
                   && ExtractRegion.IsInitialized())
            {
                if (MatchAssistant.ModelID.TupleEqual(new HalconDotNet.HTuple(-1)))
                {
                    ROIMgr.ROIList.Clear();
                    MatchAssistant.IsDetectInTrainImage = true;
                    MatchAssistant.SetNumToMatch(1);
                    MatchAssistant.ModelSearchRegion = ExtractRegion;
                    MatchAssistant.DetectShapeModel();
                    ModelID = MatchAssistant.ModelID;
                    ModelPose = MatchAssistant.ModelPose;

                    if (ModelPose.TupleNotEqual(new HalconDotNet.HTuple()))
                        MessageBox.Show("获取模板模型参数成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else { MessageBox.Show("获取模板模型参数失败!\r\n模板位姿获取失败!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else
                {
                    if (MessageBox.Show("已创建模板匹配模型!\r\n是否重新创建模板匹配模型?", "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ROIMgr.ROIList.Clear();
                        MatchAssistant.CreateShapeModel();
                        MatchAssistant.IsDetectInTrainImage = true;
                        MatchAssistant.SetNumToMatch(1);
                        MatchAssistant.ModelSearchRegion = ExtractRegion;
                        MatchAssistant.DetectShapeModel();
                        ModelID = MatchAssistant.ModelID;
                        ModelPose = MatchAssistant.ModelPose;
                        if (ModelPose.TupleNotEqual(new HalconDotNet.HTuple()))
                            MessageBox.Show("获取模板模型参数成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else { MessageBox.Show("获取模板模型参数失败!\r\n模板位姿获取失败!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                }
            }
            else { MessageBox.Show("未定义模板提取区域!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
    }

        /// <summary>
        /// 应用模型
        /// [在模板搜索区域内,
        /// 指定的参数下匹配模板;
        /// 并显示定位中心]
        /// </summary>
        private void ApplyModel()
        {
            if (ExtractRegion != null
                   && ExtractRegion.IsInitialized())
            {
                if (MatchAssistant.ModelID.TupleNotEqual(new HalconDotNet.HTuple(-1)))
                {
                    _isCreatedModelOriginCross = false;
                    ROIMgr.ROIList.Clear();

                    int numToMatch = Convert.ToInt32(this.numUpDwnNumToMatch.Value);
                    MatchAssistant.IsDetectInTrainImage = false;
                    MatchAssistant.SetTestImage(_currentImage);

                    MatchAssistant.SetNumToMatch(numToMatch);
                    MatchAssistant.ModelSearchRegion = SearchRegion;
                    MatchAssistant.DetectShapeModel();
                }
                else
                {
                    CreateModel();
                }
            }
            else { MessageBox.Show("未定义模板提取区域!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        /// <summary>
        /// 保存模板
        /// </summary>
        protected virtual void SaveModel()
        {
            if (_currentImage != null
                && _currentImage.IsInitialized())
            {
                if (ExtractRegion != null
                    && ExtractRegion.IsInitialized())
                {
                    if (MatchAssistant != null
                        && MatchAssistant.ModelID.TupleNotEqual(new HalconDotNet.HTuple(-1)))
                    {
                        if (SearchRegion != null
                           && SearchRegion.IsInitialized())
                        {

                            if (ModelPath==null)
                            {                                
                                _fbdModelFolder.Description = "请选择或者创建一个文件夹";
                                if (_fbdModelFolder.ShowDialog() == DialogResult.OK)
                                {
                                    string folderPath = _fbdModelFolder.SelectedPath;
                                    if (_imgExtention == "tif")
                                        _imgExtention = "tiff";
                                    HalconDotNet.HOperatorSet.WriteImage(_currentImage, _imgExtention, new HalconDotNet.HTuple(0), folderPath + "\\TrainImage." + _imgExtention);
                                    HalconDotNet.HOperatorSet.WriteRegion(ExtractRegion, folderPath + "\\ExtrackRegion.hobj");
                                    HalconDotNet.HOperatorSet.WriteRegion(SearchRegion, folderPath + "\\SearchRegion.hobj");
                                    ModelID = MatchAssistant.ModelID;
                                    ModelPose = MatchAssistant.ModelPose;
                                    HalconDotNet.HOperatorSet.WriteTuple(ModelPose, folderPath + "\\ModelPose.tup");                                
                                    switch(MatchAssistant.ModelType)
                                    {
                                        case Communal.MatchModelType.NCCModel:
                                            MatchAssistant.SaveShapeModel(folderPath + "\\ModelFile.ncm");
                                            break;
                                        case Communal.MatchModelType.ShapeContourModel:
                                        case Communal.MatchModelType.ShapeRegionModel:
                                            MatchAssistant.SaveShapeModel(folderPath + "\\ModelFile.shm");
                                            break;
                                        default:break;
                                    }
                                }
                            }
                            else
                            {
                                string folderPath = ModelPath;
                                if (_imgExtention == "tif")
                                    _imgExtention = "tiff";
                                HalconDotNet.HOperatorSet.WriteImage(_currentImage, _imgExtention, new HalconDotNet.HTuple(0), folderPath + "\\TrainImage." + _imgExtention);
                                HalconDotNet.HOperatorSet.WriteRegion(ExtractRegion, folderPath + "\\ExtrackRegion.hobj");
                                HalconDotNet.HOperatorSet.WriteRegion(SearchRegion, folderPath + "\\SearchRegion.hobj");
                                ModelID = MatchAssistant.ModelID;
                                ModelPose = MatchAssistant.ModelPose;
                                HalconDotNet.HOperatorSet.WriteTuple(ModelPose, folderPath + "\\ModelPose.tup");
                                switch (MatchAssistant.ModelType)
                                {
                                    case Communal.MatchModelType.NCCModel:
                                        MatchAssistant.SaveShapeModel(folderPath + "\\ModelFile.ncm");
                                        break;
                                    case Communal.MatchModelType.ShapeContourModel:
                                    case Communal.MatchModelType.ShapeRegionModel:
                                        MatchAssistant.SaveShapeModel(folderPath + "\\ModelFile.shm");
                                        break;
                                    default: break;
                                }
                            }
                        }
                        else { MessageBox.Show("未创建模板搜索区域!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                    else { MessageBox.Show("未创建模板匹配模型!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else { MessageBox.Show("未创建模板提取区域!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("未加载训练图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        /// <summary>
        /// 清空模板
        /// </summary>
        protected virtual void ClearModel()
        {
            MatchAssistant.OnExternalModelID = false;
            this.chkbAlwaysFind.Checked = false;

            if (ExtractRegion != null
                && ExtractRegion.IsInitialized())
            {
                ExtractRegion.Dispose();
                ExtractRegion = null;
            }

            if (_modelContour != null)
            {
                _modelContour.Dispose();
                _modelContour = null;
            }

            if (_instanceContour != null
                && _instanceContour.IsInitialized())
            {
                _instanceContour.Dispose();
                _instanceContour = null;
            }

            _matchModelOptAccuracy.Reset();
            _matchModelOpt = _matchModelOptAccuracy;
            OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_UPDATED_VALS);
            OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_OPTIMAL_VALS);
            OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_STATISTICS_STATUS);

            _matchModelOptResults.Reset();
            _matchModelOpt = _matchModelOptResults;
            OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RECOGRATE);
            OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RESULTS);

            MatchAssistant.Reset();
            //恢复缓存的模型参数
            MatchAssistant.RetrieveModelParameters();

            if (this.tabControlModel.SelectedIndex != 0)
            {
                this.tabControlModel.SelectedIndex = 0;
            }
            else { DisplayTrainImage(); }           
        }

        /// <summary>
        /// 加载模板
        /// </summary>
        protected virtual void LoadModel()
        {
            _fbdModelFolder.Description = "请选择包含模板文件的文件夹";
            if (_fbdModelFolder.ShowDialog() == DialogResult.OK)
            {
                HalconDotNet.HTuple exist;
                string folderPath = _fbdModelFolder.SelectedPath;
                string extension = string.Empty;
                string name = string.Empty;
                string modelFile = string.Empty;
                int idx;
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(folderPath);
                if (dirInfo.GetFiles().Length + dirInfo.GetDirectories().Length == 0)
                {
                    MessageBox.Show("文件夹下无文件!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    System.IO.FileInfo[] windImgFiles = dirInfo.GetFiles();
                    foreach (System.IO.FileInfo itm in windImgFiles)
                    {
                        idx = itm.Name.LastIndexOf(".");
                        name = itm.Name.Substring(0, idx);
                        if (name == "TrainImage")
                        {
                            extension = itm.Extension;
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(extension))
                {
                    HalconDotNet.HOperatorSet.FileExists(folderPath + "\\ExtrackRegion.hobj", out exist);
                    if ((int)exist != 0)
                    {
                        HalconDotNet.HOperatorSet.FileExists(folderPath + "\\SearchRegion.hobj", out exist);
                        if ((int)exist != 0)
                        {
                            HalconDotNet.HOperatorSet.FileExists(folderPath + "\\ModelPose.tup", out exist);
                            if ((int)exist != 0)
                            {
                               
                                switch(MatchAssistant.ModelType)
                                {
                                    case Communal.MatchModelType.NCCModel:
                                        modelFile = "\\ModelFile.ncm";
                                        break;
                                    case Communal.MatchModelType.ShapeContourModel:
                                    case Communal.MatchModelType.ShapeRegionModel:                                       
                                    default:
                                        modelFile = "\\ModelFile.shm";
                                        break;
                                }
                                HalconDotNet.HOperatorSet.FileExists(folderPath + modelFile, out exist);
                                if (exist.I != 0)
                                {
                                    MatchAssistant.Reset();
                                    this.chkbAlwaysFind.Checked = false;

                                    //模板提取区域(未更新给模板匹配助手)
                                    HalconDotNet.HObject Imgtmp, extmp; HalconDotNet.HTuple mdlP;
                                    HalconDotNet.HOperatorSet.ReadImage(out Imgtmp, folderPath + "\\TrainImage" + extension);
                                    MatchAssistant.SetTrainImage(Imgtmp);
                                    HalconDotNet.HOperatorSet.ReadRegion(out extmp, folderPath + "\\ExtrackRegion.hobj");
                                    ExtractRegion = extmp;
                                    
                                    //模板搜索区域(未更新给模板匹配助手)
                                    extmp.Dispose();
                                    HalconDotNet.HOperatorSet.ReadRegion(out extmp, folderPath + "\\SearchRegion.hobj");
                                    SearchRegion = extmp;

                                    //模板位姿(更新给模板匹配助手)
                                    HalconDotNet.HOperatorSet.ReadTuple(folderPath + "\\ModelPose.tup", out mdlP);
                                    ModelPose = mdlP;
                                    MatchAssistant.ModelPose = ModelPose;

                                    this.cmbModelType.SelectedIndex = ModelPose[3].I;
                                    this.cmbModelType.Text = this.cmbModelType.SelectedItem.ToString();

                                    ROIMgr.Reset();
                                    if (_instanceContour != null
                                    && _instanceContour.IsInitialized())
                                    {
                                        _instanceContour.Dispose();
                                        _instanceContour = null;
                                    }

                                    //加载模板匹配模型文件
                                    if (MatchAssistant.LoadShapeModel(folderPath + modelFile))
                                    {
                                        
                                        ModelID = MatchAssistant.ModelID;
                                        _modelContour = MatchAssistant.GetTrainInstanceContour(); //此时获取的是匹配模板的实例轮廓(已经加载过模板匹配模型)

                                        if (this.tabControlModel.SelectedIndex != 0)
                                        {
                                            this.tabControlModel.SelectedIndex = 0;
                                        }
                                        else
                                        {
                                            DisplayTrainImage();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("未找到模板匹配模型!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    OnModelMatched(ProVision.MatchModel.ShapeModelAssistant.ERR_NO_VALID_FILE);
                                }
                            }
                            else { MessageBox.Show("未找到模板位姿文件!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                        }
                        else { MessageBox.Show("未找到模板搜索区域文件!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                    else { MessageBox.Show("未找到模板提取区域文件!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
                else { MessageBox.Show("未找到训练图像!", "警示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
        }

        /// <summary>
        /// 加载训练图像
        /// </summary>
        protected virtual void LoadTrainImage()
        {
            _ofdTrainImg.Multiselect = false;
            _ofdTrainImg.Filter = "图像文件(*.BMP,*.JPG,*.JPEG,*.TIF)|*.bmp;*.jpg;*.jpeg;*.tif";
            _ofdTrainImg.FilterIndex = 0;
            _ofdTrainImg.Title = "请选择一张图像文件";
            if (_ofdTrainImg.ShowDialog() == DialogResult.OK)
            {
                _locked = true;
                if (_instanceContour != null
                   && _instanceContour.IsInitialized())
                {
                    _instanceContour.Dispose();
                    _instanceContour = null;
                }

                trkbDisplayLevel.Enabled = false;
                trkbDisplayLevel.Value = 1;
                numUpDwnDisplayLevel.Enabled = false;
                numUpDwnDisplayLevel.Value = 1;
                _locked = false;

                this.chkbAlwaysFind.Checked = false;

                //设置选择的图像为训练图像
                if (!MatchAssistant.SetTrainImage(_ofdTrainImg.FileName)) //1-触发清空模板信息,更新模板轮廓
                    return;

                //显示窗口显示区域复位且显示内容清空
                HWndCtrller.ResetAll();

                if (MatchAssistant.OnExternalModelID)
                    _modelContour = MatchAssistant.GetTrainInstanceContour(); //此时获取的是匹配模板的实例轮廓(已经加载过模板匹配模型)

                if (this.tabControlModel.SelectedIndex != 0)
                {
                    this.tabControlModel.SelectedIndex = 0;
                }
                else
                {
                    DisplayTrainImage();
                }
               
                int startIndex = _ofdTrainImg.FileName.LastIndexOf(".");
                _imgExtention = _ofdTrainImg.FileName.Substring(startIndex + 1, (_ofdTrainImg.FileName.Length - startIndex - 1));
            }
        }

        /// <summary>
        /// 查找模板
        /// </summary>
        protected virtual void FindModel()
        {
            if (this.lstbTestImages.Items.Count != 0)
                ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

            MatchAssistant.ModelSearchRegion = SearchRegion;
            MatchAssistant.DetectShapeModel();
            UpdateResultListBox();
        }

        /// <summary>
        /// 显示测试图像
        /// </summary>
        protected virtual void DisplayTestImage()
        {
            string filePath;
            if (this.lstbTestImages.Items.Count == 0)
            {
                ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_INCLUDE_ROI);
                SetModelGraphics();
                HWndCtrller.Repaint();
                OnModelMatched(ProVision.MatchModel.ShapeModelAssistant.ERR_NO_TESTIMAGE);
                return;
            }

            filePath = (string)this.lstbTestImages.SelectedItem;
            MatchAssistant.GetTestImage(filePath);
            ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

            if (_modelContour != null
                && _modelContour.IsInitialized()
                && this.chkbAlwaysFind.Checked)
            {
                MatchAssistant.DetectShapeModel();
            }
            else
            {
                SetInstanceGraphic();
                HWndCtrller.Repaint();
            }
        }

        /// <summary>
        /// 清空测试图像列表
        /// </summary>
        protected virtual void ClearTestImages()
        {
            if (this.lstbTestImages.Items.Count > 0)
            {
                MatchAssistant.ClearTestImage();
                this.lstbTestImages.Items.Clear();

                ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                if (_instanceContour != null
                && _instanceContour.IsInitialized())
                {
                    _instanceContour.Dispose();
                    _instanceContour = null;
                }

                SetInstanceGraphic();

                HWndCtrller.Repaint();
            }
        }

        /// <summary>
        /// 删除测试图像
        /// </summary>
        protected virtual void DeleteTestImage()
        {
            int count;
            if ((count = this.lstbTestImages.SelectedIndex) < 0)
                return;
            string filePath = (string)this.lstbTestImages.SelectedItem;

            if ((--count) < 0)
                count += 2;

            if (count < this.lstbTestImages.Items.Count)
            {
                this.lstbTestImages.SelectedIndex = count;
            }

            MatchAssistant.RemoveTestImage(filePath);
            this.lstbTestImages.Items.Remove(filePath);
        }

        /// <summary>
        /// 加载测试图像列表
        /// </summary>
        protected virtual void LoadTestImages()
        {
            _ofdTestImgs.Multiselect = true;
            _ofdTestImgs.Filter = "图像(*.BMP)|*.bmp|图像(*.JPG)|*.jpg|图像(*.JPEG)|*.jpeg|图像(*.TIF)|*.tif|所有|*.*";
            _ofdTestImgs.FilterIndex = 0;
            _ofdTestImgs.Title = "请选择一组图像(多选)";
            string[] filePaths;
            int count = 0;

            if (_ofdTestImgs.ShowDialog() == DialogResult.OK)
            {
                filePaths = _ofdTestImgs.FileNames;
                count = filePaths.Length;

                for (int i = 0; i < count; i++)
                {
                    if (MatchAssistant.AddTestImage(filePaths[i]))
                        this.lstbTestImages.Items.Add(filePaths[i]);
                }

                if (this.lstbTestImages.Items.Count != 0
                    && this.lstbTestImages.SelectedIndex < 0)
                {
                    MatchAssistant.GetTestImage((string)this.lstbTestImages.Items[0]); //此时已经在模型中更新了模型的当前测试图像,可以通过_matchShapeBasedModel.GetCurrentTestImage()获取
                    this.lstbTestImages.SelectedIndex = 0;
                    ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);//会更新UI中的当前测试图像

                    if (_instanceContour != null)
                    {
                        _instanceContour.Dispose();
                        _instanceContour = null;
                    }

                    SetInstanceGraphic();
                    HWndCtrller.Repaint();
                }
            }
        }

        /// <summary>
        /// 开启统计
        /// </summary>
        protected virtual void RunStatistic()
        {
            if (this.lstbTestImages.Items.Count != 0)
                ChangePromptionPanelColor(2);

            if (!this._timer.Enabled)
            {
                this.chkbAlwaysFind.Checked = false;
                _matchModelOpt = _matchModelOptResults;
                _matchModelOpt.Reset();//定时器未启动,则启动定时器并使评估优化过程的参数恢复到初始值[模板匹配模型的结果统计数据恢复到初始值]
                OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RECOGRATE);
                OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RESULTS);

                this.btnStatistic.Text = "停止统计";
                MatchAssistant.OnTimer = true;
                _timer.Enabled = true;

            }
            else//定时器启动,则停止计时器
            {
                this.btnStatistic.Text = "开启统计";
                MatchAssistant.OnTimer = false;
                _timer.Enabled = false;
            }
        }

        /// <summary>
        /// 开启优化
        /// </summary>
        protected virtual void RunOptimize()
        {
            if (this.lstbTestImages.Items.Count != 0)
                ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

            if (!this._timer.Enabled)//定时器未启动,则启动定时器并使评估优化过程的参数恢复到初始值[模板匹配模型部分查找参数恢复到初始值]
            {
                this.chkbAlwaysFind.Checked = false;
                _matchModelOpt = _matchModelOptAccuracy;
                _matchModelOpt.Reset();

                OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_UPDATED_VALS);
                OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_OPTIMAL_VALS);
                OnRecognizedAndStatisticed(ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_STATISTICS_STATUS);

                this.btnOptimize.Text = "停止优化";
                MatchAssistant.OnTimer = true;
                _timer.Enabled = true;
            }
            else//定时器启动,则停止计时器
            {
                this.btnOptimize.Text = "开启优化";
                MatchAssistant.OnTimer = false;
                _timer.Enabled = false;
                //this.UpdateStatisticData(ProVision.Communal.MatchModelOptimization.RUN_FAILED);
            }
        }

        #endregion

        #region HWndc事件 --09

        private void HWndcDisplay_SizeChanged(object sender, EventArgs e)
        {
            if (ROIMgr != null
                && HWndCtrller != null)
            {
                HWndCtrller.ResetAll();
                HWndCtrller.Repaint();
            }
        }

        private void HWndcDisplay_HMouseUp(object sender, HalconDotNet.HMouseEventArgs e)
        {
            if ((ExtractRegion != null
               && ExtractRegion.IsInitialized()))
            {
                //更新模板提取区域后重新提取模板信息
                ROIMgr.IconicUpdatedDel(ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI);
            }
        }

        private void HWndcDisplay_HMouseMove(object sender, HalconDotNet.HMouseEventArgs e)
        {
            //若是绘制模板提取区域:按下左键并移动时绘制一个区域并与掩膜区域进行并或差操作
            //若是绘制模板搜索区域:按下左键并移动时按照ROI的管理方式进行(平移和拖放)
            DrawMaskAndDisplayRegion(e, _brushSize);
            UpdateMouseCoordinateAndGrayValue(e);
        }

        private void HWndcDisplay_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e)
        {
            //若是绘制模板提取区域:按下左键并移动时绘制一个区域并与掩膜区域进行并或差操作
            //若是绘制模板搜索区域:按下左键并移动时按照ROI的管理方式进行(平移和拖放)
            DrawMaskAndDisplayRegion(e, _brushSize);
        }

        #endregion       

      
        /// <summary>
        /// 绘制并显示区域
        /// [模板搜索区域,模板提取区域,模板区域]
        /// </summary>
        /// <param name="e"></param>
        /// <param name="radius"></param>
        private void DrawMaskAndDisplayRegion(HalconDotNet.HMouseEventArgs e,int radius)
        {
            #region 创建模板搜索区域
            if (_isOnCreateSearchRegion)
            {
                //自由绘制且笔刷启用
                if (_isOnFreeDraw
                    && chkbBrushOnOff.Checked)
                {
                    HalconDotNet.HRegion hRegion;
                    if (this.chkbBrushShape.Checked)
                    {
                        //方形笔刷
                        hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);

                        //HalconDotNet.HObject region = new HalconDotNet.HObject();
                        //region.Dispose();
                        //HalconDotNet.HOperatorSet.GenRectangle1(out region, e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                    }
                    else
                    {
                        //圆形笔刷              
                        hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);

                        //HalconDotNet.HObject region = new HalconDotNet.HObject();
                        //region.Dispose();
                        //HalconDotNet.HOperatorSet.GenCircle(out region, new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(radius));
                    }

                    HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (_drawMode == ProVision.Communal.DrawMode.Fill)
                        {
                            if (GrdMsk != null)
                            {
                                GrdMsk.UnionRegion(hObj);
                            }
                        }
                        else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                        {
                            if (GrdMsk != null)
                            {
                                GrdMsk.DifferenceRegion(hObj);
                            }
                        }

                        SearchRegion = GrdMsk.MaskRegion;

                        DisplayMaskAndRegion(hObj, SearchRegion,ExtractRegion, _modelRegion);
                    }
                    hRegion.Dispose();
                } //基础形状绘制
                else if (!_isOnFreeDraw)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //修改模板提取区域
                        if (this.chkbBrushOnOff.Checked)
                        {
                            //已经定义基本形状(固定位置)
                            if (SearchRegion != null
                                && SearchRegion.IsInitialized())
                            {
                                if (GrdMsk != null)
                                    GrdMsk.MaskRegion = SearchRegion;

                                HalconDotNet.HRegion hRegion;
                                if (this.chkbBrushShape.Checked)
                                {
                                    //方形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                                }
                                else
                                {
                                    //圆形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);
                                }

                                HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);

                                if (_drawMode == ProVision.Communal.DrawMode.Fill)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.UnionRegion(hObj);
                                    }
                                }
                                else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.DifferenceRegion(hObj);
                                    }
                                }

                                //SearchRegion作为引用变量在进行并或差操作时，已经被释放掉,需要重新指向内存
                                SearchRegion = GrdMsk.MaskRegion;
                                DisplayMaskAndRegion(hObj, SearchRegion,ExtractRegion, _modelRegion);
                                hRegion.Dispose();
                            }
                        }
                        //更新模板提取区域(基本形状)
                        else
                        {
                            //获取模板提取区域
                            if (ROIMgr.CalculateSyntheticalRegion())
                                SearchRegion = ROIMgr.GetSyntheticalRegion().Clone();
                        }
                    }
                }
            }
            #endregion 创建模板搜索区域

            #region 创建模板提取区域
            else if(_isOnCreateExtractRegion)
            {
                //自由绘制且笔刷启用
                if (_isOnFreeDraw
                    && chkbBrushOnOff.Checked)
                {
                    HalconDotNet.HRegion hRegion;
                    if (this.chkbBrushShape.Checked)
                    {
                        //方形笔刷
                        hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);

                        //HalconDotNet.HObject region = new HalconDotNet.HObject();
                        //region.Dispose();
                        //HalconDotNet.HOperatorSet.GenRectangle1(out region, e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                    }
                    else
                    {
                        //圆形笔刷              
                        hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);

                        //HalconDotNet.HObject region = new HalconDotNet.HObject();
                        //region.Dispose();
                        //HalconDotNet.HOperatorSet.GenCircle(out region, new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(radius));
                    }

                    HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (_drawMode == ProVision.Communal.DrawMode.Fill)
                        {
                            if (GrdMsk != null)
                            {
                                GrdMsk.UnionRegion(hObj);
                            }
                        }
                        else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                        {
                            if (GrdMsk != null)
                            {
                                GrdMsk.DifferenceRegion(hObj);
                            }
                        }

                        ExtractRegion = GrdMsk.MaskRegion;

                        DisplayMaskAndRegion(hObj, SearchRegion, ExtractRegion, _modelRegion);
                    }
                    hRegion.Dispose();
                } //基础形状绘制
                else if (!_isOnFreeDraw)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //修改模板提取区域
                        if (this.chkbBrushOnOff.Checked)
                        {
                            //已经定义基本形状(固定位置)
                            if (ExtractRegion != null
                                && ExtractRegion.IsInitialized())
                            {
                                if (GrdMsk != null)
                                    GrdMsk.MaskRegion = ExtractRegion;

                                HalconDotNet.HRegion hRegion;
                                if (this.chkbBrushShape.Checked)
                                {
                                    //方形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                                }
                                else
                                {
                                    //圆形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);
                                }

                                HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);

                                if (_drawMode == ProVision.Communal.DrawMode.Fill)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.UnionRegion(hObj);
                                    }
                                }
                                else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.DifferenceRegion(hObj);
                                    }
                                }

                                //ExtractRegion作为引用变量在进行并或差操作时，已经被释放掉,需要重新指向内存
                                ExtractRegion = GrdMsk.MaskRegion;
                                DisplayMaskAndRegion(hObj, SearchRegion, ExtractRegion, _modelRegion);
                                hRegion.Dispose();
                            }
                        }
                        //更新模板提取区域(基本形状)
                        else
                        {
                            //获取模板提取区域
                            if (ROIMgr.CalculateSyntheticalRegion())
                                ExtractRegion = ROIMgr.GetSyntheticalRegion().Clone();
                        }
                    }
                }
            }
            #endregion 创建模板提取区域

            #region 擦除模板搜索区域
            else if(_isOnEraseSearchRegion)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //修改模板提取区域
                    if (this.chkbBrushOnOff.Checked)
                    {
                        //已经定义形状(固定位置)
                        if (SearchRegion != null
                            && SearchRegion.IsInitialized())
                        {
                            if (GrdMsk != null)
                                GrdMsk.MaskRegion = SearchRegion;

                            HalconDotNet.HRegion hRegion;
                            if (this.chkbBrushShape.Checked)
                            {
                                //方形笔刷
                                hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                            }
                            else
                            {
                                //圆形笔刷
                                hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);
                            }

                            HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);

                            if (_drawMode == ProVision.Communal.DrawMode.Fill)
                            {
                                if (GrdMsk != null)
                                {
                                    GrdMsk.UnionRegion(hObj);
                                }
                            }
                            else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                            {
                                if (GrdMsk != null)
                                {
                                    GrdMsk.DifferenceRegion(hObj);
                                }
                            }

                            //SearchRegion作为引用变量在进行并或差操作时，已经被释放掉,需要重新指向内存
                            SearchRegion = GrdMsk.MaskRegion;
                            DisplayMaskAndRegion(hObj, SearchRegion, ExtractRegion, _modelRegion);
                            hRegion.Dispose();
                        }
                    }
                }
            }
            #endregion 擦除模板搜索区域

            #region 擦除模板提取区域
            else if(_isOnEraseExtractRegion)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //修改模板提取区域
                    if (this.chkbBrushOnOff.Checked)
                    {
                        //已经定义形状(固定位置)
                        if (ExtractRegion != null
                            && ExtractRegion.IsInitialized())
                        {
                            if (GrdMsk != null)
                                GrdMsk.MaskRegion = ExtractRegion;

                            HalconDotNet.HRegion hRegion;
                            if (this.chkbBrushShape.Checked)
                            {
                                //方形笔刷
                                hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                            }
                            else
                            {
                                //圆形笔刷
                                hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);
                            }

                            HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);

                            if (_drawMode == ProVision.Communal.DrawMode.Fill)
                            {
                                if (GrdMsk != null)
                                {
                                    GrdMsk.UnionRegion(hObj);
                                }
                            }
                            else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                            {
                                if (GrdMsk != null)
                                {
                                    GrdMsk.DifferenceRegion(hObj);
                                }
                            }

                            //ExtractRegion作为引用变量在进行并或差操作时，已经被释放掉,需要重新指向内存
                            ExtractRegion = GrdMsk.MaskRegion;
                            DisplayMaskAndRegion(hObj, SearchRegion, ExtractRegion, _modelRegion);
                            hRegion.Dispose();
                        }
                    }
                }
            }
            #endregion 擦除模板提取区域

            #region 擦除模板区域(轮廓)
            else if(_isOnEraseModelRegion)
            {
                //只在轮廓形状模板匹配模型下允许擦除模板区域(轮廓)
                if(this.cmbModelType.SelectedIndex==1)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        //修改模板区域
                        if (this.chkbBrushOnOff.Checked)
                        {
                            //已经获取模板区域
                            if (_modelRegion != null
                                && _modelRegion.IsInitialized())
                            {
                                if (GrdMsk != null)
                                    GrdMsk.MaskRegion = _modelRegion;

                                HalconDotNet.HRegion hRegion;
                                if (this.chkbBrushShape.Checked)
                                {
                                    //方形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y - radius / 2, e.X - radius / 2, e.Y + radius / 2, e.X + radius / 2);
                                }
                                else
                                {
                                    //圆形笔刷
                                    hRegion = new HalconDotNet.HRegion(e.Y, e.X, radius);
                                }

                                HalconDotNet.HObject hObj = new HalconDotNet.HObject(hRegion);

                                if (_drawMode == ProVision.Communal.DrawMode.Fill)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.UnionRegion(hObj);
                                    }
                                }
                                else if (_drawMode == ProVision.Communal.DrawMode.Erase)
                                {
                                    if (GrdMsk != null)
                                    {
                                        GrdMsk.DifferenceRegion(hObj);
                                    }
                                }

                                //_modelRegion作为引用变量在进行并或差操作时，已经被释放掉,需要重新指向内存
                                _modelRegion = GrdMsk.MaskRegion;
                                _modelContour.Dispose();

                                //---合并区域产生多个轮廓
                                HalconDotNet.HOperatorSet.GenContourRegionXld(_modelRegion, out _modelContour, new HalconDotNet.HTuple("border"));

                                MatchAssistant.ModelContoure = _modelContour;

                                DisplayMaskAndRegion(hObj, SearchRegion, ExtractRegion, _modelRegion);
                                hRegion.Dispose();
                            }
                        }
                    }
                }
            }
            #endregion 擦除模板区域(轮廓)
        }

        /// <summary>
        /// 显示掩膜区域以及模板搜索区域,模板提取区域,模板区域
        /// </summary>
        /// <param name="brushRegion"></param>
        /// <param name="searchRegion"></param>
        /// <param name="extractRegion"></param>
        /// <param name="modelRegion"></param>
        private void DisplayMaskAndRegion(HalconDotNet.HObject brushRegion, 
            HalconDotNet.HObject searchRegion, 
            HalconDotNet.HObject extractRegion,
            HalconDotNet.HObject modelRegion)
        {
            HWndCtrller.ClearEntities();
            if (_currentImage != null
                && _currentImage.IsInitialized())
                HWndCtrller.AddHobjEntity(_currentImage);

            if (brushRegion != null
               && brushRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _maskRegionColor);
                HWndCtrller.AddHobjEntity(brushRegion);
                HWndCtrller.AddHobjEntity(GrdMsk.MaskRegion);
                HWndCtrller.AddHobjEntity(GrdMsk.DotMatriceMaskRegion);
            }

            if (extractRegion!=null
            && extractRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _extractRegionColor);
                HWndCtrller.AddHobjEntity(extractRegion);
            }            

            if (searchRegion != null
               && searchRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _searchRegionColor);
                HWndCtrller.AddHobjEntity(searchRegion);
            }

            if(modelRegion!=null
                && modelRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _modelContourColor);
                HWndCtrller.AddHobjEntity(modelRegion);
            }
                      
            HWndCtrller.Repaint();

            if (brushRegion != null
                && brushRegion.IsInitialized())
                brushRegion.Dispose();
        }

        /// <summary>
        /// 更新鼠标坐标及像素灰度值
        /// </summary>
        /// <param name="e"></param>
        private void UpdateMouseCoordinateAndGrayValue(HalconDotNet.HMouseEventArgs e)
        {
            HalconDotNet.HTuple gv = new HalconDotNet.HTuple();
            if (_currentImage != null
                && _currentImage.IsInitialized())
            {
                HalconDotNet.HObject domain;
                HalconDotNet.HTuple isInside = new HalconDotNet.HTuple();
                HalconDotNet.HOperatorSet.GetDomain(_currentImage, out domain);
                HalconDotNet.HOperatorSet.TestRegionPoint(domain, new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(e.X), out isInside);

                if (isInside.TupleNotEqual(new HalconDotNet.HTuple())
                    && isInside.Length == 1
                    && isInside[0] == 1)
                {
                    try
                    {
                        HalconDotNet.HOperatorSet.GetGrayval(_currentImage, new HalconDotNet.HTuple(e.Y), new HalconDotNet.HTuple(e.X), out gv);
                    }
                    catch (HalconDotNet.HalconException hex)
                    {

                    }
                }
            }

            string gs = (gv.TupleEqual(new HalconDotNet.HTuple())) ? "-" : gv.I.ToString();
            this.lblCoordinateGrayValue.Text = "行:" + e.Y.ToString("00.00") + ",列:" + e.X.ToString("00.00") + ",灰度:" + gs;
        }

        /// <summary>
        /// 窗体加载完成事件--15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMatchModel_Load(object sender, EventArgs e)
        {
            UpdateControls();
            _isFirstUpdate = false;

            if (_specifiedModelPara)
            {
                _locked = true;
                InitControlValueWithMatchModelParameter(MatchAssistant.Parameter);
                _locked = false;
            }
            else
            {
                _locked = true;
                InitMatchModelParameterWithControlValue(MatchAssistant.Parameter);
                _locked = false;
            }
        }    

        /// <summary>
        /// 显示训练图像--04
        /// </summary>
        private void DisplayTrainImage()
        {
            ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_INCLUDE_ROI);
            SetModelGraphics();
            HWndCtrller.Repaint();//模型匹配--显示训练状态,重新绘图
        }

        /// <summary>
        /// 根据指定的模式,切换当前图像并
        /// 改变提示容器的颜色--05
        /// </summary>
        /// <param name="roiPaintMode">
        /// 绘图模式
        /// 1-包含ROI,2-不包含ROI</param>
        private void ChangePromptionPanelColor(int roiPaintMode)
        {
            HWndCtrller.SetROIPaintMode(roiPaintMode);
            switch (roiPaintMode)
            {
                case ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_INCLUDE_ROI:
                    {
                        _currentImage = MatchAssistant.GetPyramidImage();

                        if (MatchAssistant.OnExternalModelID)
                        {
                            //外部加载的模板
                            this.spltViewResult.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;

                        }
                        else if (_currentImage == null)
                        {
                            //显示训练图像的窗口背景(未创建模板图像，弹窗提示?)
                            this.spltViewResult.Panel1.BackColor = _createModelColor;
                        }
                        else
                        {
                            //显示训练图像的窗口背景(已创建模板图像，允许修改)
                            this.spltViewResult.Panel1.BackColor = _createModelColor;
                        }
                    }
                    break;
                case ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI:
                    {
                        _currentImage = MatchAssistant.GetCurrentTestImage();
                        //显示测试图像的窗口背景
                        this.spltViewResult.Panel1.BackColor = _trainModelColor;
                    }
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 更新匹配结果列表--01
        /// </summary>
        protected virtual void UpdateResultListBox()
        {
            if (MatchAssistant != null
               && MatchAssistant.Result != null)
            {
                int count = MatchAssistant.Result.MatchCount;
                if (this.dgvMatchResult != null)
                {
                    this.dgvMatchResult.Rows.Clear();
                    //this.dgvMatchResult.DefaultCellStyle.Font = new Font("宋体", 14);
                }

                if (count > 0)
                {
                    this.dgvMatchResult.Rows.Add(count);
                    for (int i = 0; i < count; i++)
                    {
                        this.dgvMatchResult.Rows[i].Cells[0].Value = (i + 1).ToString("00");
                        this.dgvMatchResult.Rows[i].Cells[1].Value = System.Math.Round(MatchAssistant.Result.Score[i].D, 2).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 模板的图形上下文设置
        /// [包含图像,模板区域,
        /// 模板轮廓的图形上下文设置]--06
        /// </summary>
        private void SetModelGraphics()
        {
            if (_currentImage != null
                && _currentImage.IsInitialized())
            {
                HWndCtrller.ClearEntities();
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINESTYLE, new HalconDotNet.HTuple());
                HWndCtrller.AddHobjEntity(_currentImage);
            }

            //模板提取区域
            if (ExtractRegion != null
                && ExtractRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _extractRegionColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _modelContourLineWidth);
                HWndCtrller.AddHobjEntity(ExtractRegion);
            }

            //模板搜索区域
            if (SearchRegion != null
                && SearchRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _searchRegionColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _modelContourLineWidth);
                HWndCtrller.AddHobjEntity(SearchRegion);
            }

            //模板区域的轮廓
            if (_modelContour != null
                && _modelContour.IsInitialized()) //训练图像中的金字塔等级对应的模板区域的轮廓
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _modelContourColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _modelContourLineWidth);
                HWndCtrller.AddHobjEntity(_modelContour);
            }
        }

        /// <summary>
        /// 匹配实例的图形上下文设置--07
        /// </summary>
        private void SetInstanceGraphic()
        {
            if (_currentImage != null
                && _currentImage.IsInitialized())
            {
                HWndCtrller.ClearEntities();
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINESTYLE, new HalconDotNet.HTuple());
                HWndCtrller.AddHobjEntity(_currentImage);
            }

            //模板提取区域
            if (ExtractRegion != null
                && ExtractRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _extractRegionColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _modelContourLineWidth);
                HWndCtrller.AddHobjEntity(ExtractRegion);
            }

            //模板搜索区域
            if (SearchRegion != null
                && SearchRegion.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _searchRegionColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _modelContourLineWidth);
                HWndCtrller.AddHobjEntity(SearchRegion);
            }

            //匹配模板实例轮廓
            if (_instanceContour != null
                && _instanceContour.IsInitialized())
            {
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _instanceContourColor);
                HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _instanceContourLineWidth);
                int cnt = _instanceContour.CountObj(); //匹配模板的实例的轮廓对象数可能是多个               

                if (_crossContour != null
                    && _crossContour.IsInitialized())
                    _crossContour.Dispose();
              
                HalconDotNet.HOperatorSet.GenCrossContourXld(out _crossContour, MatchAssistant.Result.Row,
                    MatchAssistant.Result.Col, 50, MatchAssistant.Result.Angle);
                HWndCtrller.AddHobjEntity(_crossContour);

                if (_activeInsContourIdx >= 0
                    && _activeInsContourIdx < cnt)
                {
                    //多个匹配模板的实例选择其中一个
                    this.HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _activeInstanceContourColor);
                    this.HWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _instanceContourLineWidth);
                    this.HWndCtrller.AddHobjEntity(_crossContour.SelectObj(_activeInsContourIdx + 1));
                }
            }

        }

        /// <summary>
        /// 用控件值初始化匹配参数--15--01
        /// </summary>
        /// <param name="param"></param>
        private void InitMatchModelParameterWithControlValue(ProVision.Communal.ShapeModelParameter param)
        {
            param.NumLevels = (int)this.numUpDwnNumLevels.Value;
            param.Metric = (string)this.cmbMetric.Items[this.cmbMetric.SelectedIndex];
            param.Optimization = (string)this.cmbOptimization.Items[this.cmbOptimization.SelectedIndex];
            param.Contrast = (int)this.numUpDwnContrast.Value;
            param.MinContrast = (int)this.numUpDwnMinContrast.Value;

            param.StartAngle = (double)this.numUpDwnStartAngle.Value * System.Math.PI / 180.0;
            param.AngleExtent = (double)(this.numUpDwnAngleExtent.Value) * System.Math.PI / 180.0;
            param.AngleStep = ((double)this.numUpDwnAngleStep.Value / 10.0) * System.Math.PI / 180.0;

            param.ScaleMin = (double)this.numUpDwnMinScale.Value / 100.0;
            param.ScaleMax = (double)this.numUpDwnMaxScale.Value / 100.0;
            param.ScaleStep = (double)this.numUpDwnScaleStep.Value / 1000.0;

            param.MinScore = (double)this.numUpDwnMinScore.Value / 100.0;
            param.NumToMatch = (int)this.numUpDwnNumToMatch.Value;
            param.Greediness = (double)this.numUpDwnGreediness.Value / 100.0;
            param.MaxOverLap = (double)this.numUpDwnMaxOverlap.Value / 100.0;
            param.SubPixel = (string)this.cmbSubPixel.Items[this.cmbSubPixel.SelectedIndex];
            param.LastNumLevel = (int)this.numUpDwnLastLevel.Value;

            param.RecogRateOpt = (int)this.cmbRecogRateOption.SelectedIndex;
            param.RecogRate = (int)this.numUpDwnRecogRate.Value;
            param.RecogAccuracyMode = ProVision.Communal.ShapeModelParameter.RECOG_MODE_SPECIFIEDNUM;
            param.RecogSpecifiedMatchNum = (int)this.numUpDwnSpecifiedNum.Value;
            param.InspectMaxNoMatch = (int)this.numUpDwnMaxNumMatch.Value;
        }

        /// <summary>
        /// 用匹配参数初始化控件值--15--02
        /// </summary>
        /// <param name="param"></param>
        private void InitControlValueWithMatchModelParameter(ProVision.Communal.ShapeModelParameter param)
        {
            this.numUpDwnNumLevels.Value = param.NumLevels;
            this.cmbMetric.SelectedIndex = this.cmbMetric.Items.IndexOf(param.Metric);
            this.cmbOptimization.SelectedIndex = this.cmbOptimization.Items.IndexOf(param.Optimization);
            this.numUpDwnContrast.Value = (decimal)param.Contrast;
            this.numUpDwnMinContrast.Value = (decimal)param.MinContrast;

            this.numUpDwnStartAngle.Value = (decimal)(param.StartAngle * 180.0 / System.Math.PI);
            this.numUpDwnAngleExtent.Value = (decimal)(param.AngleExtent * 180.0 / System.Math.PI);
            this.numUpDwnAngleStep.Value = (decimal)(param.AngleStep * 180.0 / System.Math.PI * 10.0);

            this.numUpDwnMinScale.Value = (decimal)(param.ScaleMin * 100.0);
            this.numUpDwnMaxScale.Value = (decimal)(param.ScaleMax * 100.0);
            this.numUpDwnScaleStep.Value = (decimal)(param.ScaleStep * 1000.0);

            this.numUpDwnMinScore.Value = (decimal)(param.MinScore * 100.0);
            this.numUpDwnNumToMatch.Value = (decimal)(param.NumToMatch);
            this.numUpDwnGreediness.Value = (decimal)(param.Greediness * 100.0);
            this.numUpDwnMaxOverlap.Value = (decimal)(param.MaxOverLap * 100.0);
            this.cmbSubPixel.SelectedIndex = this.cmbSubPixel.Items.IndexOf(param.SubPixel);
            this.numUpDwnLastLevel.Value = (decimal)(param.LastNumLevel);

            this.cmbRecogRateOption.SelectedIndex = param.RecogRateOpt;
            this.numUpDwnRecogRate.Value = (decimal)(param.RecogRate);
            this.numUpDwnSpecifiedNum.Value = (decimal)(param.RecogSpecifiedMatchNum);
            this.numUpDwnMaxNumMatch.Value = (decimal)(param.InspectMaxNoMatch);
            this.numUpDwnRecogRate.Value = (decimal)(param.RecogRate);
        }

        /// <summary>
        /// This method is invoked if changes occur in the HWndCtrller instance
        /// or the ROIManager. In either case, the HALCON 
        /// window needs to be updated/repainted.
        /// 图形变量变化时回调--10
        /// </summary>
        private void OnIconicUpdated(int val)
        {
            if (MatchAssistant == null)
                return;
            switch (val)
            {
                //ROI创建和更新执行一次即可
                case ProVision.InteractiveROI.ROIManager.EVENT_CHANGED_ROI_SIGN:
                case ProVision.InteractiveROI.ROIManager.EVENT_DELETED_ACTROI:
                case ProVision.InteractiveROI.ROIManager.EVENT_DELETED_ALL_ROIS: //清空模板时
                case ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI:      //创建交互ROI定义模板搜索区域,模板提取区域时或加载模板(包含加载模板提取区域)
                    {
                        if (_isOnCreateExtractRegion
                            || _isOnEraseExtractRegion)
                        {
                            //此处仅用来在更改交互获得的ROI模板提取区域后，提取金字塔图层和ROI区域层
                            if (ExtractRegion != null
                                && ExtractRegion.IsInitialized())
                            {
                                if (_modelRegion != null)
                                {
                                    _modelRegion.Dispose();
                                }

                                if (_modelContour != null
                                     && _modelContour.IsInitialized())
                                {
                                    _modelContour.Dispose();
                                    _modelContour = null;
                                }

                                if (_instanceContour != null)
                                {
                                    _instanceContour.Dispose();
                                    _instanceContour = null;
                                }

                                MatchAssistant.SetModelROI(ExtractRegion);
                            }
                        }
                        else if (_isOnCreateSearchRegion
                            || _isOnEraseSearchRegion)
                        {
                            if (SearchRegion != null
                                && SearchRegion.IsInitialized())
                            {
                                OnModelMatched(ProVision.MatchModel.ShapeModelAssistant.UPDATE_MODEL_XLD);
                            }
                        }
                    }
                    break;
                case ProVision.InteractiveROI.HWndCtrller.ERROR_READING_IMAGE:
                    {
                        System.Windows.Forms.MessageBox.Show("读取文件时发生异常!\r\n" + this.HWndCtrller.ExceptionMsg,
                            "警告信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default: break;
            }
        }

        /// <summary>
        /// This method is invoked for any changes in the 
        /// 'MatchModel', concerning the model creation and
        /// the model finding. Also changes in the display mode 
        /// (e.g., pyramid level) are mapped here.
        /// 模板匹配模型创建或者匹配,或者显示模式变化时回调--11
        /// </summary>
        private void OnModelMatched(int val)
        {
            bool isrepaint = false; //是否重绘
            switch (val)
            {
                case ProVision.MatchModel.ShapeModelAssistant.UPDATE_MODEL_XLD:
                case ProVision.MatchModel.ShapeModelAssistant.UPDATE_DISP_LEVEL:
                    {
                       if(_isOnCreateExtractRegion
                            || _isOnEraseExtractRegion
                            || _isOnCreateSearchRegion
                            || _isOnEraseSearchRegion)
                        {
                            _currentImage = MatchAssistant.GetPyramidImage();
                            _modelContour = MatchAssistant.GetPyramidContour();
                            _modelRegion = MatchAssistant.GetPyramidRegion();

                            SetModelGraphics();
                            isrepaint = true;
                        }
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.UPDATE_PYRAMID_LEVELS:
                    {
                        this.numUpDwnDisplayLevel.Enabled = true;
                        this.trkbDisplayLevel.Enabled = true;
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.UPDATE_DETECTION_RESULT:
                    {
                        _instanceContour = MatchAssistant.Result.GetInstanceContour();
                        SetInstanceGraphic();
                        isrepaint = true;
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.UPDATE_TEST_VIEW:
                    {
                        _currentImage = MatchAssistant.GetCurrentTestImage();
                        SetInstanceGraphic();
                        isrepaint = true;
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_WRITE_SHAPEMODEL:
                    {
                        System.Windows.Forms.MessageBox.Show("写入文件时发生异常!\r\n" + MatchAssistant.ExceptionMsg,
                           "错误信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_READ_SHAPEMODEL:
                    {
                        System.Windows.Forms.MessageBox.Show("读取文件时发生异常!\r\n" + MatchAssistant.ExceptionMsg,
                          "错误信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_NO_MODEL_DEFINED:
                    {
                        if (!_isFirstUpdate)
                            System.Windows.Forms.MessageBox.Show("未能创建模板匹配模型!\r\n请先定义模板区域!",
                          "提示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_NO_IMAGE:
                    {
                        if(!_isFirstUpdate)
                            System.Windows.Forms.MessageBox.Show("未加载模板图像!",
                             "警示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_NO_TESTIMAGE:
                    {
                        System.Windows.Forms.MessageBox.Show("未加载测试图像!",
                         "警示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_NO_VALID_FILE:
                    {
                        System.Windows.Forms.MessageBox.Show("已加载的文件非Halcon定义的模板匹配模型文件(*.shm)!",
                         "警示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_READING_IMG:
                    OnIconicUpdated(ProVision.InteractiveROI.HWndCtrller.ERROR_READING_IMAGE);
                    break;
                default: break;
            }
            if (isrepaint)
                HWndCtrller.Repaint();
        }

        /// <summary>
        /// Calculates new optimal values for a parameter, if the parameter is
        /// in the auto-mode list. The new settings are forwarded to the GUI
        /// components to update the display.
        /// 有自动参数时,计算新的优化参数.新的优化参数更新显示到控件.
        /// </summary>
        private void OnAutoParameterized(string val)
        {
            int[] r;
            this._locked = true;
            switch (val)
            {
                case ProVision.Communal.ShapeModelParameter.AUTO_ANGLE_STEP:
                    this.numUpDwnAngleStep.Value = (int)(MatchAssistant.Parameter.AngleStep * 10.0 * 180.0 / System.Math.PI);
                    break;
                case ProVision.Communal.ShapeModelParameter.AUTO_CONTRAST:
                    this.numUpDwnContrast.Value = MatchAssistant.Parameter.Contrast;
                    break;
                case ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST:
                    this.numUpDwnMinContrast.Value = MatchAssistant.Parameter.MinContrast;
                    break;
                case ProVision.Communal.ShapeModelParameter.AUTO_NUM_LEVELS:
                    this.numUpDwnNumLevels.Value = MatchAssistant.Parameter.NumLevels;
                    break;
                case ProVision.Communal.ShapeModelParameter.AUTO_OPTIMIZATION:
                    this.cmbOptimization.Text = MatchAssistant.Parameter.Optimization;
                    break;
                case ProVision.Communal.ShapeModelParameter.AUTO_SCALE_STEP:
                    this.numUpDwnScaleStep.Value = (int)(MatchAssistant.Parameter.ScaleStep * 1000.0);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_ANGLE_EXTENT:
                    this.numUpDwnAngleExtent.Value = (int)(MatchAssistant.Parameter.AngleExtent * 180.0 / System.Math.PI);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_ANGLE_START:
                    this.numUpDwnStartAngle.Value = (int)(MatchAssistant.Parameter.StartAngle * 180.0 / System.Math.PI);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_GREEDINESS:
                    this.numUpDwnGreediness.Value = (int)(MatchAssistant.Parameter.Greediness * 100.0);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_METRIC:
                    this.cmbMetric.Text = MatchAssistant.Parameter.Metric;
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_MINSCORE:
                    this.numUpDwnMinScore.Value = (int)(MatchAssistant.Parameter.MinScore * 100.0);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_SCALE_MAX:
                    this.numUpDwnMaxScale.Value = (int)(MatchAssistant.Parameter.ScaleMax * 100.0);
                    break;
                case ProVision.Communal.ShapeModelParameter.CONTROL_SCALE_MIN:
                    this.numUpDwnMinScale.Value = (int)(MatchAssistant.Parameter.ScaleMin * 100.0);
                    break;
                case ProVision.Communal.ShapeModelParameter.H_ERR_MESSAGE:
                    {
                        System.Windows.Forms.MessageBox.Show("参数异常!\r\n" + this.MatchAssistant.ExceptionMsg,
                           "警示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case ProVision.Communal.ShapeModelParameter.RANGE_ANGLE_STEP:
                    {
                        r = this.MatchAssistant.GetStepRange(ProVision.Communal.ShapeModelParameter.RANGE_ANGLE_STEP);
                        this.numUpDwnAngleStep.Minimum = (decimal)r[0];
                        this.trkbAngleStep.Minimum = r[0];
                        this.numUpDwnAngleStep.Maximum = (decimal)r[1];
                        this.trkbAngleStep.Maximum = r[1];

                        this.numUpDwnAngleStep.Value = (int)(MatchAssistant.Parameter.AngleStep * 10.0 * 180.0 / System.Math.PI);
                    }
                    break;
                case ProVision.Communal.ShapeModelParameter.RANGE_SCALE_STEP:
                    {
                        r = this.MatchAssistant.GetStepRange(ProVision.Communal.ShapeModelParameter.RANGE_SCALE_STEP);
                        this.numUpDwnScaleStep.Minimum = (decimal)r[0];
                        this.trkbScaleStep.Minimum = r[0];
                        this.numUpDwnScaleStep.Maximum = (decimal)r[1];
                        this.trkbScaleStep.Maximum = r[1];

                        this.numUpDwnScaleStep.Value = (int)(MatchAssistant.Parameter.ScaleStep * 1000.0);
                    }
                    break;
                default: break;
            }
            this._locked = false;
        }

        /// <summary>
        /// This method is invoked when the inspection tab or the 
        /// recognition tab are triggered to compute the optimized values
        /// and to forward the results to the display.
        /// 计算最优参数并显示到窗体控件--13
        /// </summary>
        private void OnRecognizedAndStatisticed(int val)
        {
            switch (val)
            {
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_STATISTICS_STATUS:
                    this.lblOptimizationStatus.Text = _matchModelOpt.OptimizationStatus;
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_UPDATED_VALS:
                    {
                        //更新:识别更新后的参数
                        this.lblLastMinScore.Text = _matchModelOpt.RecogTabOpimizationData[0];
                        this.lblLastGreediness.Text = _matchModelOpt.RecogTabOpimizationData[1];
                        this.lblLastRecogRate.Text = _matchModelOpt.RecogTabOpimizationData[2];
                        this.lblLastElapse.Text = _matchModelOpt.RecogTabOpimizationData[3];
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_OPTIMAL_VALS:
                    {
                        //更新:优化后的参数
                        this.lblOptMinScore.Text = _matchModelOpt.RecogTabOpimizationData[4];
                        this.lblOptGreediness.Text = _matchModelOpt.RecogTabOpimizationData[5];
                        this.lblOptRecogRate.Text = _matchModelOpt.RecogTabOpimizationData[6];
                        this.lblOptElapse.Text = _matchModelOpt.RecogTabOpimizationData[7];
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RECOGRATE:
                    {
                        //更新:检测模板识别率
                        this.lblAtleastOne.Text = _matchModelOpt.InspectTabRecogRateData[0];
                        this.lblSpecifiedNum.Text = _matchModelOpt.InspectTabRecogRateData[1];
                        this.lblMaxNum.Text = _matchModelOpt.InspectTabRecogRateData[2];
                        this.lblToSpecifiedNum.Text = _matchModelOpt.InspectTabRecogRateData[3];
                        this.lblToMaxNum.Text = _matchModelOpt.InspectTabRecogRateData[4];
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_INSP_RESULTS:
                    {
                        //更新:检测模板统计
                        this.lblInspectMinScore.Text = _matchModelOpt.InspectTabResultsData[0];
                        this.lblInspectMaxScore.Text = _matchModelOpt.InspectTabResultsData[1];
                        this.lblInspectRangeScore.Text = _matchModelOpt.InspectTabResultsData[2];

                        this.lblInspectMinElapse.Text = _matchModelOpt.InspectTabResultsData[3];
                        this.lblInspectMaxElapse.Text = _matchModelOpt.InspectTabResultsData[4];
                        this.lblInspectRangeElapse.Text = _matchModelOpt.InspectTabResultsData[5];

                        this.lblInspectMinRow.Text = _matchModelOpt.InspectTabResultsData[6];
                        this.lblInspectMaxRow.Text = _matchModelOpt.InspectTabResultsData[7];
                        this.lblInspectRangeRow.Text = _matchModelOpt.InspectTabResultsData[8];

                        this.lblInspectMinCol.Text = _matchModelOpt.InspectTabResultsData[9];
                        this.lblInspectMaxCol.Text = _matchModelOpt.InspectTabResultsData[10];
                        this.lblInspectRangeCol.Text = _matchModelOpt.InspectTabResultsData[11];

                        this.lblInspectMinAngle.Text = _matchModelOpt.InspectTabResultsData[12];
                        this.lblInspectMaxAngle.Text = _matchModelOpt.InspectTabResultsData[13];
                        this.lblInspectRangeAngle.Text = _matchModelOpt.InspectTabResultsData[14];

                        this.lblInspectMinRowScale.Text = _matchModelOpt.InspectTabResultsData[15];
                        this.lblInspectMaxRowScale.Text = _matchModelOpt.InspectTabResultsData[16];
                        this.lblInspectRangeRowScale.Text = _matchModelOpt.InspectTabResultsData[17];

                        this.lblInspectMinColScale.Text = _matchModelOpt.InspectTabResultsData[18];
                        this.lblInspectMaxColScale.Text = _matchModelOpt.InspectTabResultsData[19];
                        this.lblInspectRangeColScale.Text = _matchModelOpt.InspectTabResultsData[20];
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_TEST_ERR:
                    {
                        System.Windows.Forms.MessageBox.Show("优化异常!\r\n请检查是否定义模板匹配模型!",
                           "警示信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.UPDATE_RECOG_ERR:
                    {
                        System.Windows.Forms.MessageBox.Show("识别异常!\r\n无法匹配到对应模型的参数设置的实例\r\n请检查是否定义模板匹配模型且适当的参数设置",
                           "错误信息-[匹配向导]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelOpt.RUN_SUCCESSFUL:
                    OnAutoParameterized(ProVision.Communal.ShapeModelParameter.CONTROL_GREEDINESS);
                    OnAutoParameterized(ProVision.Communal.ShapeModelParameter.CONTROL_MINSCORE);
                    break;
                case ProVision.MatchModel.ShapeModelOpt.RUN_FAILED:
                    {
                        if (this.lstbTestImages.Items.Count != 0
                                   && this.chkbAlwaysFind.Checked)
                            ChangePromptionPanelColor(ProVision.InteractiveROI.HWndCtrller.PAINT_MODE_EXCLUDE_ROI);

                        MatchAssistant.SetMinScore((double)this.numUpDwnMinScore.Value / 100.0);
                        MatchAssistant.SetGreediness((double)this.numUpDwnGreediness.Value / 100.0);
                    }
                    break;
                case ProVision.MatchModel.ShapeModelAssistant.ERR_NO_TESTIMAGE:
                    OnModelMatched(ProVision.MatchModel.ShapeModelAssistant.ERR_NO_TESTIMAGE);
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 可见等级改变--22
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnOperationLevelChanged(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        this.numUpDwnDisplayLevel.Enabled = false;
                        this.trkbDisplayLevel.Enabled = false;
                        this.numUpDwnDisplayLevel.Value = 1;

                        this.numUpDwnContrast.Enabled = false;
                        this.trkbContrast.Enabled = false;
                        this.chkbContrast.Checked = true;
                        this.chkbContrast.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);

                        this.numUpDwnMinScale.Enabled = false;
                        this.numUpDwnMinScale.Value = (decimal)100;
                        this.trkbMinScale.Enabled = false;
                        this.trkbMinScale.Value = 1;

                        this.numUpDwnMaxScale.Enabled = false;
                        this.numUpDwnMaxScale.Value = (decimal)100;
                        this.trkbMaxScale.Enabled = false;
                        this.trkbMaxScale.Value = 1;

                        this.numUpDwnScaleStep.Enabled = false;
                        this.trkbScaleStep.Enabled = false;
                        this.chkbScaleStep.Checked = true;
                        this.chkbScaleStep.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_SCALE_STEP);

                        this.numUpDwnStartAngle.Enabled = false;
                        this.numUpDwnStartAngle.Value = (decimal)0;
                        this.trkbStartAngle.Enabled = false;
                        this.trkbStartAngle.Value = 0;

                        this.numUpDwnAngleExtent.Enabled = false;
                        this.numUpDwnAngleExtent.Value = (decimal)360;
                        this.trkbAngleExtent.Enabled = false;
                        this.trkbAngleExtent.Value = 360;

                        this.numUpDwnAngleStep.Enabled = false;
                        this.trkbAngleStep.Enabled = false;
                        this.chkbAngleStep.Checked = true;
                        this.chkbAngleStep.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_ANGLE_STEP);

                        this.numUpDwnNumLevels.Enabled = false;
                        this.trkbNumLevels.Enabled = false;
                        this.chkbNumLevel.Checked = true;
                        this.chkbNumLevel.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_NUM_LEVELS);

                        this.cmbMetric.Enabled = false;
                        this.cmbMetric.SelectedIndex = 0;
                        this.cmbMetric.Text = "use_polarity";

                        this.cmbOptimization.Enabled = false;
                        this.chkbOption.Checked = true;
                        this.chkbOption.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_OPTIMIZATION);

                        this.numUpDwnMinContrast.Enabled = false;
                        this.trkbMinContrast.Enabled = false;
                        this.chkbMinContrast.Checked = true;
                        this.chkbMinContrast.Enabled = false;
                        if (MatchAssistant != null)
                            MatchAssistant.AddAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);

                        this.numUpDwnGreediness.Enabled = false;
                        this.numUpDwnGreediness.Value = (decimal)75;
                        this.trkbGreediness.Enabled = false;
                        this.trkbGreediness.Value = 75;

                        this.numUpDwnMaxOverlap.Enabled = false;
                        this.numUpDwnMaxOverlap.Value = 50;
                        this.trkbMaxOverlap.Enabled = false;
                        this.trkbMaxOverlap.Value = 50;

                        this.cmbSubPixel.Enabled = false;
                        this.cmbSubPixel.SelectedIndex = 2;
                        this.cmbSubPixel.Text = "least_squares";

                        this.numUpDwnLastLevel.Enabled = false;
                        this.numUpDwnLastLevel.Value = (decimal)1;
                        this.trkbLastLevel.Enabled = false;
                        this.trkbLastLevel.Value = 1;

                        this.tbpInspectModel.Parent = null;
                        this.tbpOptimize.Parent = null;
                        this.tbpStatistic.Parent = null;
                    }
                    break;
                case 1:
                    {
                        this.numUpDwnDisplayLevel.Enabled = true;
                        this.trkbDisplayLevel.Enabled = true;
                        this.numUpDwnDisplayLevel.Value = 1;

                        this.numUpDwnContrast.Enabled = true;
                        this.trkbContrast.Enabled = true;
                        this.chkbContrast.Checked = false;
                        this.chkbContrast.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);

                        this.numUpDwnMinScale.Enabled = true;
                        this.numUpDwnMinScale.Value = (decimal)100;
                        this.trkbMinScale.Enabled = true;
                        this.trkbMinScale.Value = 1;

                        this.numUpDwnMaxScale.Enabled = true;
                        this.numUpDwnMaxScale.Value = (decimal)100;
                        this.trkbMaxScale.Enabled = true;
                        this.trkbMaxScale.Value = 1;

                        this.numUpDwnScaleStep.Enabled = true;
                        this.trkbScaleStep.Enabled = true;
                        this.chkbScaleStep.Checked = false;
                        this.chkbScaleStep.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_SCALE_STEP);

                        this.numUpDwnStartAngle.Enabled = true;
                        this.numUpDwnStartAngle.Value = (decimal)00;
                        this.trkbStartAngle.Enabled = true;
                        this.trkbStartAngle.Value = 0;

                        this.numUpDwnAngleExtent.Enabled = true;
                        this.numUpDwnAngleExtent.Value = (decimal)360;
                        this.trkbAngleExtent.Enabled = true;
                        this.trkbAngleExtent.Value = 360;

                        this.numUpDwnAngleStep.Enabled = true;
                        this.trkbAngleStep.Enabled = true;
                        this.chkbAngleStep.Checked = false;
                        this.chkbAngleStep.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_ANGLE_STEP);

                        this.numUpDwnNumLevels.Enabled = true;
                        this.trkbNumLevels.Enabled = true;
                        this.chkbNumLevel.Checked = false;
                        this.chkbNumLevel.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_NUM_LEVELS);

                        this.cmbMetric.Enabled = true;
                        this.cmbMetric.SelectedIndex = 0;
                        this.cmbMetric.Text = "use_polarity";

                        this.cmbOptimization.Enabled = true;
                        this.chkbOption.Checked = false;
                        this.chkbOption.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_OPTIMIZATION);

                        this.numUpDwnMinContrast.Enabled = true;
                        this.trkbMinContrast.Enabled = true;
                        this.chkbMinContrast.Checked = false;
                        this.chkbMinContrast.Enabled = true;
                        if (MatchAssistant != null)
                            MatchAssistant.RemoveAutoParameter(ProVision.Communal.ShapeModelParameter.AUTO_MIN_CONTRAST);

                        this.numUpDwnGreediness.Enabled = true;
                        this.numUpDwnGreediness.Value = (decimal)75;
                        this.trkbGreediness.Enabled = true;
                        this.trkbGreediness.Value = 75;

                        this.numUpDwnMaxOverlap.Enabled = true;
                        this.numUpDwnMaxOverlap.Value = 50;
                        this.trkbMaxOverlap.Enabled = true;
                        this.trkbMaxOverlap.Value = 50;

                        this.cmbSubPixel.Enabled = true;
                        this.cmbSubPixel.SelectedIndex = 2;
                        this.cmbSubPixel.Text = "least_squares";

                        this.numUpDwnLastLevel.Enabled = true;
                        this.numUpDwnLastLevel.Value = (decimal)1;
                        this.trkbLastLevel.Enabled = true;
                        this.trkbLastLevel.Value = 1;

                        this.tbpInspectModel.Parent = this.tabControlModel;
                        this.tbpOptimize.Parent = this.tabControlModel;
                        this.tbpStatistic.Parent = this.tabControlModel;
                    }
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 度量项选择值改变--23
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnMetricChanged(int selectedIndex)
        {
            if (MatchAssistant != null
                && MatchAssistant.Parameter != null)
            {
                MatchAssistant.Parameter.SetMetric(this.cmbMetric.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// 优化项选择值改变
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnOpimizationChanged(int selectedIndex)
        {
            if (MatchAssistant != null
               && MatchAssistant.Parameter != null)
            {
                MatchAssistant.Parameter.SetOptimization(this.cmbOptimization.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// 亚像素项选择值改变
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnSubpixelChanged(int selectedIndex)
        {
            if (MatchAssistant != null
              && MatchAssistant.Parameter != null)
            {
                MatchAssistant.Parameter.SetSubPixel(this.cmbSubPixel.SelectedItem.ToString());
            }
        }

        /// <summary>
        /// 擦除项选择值改变
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnEraseOptionChanged(int selectedIndex)
        {
            switch(selectedIndex)
            {
                case 0:
                    _isOnCreateSearchRegion = false;
                    _isOnCreateExtractRegion = false;
                    _isOnEraseSearchRegion = true;
                    _isOnEraseExtractRegion = false;
                    _isOnEraseModelRegion = false;
                    break;
                case 1:
                    _isOnCreateSearchRegion = false;
                    _isOnCreateExtractRegion = false;
                    _isOnEraseSearchRegion = false;
                    _isOnEraseExtractRegion = true;
                    _isOnEraseModelRegion = false;
                    break;
                case 2:
                    _isOnCreateSearchRegion = false;
                    _isOnCreateExtractRegion = false;
                    _isOnEraseSearchRegion = false;
                    _isOnEraseExtractRegion = false;
                    _isOnEraseModelRegion = true;
                    break;
                default:break;
            }
        }

        /// <summary>
        /// 模板匹配类型项选择值改变
        /// </summary>
        /// <param name="selectedIndex"></param>
        private void OnModelTypeChanged(int selectedIndex)
        {
            if (MatchAssistant != null
             && MatchAssistant.Parameter != null)
            {
                this.numUpDwnFilterAlpha.Enabled = false;
                this.numUpDwnHysteresisHigh.Enabled = false;
                this.numUpDwnHysteresisLow.Enabled = false;

                switch(selectedIndex)
                {
                    case 1:
                        MatchAssistant.ModelType = ProVision.Communal.MatchModelType.ShapeContourModel;
                        ChangeMetricItems(ProVision.Communal.MatchModelType.ShapeContourModel);
                        this.numUpDwnFilterAlpha.Enabled = true;
                        this.numUpDwnHysteresisHigh.Enabled = true;
                        this.numUpDwnHysteresisLow.Enabled = true;
                        MatchAssistant.Filter = "canny";
                        MatchAssistant.Alpha = (float)this.numUpDwnFilterAlpha.Value;
                        MatchAssistant.HysteresisLow = (int)this.numUpDwnHysteresisLow.Value;
                        MatchAssistant.HysteresisHigh = (int)this.numUpDwnHysteresisHigh.Value;

                        break;
                    case 2:
                        MatchAssistant.ModelType = ProVision.Communal.MatchModelType.NCCModel;
                        break;
                    default:
                        MatchAssistant.ModelType = ProVision.Communal.MatchModelType.ShapeRegionModel;
                        ChangeMetricItems(ProVision.Communal.MatchModelType.ShapeRegionModel);
                        break;
                }

                if ((ExtractRegion != null
                            && ExtractRegion.IsInitialized())
                            || (SearchRegion != null
                            && SearchRegion.IsInitialized()))
                {
                    //更新模板提取区域后重新提取模板信息
                    ROIMgr.IconicUpdatedDel(ProVision.InteractiveROI.ROIManager.EVENT_UPDATE_ROI);
                }
            }
        }

        /// <summary>
        /// 改变度量项--19
        /// </summary>
        /// <param name="mt"></param>
        private void ChangeMetricItems(ProVision.Communal.MatchModelType mt)
        {
            switch (mt)
            {
                case ProVision.Communal.MatchModelType.ShapeContourModel:
                    {
                        this.cmbMetric.Items.Clear();
                        this.cmbMetric.Items.Add("ignore_local_polarity");
                        this.cmbMetric.Items.Add("ignore_color_polarity");
                        this.cmbMetric.SelectedIndex = 0;
                        this.cmbMetric.Text = "ignore_local_polarity";
                    }
                    break;
                case ProVision.Communal.MatchModelType.ShapeRegionModel:
                    {
                        this.cmbMetric.Items.Clear();
                        this.cmbMetric.Items.Add("use_polarity");
                        this.cmbMetric.Items.Add("ignore_global_polarity");
                        this.cmbMetric.Items.Add("ignore_local_polarity");
                        this.cmbMetric.Items.Add("ignore_color_polarity");
                        this.cmbMetric.SelectedIndex = 0;
                        this.cmbMetric.Text = "use_polarity";
                    }
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 定时器事件--02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            bool rt;
            rt = _matchModelOpt.ExecuteStep();
            if (!rt)
            {
                this._timer.Enabled = false;
                _matchModelOpt.Stop();
                MatchAssistant.OnTimer = false;

                this.btnOptimize.Text = "开启优化";
                this.btnStatistic.Text = "开启统计";
            }
        }

    }
}
