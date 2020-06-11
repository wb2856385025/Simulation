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
    public partial class FrmCalibOnPlate : System.Windows.Forms.Form
    {
        public ProVision.Communal.Language LanguageVersion { protected set; get; }

        private ProVision.InteractiveROI.HWndCtrller _hWndCtrller;
        private ProVision.Calibration.CalibOnPlateAssistant _calAssistant;
        private int _currIdx, _currLineW;
        private double _thickNess = 0.0;
        private double _cellWidth = 0.0;
        private double _cellHeight = 0.0;
        private double _focalLength = 0.0;
        private double _motionX = 0.0;
        private double _motionY = 0.0;
        private double _motionZ = 0.0;
        private bool _locked;
        private bool _plateRegionDisp;
        private bool _markCenterDisp;
        private bool _coordSystemDisp;

        private string _plateRegionColor;
        private string _markCenterColor;
        private string _coordSystemColor;
        private string[] _chsColors, _enColors;
        private string[] _chsDrawMode, _enDrawMode;
        private string[] _chsCameraType, _enCameraType;
        private string[] _chsOperationOption, _enOperationOption;

        private System.Windows.Forms.OpenFileDialog _ofdDescriptionFile;
        private System.Windows.Forms.OpenFileDialog _ofdImage;
        private System.Windows.Forms.OpenFileDialog _ofdImportParams;
        private System.Windows.Forms.OpenFileDialog _ofdSaveParams;

        private FrmCalibOnPlate()
        {
            InitializeComponent();
        }

        public FrmCalibOnPlate(ProVision.Communal.Language lan):this()
        {
            this.Load += FrmCalibOnPlate_Load;
            this.FormClosing += FrmCalibOnPlate_FormClosing;
        }

        protected internal void FrmCalibOnPlate_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
           
        }

        protected internal void FrmCalibOnPlate_Load(object sender, EventArgs e)
        {
            InitFieldAndProperty();
            UpdateControl();
        }

        protected internal virtual void InitFieldAndProperty()
        {
            _currIdx = 0;
            _currLineW = 1;
            _locked = true;
            _chsColors = new string[] { "绿色", "红色", "蓝色", "黑色", "白色", "黄色", "品红", "蓝绿", "灰色" };
            _enColors = new string[] { "green", "red", "blue", "black", "white", "yellow", "magenta", "cyan", "gray" };

            _chsDrawMode = new string[] { "边缘", "填充" };
            _enDrawMode = new string[] { "margin", "fill" };

            _chsCameraType = new string[] {"面扫相机(除法)","面扫相机(多项式)","线扫相机" };
            _enCameraType = new string[] { "Area_Scan(division)", "Area_Scan(Polynomial)", "Line_Scan" };

            _chsOperationOption = new string[] {"所有","快速","无"};
            _enOperationOption = new string[] {"All","Quick","None" };

            _hWndCtrller = new InteractiveROI.HWndCtrller(this.hWndcDisplay);
            _hWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);
            _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_DRAWMODE, _enDrawMode[0]);
            _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, 1);
            _hWndCtrller.RegisterHwndCtrlMouseEvents();

            _calAssistant = new CalibOnPlateAssistant();
            _calAssistant.NotifyCaliObserver = new CalibOnPlateDelegate(UpdateCalibResults);

            if (_ofdDescriptionFile == null)
            {
                _ofdDescriptionFile = new System.Windows.Forms.OpenFileDialog();
                _ofdDescriptionFile.Filter = "Plate Description (*.descr)|*.descr| all files (*.*)|*.*";
                _ofdDescriptionFile.FilterIndex = 1;
                string halconPathValue = Environment.GetEnvironmentVariable(
                                    "HALCONROOT");
                _ofdDescriptionFile.InitialDirectory = halconPathValue + "\\calib";

            }

            if (_ofdImage == null)
            {
                _ofdImage = new System.Windows.Forms.OpenFileDialog();
                _ofdImage.Filter = "png (*.png)|*.png|tiff (*.tif)|*.tif|jpeg (*.jpg)| *.jpg|all files (*.*)|*.*";
                _ofdImage.FilterIndex = 4;
                _ofdImage.Multiselect = true;
                string imPathValue =
                           (string)HalconDotNet.HSystem.GetSystem("image_dir").TupleSplit(";");
                _ofdImage.InitialDirectory = imPathValue + "\\calib";
            }

            if (_ofdImportParams == null)
            {
                _ofdImportParams = new System.Windows.Forms.OpenFileDialog();
                _ofdImportParams.Filter = "camera parameters (*.cal)|*.cal|camera parameters (*.dat)|*dat| all files (*.*)|*.*";
                _ofdImportParams.FilterIndex = 3;
                // set initial directory to standard user's working directory
                _ofdImportParams.InitialDirectory =
                Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            }

            if (_ofdSaveParams == null)
            {
                _ofdSaveParams = new System.Windows.Forms.OpenFileDialog();
                _ofdSaveParams.Filter = "camera parameters (*.cal)|*.cal|camera parameters (*.dat)|*dat| all files (*.*)|*.*";
                // set initial directory to standard user's working directory
                _ofdSaveParams.InitialDirectory =
                Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            }

            _locked = false;
        }

        protected internal virtual void UpdateControl()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            bool isChs = (LanguageVersion == ProVision.Communal.Language.Chinese);
            //string str = this.Tag.ToString();
            //this.Text = isChs ? ProVision.Properties.Resources.ResourceManager.GetString("chs_" + str) : ProVision.Properties.Resources.ResourceManager.GetString("en_" + str);

            _plateRegionDisp = this.chkbPlateRegion.Checked;
            _markCenterDisp = this.chkbMarkCenters.Checked;
            _coordSystemDisp = this.chkbCoordinateSystem.Checked;

            this.cmbPlateRegionColor.SelectedIndex = 0;
            _plateRegionColor = _enColors[0];
            this.cmbMarkCenterColor.SelectedIndex = 7;
            _markCenterColor = _enColors[7];
            this.cmbCoordinateSystemColor.SelectedIndex = 5;
            _coordSystemColor = _enColors[5];

            this.cmbCameraType.SelectedIndex = 0;
            this.numUpDwnCellWidth.Value = (decimal)_calAssistant.CellWidth;
            this.numUpDwnCellWidth.Increment = 0.100m;
           
            this.numUpDwnCellHeight.Value = (decimal)_calAssistant.CellHeight;
            this.numUpDwnCellHeight.Increment = 0.100m;

            this.numUpDwnFocalLength.Value = (decimal)_calAssistant.FocalLength;
            this.numUpDwnFocalLength.Increment = 0.100m;

            this.numUpDwnThickness.Value = (decimal)_calAssistant.Thickness;
            this.numUpDwnThickness.Increment = 0.100m;

            this.txtbDescriptionFile.Text = _calAssistant.DescrpFile;
            this.numUpDwnSmoothFactor.Value = (int)_calAssistant.FilterSize;
            this.numUpDwnMarkThreshold.Value = (int)_calAssistant.MarkThresh;
            this.numUpDwnMarkMinDiameter.Value = (int)_calAssistant.MarkMinDiameter;
            this.numUpDwnInitThreshold.Value = (int)_calAssistant.StartThresh;
            this.numUpDwnThresholdDecrease.Value = (int)_calAssistant.DeltaThresh;
            this.numUpDwnMinThreshold.Value = (int)_calAssistant.MinThresh;
            this.numUpDwnSmoothFactor.Value = (int)(_calAssistant.Alpha*100);
            this.numUpDwnMarkMinContourLength.Value = (int)_calAssistant.MinContLength;
            this.numUpDwnMarkMaxDiameter.Value = (int)_calAssistant.MarkMaxDiameter;
            this.numUpDwnWarnLevel.Value = (int)_calAssistant.WarnLevel;

            this.numUpDwnMotionVx.Value = (decimal)_calAssistant.MotionVx;
            this.numUpDwnMotionVx.Increment = 0.100m;

            this.numUpDwnMotionVy.Value = (decimal)_calAssistant.MotionVy;
            this.numUpDwnMotionVy.Increment = 0.100m;
           
            this.numUpDwnMotionVz.Value = (decimal)_calAssistant.MotionVz;
            this.numUpDwnMotionVz.Increment = 0.100m;

            UpdateChekBox(this.chkbPlateRegion, LanguageVersion, null);
            UpdateChekBox(this.chkbMarkCenters, LanguageVersion, null);
            UpdateChekBox(this.chkbCoordinateSystem, LanguageVersion, null);
           

            UpdateChekBox(this.chkbTelecentric, LanguageVersion, null);
            UpdateChekBox(this.chkbOriginAtImgCorner, LanguageVersion, null);

            string[] tmpcolors = isChs ? _chsColors : _enColors;
            UpdateComboBox(this.cmbPlateRegionColor, tmpcolors);
            UpdateComboBox(this.cmbMarkCenterColor, tmpcolors);
            UpdateComboBox(this.cmbCoordinateSystemColor, tmpcolors);

            string[] tmpDrawMode = isChs ? _chsDrawMode : _enDrawMode;
            UpdateComboBox(this.cmbDrawMode, tmpDrawMode);

            string[] tmpCameraType = isChs ? _chsCameraType : _enCameraType;
            UpdateComboBox(this.cmbCameraType, tmpCameraType);

            string[] tmpOption = isChs ? _chsOperationOption : _enOperationOption;
            UpdateComboBox(this.cmbImageAccuracy, tmpOption);
            UpdateComboBox(this.cmbImageSetAccuracy, tmpOption);

            UpdateRadioButton(this.rdbtnNone, LanguageVersion, null);
            UpdateRadioButton(this.rdbtnMove, LanguageVersion, null);
            UpdateRadioButton(this.rdbtnZoom, LanguageVersion, null);
            UpdateRadioButton(this.rdbtnMagnify, LanguageVersion, null);

            UpdateRadioButton(this.rdbtnOriginalCoord, LanguageVersion, null);
            UpdateRadioButton(this.rdbtnSimulatedCoord, LanguageVersion, null);

            UpdateNumberUpDwn(this.numUpDwnLineWidth);
            UpdateNumberUpDwn(this.numUpDwnThickness);
            UpdateNumberUpDwn(this.numUpDwnCellWidth);
            UpdateNumberUpDwn(this.numUpDwnCellHeight);
            UpdateNumberUpDwn(this.numUpDwnMotionVx);
            UpdateNumberUpDwn(this.numUpDwnMotionVy);
            UpdateNumberUpDwn(this.numUpDwnMotionVz);
            UpdateNumberUpDwn(this.numUpDwnWarnLevel);           

            UpdateButton(this.btnLoadImage, LanguageVersion, null);
            UpdateButton(this.btnDeleteImage, LanguageVersion, null);
            UpdateButton(this.btnDeleteAll, LanguageVersion, null);
            UpdateButton(this.btnSetReference, LanguageVersion, null);
            UpdateButton(this.btnCalibrateCamera, LanguageVersion, null);
            UpdateButton(this.btnLoadDescriptinFile, LanguageVersion, null);
            UpdateButton(this.btnImportParameter, LanguageVersion, null);
            UpdateButton(this.btnResetParameter, LanguageVersion, null);

            UpdateNumberUpDwn(this.numUpDwnGaussFilterSize);
            UpdateNumberUpDwn(this.numUpDwnMarkThreshold);
            UpdateNumberUpDwn(this.numUpDwnMarkMinDiameter);
            UpdateNumberUpDwn(this.numUpDwnInitThreshold);
            UpdateNumberUpDwn(this.numUpDwnThresholdDecrease);
            UpdateNumberUpDwn(this.numUpDwnMinThreshold);
            UpdateNumberUpDwn(this.numUpDwnSmoothFactor);
            UpdateNumberUpDwn(this.numUpDwnMarkMinContourLength);
            UpdateNumberUpDwn(this.numUpDwnMarkMaxDiameter);

            UpdateTrackBar(this.trcbGaussFilterSize);
            UpdateTrackBar(this.trcbMarkThreshold);
            UpdateTrackBar(this.trcbMarkMinDiameter);
            UpdateTrackBar(this.trcbInitThreshold);
            UpdateTrackBar(this.trcbThresholdDecrease);
            UpdateTrackBar(this.trcbMinThreshold);
            UpdateTrackBar(this.trcbSmoothFactor);
            UpdateTrackBar(this.trcbMarkMinContourLength);
            UpdateTrackBar(this.trcbMarkMaxDiameter);

            UpdateButton(this.btnGaussFilterSize, LanguageVersion, null);
            UpdateButton(this.btnMarkThreshold, LanguageVersion, null);
            UpdateButton(this.btnMarkMinDiameter, LanguageVersion, null);
            UpdateButton(this.btnInitThreshold, LanguageVersion, null);
            UpdateButton(this.btnThresholdDecrease, LanguageVersion, null);
            UpdateButton(this.btnMinThreshold, LanguageVersion, null);
            UpdateButton(this.btnSmoothFactor, LanguageVersion, null);
            UpdateButton(this.btnMarkMinContourLength, LanguageVersion, null);
            UpdateButton(this.btnMarkMaxDiameter, LanguageVersion, null);

            UpdateButton(this.btnSaveInternalParameter, LanguageVersion, null);
            UpdateButton(this.btnSaveExternalParameter, LanguageVersion, null);

            this.tbcCalibration.SelectedIndexChanged -= TbcCalibration_SelectedIndexChanged;
            this.tbcCalibration.SelectedIndexChanged += TbcCalibration_SelectedIndexChanged;

            this.lstbImages.SelectedIndexChanged -= LstbImages_SelectedIndexChanged;
            this.lstbImages.SelectedIndexChanged += LstbImages_SelectedIndexChanged;
        }

        private void LstbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = "";
            System.Windows.Forms.ListView.SelectedListViewItemCollection items = this.lstbImages.SelectedItems;

            foreach (System.Windows.Forms.ListViewItem item in items)
            {
                path = item.SubItems[1].Text;
                if (path != "")
                {
                    //上次选择的行,颜色为背景色
                    this.lstbImages.Items[_currIdx].BackColor = System.Drawing.SystemColors.Window;

                    //获取选择的行索引
                    _currIdx = this.lstbImages.Items.IndexOf(item);
                    this.lstbImages.Items[_currIdx].BackColor = System.Drawing.SystemColors.Control;

                    ShowErrorMessage();
                    UpdateView();
                    UpdateQualityIssueTable();
                    break;
                }
            }
        }

        private void TbcCalibration_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
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
                chkb.CheckedChanged -= Chkb_CheckedChanged;
                if (resourceManager != null)
                {
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = chkb.Tag.ToString();
                    chkb.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
                chkb.CheckedChanged += Chkb_CheckedChanged;
            }
        }
        private void Chkb_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox chkb = sender as System.Windows.Forms.CheckBox;
            if(chkb!=null
                && chkb.Tag!=null)
            {
                switch(chkb.Tag.ToString())
                {
                    case "CHKB_PLATEREGION":
                        _plateRegionDisp = chkb.Checked;
                        UpdateView();
                        break;
                    case "CHKB_MARKCENTERS":
                        _markCenterDisp = chkb.Checked;
                        UpdateView();
                        break;
                    case "CHKB_COORDINATESYSTEM":
                        _coordSystemDisp = chkb.Checked;
                        UpdateView();
                        break;
                    case "CHKB_TELECENTRIC":
                        {
                            this.numUpDwnFocalLength.Enabled = !chkb.Checked;
                            if (!_locked)
                                _calAssistant.IsTelecentric = chkb.Checked;
                        }
                        break;
                    case "CHKB_ORIGINATIMGCORNER":
                        {
                            if (!_locked)
                                _calAssistant.AtImgCoord = chkb.Checked;
                            UpdateView();
                        }
                        break;
                    default:break;
                }
            }
        }

        /// <summary>
        /// 更新ComboBox控件
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="itms"></param>
        protected void UpdateComboBox(System.Windows.Forms.ComboBox cmb,string[] itms)
        {
            if (cmb != null
              && cmb.Tag != null)
            {
                cmb.SelectedIndexChanged -= Cmb_SelectedIndexChanged;
                if (itms!= null)
                {
                    cmb.Items.Clear(); //会否触发选项值改变?
                    for (int i = 0; i < itms.Length; i++)
                        cmb.Items.Add(itms[i]);                 
                }
                cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;
            }
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = sender as System.Windows.Forms.ComboBox;
            if (cmb != null
              && cmb.Tag != null)
            {
                switch(cmb.Tag.ToString())
                {
                    case "CMB_PLATEREGIONCOLOR":
                        {
                            if(cmb.SelectedIndex>-1)
                            {
                                _plateRegionColor = _enColors[cmb.SelectedIndex];
                                UpdateView();
                            }
                        }
                        break;
                    case "CMB_MARKCENTERCOLOR":
                        {
                            if (cmb.SelectedIndex > -1)
                            {
                                _markCenterColor = _enColors[cmb.SelectedIndex];
                                UpdateView();
                            }
                        }
                        break;
                    case "CMB_COORDINATESYSTEMCOLOR":
                        {
                            if (cmb.SelectedIndex > -1)
                            {
                                _coordSystemColor = _enColors[cmb.SelectedIndex];
                                UpdateView();
                            }
                        }
                        break;
                    case "CMB_DRAWMODE":
                        {
                            if (cmb.SelectedIndex > -1)
                            {
                                if (_hWndCtrller != null)
                                    _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_DRAWMODE,
                                    _enDrawMode[cmb.SelectedIndex]);
                                UpdateView();
                            }
                        }
                        break;
                    case "CMB_CAMERATYPE":
                        {
                            if (cmb.SelectedIndex > -1)
                                ChangeCameraType();
                        }
                        break;
                    case "CMB_IMAGEACCURACY":
                        {
                            if (cmb.SelectedIndex > -1)
                                if (!_locked)
                                    _calAssistant.ImageAccuracyMode = cmb.SelectedIndex;
                        }
                        break;
                    case "CMB_IMAGESETACCURACY":
                        {
                            if (cmb.SelectedIndex > -1)
                                if (!_locked)
                                    _calAssistant.ImageSetAccuracyMode = cmb.SelectedIndex;
                        }
                        break;
                    default:break;
                }
            }
        }

        /// <summary>
        /// 相机类型改变
        /// </summary>
        private void ChangeCameraType()
        {
            int val = 0;
          
            this.pLineScanPreSet.Visible = false;
            this.pKappa.Visible = false;
            this.pLineScanResult.Visible = false;
            this.pAreaScanPolynormal.Visible = false;

            switch(this.cmbCameraType.SelectedIndex)
            {
                case 0:
                    val = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_DIV;
                    this.pKappa.Visible = true;
                    this.chkbTelecentric.Enabled = true;
                    break;
                case 1:
                    val = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_POLY;
                    this.pAreaScanPolynormal.Visible = true;
                    this.chkbTelecentric.Enabled = true;
                    break;
                case 2:
                    val = ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_LINE_SCAN;
                    this.pLineScanPreSet.Visible = true;
                    this.pKappa.Visible = true;
                    this.pLineScanResult.Visible = true;
                    this.chkbTelecentric.Checked = false;
                    this.chkbTelecentric.Enabled = false;
                    break;
                default:break;
            }

            if(!_locked)
                _calAssistant.CameraType = val;
        }

        /// <summary>
        /// 更新NumberUpDown控件
        /// </summary>
        /// <param name="numUpDwn"></param>
        protected void UpdateNumberUpDwn(System.Windows.Forms.NumericUpDown numUpDwn)
        {
            if(numUpDwn!=null)
            {
                numUpDwn.ValueChanged -= NumUpDwn_ValueChanged;
                numUpDwn.ValueChanged += NumUpDwn_ValueChanged;
            }
        }

        /// <summary>
        /// 更新TrackBar控件
        /// </summary>
        /// <param name="trkb"></param>
        protected void UpdateTrackBar(System.Windows.Forms.TrackBar trkb)
        {
            if(trkb!=null)
            {
                trkb.Scroll -= Trkb_Scroll;
                trkb.Scroll += Trkb_Scroll;
            }
        }

        private void NumUpDwn_ValueChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.NumericUpDown numUpDwn = sender as System.Windows.Forms.NumericUpDown;
            if (numUpDwn != null
                && numUpDwn.Tag!=null)
            {
                switch(numUpDwn.Tag.ToString())
                {
                    case "NUMUPDWN_LINEWIDTH":
                        {
                            _currLineW = (int)numUpDwn.Value;
                            if(_hWndCtrller!=null)
                                _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _currLineW);
                            UpdateView();
                        }
                        break;
                    case "NUMUPDWN_PLATETHICKNESS":
                        {
                            _thickNess = (double)numUpDwn.Value;
                            _calAssistant.Thickness = _thickNess;
                        }
                        break;
                    case "NUMUPDWN_CELLWIDTH":
                        {
                            _cellWidth = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.CellWidth = _cellWidth;
                        }
                        break;
                    case "NUMUPDWN_CELLHEIGHT":
                        {
                            _cellHeight = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.CellHeight = _cellHeight;
                        }
                        break;
                    case "NUMUPDWN_FOCALLENGTH":
                        {
                            _focalLength = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.FocalLength = _focalLength;
                        }
                        break;
                    case "NUMUPDWN_SPEEDX":
                        {
                            _motionX = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.MotionVx = _motionX;
                        }
                        break;
                    case "NUMUPDWN_SPEEDY":
                        {
                            _motionY = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.MotionVy = _motionY;
                        }
                        break;
                    case "NUMUPDWN_SPEEDZ":
                        {
                            _motionZ = (double)numUpDwn.Value;
                            if (!_locked)
                                _calAssistant.MotionVz = _motionZ;
                        }
                        break;
                    case "NUMUPDWN_WARNLEVEL":
                        {
                            if (!_locked)
                                _calAssistant.WarnLevel = (int)numUpDwn.Value;
                        }
                        break;
                    case "NUMUPDWN_GAUSSFILTERSIZE":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbGaussFilterSize.Value = val;
                            this.btnGaussFilterSize.ForeColor= System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.FilterSize = val;
                        }
                        break;
                    case "NUMUPDWN_MARKTHRESHOLD":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbMarkThreshold.Value = val;
                            this.btnMarkThreshold.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.MarkThresh = val;
                        }
                        break;
                    case "NUMUPDWN_MARKMINDIAMETER":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbMarkMinDiameter.Value = val;
                            this.btnMarkMinDiameter.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.MarkMinDiameter = val;
                        }
                        break;
                    case "NUMUPDWN_INITTHRESHOLD":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbInitThreshold.Value = val;
                            this.btnInitThreshold.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.StartThresh = val;
                        }
                        break;
                    case "NUMUPDWN_THRESHOLDDECREASE":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbThresholdDecrease.Value = val;
                            this.btnThresholdDecrease.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.DeltaThresh = val;
                        }
                        break;
                    case "NUMUPDWN_MINTHRESHOLD":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbMinThreshold.Value = val;
                            this.btnMinThreshold.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.MinThresh = val;
                        }
                        break;
                    case "NUMUPDWN_SMOOTHFACTOR":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbSmoothFactor.Value = val;
                            this.btnSmoothFactor.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.Alpha = val;
                        }
                        break;
                    case "NUMUPDWN_MARKMINCONTOURLENGTH":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbMarkMinContourLength.Value = val;
                            this.btnMarkMinContourLength.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.MinContLength = val;
                        }
                        break;
                    case "NUMUPDWN_MARKMAXDIAMETER":
                        {
                            int val = (int)numUpDwn.Value;
                            this.trcbMarkMaxDiameter.Value = val;
                            this.btnMarkMaxDiameter.ForeColor = System.Drawing.Color.Black;

                            if (!_locked)
                                _calAssistant.MinContLength = val;
                        }
                        break;                   
                    case "":
                        break;
                    default:break;
                }
            }
        }

        private void Trkb_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar trkb = sender as System.Windows.Forms.TrackBar;
            if (trkb != null
                && trkb.Tag!=null)
            {
                switch(trkb.Tag.ToString())
                {
                    case "TRCB_GAUSSFILTERSIZE":
                        this.numUpDwnGaussFilterSize.Value = trkb.Value;
                        this.numUpDwnGaussFilterSize.Refresh();
                        break;
                    case "TRCB_MARKTHRESHOLD":
                        this.numUpDwnMarkThreshold.Value = trkb.Value;
                        this.numUpDwnMarkThreshold.Refresh();
                        break;
                    case "TRCB_MARKMINDIAMETER":
                        this.numUpDwnMarkMinDiameter.Value = trkb.Value;
                        this.numUpDwnMarkMinDiameter.Refresh();
                        break;
                    case "TRCB_INITTHRESHOLD":
                        this.numUpDwnInitThreshold.Value = trkb.Value;
                        this.numUpDwnInitThreshold.Refresh();
                        break;
                    case "TRCB_THRESHOLDDECREASE":
                        this.numUpDwnThresholdDecrease.Value = trkb.Value;
                        this.numUpDwnThresholdDecrease.Refresh();
                        break;
                    case "TRCB_MINTHRESHOLD":
                        this.numUpDwnMinThreshold.Value = trkb.Value;
                        this.numUpDwnMinThreshold.Refresh();
                        break;
                    case "TRCB_SMOOTHFACTOR":
                        this.numUpDwnSmoothFactor.Value = trkb.Value;
                        this.numUpDwnSmoothFactor.Refresh();
                        break;
                    case "TRCB_MARKMINCONTOURLENGTH":
                        this.numUpDwnMarkMinContourLength.Value = trkb.Value;
                        this.numUpDwnMarkMinContourLength.Refresh();
                        break;
                    case "TRCB_MARKMAXDIAMETER":
                        this.numUpDwnMarkMaxDiameter.Value = trkb.Value;
                        this.numUpDwnMarkMaxDiameter.Refresh();
                        break;                  
                    default:break;
                }
            }
        }


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
                rdbtn.CheckedChanged -= Rdbtn_CheckedChanged;
                if (resourceManager != null)
                {
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = rdbtn.Tag.ToString();
                    rdbtn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
                rdbtn.CheckedChanged += Rdbtn_CheckedChanged;
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
                    case "RDBTN_NONE":
                        if (rdbtn.Checked)
                        {
                            if (_hWndCtrller != null)
                            {
                                _hWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_NONE);
                                _hWndCtrller.ResetWindow();
                            }
                                                       
                            UpdateView();
                        }
                        break;
                    case "RDBTN_MOVE":
                        if (rdbtn.Checked)
                        {
                            if (_hWndCtrller != null)
                                _hWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MOVE);
                        }
                        break;
                    case "RDBTN_ZOOM":
                        if (rdbtn.Checked)
                        {
                            if (_hWndCtrller != null)
                                _hWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_ZOOM);
                        }
                        break;
                    case "RDBTN_MAGNIFY":
                        if (rdbtn.Checked)
                        {
                            if (_hWndCtrller != null)
                                _hWndCtrller.SetViewMode(ProVision.InteractiveROI.HWndCtrller.VIEW_MODE_MAGNIFY);
                        }
                        break;
                    case "RDBTN_ORIGINALCOORDINATE":
                        if (rdbtn.Checked)
                            UpdateView();
                        break;
                    case "RDBTN_SIMULATEDCOORDINATE":
                        if (rdbtn.Checked)
                            UpdateView();
                        break;
                    default: break;
                }
            }          
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
                btn.Click -= Btn_Click;
                if (resourceManager != null)
                {
                    bool isChs = lan == ProVision.Communal.Language.Chinese;
                    string str = btn.Tag.ToString();
                    btn.Text = isChs ? resourceManager.GetString("chs_" + str) : resourceManager.GetString("en_" + str);
                }
                btn.Click += Btn_Click;
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
                    case "BTN_LOADIMAGE":
                        LoadImage();
                        break;
                    case "BTN_DELETEIMAGE":
                        DeleteImage();
                        break;
                    case "BTN_DELETEALL":
                        DeleteImageAll();
                        break;
                    case "BTN_SETREFERENCE":
                        SetReferenceImage();
                        break;
                    case "BTN_CALIBRATECAMERA":
                        CalibrateCamera();
                        break;
                    case "BTN_LOADDESCRIPTIONFILE":
                        LoadDescriptionFile();
                        break;
                    case "BTN_IMPORTPARAMETER":
                        ImportParameter();
                        break;
                    case "BTN_RESETPARAMETER":
                        ResetParameter();
                        break;
                    case "BTN_GAUSSFILTERSIZE":
                        {
                            this.numUpDwnGaussFilterSize.Value = _calAssistant.ResetFilterSize;
                            btn.ForeColor= System.Drawing.Color.Gray;
                        }                      
                        break;
                    case "BTN_MARKTHRESHOLD":
                        {
                            this.numUpDwnMarkThreshold.Value = _calAssistant.ResetMarkThresh;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_MARKMINDIAMETER":
                        {
                            this.numUpDwnMarkMinDiameter.Value = _calAssistant.ResetMarkMinDiam;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_INITTHRESHOLD":
                        {
                            this.numUpDwnInitThreshold.Value = _calAssistant.ResetStartThresh;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_THRESHOLDDECREASE":
                        {
                            this.numUpDwnThresholdDecrease.Value = _calAssistant.ResetDeltaThresh;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_MINTHRESHOLD":
                        {
                            this.numUpDwnMinThreshold.Value = _calAssistant.ResetMinThresh;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_SMOOTHFACTOR":
                        {
                            this.numUpDwnSmoothFactor.Value = Convert.ToInt32(_calAssistant.ResetAlpha*100);
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_MARKMINCONTOURLENGTH":
                        {
                            this.numUpDwnMarkMinContourLength.Value = _calAssistant.ResetMinContLength;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_MARKMAXDIAMETER":
                        {
                            this.numUpDwnMarkMaxDiameter.Value = _calAssistant.ResetMarkMaxDiam;
                            btn.ForeColor = System.Drawing.Color.Gray;
                        }
                        break;
                    case "BTN_SAVEINTERNALPARAMETER":
                        {
                            string files;
                            if (_ofdSaveParams.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                files = _ofdSaveParams.FileName;

                                if (!files.EndsWith(".cal") && !files.EndsWith(".CAL"))
                                    files += ".cal";

                                if (_calAssistant.IsCalibValid)
                                    _calAssistant.SaveCameraParams(files);
                            }
                        }
                        break;
                    case "BTN_SAVEEXTERNALPARAMETER":
                        {
                            string files;
                            if (_ofdSaveParams.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                files = _ofdSaveParams.FileName;

                                if (!files.EndsWith(".dat") && !files.EndsWith(".DAT"))
                                    files += ".dat";

                                if (_calAssistant.IsCalibValid)
                                    _calAssistant.SaveCameraPose(files);
                            }
                        }
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 重置相机参数
        /// </summary>
        private void ResetParameter()
        {
            _calAssistant.ResetCameraSetup(false);
            _locked = true;
            ResetGUICameraSetup();
            _locked = false;
        }

        /// <summary>
        /// 重置界面相机参数
        /// </summary>
        private void ResetGUICameraSetup()
        {
            int camType, val;
            try
            {
                camType = _calAssistant.CameraType;
                if (camType == ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_DIV)
                    val = 0;
                else if (camType == ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_POLY)
                    val = 1;
                else if (camType == ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_LINE_SCAN)
                    val = 2;
                else
                    throw (new System.ArgumentException());

                this.cmbCameraType.SelectedIndex = val;
                this.numUpDwnCellWidth.Value = (decimal)_calAssistant.CellWidth;
                this.numUpDwnCellHeight.Value = (decimal)_calAssistant.CellHeight;
                this.numUpDwnFocalLength.Value = (decimal)_calAssistant.FocalLength;
                this.chkbTelecentric.Checked = _calAssistant.IsTelecentric;

                this.numUpDwnMotionVx.Value = (decimal)_calAssistant.MotionVx;
                this.numUpDwnMotionVy.Value = (decimal)_calAssistant.MotionVy;
                this.numUpDwnMotionVz.Value = (decimal)_calAssistant.MotionVz;
            }
            catch (System.ArgumentException) { _locked = false; }
        }     

        /// <summary>
        /// 加载图像
        /// </summary>
        private void LoadImage()
        {
            string[] files;
            System.Windows.Forms.ListViewItem item;
            int count = 0;
            CalibImage data = null;           

            if (_ofdImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = _ofdImage.FileNames;
                count = files.Length;


                for (int i = 0; i < count; i++)
                {
                    if ((data=_calAssistant.AddImage(files[i])) != null)
                    {
                        item = new System.Windows.Forms.ListViewItem("");
                        item.SubItems.Add(files[i]);
                        item.SubItems.Add(data.PlateStatus);
                        this.lstbImages.Items.AddRange(new System.Windows.Forms.ListViewItem[] { item });
                    }

                   
                }//for

                _calAssistant.UpdateImageSetQualityIssues();

                this.btnCalibrateCamera.Enabled = (_calAssistant.CanCalib && (_calAssistant.ReferenceIndex != -1));
                this.btnSetReference.Enabled = true;

                if (data != null)
                {
                    this.lstbImages.Items[_currIdx].BackColor = System.Drawing.SystemColors.Window;
                    _currIdx = this.lstbImages.Items.Count - 1;
                    UpdateCalibResults(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_MARKS_POSE);
                    UpdateCalibResults(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_QUALITY_TABLE);
                    UpdateCalibResults(ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS);
                }
            }//if
        }

        /// <summary>
        /// 删除指定图像
        /// </summary>
        private void DeleteImage()
        {
            int cIdx = -1;
            int refIdx = -1;
            string path = "";

            System.Windows.Forms.ListView.SelectedListViewItemCollection items = this.lstbImages.SelectedItems;
            _currIdx = 0;
            foreach(System.Windows.Forms.ListViewItem itm in items)
            {
                path = itm.SubItems[1].Text;
                if (path != "")
                {
                    //获取已设置的参考标定图像的索引
                    refIdx = _calAssistant.ReferenceIndex;

                    //删除的图像为设置的参考标定图像,则参考标定图像的索引复位,即为-1
                    if ((cIdx = this.lstbImages.Items.IndexOf(itm)) == refIdx)
                        refIdx = -1;
                    else if (cIdx < refIdx) //删除的图像的索引小于设置为参考标定图像的索引,则参考标定图像的索引递减;删除的图像的索引大于设置为参考标定图像的索引,参考标定图像索引不变
                        refIdx--;

                    _calAssistant.ReferenceIndex = refIdx;
                    _calAssistant.RemoveImage(cIdx);
                    this.btnCalibrateCamera.Enabled = (_calAssistant.CanCalib && (refIdx != -1));
                    this.lstbImages.Items.Remove(itm);
                    this.lstbQualityCheck.Items.Clear();
                    break;
                }//if
            }

            if (this.lstbImages.Items.Count == 0)
                this.btnSetReference.Enabled = false;
            else
                UpdateView();
        }

        /// <summary>
        /// 删除所有图像
        /// </summary>
        private void DeleteImageAll()
        {
            _calAssistant.RemoveImage();
            _hWndCtrller.ResetWindow();
            _hWndCtrller.ClearEntities();

            _currIdx = 0;
            this.lstbImages.Items.Clear();
            this.lstbQualityCheck.Items.Clear();

            this.btnSetReference.Enabled = false;
            this.btnCalibrateCamera.Enabled = false;
            _calAssistant.ReferenceIndex = -1;
            _calAssistant.CanCalib = true;

            UpdateView();
        }

        /// <summary>
        /// 设置参考位姿图像
        /// </summary>
        private void SetReferenceImage()
        {
            //获取设置参考位姿索引
            int val = _calAssistant.ReferenceIndex;
            //若已设置参考位姿索引,则将其标记符号复位为空""
            if (val > -1)
                this.lstbImages.Items[val].SubItems[0].Text = "";

            //更新参考位姿索引为当前设置的索引,并将其标记符号设置为" *"
            _calAssistant.ReferenceIndex = _currIdx;
            this.lstbImages.Items[_currIdx].SubItems[0].Text = "  *";
            this.btnCalibrateCamera.Enabled = _calAssistant.CanCalib;
        }

        /// <summary>
        /// 执行标定
        /// </summary>
        private void CalibrateCamera()
        {
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
            this.lblStatusPrompt.Text = isChs ? "标定中..." : "Calibrating ...";
            this.lblStatus.Refresh();

            _calAssistant.ApplyCalibration();
            this.tbcCalibration.SelectedTab = this.tbcCalibration.TabPages[2];
        }

        /// <summary>
        /// 加载描述文件
        /// </summary>
        private void LoadDescriptionFile()
        {
            string file;
            string[] val;
            if (_ofdDescriptionFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = _ofdDescriptionFile.FileNames[0];
                if (file.EndsWith(".descr"))
                {
                    _calAssistant.DescrpFile = file;
                    val = file.Split(new Char[] { '\\' });
                    file = val[val.Length - 1];
                    this.txtbDescriptionFile.Text = file;
                }
                else
                {
                    bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
                    string txt = isChs ? "文件格式错误,非描述文件!" : "Fileformat is wrong, it's not a description file!";
                    string caption = isChs ? "警告信息" : "Warning Message";
                    ProVision.Communal.FrmMsgBox.Show(txt, caption, ProVision.Communal.MyButtons.OK,
                        ProVision.Communal.MyIcon.Warning, isChs);
                }
            }
        }

        /// <summary>
        /// 导入相机参数文件
        /// </summary>
        private void ImportParameter()
        {
            string file;
            bool success;

            if (_ofdImportParams.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = _ofdImportParams.FileNames[0];
                if (file.EndsWith(".cal") || file.EndsWith(".dat"))
                {
                    success = _calAssistant.ImportCameraParams(file);
                    if (success)
                    {
                        _locked = true;
                        ResetGUICameraSetup();
                        _locked = false;
                    }
                }
                else
                {
                    UpdateCalibResults(ProVision.Calibration.CalibOnPlateAssistant.ERR_READING_FILE);
                }
            }
        }

        /// <summary>
        /// 显示获取标定图像基本信息时产生的异常信息
        /// </summary>
        private void ShowErrorMessage()
        {
            string message = _calAssistant.GetCalibDataAt(_currIdx).ErrorMessage;
            ShowErrorMessage(message);
        }

        /// <summary>
        /// 显示指定信息
        /// </summary>
        /// <param name="message"></param>
        private void ShowErrorMessage(string message)
        {
            if (message!=null)
            {
                int idx = message.IndexOf(":");
                string tmp;
                if (idx > 0)
                {
                    message = "Error" + message.Remove(0, idx);

                    if (message.Length > 90)
                    {
                        idx = message.LastIndexOf(" ", 80);
                        tmp = message.Substring(0, idx) + "\n          " + message.Substring(idx + 1);
                        message = tmp;
                    }
                    this.lblStatus.Text = message;
                }
                else { this.lblStatus.Text = ""; }
            }
        }

        /// <summary>
        /// This update method is invoked for all changes occurring in the 
        /// CalibrationAssistant that need to be forwarded to the GUI. The
        /// referring delegate invokes an update for changes in the model
        /// data, which leads to an update in the graphics view. Also, errors
        /// that occur during IO functions and for single calibration steps
        /// are mapped here. 
        /// 该更新方法用在标定助手内部发生变化且需要响应到界面时.
        /// 模型参数发生变化时调用引用的委托，也会更新窗体界面.
        /// 此外,在IO函数和单个标定步骤发生的错误也会被映射到这里.
        /// </summary>
        /// <param name="mode">
        /// Constant of the class CalibrationAssistant, which starts with 
        /// UPDATE_* or ERR_* and which describes an update of the model
        /// data or an HALCON error, respectively.
        /// </param>
        public void UpdateCalibResults(int mode)
        {
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
            string txt1 = string.Empty;
            string txt2 = string.Empty;
            string caption = isChs? "警告信息--[标定助手]" : "Warning Message--[CalibrationOnPlate]";

            switch(mode)
            {
                case ProVision.Calibration.CalibOnPlateAssistant.UPDATE_MARKS_POSE:
                    UpdateView();
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.UPDATE_QUALITY_TABLE:
                    UpdateQualityIssueTable();
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALTAB_STATUS:
                    UpdateImageStatus();
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.UPDATE_CALIBRATION_RESULTS:
                    txt1 = isChs ? "更新标定数据" : "Update calibration data";
                    UpdateResultTab(_calAssistant.IsCalibValid);
                    this.lblStatusPrompt.Text = txt1;
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.ERR_READING_FILE:
                    txt1 = isChs ? "读取文件时发生异常!\n" : "Problem occured while reading file!\n";
                    ProVision.Communal.FrmMsgBox.Show(txt1+_calAssistant.ErrorMessage, 
                        caption, 
                        ProVision.Communal.MyButtons.OK, 
                        ProVision.Communal.MyIcon.Warning, isChs);
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.ERR_QUALITY_ISSUES:
                    txt1 = isChs ? "标定图像品质测试时发生异常!" : "Error occured while testing for quality issues!";
                    ProVision.Communal.FrmMsgBox.Show(txt1 + _calAssistant.ErrorMessage,
                        caption,
                        ProVision.Communal.MyButtons.OK,
                        ProVision.Communal.MyIcon.Warning, isChs);
                    this.lstbQualityCheck.Items.Clear();
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.ERR_IN_CALIBRATION:
                    txt1 = isChs ? "相机标定时发生异常!\n" : "Problem occured while calibrating!\n";
                    ProVision.Communal.FrmMsgBox.Show(txt1,
                        caption,
                        ProVision.Communal.MyButtons.OK,
                        ProVision.Communal.MyIcon.Warning, isChs);
                    UpdateResultTab(_calAssistant.IsCalibValid);
                    ShowErrorMessage(_calAssistant.ErrorMessage);
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.ERR_REFINDEX_INVALID:
                    txt1 = isChs ? "发生异常: \n" : "Problem occured: \n";
                    txt2 = isChs ? "请检查位姿参考索引是否设置" : "Please check, whether your reference index is valid";
                    ProVision.Communal.FrmMsgBox.Show(txt1 + txt2,
                        caption,
                        ProVision.Communal.MyButtons.OK,
                        ProVision.Communal.MyIcon.Warning, isChs);
                    break;
                case ProVision.Calibration.CalibOnPlateAssistant.ERR_WRITE_CALIB_RESULTS:
                    txt1 = isChs ? "发生异常 !\n" : "Problem occured while ! \n";
                    ProVision.Communal.FrmMsgBox.Show(txt1 + _calAssistant.ErrorMessage,
                        caption,
                        ProVision.Communal.MyButtons.OK,
                        ProVision.Communal.MyIcon.Warning, isChs);
                    break;              
                default: break;
            }
        }

        /// <summary> 
        /// Update the graphical window, by adding all objects of either
        /// the training data set or the test data set, including the 
        /// reference world coordinate system and the calibrated world
        /// coordinate system.
        /// 通过添加训练数据对象或者测试数据对象,
        /// 包括参考世界坐标系和校正后的世界坐标系,
        /// 更新图形窗口
        /// </summary>
        public void UpdateView()
        {
            HalconDotNet.HObject img = null;
            ProVision.Calibration.CalibImage data = _calAssistant.GetCalibDataAt(_currIdx);

            if (data == null)
                _hWndCtrller.ClearEntities();
            else
            {
                if(this.tbcCalibration.SelectedIndex==2
                    && _calAssistant.IsCalibValid)
                {
                    if (this.rdbtnOriginalCoord.Checked)
                        img = _calAssistant.ReferenceImage;
                    else
                        img = _calAssistant.SimulatedImage;

                    _hWndCtrller.AddHobjEntity(img);

                    if (_coordSystemDisp
                       && _calAssistant.ReferenceWCS.IsInitialized())
                    {
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _currLineW +1);
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _coordSystemColor);
                        _hWndCtrller.AddHobjEntity(_calAssistant.ReferenceWCS);
                    }
                }
                else
                {
                    _hWndCtrller.AddHobjEntity(data.Image);
                    _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _currLineW);

                    if(_plateRegionDisp
                        &&data.CaltabRegion.IsInitialized())
                    {
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _plateRegionColor);
                        _hWndCtrller.AddHobjEntity(data.CaltabRegion);
                    }

                    if(_markCenterDisp
                        && data.MarkCenterXLD.IsInitialized())
                    {
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR,_markCenterColor);
                        _hWndCtrller.AddHobjEntity(data.MarkCenterXLD);
                    }

                    if(_coordSystemDisp
                        && data.EstimatedWorldCoordinateSystem.IsInitialized())
                    {
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_LINEWIDTH, _currLineW+1);
                        _hWndCtrller.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, _coordSystemColor);
                        _hWndCtrller.AddHobjEntity(data.EstimatedWorldCoordinateSystem);
                    }
                }
            }
            _hWndCtrller.Repaint();
        }

        /// <summary>
        /// If the quality issues are recalculated for all calibration 
        /// images, the information table depicting the quality
        /// measure for each image must be updated. 
        /// 标定图像的品质重计算后,更新描述每张图像品质信息的表.
        /// </summary>
        public void UpdateQualityIssueTable()
        {
            System.Windows.Forms.ListViewItem item;
            ProVision.Calibration.QualityIssue issue;

            int count;
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;
            string scope = isChs ? "单图" : "Image";
            string descr = "";
            System.Collections.ArrayList qList;

            qList = (_calAssistant.GetCalibDataAt(_currIdx)).QualityIssueList;
            count = qList.Count;
            this.lstbQualityCheck.Items.Clear();

            for(int i=0;i<count;i++)
            {
                issue = (ProVision.Calibration.QualityIssue)qList[i];
                item = new System.Windows.Forms.ListViewItem(scope);

                switch(issue.Issue)
                {
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_FAILURE:
                        descr = isChs?"品质评估失败": "Quality assessment failed";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_CALTAB_SIZE:
                        descr = isChs ? "标定板在图像中太小" : "Plate in image is too small";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_CONTRAST:
                        descr = isChs ? "对比度太低" : "Contrast is too low";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_EXPOSURE:
                        descr = isChs ? "标定板过曝" : "Plate is too overexposed";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_FOCUS:
                        descr = isChs ? "标定板上的标志点未对焦" : "Marks on plate are out of focus";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_IMG_HOMOGENEITY:
                        descr = isChs ? "亮度分布不均匀" : "Illumination is inhomogeneous";
                        break;
                    default:break;
                }

                item.SubItems.Add(descr);
                item.SubItems.Add(((int)(issue.Score * 100.0)) + " %");
                this.lstbQualityCheck.Items.AddRange(new System.Windows.Forms.ListViewItem[] { item });
            }

            qList = _calAssistant.ImageSetQualityList;
            count = qList.Count;
            scope = isChs ? "图集" : "ImageSet";
            for (int i = 0; i < count; i++)
            {
                issue = (ProVision.Calibration.QualityIssue)qList[i];
                item = new System.Windows.Forms.ListViewItem(scope);
                switch (issue.Issue)
                {
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_FAILURE:
                        descr = isChs ? "品质评估失败" : "Quality assessment failed";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_ALL_OVER:
                        descr = isChs ? "仅部分图像进行品质评估" : "Quality issues detected for some images";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_CALTAB_TILT:
                        descr = isChs ? "评估图像未覆盖倾斜角" : "Tilt angles are not covered by sequence";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_MARKS_DISTR:
                        descr = isChs ? "标定板图像未覆盖视野" : "Field of view is not covered by plate images";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_NUMBER:
                        descr = isChs ? "图像数量不够" : "Number of images is too low";
                        break;
                    case ProVision.Calibration.CalibOnPlateAssistant.QUALITY_ISSUE_SEQ_ERROR:
                        descr = isChs ? "部分图像标志点提取失败" : "Mark extraction failed for some images";
                        break;
                    default:
                        descr = isChs ? "未知原因" : "unknown issue";
                        break;
                }

                item.SubItems.Add(descr);
                item.SubItems.Add(((int)(issue.Score * 100.0)) + " %");
                this.lstbQualityCheck.Items.AddRange(new System.Windows.Forms.ListViewItem[] { item });
            }

        }

        /// <summary>
        /// For each change in the calibration parameter set the basic parts,
        /// like finding the calibration plate and the marks, need to be 
        /// recalculated.
        /// The success or failure for detecting each of these basic parts
        /// are described for each calibration image by one of the following 
        /// status messages:
        /// ["Plate not found", "Marks not found", 
        /// "Quality issues detected", "Ok"]
        /// 标定参数设置的每一次变化,都需要重新计算，如标定板和标志点等.
        /// 每一张标定图像中查找这些基本特征时是失败或成功,通过以下状态之一来表述:
        /// "标定板未找到","标志点未找到","品质出现提示","成功"
        /// </summary>
        public void UpdateImageStatus()
        {
            System.Windows.Forms.ListViewItem item;
            int count = this.lstbImages.Items.Count;
            for (int i = 0; i < count; i++)
            {
                item = this.lstbImages.Items[i];
                item.SubItems[2].Text = ((ProVision.Calibration.CalibImage)_calAssistant.GetCalibDataAt(i)).PlateStatus;
            }
            ShowErrorMessage();
            this.btnCalibrateCamera.Enabled = (_calAssistant.CanCalib
                && (_calAssistant.ReferenceIndex != -1));
        }

        /// <summary>Displays the calibration results</summary>
        /// <param name="CalibSuccess"> 
        /// Depicts success or failure of the calibration process
        /// </param>
        private void UpdateResultTab(bool isCalibValid)
        {
            HalconDotNet.HTuple campar, reference;
            HalconDotNet.HTuple from = new HalconDotNet.HTuple(7*_calAssistant.ReferenceIndex);
            HalconDotNet.HTuple to = new HalconDotNet.HTuple(7 * _calAssistant.ReferenceIndex+6);
            bool isChs = LanguageVersion == ProVision.Communal.Language.Chinese;

            if(isCalibValid)
            {
                int offset = 0;

                _calAssistant.GetCalibratedResult(out campar, out reference);
                this.lblStatus.Text = isChs ? "标定成功" : "Calibration successful";
                this.lblMeanError.Text = _calAssistant.ErrorMean.ToString("f5");
                this.lblFocalLength.Text = (campar[0].D * 1000.0).ToString("f4");

                if (_calAssistant.CameraType ==
                    ProVision.Calibration.CalibOnPlateAssistant.CAMERA_TYP_AREA_SCAN_POLY)
                {
                    offset = 4;
                    this.lblRadialK1.Text = campar[1].D.ToString("f2");
                    this.lblRadialK2.Text = campar[2].D.ToString("e10");
                    this.lblRadialK3.Text = campar[3].D.ToString("e10");
                    this.lblTangentialP1.Text = campar[4].D.ToString("f6");
                    this.lblTangentialP2.Text = campar[5].D.ToString("f6");
                }
                else
                {
                    this.lblKappa.Text= campar[1].D.ToString("f2");
                }

                this.lblCellWidth.Text   = (campar[2 + offset].D * 1000000.0).ToString("f3");
                this.lblCellHeight.Text = (campar[3 + offset].D * 1000000.0).ToString("f3");
                this.lblCenterCol.Text = campar[4 + offset].D.ToString("f3");
                this.lblCenterRow.Text   = campar[5 + offset].D.ToString("f3");
                this.lblImageWidth.Text = campar[6 + offset].I + "";
                this.lblImageHeight.Text = campar[7 + offset].I + "";

                if (campar.Length == 11)
                {
                    this.lblMotionVx.Text = (campar[8].D * 1000000.0).ToString("f3");
                    this.lblMotionVy.Text = (campar[9].D * 1000000.0).ToString("f3");
                    this.lblMotionVz.Text = (campar[10].D * 1000000.0).ToString("f3");
                }

                if (reference.Length >= 6)
                {
                    this.lblPoseX.Text = (reference[0].D*1000).ToString("f3");
                    this.lblPoseY.Text = (reference[1].D*1000).ToString("f3");
                    this.lblPoseZ.Text = (reference[2].D*1000).ToString("f3");
                    this.lblPoseA.Text = (reference[3].D).ToString("f3");
                    this.lblPoseB.Text = (reference[4].D).ToString("f3");
                    this.lblPoseG.Text = (reference[5].D).ToString("f3");
                }
            }
            else
            {
                this.lblStatus.Text =isChs?"标定数据无效": "No calibration data available";
                this.lblMeanError.Text = "";
                this.lblCellWidth.Text = "";
                this.lblCellHeight.Text = "";
                this.lblFocalLength.Text = "";
                this.lblKappa.Text = "";
                this.lblCenterCol.Text = "";
                this.lblCenterRow.Text = "";
                this.lblImageWidth.Text = "";
                this.lblImageHeight.Text = "";
                this.lblMotionVx.Text = "";
                this.lblMotionVy.Text = "";
                this.lblMotionVz.Text = "";
                this.lblPoseX.Text = "";
                this.lblPoseY.Text = "";
                this.lblPoseZ.Text = "";
                this.lblPoseA.Text = "";
                this.lblPoseB.Text = "";
                this.lblPoseG.Text = "";

                this.lblRadialK1.Text = "";
                this.lblRadialK2.Text = "";
                this.lblRadialK3.Text = "";

                this.lblTangentialP1.Text = "";
                this.lblTangentialP2.Text = "";

            }
        }
    }
}
