namespace ProVision.Calibration
{
    partial class FrmCalibOnPlate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tblpResultDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.hWndcDisplay = new HalconDotNet.HWindowControl();
            this.pResultOption = new System.Windows.Forms.Panel();
            this.lblStatusPrompt = new System.Windows.Forms.Label();
            this.grpbViewOption = new System.Windows.Forms.GroupBox();
            this.rdbtnMagnify = new System.Windows.Forms.RadioButton();
            this.rdbtnZoom = new System.Windows.Forms.RadioButton();
            this.rdbtnMove = new System.Windows.Forms.RadioButton();
            this.rdbtnNone = new System.Windows.Forms.RadioButton();
            this.grpbDiapalyParameter = new System.Windows.Forms.GroupBox();
            this.numUpDwnLineWidth = new System.Windows.Forms.NumericUpDown();
            this.cmbDrawMode = new System.Windows.Forms.ComboBox();
            this.lblLineWidth = new System.Windows.Forms.Label();
            this.lblDrawMode = new System.Windows.Forms.Label();
            this.cmbCoordinateSystemColor = new System.Windows.Forms.ComboBox();
            this.cmbMarkCenterColor = new System.Windows.Forms.ComboBox();
            this.cmbPlateRegionColor = new System.Windows.Forms.ComboBox();
            this.chkbCoordinateSystem = new System.Windows.Forms.CheckBox();
            this.chkbMarkCenters = new System.Windows.Forms.CheckBox();
            this.chkbPlateRegion = new System.Windows.Forms.CheckBox();
            this.tbcCalibration = new System.Windows.Forms.TabControl();
            this.tbpImageAndModel = new System.Windows.Forms.TabPage();
            this.grpbCameraSetup = new System.Windows.Forms.GroupBox();
            this.pLineScanPreSet = new System.Windows.Forms.Panel();
            this.lblMicroMeterPerPixelZ1 = new System.Windows.Forms.Label();
            this.lblSpeedX1 = new System.Windows.Forms.Label();
            this.lblSpeedY1 = new System.Windows.Forms.Label();
            this.lblSpeedZ1 = new System.Windows.Forms.Label();
            this.numUpDwnMotionVz = new System.Windows.Forms.NumericUpDown();
            this.lblMicroMeterPerPixelX1 = new System.Windows.Forms.Label();
            this.numUpDwnMotionVy = new System.Windows.Forms.NumericUpDown();
            this.lblMicroMeterPerPixelY1 = new System.Windows.Forms.Label();
            this.numUpDwnMotionVx = new System.Windows.Forms.NumericUpDown();
            this.btnResetParameter = new System.Windows.Forms.Button();
            this.btnImportParameter = new System.Windows.Forms.Button();
            this.btnLoadDescriptinFile = new System.Windows.Forms.Button();
            this.chkbTelecentric = new System.Windows.Forms.CheckBox();
            this.numUpDwnFocalLength = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnCellHeight = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnCellWidth = new System.Windows.Forms.NumericUpDown();
            this.cmbCameraType = new System.Windows.Forms.ComboBox();
            this.numUpDwnThickness = new System.Windows.Forms.NumericUpDown();
            this.txtbDescriptionFile = new System.Windows.Forms.TextBox();
            this.lblMicroMeterH = new System.Windows.Forms.Label();
            this.lblMicroMeterW = new System.Windows.Forms.Label();
            this.lblMilliMeterF = new System.Windows.Forms.Label();
            this.lblMilliMeterT = new System.Windows.Forms.Label();
            this.lblFocalLengthPrompt1 = new System.Windows.Forms.Label();
            this.lblCellHeightPrompt1 = new System.Windows.Forms.Label();
            this.lblCellWidthPrompt1 = new System.Windows.Forms.Label();
            this.lblCameraType = new System.Windows.Forms.Label();
            this.lblPlateThickness = new System.Windows.Forms.Label();
            this.lblDescriptionFile = new System.Windows.Forms.Label();
            this.btnCalibrateCamera = new System.Windows.Forms.Button();
            this.btnSetReference = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.lstbImages = new System.Windows.Forms.ListView();
            this.colRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpQualityCheck = new System.Windows.Forms.TabPage();
            this.grpbPlateExtractionParameter = new System.Windows.Forms.GroupBox();
            this.btnMarkMaxDiameter = new System.Windows.Forms.Button();
            this.btnMarkMinContourLength = new System.Windows.Forms.Button();
            this.btnSmoothFactor = new System.Windows.Forms.Button();
            this.btnMinThreshold = new System.Windows.Forms.Button();
            this.btnThresholdDecrease = new System.Windows.Forms.Button();
            this.btnInitThreshold = new System.Windows.Forms.Button();
            this.btnMarkMinDiameter = new System.Windows.Forms.Button();
            this.btnMarkThreshold = new System.Windows.Forms.Button();
            this.btnGaussFilterSize = new System.Windows.Forms.Button();
            this.trcbMarkMaxDiameter = new System.Windows.Forms.TrackBar();
            this.trcbMarkMinContourLength = new System.Windows.Forms.TrackBar();
            this.trcbSmoothFactor = new System.Windows.Forms.TrackBar();
            this.trcbMinThreshold = new System.Windows.Forms.TrackBar();
            this.trcbThresholdDecrease = new System.Windows.Forms.TrackBar();
            this.trcbInitThreshold = new System.Windows.Forms.TrackBar();
            this.trcbMarkMinDiameter = new System.Windows.Forms.TrackBar();
            this.trcbMarkThreshold = new System.Windows.Forms.TrackBar();
            this.trcbGaussFilterSize = new System.Windows.Forms.TrackBar();
            this.numUpDwnMarkMaxDiameter = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMarkMinContourLength = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnSmoothFactor = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMinThreshold = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnThresholdDecrease = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnInitThreshold = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMarkMinDiameter = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMarkThreshold = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnGaussFilterSize = new System.Windows.Forms.NumericUpDown();
            this.lblMarkMaxDiameter = new System.Windows.Forms.Label();
            this.lblMarkMinContourLength = new System.Windows.Forms.Label();
            this.lblSmoothFactor = new System.Windows.Forms.Label();
            this.lblMinThreshold = new System.Windows.Forms.Label();
            this.lblThresholdDecrease = new System.Windows.Forms.Label();
            this.lblInitThreshold = new System.Windows.Forms.Label();
            this.lblMarkMinDiameter = new System.Windows.Forms.Label();
            this.lblMarkThreshold = new System.Windows.Forms.Label();
            this.lblGaussFilterSize = new System.Windows.Forms.Label();
            this.numUpDwnWarnLevel = new System.Windows.Forms.NumericUpDown();
            this.cmbImageSetAccuracy = new System.Windows.Forms.ComboBox();
            this.cmbImageAccuracy = new System.Windows.Forms.ComboBox();
            this.lblWarnLevel = new System.Windows.Forms.Label();
            this.lblTestOption = new System.Windows.Forms.Label();
            this.lblImageOption = new System.Windows.Forms.Label();
            this.lstbQualityCheck = new System.Windows.Forms.ListView();
            this.colScope = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpResult = new System.Windows.Forms.TabPage();
            this.rdbtnSimulatedCoord = new System.Windows.Forms.RadioButton();
            this.rdbtnOriginalCoord = new System.Windows.Forms.RadioButton();
            this.grpbExternalCampara = new System.Windows.Forms.GroupBox();
            this.btnSaveExternalParameter = new System.Windows.Forms.Button();
            this.lblDegreeG = new System.Windows.Forms.Label();
            this.lblPoseG = new System.Windows.Forms.Label();
            this.lblPoseGPrompt = new System.Windows.Forms.Label();
            this.lblMilliMeterZ = new System.Windows.Forms.Label();
            this.lblDegreeB = new System.Windows.Forms.Label();
            this.lblPoseZ = new System.Windows.Forms.Label();
            this.chkbOriginAtImgCorner = new System.Windows.Forms.CheckBox();
            this.lblPoseB = new System.Windows.Forms.Label();
            this.lblPoseZPrompt = new System.Windows.Forms.Label();
            this.lblMilliMeterY = new System.Windows.Forms.Label();
            this.lblPoseBPrompt = new System.Windows.Forms.Label();
            this.lblDegreeA = new System.Windows.Forms.Label();
            this.lblPoseY = new System.Windows.Forms.Label();
            this.lblPoseA = new System.Windows.Forms.Label();
            this.lblPoseYPrompt = new System.Windows.Forms.Label();
            this.lblMilliMeterX = new System.Windows.Forms.Label();
            this.lblPoseAPrompt = new System.Windows.Forms.Label();
            this.lblPoseX = new System.Windows.Forms.Label();
            this.lblPoseXPrompt = new System.Windows.Forms.Label();
            this.grpbInternalCampara = new System.Windows.Forms.GroupBox();
            this.pKappa = new System.Windows.Forms.Panel();
            this.pLineScanResult = new System.Windows.Forms.Panel();
            this.lblMicroMeterPerPixelZ2 = new System.Windows.Forms.Label();
            this.pAreaScanPolynormal = new System.Windows.Forms.Panel();
            this.lblMeter6K3 = new System.Windows.Forms.Label();
            this.lblRadialK1Prompt = new System.Windows.Forms.Label();
            this.lblMeter2K1 = new System.Windows.Forms.Label();
            this.lblTangentialP2Prompt = new System.Windows.Forms.Label();
            this.lblRadialK3Prompt = new System.Windows.Forms.Label();
            this.lblTangentialP1Prompt = new System.Windows.Forms.Label();
            this.lblMeter4K2 = new System.Windows.Forms.Label();
            this.lblTangentialP2 = new System.Windows.Forms.Label();
            this.lblRadialK2Prompt = new System.Windows.Forms.Label();
            this.lblTangentialP1 = new System.Windows.Forms.Label();
            this.lblRadialK1 = new System.Windows.Forms.Label();
            this.lblRadialK2 = new System.Windows.Forms.Label();
            this.lblRadialK3 = new System.Windows.Forms.Label();
            this.lblMeter2P2 = new System.Windows.Forms.Label();
            this.lblMeter2P1 = new System.Windows.Forms.Label();
            this.lblSpeedX2 = new System.Windows.Forms.Label();
            this.lblSpeedY2 = new System.Windows.Forms.Label();
            this.lblSpeedZ2 = new System.Windows.Forms.Label();
            this.lblMicroMeterPerPixelX2 = new System.Windows.Forms.Label();
            this.lblMicroMeterPerPixelY2 = new System.Windows.Forms.Label();
            this.lblMotionVz = new System.Windows.Forms.Label();
            this.lblMotionVy = new System.Windows.Forms.Label();
            this.lblMotionVx = new System.Windows.Forms.Label();
            this.lblKappaPrompt = new System.Windows.Forms.Label();
            this.lblKappa = new System.Windows.Forms.Label();
            this.lblMeterKappa = new System.Windows.Forms.Label();
            this.btnSaveInternalParameter = new System.Windows.Forms.Button();
            this.lblFocalLength = new System.Windows.Forms.Label();
            this.lblImageHeight = new System.Windows.Forms.Label();
            this.lblImageWidth = new System.Windows.Forms.Label();
            this.lblCenterRow = new System.Windows.Forms.Label();
            this.lblCenterCol = new System.Windows.Forms.Label();
            this.lblMilliMeterL = new System.Windows.Forms.Label();
            this.lblPixelIH = new System.Windows.Forms.Label();
            this.lblPixelW = new System.Windows.Forms.Label();
            this.lblPixelCY = new System.Windows.Forms.Label();
            this.lblPixelCX = new System.Windows.Forms.Label();
            this.lblCellHeight = new System.Windows.Forms.Label();
            this.lblCellWidth = new System.Windows.Forms.Label();
            this.lblMicroMeterSY = new System.Windows.Forms.Label();
            this.lblMicroMeterSX = new System.Windows.Forms.Label();
            this.lblFocalLengthPrompt2 = new System.Windows.Forms.Label();
            this.lblImageHeightPrompt = new System.Windows.Forms.Label();
            this.lblImageWidthPrompt = new System.Windows.Forms.Label();
            this.lblCenterRowPrompt = new System.Windows.Forms.Label();
            this.lblCenterColPrompt = new System.Windows.Forms.Label();
            this.lblCellHeightPrompt2 = new System.Windows.Forms.Label();
            this.lblCellWidthPrompt2 = new System.Windows.Forms.Label();
            this.lblMeanError = new System.Windows.Forms.Label();
            this.lblPixelE = new System.Windows.Forms.Label();
            this.lblErrorPrompt = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblResultStatusPrompt = new System.Windows.Forms.Label();
            this.tblpRoot.SuspendLayout();
            this.tblpResultDisplay.SuspendLayout();
            this.pResultOption.SuspendLayout();
            this.grpbViewOption.SuspendLayout();
            this.grpbDiapalyParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnLineWidth)).BeginInit();
            this.tbcCalibration.SuspendLayout();
            this.tbpImageAndModel.SuspendLayout();
            this.grpbCameraSetup.SuspendLayout();
            this.pLineScanPreSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnFocalLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnCellHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnCellWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnThickness)).BeginInit();
            this.tbpQualityCheck.SuspendLayout();
            this.grpbPlateExtractionParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMaxDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMinContourLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbSmoothFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbThresholdDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbInitThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMinDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbGaussFilterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMaxDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMinContourLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnSmoothFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnThresholdDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnInitThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMinDiameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGaussFilterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnWarnLevel)).BeginInit();
            this.tbpResult.SuspendLayout();
            this.grpbExternalCampara.SuspendLayout();
            this.grpbInternalCampara.SuspendLayout();
            this.pKappa.SuspendLayout();
            this.pLineScanResult.SuspendLayout();
            this.pAreaScanPolynormal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpRoot
            // 
            this.tblpRoot.ColumnCount = 2;
            this.tblpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.81301F));
            this.tblpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.18699F));
            this.tblpRoot.Controls.Add(this.tblpResultDisplay, 0, 0);
            this.tblpRoot.Controls.Add(this.tbcCalibration, 1, 0);
            this.tblpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpRoot.Location = new System.Drawing.Point(0, 0);
            this.tblpRoot.Margin = new System.Windows.Forms.Padding(2);
            this.tblpRoot.Name = "tblpRoot";
            this.tblpRoot.RowCount = 1;
            this.tblpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpRoot.Size = new System.Drawing.Size(945, 630);
            this.tblpRoot.TabIndex = 0;
            // 
            // tblpResultDisplay
            // 
            this.tblpResultDisplay.ColumnCount = 1;
            this.tblpResultDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpResultDisplay.Controls.Add(this.hWndcDisplay, 0, 0);
            this.tblpResultDisplay.Controls.Add(this.pResultOption, 0, 1);
            this.tblpResultDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpResultDisplay.Location = new System.Drawing.Point(2, 2);
            this.tblpResultDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.tblpResultDisplay.Name = "tblpResultDisplay";
            this.tblpResultDisplay.RowCount = 2;
            this.tblpResultDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.19829F));
            this.tblpResultDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.80171F));
            this.tblpResultDisplay.Size = new System.Drawing.Size(476, 626);
            this.tblpResultDisplay.TabIndex = 0;
            // 
            // hWndcDisplay
            // 
            this.hWndcDisplay.BackColor = System.Drawing.Color.Black;
            this.hWndcDisplay.BorderColor = System.Drawing.Color.Black;
            this.hWndcDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndcDisplay.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndcDisplay.Location = new System.Drawing.Point(2, 2);
            this.hWndcDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.hWndcDisplay.Name = "hWndcDisplay";
            this.hWndcDisplay.Size = new System.Drawing.Size(472, 379);
            this.hWndcDisplay.TabIndex = 0;
            this.hWndcDisplay.WindowSize = new System.Drawing.Size(472, 379);
            // 
            // pResultOption
            // 
            this.pResultOption.Controls.Add(this.lblStatusPrompt);
            this.pResultOption.Controls.Add(this.grpbViewOption);
            this.pResultOption.Controls.Add(this.grpbDiapalyParameter);
            this.pResultOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pResultOption.Location = new System.Drawing.Point(2, 385);
            this.pResultOption.Margin = new System.Windows.Forms.Padding(2);
            this.pResultOption.Name = "pResultOption";
            this.pResultOption.Size = new System.Drawing.Size(472, 239);
            this.pResultOption.TabIndex = 1;
            // 
            // lblStatusPrompt
            // 
            this.lblStatusPrompt.Location = new System.Drawing.Point(0, 214);
            this.lblStatusPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusPrompt.Name = "lblStatusPrompt";
            this.lblStatusPrompt.Size = new System.Drawing.Size(471, 25);
            this.lblStatusPrompt.TabIndex = 2;
            this.lblStatusPrompt.Text = "状态提示";
            this.lblStatusPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpbViewOption
            // 
            this.grpbViewOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbViewOption.Controls.Add(this.rdbtnMagnify);
            this.grpbViewOption.Controls.Add(this.rdbtnZoom);
            this.grpbViewOption.Controls.Add(this.rdbtnMove);
            this.grpbViewOption.Controls.Add(this.rdbtnNone);
            this.grpbViewOption.Location = new System.Drawing.Point(323, 2);
            this.grpbViewOption.Margin = new System.Windows.Forms.Padding(2);
            this.grpbViewOption.Name = "grpbViewOption";
            this.grpbViewOption.Padding = new System.Windows.Forms.Padding(2);
            this.grpbViewOption.Size = new System.Drawing.Size(146, 193);
            this.grpbViewOption.TabIndex = 1;
            this.grpbViewOption.TabStop = false;
            this.grpbViewOption.Tag = "GRPB_VIEWOPTION";
            this.grpbViewOption.Text = "视图选项";
            // 
            // rdbtnMagnify
            // 
            this.rdbtnMagnify.AutoSize = true;
            this.rdbtnMagnify.Location = new System.Drawing.Point(32, 154);
            this.rdbtnMagnify.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnMagnify.Name = "rdbtnMagnify";
            this.rdbtnMagnify.Size = new System.Drawing.Size(71, 16);
            this.rdbtnMagnify.TabIndex = 0;
            this.rdbtnMagnify.Tag = "RDBTN_MAGNIFY";
            this.rdbtnMagnify.Text = "局部放大";
            this.rdbtnMagnify.UseVisualStyleBackColor = true;
            // 
            // rdbtnZoom
            // 
            this.rdbtnZoom.AutoSize = true;
            this.rdbtnZoom.Location = new System.Drawing.Point(32, 113);
            this.rdbtnZoom.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnZoom.Name = "rdbtnZoom";
            this.rdbtnZoom.Size = new System.Drawing.Size(71, 16);
            this.rdbtnZoom.TabIndex = 0;
            this.rdbtnZoom.Tag = "RDBTN_ZOOM";
            this.rdbtnZoom.Text = "缩放图形";
            this.rdbtnZoom.UseVisualStyleBackColor = true;
            // 
            // rdbtnMove
            // 
            this.rdbtnMove.AutoSize = true;
            this.rdbtnMove.Location = new System.Drawing.Point(32, 71);
            this.rdbtnMove.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnMove.Name = "rdbtnMove";
            this.rdbtnMove.Size = new System.Drawing.Size(71, 16);
            this.rdbtnMove.TabIndex = 0;
            this.rdbtnMove.Tag = "RDBTN_MOVE";
            this.rdbtnMove.Text = "移动图形";
            this.rdbtnMove.UseVisualStyleBackColor = true;
            // 
            // rdbtnNone
            // 
            this.rdbtnNone.AutoSize = true;
            this.rdbtnNone.Checked = true;
            this.rdbtnNone.Location = new System.Drawing.Point(32, 30);
            this.rdbtnNone.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnNone.Name = "rdbtnNone";
            this.rdbtnNone.Size = new System.Drawing.Size(71, 16);
            this.rdbtnNone.TabIndex = 0;
            this.rdbtnNone.TabStop = true;
            this.rdbtnNone.Tag = "RDBTN_NONE";
            this.rdbtnNone.Text = "恢复初态";
            this.rdbtnNone.UseVisualStyleBackColor = true;
            // 
            // grpbDiapalyParameter
            // 
            this.grpbDiapalyParameter.Controls.Add(this.numUpDwnLineWidth);
            this.grpbDiapalyParameter.Controls.Add(this.cmbDrawMode);
            this.grpbDiapalyParameter.Controls.Add(this.lblLineWidth);
            this.grpbDiapalyParameter.Controls.Add(this.lblDrawMode);
            this.grpbDiapalyParameter.Controls.Add(this.cmbCoordinateSystemColor);
            this.grpbDiapalyParameter.Controls.Add(this.cmbMarkCenterColor);
            this.grpbDiapalyParameter.Controls.Add(this.cmbPlateRegionColor);
            this.grpbDiapalyParameter.Controls.Add(this.chkbCoordinateSystem);
            this.grpbDiapalyParameter.Controls.Add(this.chkbMarkCenters);
            this.grpbDiapalyParameter.Controls.Add(this.chkbPlateRegion);
            this.grpbDiapalyParameter.Location = new System.Drawing.Point(4, 2);
            this.grpbDiapalyParameter.Margin = new System.Windows.Forms.Padding(2);
            this.grpbDiapalyParameter.Name = "grpbDiapalyParameter";
            this.grpbDiapalyParameter.Padding = new System.Windows.Forms.Padding(2);
            this.grpbDiapalyParameter.Size = new System.Drawing.Size(300, 193);
            this.grpbDiapalyParameter.TabIndex = 0;
            this.grpbDiapalyParameter.TabStop = false;
            this.grpbDiapalyParameter.Tag = "GRPB_DISPLAYPARAMETER";
            this.grpbDiapalyParameter.Text = "显示参数";
            // 
            // numUpDwnLineWidth
            // 
            this.numUpDwnLineWidth.Location = new System.Drawing.Point(158, 157);
            this.numUpDwnLineWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnLineWidth.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDwnLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnLineWidth.Name = "numUpDwnLineWidth";
            this.numUpDwnLineWidth.Size = new System.Drawing.Size(109, 21);
            this.numUpDwnLineWidth.TabIndex = 4;
            this.numUpDwnLineWidth.Tag = "NUMUPDWN_LINEWIDTH";
            this.numUpDwnLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbDrawMode
            // 
            this.cmbDrawMode.FormattingEnabled = true;
            this.cmbDrawMode.Items.AddRange(new object[] {
            "边缘",
            "填充"});
            this.cmbDrawMode.Location = new System.Drawing.Point(158, 126);
            this.cmbDrawMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDrawMode.Name = "cmbDrawMode";
            this.cmbDrawMode.Size = new System.Drawing.Size(110, 20);
            this.cmbDrawMode.TabIndex = 3;
            this.cmbDrawMode.Tag = "CMB_DRAWMODE";
            this.cmbDrawMode.Text = "边缘";
            // 
            // lblLineWidth
            // 
            this.lblLineWidth.AutoSize = true;
            this.lblLineWidth.Location = new System.Drawing.Point(10, 158);
            this.lblLineWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLineWidth.Name = "lblLineWidth";
            this.lblLineWidth.Size = new System.Drawing.Size(41, 12);
            this.lblLineWidth.TabIndex = 2;
            this.lblLineWidth.Tag = "LBL_LINEWIDTH";
            this.lblLineWidth.Text = "线宽度";
            // 
            // lblDrawMode
            // 
            this.lblDrawMode.AutoSize = true;
            this.lblDrawMode.Location = new System.Drawing.Point(10, 130);
            this.lblDrawMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDrawMode.Name = "lblDrawMode";
            this.lblDrawMode.Size = new System.Drawing.Size(41, 12);
            this.lblDrawMode.TabIndex = 2;
            this.lblDrawMode.Tag = "LBL_DRAWMODE";
            this.lblDrawMode.Text = "画模式";
            // 
            // cmbCoordinateSystemColor
            // 
            this.cmbCoordinateSystemColor.FormattingEnabled = true;
            this.cmbCoordinateSystemColor.Items.AddRange(new object[] {
            "绿色",
            "红色",
            "蓝色",
            "黑色",
            "白色",
            "黄色",
            "品红",
            "蓝绿",
            "灰色"});
            this.cmbCoordinateSystemColor.Location = new System.Drawing.Point(158, 95);
            this.cmbCoordinateSystemColor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCoordinateSystemColor.Name = "cmbCoordinateSystemColor";
            this.cmbCoordinateSystemColor.Size = new System.Drawing.Size(110, 20);
            this.cmbCoordinateSystemColor.TabIndex = 1;
            this.cmbCoordinateSystemColor.Tag = "CMB_COORDINATESYSTEMCOLOR";
            this.cmbCoordinateSystemColor.Text = "黄色";
            // 
            // cmbMarkCenterColor
            // 
            this.cmbMarkCenterColor.FormattingEnabled = true;
            this.cmbMarkCenterColor.Items.AddRange(new object[] {
            "绿色",
            "红色",
            "蓝色",
            "黑色",
            "白色",
            "黄色",
            "品红",
            "蓝绿",
            "灰色"});
            this.cmbMarkCenterColor.Location = new System.Drawing.Point(158, 59);
            this.cmbMarkCenterColor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMarkCenterColor.Name = "cmbMarkCenterColor";
            this.cmbMarkCenterColor.Size = new System.Drawing.Size(110, 20);
            this.cmbMarkCenterColor.TabIndex = 1;
            this.cmbMarkCenterColor.Tag = "CMB_MARKCENTERCOLOR";
            this.cmbMarkCenterColor.Text = "蓝绿";
            // 
            // cmbPlateRegionColor
            // 
            this.cmbPlateRegionColor.FormattingEnabled = true;
            this.cmbPlateRegionColor.Items.AddRange(new object[] {
            "绿色",
            "红色",
            "蓝色",
            "黑色",
            "白色",
            "黄色",
            "品红",
            "蓝绿",
            "灰色"});
            this.cmbPlateRegionColor.Location = new System.Drawing.Point(158, 26);
            this.cmbPlateRegionColor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPlateRegionColor.Name = "cmbPlateRegionColor";
            this.cmbPlateRegionColor.Size = new System.Drawing.Size(110, 20);
            this.cmbPlateRegionColor.TabIndex = 1;
            this.cmbPlateRegionColor.Tag = "CMB_PLATEREGIONCOLOR";
            this.cmbPlateRegionColor.Text = "绿色";
            // 
            // chkbCoordinateSystem
            // 
            this.chkbCoordinateSystem.AutoSize = true;
            this.chkbCoordinateSystem.Checked = true;
            this.chkbCoordinateSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbCoordinateSystem.Location = new System.Drawing.Point(10, 98);
            this.chkbCoordinateSystem.Margin = new System.Windows.Forms.Padding(2);
            this.chkbCoordinateSystem.Name = "chkbCoordinateSystem";
            this.chkbCoordinateSystem.Size = new System.Drawing.Size(60, 16);
            this.chkbCoordinateSystem.TabIndex = 0;
            this.chkbCoordinateSystem.Tag = "CHKB_COORDINATESYSTEM";
            this.chkbCoordinateSystem.Text = "坐标系";
            this.chkbCoordinateSystem.UseVisualStyleBackColor = true;
            // 
            // chkbMarkCenters
            // 
            this.chkbMarkCenters.AutoSize = true;
            this.chkbMarkCenters.Checked = true;
            this.chkbMarkCenters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbMarkCenters.Location = new System.Drawing.Point(10, 62);
            this.chkbMarkCenters.Margin = new System.Windows.Forms.Padding(2);
            this.chkbMarkCenters.Name = "chkbMarkCenters";
            this.chkbMarkCenters.Size = new System.Drawing.Size(84, 16);
            this.chkbMarkCenters.TabIndex = 0;
            this.chkbMarkCenters.Tag = "CHKB_MARKCENTERS";
            this.chkbMarkCenters.Text = "标志点中心";
            this.chkbMarkCenters.UseVisualStyleBackColor = true;
            // 
            // chkbPlateRegion
            // 
            this.chkbPlateRegion.AutoSize = true;
            this.chkbPlateRegion.Checked = true;
            this.chkbPlateRegion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbPlateRegion.Location = new System.Drawing.Point(10, 26);
            this.chkbPlateRegion.Margin = new System.Windows.Forms.Padding(2);
            this.chkbPlateRegion.Name = "chkbPlateRegion";
            this.chkbPlateRegion.Size = new System.Drawing.Size(84, 16);
            this.chkbPlateRegion.TabIndex = 0;
            this.chkbPlateRegion.Tag = "CHKB_PLATEREGION";
            this.chkbPlateRegion.Text = "标定板区域";
            this.chkbPlateRegion.UseVisualStyleBackColor = true;
            // 
            // tbcCalibration
            // 
            this.tbcCalibration.Controls.Add(this.tbpImageAndModel);
            this.tbcCalibration.Controls.Add(this.tbpQualityCheck);
            this.tbcCalibration.Controls.Add(this.tbpResult);
            this.tbcCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCalibration.Location = new System.Drawing.Point(482, 2);
            this.tbcCalibration.Margin = new System.Windows.Forms.Padding(2);
            this.tbcCalibration.Name = "tbcCalibration";
            this.tbcCalibration.SelectedIndex = 0;
            this.tbcCalibration.Size = new System.Drawing.Size(461, 626);
            this.tbcCalibration.TabIndex = 1;
            // 
            // tbpImageAndModel
            // 
            this.tbpImageAndModel.Controls.Add(this.grpbCameraSetup);
            this.tbpImageAndModel.Controls.Add(this.btnCalibrateCamera);
            this.tbpImageAndModel.Controls.Add(this.btnSetReference);
            this.tbpImageAndModel.Controls.Add(this.btnDeleteAll);
            this.tbpImageAndModel.Controls.Add(this.btnDeleteImage);
            this.tbpImageAndModel.Controls.Add(this.btnLoadImage);
            this.tbpImageAndModel.Controls.Add(this.lstbImages);
            this.tbpImageAndModel.Location = new System.Drawing.Point(4, 22);
            this.tbpImageAndModel.Margin = new System.Windows.Forms.Padding(2);
            this.tbpImageAndModel.Name = "tbpImageAndModel";
            this.tbpImageAndModel.Padding = new System.Windows.Forms.Padding(2);
            this.tbpImageAndModel.Size = new System.Drawing.Size(453, 600);
            this.tbpImageAndModel.TabIndex = 0;
            this.tbpImageAndModel.Tag = "TBP_IMAGEANDMODEL";
            this.tbpImageAndModel.Text = "图像与模型";
            this.tbpImageAndModel.UseVisualStyleBackColor = true;
            // 
            // grpbCameraSetup
            // 
            this.grpbCameraSetup.Controls.Add(this.pLineScanPreSet);
            this.grpbCameraSetup.Controls.Add(this.btnResetParameter);
            this.grpbCameraSetup.Controls.Add(this.btnImportParameter);
            this.grpbCameraSetup.Controls.Add(this.btnLoadDescriptinFile);
            this.grpbCameraSetup.Controls.Add(this.chkbTelecentric);
            this.grpbCameraSetup.Controls.Add(this.numUpDwnFocalLength);
            this.grpbCameraSetup.Controls.Add(this.numUpDwnCellHeight);
            this.grpbCameraSetup.Controls.Add(this.numUpDwnCellWidth);
            this.grpbCameraSetup.Controls.Add(this.cmbCameraType);
            this.grpbCameraSetup.Controls.Add(this.numUpDwnThickness);
            this.grpbCameraSetup.Controls.Add(this.txtbDescriptionFile);
            this.grpbCameraSetup.Controls.Add(this.lblMicroMeterH);
            this.grpbCameraSetup.Controls.Add(this.lblMicroMeterW);
            this.grpbCameraSetup.Controls.Add(this.lblMilliMeterF);
            this.grpbCameraSetup.Controls.Add(this.lblMilliMeterT);
            this.grpbCameraSetup.Controls.Add(this.lblFocalLengthPrompt1);
            this.grpbCameraSetup.Controls.Add(this.lblCellHeightPrompt1);
            this.grpbCameraSetup.Controls.Add(this.lblCellWidthPrompt1);
            this.grpbCameraSetup.Controls.Add(this.lblCameraType);
            this.grpbCameraSetup.Controls.Add(this.lblPlateThickness);
            this.grpbCameraSetup.Controls.Add(this.lblDescriptionFile);
            this.grpbCameraSetup.Location = new System.Drawing.Point(4, 263);
            this.grpbCameraSetup.Margin = new System.Windows.Forms.Padding(2);
            this.grpbCameraSetup.Name = "grpbCameraSetup";
            this.grpbCameraSetup.Padding = new System.Windows.Forms.Padding(2);
            this.grpbCameraSetup.Size = new System.Drawing.Size(435, 295);
            this.grpbCameraSetup.TabIndex = 2;
            this.grpbCameraSetup.TabStop = false;
            this.grpbCameraSetup.Tag = "GRPB_CAMERASETUP";
            this.grpbCameraSetup.Text = "相机模型";
            // 
            // pLineScanPreSet
            // 
            this.pLineScanPreSet.Controls.Add(this.lblMicroMeterPerPixelZ1);
            this.pLineScanPreSet.Controls.Add(this.lblSpeedX1);
            this.pLineScanPreSet.Controls.Add(this.lblSpeedY1);
            this.pLineScanPreSet.Controls.Add(this.lblSpeedZ1);
            this.pLineScanPreSet.Controls.Add(this.numUpDwnMotionVz);
            this.pLineScanPreSet.Controls.Add(this.lblMicroMeterPerPixelX1);
            this.pLineScanPreSet.Controls.Add(this.numUpDwnMotionVy);
            this.pLineScanPreSet.Controls.Add(this.lblMicroMeterPerPixelY1);
            this.pLineScanPreSet.Controls.Add(this.numUpDwnMotionVx);
            this.pLineScanPreSet.Location = new System.Drawing.Point(4, 196);
            this.pLineScanPreSet.Margin = new System.Windows.Forms.Padding(2);
            this.pLineScanPreSet.Name = "pLineScanPreSet";
            this.pLineScanPreSet.Size = new System.Drawing.Size(343, 94);
            this.pLineScanPreSet.TabIndex = 3;
            // 
            // lblMicroMeterPerPixelZ1
            // 
            this.lblMicroMeterPerPixelZ1.Location = new System.Drawing.Point(273, 59);
            this.lblMicroMeterPerPixelZ1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelZ1.Name = "lblMicroMeterPerPixelZ1";
            this.lblMicroMeterPerPixelZ1.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelZ1.TabIndex = 0;
            this.lblMicroMeterPerPixelZ1.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelZ1.Text = "微米/像素";
            this.lblMicroMeterPerPixelZ1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeedX1
            // 
            this.lblSpeedX1.Location = new System.Drawing.Point(11, 6);
            this.lblSpeedX1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedX1.Name = "lblSpeedX1";
            this.lblSpeedX1.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedX1.TabIndex = 0;
            this.lblSpeedX1.Tag = "LBL_SPEEDX";
            this.lblSpeedX1.Text = "X方向速度(Vx)";
            // 
            // lblSpeedY1
            // 
            this.lblSpeedY1.Location = new System.Drawing.Point(11, 34);
            this.lblSpeedY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedY1.Name = "lblSpeedY1";
            this.lblSpeedY1.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedY1.TabIndex = 0;
            this.lblSpeedY1.Tag = "LBL_SPEEDY";
            this.lblSpeedY1.Text = "Y方向速度(Vy)";
            // 
            // lblSpeedZ1
            // 
            this.lblSpeedZ1.Location = new System.Drawing.Point(11, 62);
            this.lblSpeedZ1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedZ1.Name = "lblSpeedZ1";
            this.lblSpeedZ1.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedZ1.TabIndex = 0;
            this.lblSpeedZ1.Tag = "LBL_SPEEDZ";
            this.lblSpeedZ1.Text = "Z方向速度(Vz)";
            // 
            // numUpDwnMotionVz
            // 
            this.numUpDwnMotionVz.Location = new System.Drawing.Point(103, 61);
            this.numUpDwnMotionVz.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMotionVz.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDwnMotionVz.Name = "numUpDwnMotionVz";
            this.numUpDwnMotionVz.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnMotionVz.TabIndex = 4;
            this.numUpDwnMotionVz.Tag = "NUMUPDWN_SPEEDZ";
            // 
            // lblMicroMeterPerPixelX1
            // 
            this.lblMicroMeterPerPixelX1.Location = new System.Drawing.Point(273, 7);
            this.lblMicroMeterPerPixelX1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelX1.Name = "lblMicroMeterPerPixelX1";
            this.lblMicroMeterPerPixelX1.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelX1.TabIndex = 0;
            this.lblMicroMeterPerPixelX1.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelX1.Text = "微米/像素";
            this.lblMicroMeterPerPixelX1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numUpDwnMotionVy
            // 
            this.numUpDwnMotionVy.Location = new System.Drawing.Point(103, 33);
            this.numUpDwnMotionVy.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMotionVy.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDwnMotionVy.Name = "numUpDwnMotionVy";
            this.numUpDwnMotionVy.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnMotionVy.TabIndex = 4;
            this.numUpDwnMotionVy.Tag = "NUMUPDWN_SPEEDY";
            // 
            // lblMicroMeterPerPixelY1
            // 
            this.lblMicroMeterPerPixelY1.Location = new System.Drawing.Point(273, 34);
            this.lblMicroMeterPerPixelY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelY1.Name = "lblMicroMeterPerPixelY1";
            this.lblMicroMeterPerPixelY1.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelY1.TabIndex = 0;
            this.lblMicroMeterPerPixelY1.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelY1.Text = "微米/像素";
            this.lblMicroMeterPerPixelY1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numUpDwnMotionVx
            // 
            this.numUpDwnMotionVx.Location = new System.Drawing.Point(104, 5);
            this.numUpDwnMotionVx.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMotionVx.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDwnMotionVx.Name = "numUpDwnMotionVx";
            this.numUpDwnMotionVx.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnMotionVx.TabIndex = 4;
            this.numUpDwnMotionVx.Tag = "NUMUPDWN_SPEEDX";
            // 
            // btnResetParameter
            // 
            this.btnResetParameter.Location = new System.Drawing.Point(347, 252);
            this.btnResetParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetParameter.Name = "btnResetParameter";
            this.btnResetParameter.Size = new System.Drawing.Size(78, 28);
            this.btnResetParameter.TabIndex = 6;
            this.btnResetParameter.Tag = "BTN_RESETPARAMETER";
            this.btnResetParameter.Text = "重置参数";
            this.btnResetParameter.UseVisualStyleBackColor = true;
            // 
            // btnImportParameter
            // 
            this.btnImportParameter.Location = new System.Drawing.Point(347, 78);
            this.btnImportParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportParameter.Name = "btnImportParameter";
            this.btnImportParameter.Size = new System.Drawing.Size(78, 28);
            this.btnImportParameter.TabIndex = 6;
            this.btnImportParameter.Tag = "BTN_IMPORTPARAMETER";
            this.btnImportParameter.Text = "导入参数";
            this.btnImportParameter.UseVisualStyleBackColor = true;
            // 
            // btnLoadDescriptinFile
            // 
            this.btnLoadDescriptinFile.Location = new System.Drawing.Point(347, 20);
            this.btnLoadDescriptinFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadDescriptinFile.Name = "btnLoadDescriptinFile";
            this.btnLoadDescriptinFile.Size = new System.Drawing.Size(78, 28);
            this.btnLoadDescriptinFile.TabIndex = 6;
            this.btnLoadDescriptinFile.Tag = "BTN_LOADDESCRIPTIONFILE";
            this.btnLoadDescriptinFile.Text = "加载文件";
            this.btnLoadDescriptinFile.UseVisualStyleBackColor = true;
            // 
            // chkbTelecentric
            // 
            this.chkbTelecentric.AutoSize = true;
            this.chkbTelecentric.Location = new System.Drawing.Point(345, 172);
            this.chkbTelecentric.Margin = new System.Windows.Forms.Padding(2);
            this.chkbTelecentric.Name = "chkbTelecentric";
            this.chkbTelecentric.Size = new System.Drawing.Size(48, 16);
            this.chkbTelecentric.TabIndex = 5;
            this.chkbTelecentric.Tag = "CHKB_TELECENTRIC";
            this.chkbTelecentric.Text = "远心";
            this.chkbTelecentric.UseVisualStyleBackColor = true;
            // 
            // numUpDwnFocalLength
            // 
            this.numUpDwnFocalLength.Location = new System.Drawing.Point(113, 171);
            this.numUpDwnFocalLength.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnFocalLength.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numUpDwnFocalLength.Name = "numUpDwnFocalLength";
            this.numUpDwnFocalLength.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnFocalLength.TabIndex = 4;
            this.numUpDwnFocalLength.Tag = "NUMUPDWN_FOCALLENGTH";
            // 
            // numUpDwnCellHeight
            // 
            this.numUpDwnCellHeight.Location = new System.Drawing.Point(113, 146);
            this.numUpDwnCellHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnCellHeight.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numUpDwnCellHeight.Name = "numUpDwnCellHeight";
            this.numUpDwnCellHeight.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnCellHeight.TabIndex = 4;
            this.numUpDwnCellHeight.Tag = "NUMUPDWN_CELLHEIGHT";
            // 
            // numUpDwnCellWidth
            // 
            this.numUpDwnCellWidth.Location = new System.Drawing.Point(113, 113);
            this.numUpDwnCellWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnCellWidth.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numUpDwnCellWidth.Name = "numUpDwnCellWidth";
            this.numUpDwnCellWidth.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnCellWidth.TabIndex = 4;
            this.numUpDwnCellWidth.Tag = "NUMUPDWN_CELLWIDTH";
            // 
            // cmbCameraType
            // 
            this.cmbCameraType.FormattingEnabled = true;
            this.cmbCameraType.Items.AddRange(new object[] {
            "面扫相机(除法)",
            "面扫相机(多项式)",
            "线扫相机"});
            this.cmbCameraType.Location = new System.Drawing.Point(113, 90);
            this.cmbCameraType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCameraType.Name = "cmbCameraType";
            this.cmbCameraType.Size = new System.Drawing.Size(165, 20);
            this.cmbCameraType.TabIndex = 3;
            this.cmbCameraType.Tag = "CMB_CAMERATYPE";
            this.cmbCameraType.Text = "面扫相机(除法)";
            // 
            // numUpDwnThickness
            // 
            this.numUpDwnThickness.DecimalPlaces = 3;
            this.numUpDwnThickness.Location = new System.Drawing.Point(113, 54);
            this.numUpDwnThickness.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnThickness.Name = "numUpDwnThickness";
            this.numUpDwnThickness.Size = new System.Drawing.Size(164, 21);
            this.numUpDwnThickness.TabIndex = 2;
            this.numUpDwnThickness.Tag = "NUMUPDWN_PLATETHICKNESS";
            // 
            // txtbDescriptionFile
            // 
            this.txtbDescriptionFile.Location = new System.Drawing.Point(113, 26);
            this.txtbDescriptionFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtbDescriptionFile.Name = "txtbDescriptionFile";
            this.txtbDescriptionFile.ReadOnly = true;
            this.txtbDescriptionFile.Size = new System.Drawing.Size(165, 21);
            this.txtbDescriptionFile.TabIndex = 1;
            this.txtbDescriptionFile.Text = ".descr";
            // 
            // lblMicroMeterH
            // 
            this.lblMicroMeterH.Location = new System.Drawing.Point(286, 145);
            this.lblMicroMeterH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterH.Name = "lblMicroMeterH";
            this.lblMicroMeterH.Size = new System.Drawing.Size(40, 18);
            this.lblMicroMeterH.TabIndex = 0;
            this.lblMicroMeterH.Tag = "LBL_MICROMETER";
            this.lblMicroMeterH.Text = "微米";
            this.lblMicroMeterH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMicroMeterW
            // 
            this.lblMicroMeterW.Location = new System.Drawing.Point(286, 111);
            this.lblMicroMeterW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterW.Name = "lblMicroMeterW";
            this.lblMicroMeterW.Size = new System.Drawing.Size(40, 18);
            this.lblMicroMeterW.TabIndex = 0;
            this.lblMicroMeterW.Tag = "LBL_MICROMETER";
            this.lblMicroMeterW.Text = "微米";
            this.lblMicroMeterW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMilliMeterF
            // 
            this.lblMilliMeterF.Location = new System.Drawing.Point(286, 170);
            this.lblMilliMeterF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterF.Name = "lblMilliMeterF";
            this.lblMilliMeterF.Size = new System.Drawing.Size(40, 18);
            this.lblMilliMeterF.TabIndex = 0;
            this.lblMilliMeterF.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterF.Text = "毫米";
            this.lblMilliMeterF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMilliMeterT
            // 
            this.lblMilliMeterT.Location = new System.Drawing.Point(286, 54);
            this.lblMilliMeterT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterT.Name = "lblMilliMeterT";
            this.lblMilliMeterT.Size = new System.Drawing.Size(40, 18);
            this.lblMilliMeterT.TabIndex = 0;
            this.lblMilliMeterT.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterT.Text = "毫米";
            this.lblMilliMeterT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFocalLengthPrompt1
            // 
            this.lblFocalLengthPrompt1.Location = new System.Drawing.Point(20, 176);
            this.lblFocalLengthPrompt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFocalLengthPrompt1.Name = "lblFocalLengthPrompt1";
            this.lblFocalLengthPrompt1.Size = new System.Drawing.Size(75, 18);
            this.lblFocalLengthPrompt1.TabIndex = 0;
            this.lblFocalLengthPrompt1.Tag = "LBL_FOCALLENGTH";
            this.lblFocalLengthPrompt1.Text = "镜头焦距";
            // 
            // lblCellHeightPrompt1
            // 
            this.lblCellHeightPrompt1.Location = new System.Drawing.Point(20, 148);
            this.lblCellHeightPrompt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellHeightPrompt1.Name = "lblCellHeightPrompt1";
            this.lblCellHeightPrompt1.Size = new System.Drawing.Size(75, 18);
            this.lblCellHeightPrompt1.TabIndex = 0;
            this.lblCellHeightPrompt1.Tag = "LBL_CELLHEIGHT";
            this.lblCellHeightPrompt1.Text = "像元高度";
            // 
            // lblCellWidthPrompt1
            // 
            this.lblCellWidthPrompt1.Location = new System.Drawing.Point(20, 120);
            this.lblCellWidthPrompt1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellWidthPrompt1.Name = "lblCellWidthPrompt1";
            this.lblCellWidthPrompt1.Size = new System.Drawing.Size(75, 18);
            this.lblCellWidthPrompt1.TabIndex = 0;
            this.lblCellWidthPrompt1.Tag = "LBL_CELLWIDTH";
            this.lblCellWidthPrompt1.Text = "像元宽度";
            // 
            // lblCameraType
            // 
            this.lblCameraType.Location = new System.Drawing.Point(20, 92);
            this.lblCameraType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCameraType.Name = "lblCameraType";
            this.lblCameraType.Size = new System.Drawing.Size(75, 18);
            this.lblCameraType.TabIndex = 0;
            this.lblCameraType.Tag = "LBL_";
            this.lblCameraType.Text = "相机类型";
            // 
            // lblPlateThickness
            // 
            this.lblPlateThickness.Location = new System.Drawing.Point(20, 58);
            this.lblPlateThickness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlateThickness.Name = "lblPlateThickness";
            this.lblPlateThickness.Size = new System.Drawing.Size(75, 18);
            this.lblPlateThickness.TabIndex = 0;
            this.lblPlateThickness.Tag = "LBL_PLATETHICKNESS";
            this.lblPlateThickness.Text = "标定板厚";
            // 
            // lblDescriptionFile
            // 
            this.lblDescriptionFile.Location = new System.Drawing.Point(20, 28);
            this.lblDescriptionFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescriptionFile.Name = "lblDescriptionFile";
            this.lblDescriptionFile.Size = new System.Drawing.Size(75, 18);
            this.lblDescriptionFile.TabIndex = 0;
            this.lblDescriptionFile.Tag = "LBL_DESCRIPTIONFILE";
            this.lblDescriptionFile.Text = "描述文件";
            // 
            // btnCalibrateCamera
            // 
            this.btnCalibrateCamera.Location = new System.Drawing.Point(347, 216);
            this.btnCalibrateCamera.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalibrateCamera.Name = "btnCalibrateCamera";
            this.btnCalibrateCamera.Size = new System.Drawing.Size(78, 28);
            this.btnCalibrateCamera.TabIndex = 1;
            this.btnCalibrateCamera.Tag = "BTN_CALIBRATECAMERA";
            this.btnCalibrateCamera.Text = "标定相机";
            this.btnCalibrateCamera.UseVisualStyleBackColor = true;
            // 
            // btnSetReference
            // 
            this.btnSetReference.Location = new System.Drawing.Point(347, 166);
            this.btnSetReference.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetReference.Name = "btnSetReference";
            this.btnSetReference.Size = new System.Drawing.Size(78, 28);
            this.btnSetReference.TabIndex = 1;
            this.btnSetReference.Tag = "BTN_SETREFERENCE";
            this.btnSetReference.Text = "设为参考";
            this.btnSetReference.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(347, 117);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(78, 28);
            this.btnDeleteAll.TabIndex = 1;
            this.btnDeleteAll.Tag = "BTN_DELETEALL";
            this.btnDeleteAll.Text = "删除所有";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(347, 67);
            this.btnDeleteImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(78, 28);
            this.btnDeleteImage.TabIndex = 1;
            this.btnDeleteImage.Tag = "BTN_DELETEIMAGE";
            this.btnDeleteImage.Text = "删除图像";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(347, 18);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(78, 28);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Tag = "BTN_LOADIMAGE";
            this.btnLoadImage.Text = "加载图像";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // lstbImages
            // 
            this.lstbImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRef,
            this.colImage,
            this.colStatus});
            this.lstbImages.FullRowSelect = true;
            this.lstbImages.Location = new System.Drawing.Point(4, 18);
            this.lstbImages.Margin = new System.Windows.Forms.Padding(2);
            this.lstbImages.MultiSelect = false;
            this.lstbImages.Name = "lstbImages";
            this.lstbImages.Size = new System.Drawing.Size(320, 241);
            this.lstbImages.TabIndex = 0;
            this.lstbImages.UseCompatibleStateImageBehavior = false;
            this.lstbImages.View = System.Windows.Forms.View.Details;
            // 
            // colRef
            // 
            this.colRef.Text = "参考";
            // 
            // colImage
            // 
            this.colImage.Text = "图像";
            // 
            // colStatus
            // 
            this.colStatus.Text = "状态";
            // 
            // tbpQualityCheck
            // 
            this.tbpQualityCheck.Controls.Add(this.grpbPlateExtractionParameter);
            this.tbpQualityCheck.Controls.Add(this.numUpDwnWarnLevel);
            this.tbpQualityCheck.Controls.Add(this.cmbImageSetAccuracy);
            this.tbpQualityCheck.Controls.Add(this.cmbImageAccuracy);
            this.tbpQualityCheck.Controls.Add(this.lblWarnLevel);
            this.tbpQualityCheck.Controls.Add(this.lblTestOption);
            this.tbpQualityCheck.Controls.Add(this.lblImageOption);
            this.tbpQualityCheck.Controls.Add(this.lstbQualityCheck);
            this.tbpQualityCheck.Location = new System.Drawing.Point(4, 22);
            this.tbpQualityCheck.Margin = new System.Windows.Forms.Padding(2);
            this.tbpQualityCheck.Name = "tbpQualityCheck";
            this.tbpQualityCheck.Padding = new System.Windows.Forms.Padding(2);
            this.tbpQualityCheck.Size = new System.Drawing.Size(453, 600);
            this.tbpQualityCheck.TabIndex = 1;
            this.tbpQualityCheck.Tag = "TBP_QUALITYCHECK";
            this.tbpQualityCheck.Text = "品质检测";
            this.tbpQualityCheck.UseVisualStyleBackColor = true;
            // 
            // grpbPlateExtractionParameter
            // 
            this.grpbPlateExtractionParameter.Controls.Add(this.btnMarkMaxDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnMarkMinContourLength);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnSmoothFactor);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnMinThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnThresholdDecrease);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnInitThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnMarkMinDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnMarkThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.btnGaussFilterSize);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbMarkMaxDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbMarkMinContourLength);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbSmoothFactor);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbMinThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbThresholdDecrease);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbInitThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbMarkMinDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbMarkThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.trcbGaussFilterSize);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnMarkMaxDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnMarkMinContourLength);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnSmoothFactor);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnMinThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnThresholdDecrease);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnInitThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnMarkMinDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnMarkThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.numUpDwnGaussFilterSize);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblMarkMaxDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblMarkMinContourLength);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblSmoothFactor);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblMinThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblThresholdDecrease);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblInitThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblMarkMinDiameter);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblMarkThreshold);
            this.grpbPlateExtractionParameter.Controls.Add(this.lblGaussFilterSize);
            this.grpbPlateExtractionParameter.Location = new System.Drawing.Point(4, 250);
            this.grpbPlateExtractionParameter.Margin = new System.Windows.Forms.Padding(2);
            this.grpbPlateExtractionParameter.Name = "grpbPlateExtractionParameter";
            this.grpbPlateExtractionParameter.Padding = new System.Windows.Forms.Padding(2);
            this.grpbPlateExtractionParameter.Size = new System.Drawing.Size(441, 366);
            this.grpbPlateExtractionParameter.TabIndex = 4;
            this.grpbPlateExtractionParameter.TabStop = false;
            this.grpbPlateExtractionParameter.Tag = "GRPB_PLATEEXTRACTIONPARAMETER";
            this.grpbPlateExtractionParameter.Text = "标定板提取参数";
            // 
            // btnMarkMaxDiameter
            // 
            this.btnMarkMaxDiameter.Location = new System.Drawing.Point(358, 310);
            this.btnMarkMaxDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkMaxDiameter.Name = "btnMarkMaxDiameter";
            this.btnMarkMaxDiameter.Size = new System.Drawing.Size(66, 26);
            this.btnMarkMaxDiameter.TabIndex = 4;
            this.btnMarkMaxDiameter.Tag = "BTN_MARKMAXDIAMETER";
            this.btnMarkMaxDiameter.Text = "重置";
            this.btnMarkMaxDiameter.UseVisualStyleBackColor = true;
            // 
            // btnMarkMinContourLength
            // 
            this.btnMarkMinContourLength.Location = new System.Drawing.Point(358, 274);
            this.btnMarkMinContourLength.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkMinContourLength.Name = "btnMarkMinContourLength";
            this.btnMarkMinContourLength.Size = new System.Drawing.Size(66, 26);
            this.btnMarkMinContourLength.TabIndex = 4;
            this.btnMarkMinContourLength.Tag = "BTN_MARKMINCONTOURLENGTH";
            this.btnMarkMinContourLength.Text = "重置";
            this.btnMarkMinContourLength.UseVisualStyleBackColor = true;
            // 
            // btnSmoothFactor
            // 
            this.btnSmoothFactor.Location = new System.Drawing.Point(358, 234);
            this.btnSmoothFactor.Margin = new System.Windows.Forms.Padding(2);
            this.btnSmoothFactor.Name = "btnSmoothFactor";
            this.btnSmoothFactor.Size = new System.Drawing.Size(66, 26);
            this.btnSmoothFactor.TabIndex = 4;
            this.btnSmoothFactor.Tag = "BTN_SMOOTHFACTOR";
            this.btnSmoothFactor.Text = "重置";
            this.btnSmoothFactor.UseVisualStyleBackColor = true;
            // 
            // btnMinThreshold
            // 
            this.btnMinThreshold.Location = new System.Drawing.Point(358, 202);
            this.btnMinThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinThreshold.Name = "btnMinThreshold";
            this.btnMinThreshold.Size = new System.Drawing.Size(66, 26);
            this.btnMinThreshold.TabIndex = 4;
            this.btnMinThreshold.Tag = "BTN_MINTHRESHOLD";
            this.btnMinThreshold.Text = "重置";
            this.btnMinThreshold.UseVisualStyleBackColor = true;
            // 
            // btnThresholdDecrease
            // 
            this.btnThresholdDecrease.Location = new System.Drawing.Point(358, 166);
            this.btnThresholdDecrease.Margin = new System.Windows.Forms.Padding(2);
            this.btnThresholdDecrease.Name = "btnThresholdDecrease";
            this.btnThresholdDecrease.Size = new System.Drawing.Size(66, 26);
            this.btnThresholdDecrease.TabIndex = 4;
            this.btnThresholdDecrease.Tag = "BTN_THRESHOLDDECREASE";
            this.btnThresholdDecrease.Text = "重置";
            this.btnThresholdDecrease.UseVisualStyleBackColor = true;
            // 
            // btnInitThreshold
            // 
            this.btnInitThreshold.Location = new System.Drawing.Point(358, 130);
            this.btnInitThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.btnInitThreshold.Name = "btnInitThreshold";
            this.btnInitThreshold.Size = new System.Drawing.Size(66, 26);
            this.btnInitThreshold.TabIndex = 4;
            this.btnInitThreshold.Tag = "BTN_INITTHRESHOLD";
            this.btnInitThreshold.Text = "重置";
            this.btnInitThreshold.UseVisualStyleBackColor = true;
            // 
            // btnMarkMinDiameter
            // 
            this.btnMarkMinDiameter.Location = new System.Drawing.Point(358, 94);
            this.btnMarkMinDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkMinDiameter.Name = "btnMarkMinDiameter";
            this.btnMarkMinDiameter.Size = new System.Drawing.Size(66, 26);
            this.btnMarkMinDiameter.TabIndex = 4;
            this.btnMarkMinDiameter.Tag = "BTN_MARKMINDIAMETER";
            this.btnMarkMinDiameter.Text = "重置";
            this.btnMarkMinDiameter.UseVisualStyleBackColor = true;
            // 
            // btnMarkThreshold
            // 
            this.btnMarkThreshold.Location = new System.Drawing.Point(358, 58);
            this.btnMarkThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkThreshold.Name = "btnMarkThreshold";
            this.btnMarkThreshold.Size = new System.Drawing.Size(66, 26);
            this.btnMarkThreshold.TabIndex = 4;
            this.btnMarkThreshold.Tag = "BTN_MARKTHRESHOLD";
            this.btnMarkThreshold.Text = "重置";
            this.btnMarkThreshold.UseVisualStyleBackColor = true;
            // 
            // btnGaussFilterSize
            // 
            this.btnGaussFilterSize.Location = new System.Drawing.Point(358, 27);
            this.btnGaussFilterSize.Margin = new System.Windows.Forms.Padding(2);
            this.btnGaussFilterSize.Name = "btnGaussFilterSize";
            this.btnGaussFilterSize.Size = new System.Drawing.Size(66, 26);
            this.btnGaussFilterSize.TabIndex = 4;
            this.btnGaussFilterSize.Tag = "BTN_GAUSSFILTERSIZE";
            this.btnGaussFilterSize.Text = "重置";
            this.btnGaussFilterSize.UseVisualStyleBackColor = true;
            // 
            // trcbMarkMaxDiameter
            // 
            this.trcbMarkMaxDiameter.LargeChange = 20;
            this.trcbMarkMaxDiameter.Location = new System.Drawing.Point(226, 315);
            this.trcbMarkMaxDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.trcbMarkMaxDiameter.Maximum = 500;
            this.trcbMarkMaxDiameter.Name = "trcbMarkMaxDiameter";
            this.trcbMarkMaxDiameter.Size = new System.Drawing.Size(120, 45);
            this.trcbMarkMaxDiameter.TabIndex = 3;
            this.trcbMarkMaxDiameter.Tag = "TRCB_MARKMAXDIAMETER";
            this.trcbMarkMaxDiameter.TickFrequency = 20;
            this.trcbMarkMaxDiameter.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbMarkMinContourLength
            // 
            this.trcbMarkMinContourLength.LargeChange = 20;
            this.trcbMarkMinContourLength.Location = new System.Drawing.Point(226, 279);
            this.trcbMarkMinContourLength.Margin = new System.Windows.Forms.Padding(2);
            this.trcbMarkMinContourLength.Maximum = 500;
            this.trcbMarkMinContourLength.Name = "trcbMarkMinContourLength";
            this.trcbMarkMinContourLength.Size = new System.Drawing.Size(120, 45);
            this.trcbMarkMinContourLength.TabIndex = 3;
            this.trcbMarkMinContourLength.Tag = "TRCB_MARKMINCONTOURLENGTH";
            this.trcbMarkMinContourLength.TickFrequency = 20;
            this.trcbMarkMinContourLength.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbSmoothFactor
            // 
            this.trcbSmoothFactor.LargeChange = 10;
            this.trcbSmoothFactor.Location = new System.Drawing.Point(226, 243);
            this.trcbSmoothFactor.Margin = new System.Windows.Forms.Padding(2);
            this.trcbSmoothFactor.Maximum = 200;
            this.trcbSmoothFactor.Name = "trcbSmoothFactor";
            this.trcbSmoothFactor.Size = new System.Drawing.Size(120, 45);
            this.trcbSmoothFactor.TabIndex = 3;
            this.trcbSmoothFactor.Tag = "TRCB_SMOOTHFACTOR";
            this.trcbSmoothFactor.TickFrequency = 10;
            this.trcbSmoothFactor.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbMinThreshold
            // 
            this.trcbMinThreshold.LargeChange = 10;
            this.trcbMinThreshold.Location = new System.Drawing.Point(226, 209);
            this.trcbMinThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.trcbMinThreshold.Maximum = 100;
            this.trcbMinThreshold.Name = "trcbMinThreshold";
            this.trcbMinThreshold.Size = new System.Drawing.Size(120, 45);
            this.trcbMinThreshold.SmallChange = 5;
            this.trcbMinThreshold.TabIndex = 3;
            this.trcbMinThreshold.Tag = "TRCB_MINTHRESHOLD";
            this.trcbMinThreshold.TickFrequency = 10;
            this.trcbMinThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbThresholdDecrease
            // 
            this.trcbThresholdDecrease.LargeChange = 10;
            this.trcbThresholdDecrease.Location = new System.Drawing.Point(226, 171);
            this.trcbThresholdDecrease.Margin = new System.Windows.Forms.Padding(2);
            this.trcbThresholdDecrease.Maximum = 100;
            this.trcbThresholdDecrease.Name = "trcbThresholdDecrease";
            this.trcbThresholdDecrease.Size = new System.Drawing.Size(120, 45);
            this.trcbThresholdDecrease.SmallChange = 5;
            this.trcbThresholdDecrease.TabIndex = 3;
            this.trcbThresholdDecrease.Tag = "TRCB_THRESHOLDDECREASE";
            this.trcbThresholdDecrease.TickFrequency = 10;
            this.trcbThresholdDecrease.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbInitThreshold
            // 
            this.trcbInitThreshold.LargeChange = 10;
            this.trcbInitThreshold.Location = new System.Drawing.Point(226, 137);
            this.trcbInitThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.trcbInitThreshold.Maximum = 255;
            this.trcbInitThreshold.Name = "trcbInitThreshold";
            this.trcbInitThreshold.Size = new System.Drawing.Size(120, 45);
            this.trcbInitThreshold.TabIndex = 3;
            this.trcbInitThreshold.Tag = "TRCB_INITTHRESHOLD";
            this.trcbInitThreshold.TickFrequency = 10;
            this.trcbInitThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbMarkMinDiameter
            // 
            this.trcbMarkMinDiameter.LargeChange = 10;
            this.trcbMarkMinDiameter.Location = new System.Drawing.Point(226, 101);
            this.trcbMarkMinDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.trcbMarkMinDiameter.Maximum = 100;
            this.trcbMarkMinDiameter.Name = "trcbMarkMinDiameter";
            this.trcbMarkMinDiameter.Size = new System.Drawing.Size(120, 45);
            this.trcbMarkMinDiameter.TabIndex = 3;
            this.trcbMarkMinDiameter.Tag = "TRCB_MARKMINDIAMETER";
            this.trcbMarkMinDiameter.TickFrequency = 10;
            this.trcbMarkMinDiameter.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbMarkThreshold
            // 
            this.trcbMarkThreshold.LargeChange = 10;
            this.trcbMarkThreshold.Location = new System.Drawing.Point(226, 65);
            this.trcbMarkThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.trcbMarkThreshold.Maximum = 255;
            this.trcbMarkThreshold.Name = "trcbMarkThreshold";
            this.trcbMarkThreshold.Size = new System.Drawing.Size(120, 45);
            this.trcbMarkThreshold.SmallChange = 5;
            this.trcbMarkThreshold.TabIndex = 3;
            this.trcbMarkThreshold.Tag = "TRCB_MARKTHRESHOLD";
            this.trcbMarkThreshold.TickFrequency = 10;
            this.trcbMarkThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trcbGaussFilterSize
            // 
            this.trcbGaussFilterSize.LargeChange = 1;
            this.trcbGaussFilterSize.Location = new System.Drawing.Point(226, 29);
            this.trcbGaussFilterSize.Margin = new System.Windows.Forms.Padding(2);
            this.trcbGaussFilterSize.Maximum = 15;
            this.trcbGaussFilterSize.Name = "trcbGaussFilterSize";
            this.trcbGaussFilterSize.Size = new System.Drawing.Size(120, 45);
            this.trcbGaussFilterSize.TabIndex = 3;
            this.trcbGaussFilterSize.Tag = "TRCB_GAUSSFILTERSIZE";
            this.trcbGaussFilterSize.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // numUpDwnMarkMaxDiameter
            // 
            this.numUpDwnMarkMaxDiameter.Location = new System.Drawing.Point(124, 315);
            this.numUpDwnMarkMaxDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMarkMaxDiameter.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpDwnMarkMaxDiameter.Name = "numUpDwnMarkMaxDiameter";
            this.numUpDwnMarkMaxDiameter.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnMarkMaxDiameter.TabIndex = 2;
            this.numUpDwnMarkMaxDiameter.Tag = "NUMUPDWN_MARKMAXDIAMETER";
            // 
            // numUpDwnMarkMinContourLength
            // 
            this.numUpDwnMarkMinContourLength.Location = new System.Drawing.Point(124, 279);
            this.numUpDwnMarkMinContourLength.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMarkMinContourLength.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numUpDwnMarkMinContourLength.Name = "numUpDwnMarkMinContourLength";
            this.numUpDwnMarkMinContourLength.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnMarkMinContourLength.TabIndex = 2;
            this.numUpDwnMarkMinContourLength.Tag = "NUMUPDWN_MARKMINCONTOURLENGTH";
            // 
            // numUpDwnSmoothFactor
            // 
            this.numUpDwnSmoothFactor.Location = new System.Drawing.Point(124, 243);
            this.numUpDwnSmoothFactor.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnSmoothFactor.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUpDwnSmoothFactor.Name = "numUpDwnSmoothFactor";
            this.numUpDwnSmoothFactor.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnSmoothFactor.TabIndex = 2;
            this.numUpDwnSmoothFactor.Tag = "NUMUPDWN_SMOOTHFACTOR";
            // 
            // numUpDwnMinThreshold
            // 
            this.numUpDwnMinThreshold.Location = new System.Drawing.Point(124, 207);
            this.numUpDwnMinThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMinThreshold.Name = "numUpDwnMinThreshold";
            this.numUpDwnMinThreshold.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnMinThreshold.TabIndex = 2;
            this.numUpDwnMinThreshold.Tag = "NUMUPDWN_MINTHRESHOLD";
            // 
            // numUpDwnThresholdDecrease
            // 
            this.numUpDwnThresholdDecrease.Location = new System.Drawing.Point(124, 171);
            this.numUpDwnThresholdDecrease.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnThresholdDecrease.Name = "numUpDwnThresholdDecrease";
            this.numUpDwnThresholdDecrease.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnThresholdDecrease.TabIndex = 2;
            this.numUpDwnThresholdDecrease.Tag = "NUMUPDWN_THRESHOLDDECREASE";
            // 
            // numUpDwnInitThreshold
            // 
            this.numUpDwnInitThreshold.Location = new System.Drawing.Point(124, 135);
            this.numUpDwnInitThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnInitThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnInitThreshold.Name = "numUpDwnInitThreshold";
            this.numUpDwnInitThreshold.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnInitThreshold.TabIndex = 2;
            this.numUpDwnInitThreshold.Tag = "NUMUPDWN_INITTHRESHOLD";
            // 
            // numUpDwnMarkMinDiameter
            // 
            this.numUpDwnMarkMinDiameter.Location = new System.Drawing.Point(124, 99);
            this.numUpDwnMarkMinDiameter.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMarkMinDiameter.Name = "numUpDwnMarkMinDiameter";
            this.numUpDwnMarkMinDiameter.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnMarkMinDiameter.TabIndex = 2;
            this.numUpDwnMarkMinDiameter.Tag = "NUMUPDWN_MARKMINDIAMETER";
            // 
            // numUpDwnMarkThreshold
            // 
            this.numUpDwnMarkThreshold.Location = new System.Drawing.Point(124, 63);
            this.numUpDwnMarkThreshold.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnMarkThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnMarkThreshold.Name = "numUpDwnMarkThreshold";
            this.numUpDwnMarkThreshold.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnMarkThreshold.TabIndex = 2;
            this.numUpDwnMarkThreshold.Tag = "NUMUPDWN_MARKTHRESHOLD";
            // 
            // numUpDwnGaussFilterSize
            // 
            this.numUpDwnGaussFilterSize.Location = new System.Drawing.Point(124, 27);
            this.numUpDwnGaussFilterSize.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnGaussFilterSize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDwnGaussFilterSize.Name = "numUpDwnGaussFilterSize";
            this.numUpDwnGaussFilterSize.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnGaussFilterSize.TabIndex = 2;
            this.numUpDwnGaussFilterSize.Tag = "NUMUPDWN_GAUSSFILTERSIZE";
            // 
            // lblMarkMaxDiameter
            // 
            this.lblMarkMaxDiameter.Location = new System.Drawing.Point(14, 317);
            this.lblMarkMaxDiameter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarkMaxDiameter.Name = "lblMarkMaxDiameter";
            this.lblMarkMaxDiameter.Size = new System.Drawing.Size(88, 18);
            this.lblMarkMaxDiameter.TabIndex = 1;
            this.lblMarkMaxDiameter.Tag = "LBL_MARKMAXDIAMETER";
            this.lblMarkMaxDiameter.Text = "标志点最大直径";
            // 
            // lblMarkMinContourLength
            // 
            this.lblMarkMinContourLength.Location = new System.Drawing.Point(14, 281);
            this.lblMarkMinContourLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarkMinContourLength.Name = "lblMarkMinContourLength";
            this.lblMarkMinContourLength.Size = new System.Drawing.Size(75, 18);
            this.lblMarkMinContourLength.TabIndex = 1;
            this.lblMarkMinContourLength.Tag = "LBL_MARKMINCONTOURLENGTH";
            this.lblMarkMinContourLength.Text = "最小轮廓长度";
            // 
            // lblSmoothFactor
            // 
            this.lblSmoothFactor.Location = new System.Drawing.Point(14, 245);
            this.lblSmoothFactor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSmoothFactor.Name = "lblSmoothFactor";
            this.lblSmoothFactor.Size = new System.Drawing.Size(99, 18);
            this.lblSmoothFactor.TabIndex = 1;
            this.lblSmoothFactor.Tag = "LBL_SMOOTHFACTOR";
            this.lblSmoothFactor.Text = "边缘平滑值(*100)";
            // 
            // lblMinThreshold
            // 
            this.lblMinThreshold.Location = new System.Drawing.Point(14, 209);
            this.lblMinThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMinThreshold.Name = "lblMinThreshold";
            this.lblMinThreshold.Size = new System.Drawing.Size(75, 18);
            this.lblMinThreshold.TabIndex = 1;
            this.lblMinThreshold.Tag = "LBL_MINTHRESHOLD";
            this.lblMinThreshold.Text = "最小灰度值";
            // 
            // lblThresholdDecrease
            // 
            this.lblThresholdDecrease.Location = new System.Drawing.Point(14, 173);
            this.lblThresholdDecrease.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThresholdDecrease.Name = "lblThresholdDecrease";
            this.lblThresholdDecrease.Size = new System.Drawing.Size(75, 18);
            this.lblThresholdDecrease.TabIndex = 1;
            this.lblThresholdDecrease.Tag = "LBL_THRESHOLDDECREASE";
            this.lblThresholdDecrease.Text = "灰度值递减";
            // 
            // lblInitThreshold
            // 
            this.lblInitThreshold.Location = new System.Drawing.Point(14, 137);
            this.lblInitThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInitThreshold.Name = "lblInitThreshold";
            this.lblInitThreshold.Size = new System.Drawing.Size(75, 18);
            this.lblInitThreshold.TabIndex = 1;
            this.lblInitThreshold.Tag = "LBL_INITTHRESHOLD";
            this.lblInitThreshold.Text = "初始灰度值";
            // 
            // lblMarkMinDiameter
            // 
            this.lblMarkMinDiameter.Location = new System.Drawing.Point(14, 101);
            this.lblMarkMinDiameter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarkMinDiameter.Name = "lblMarkMinDiameter";
            this.lblMarkMinDiameter.Size = new System.Drawing.Size(88, 18);
            this.lblMarkMinDiameter.TabIndex = 1;
            this.lblMarkMinDiameter.Tag = "LBL_MARKMINDIAMETER";
            this.lblMarkMinDiameter.Text = "标志点最小直径";
            // 
            // lblMarkThreshold
            // 
            this.lblMarkThreshold.Location = new System.Drawing.Point(14, 65);
            this.lblMarkThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarkThreshold.Name = "lblMarkThreshold";
            this.lblMarkThreshold.Size = new System.Drawing.Size(75, 18);
            this.lblMarkThreshold.TabIndex = 1;
            this.lblMarkThreshold.Tag = "LBL_MARKTHRESHOLD";
            this.lblMarkThreshold.Text = "标志点灰度值";
            // 
            // lblGaussFilterSize
            // 
            this.lblGaussFilterSize.Location = new System.Drawing.Point(14, 29);
            this.lblGaussFilterSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGaussFilterSize.Name = "lblGaussFilterSize";
            this.lblGaussFilterSize.Size = new System.Drawing.Size(75, 18);
            this.lblGaussFilterSize.TabIndex = 1;
            this.lblGaussFilterSize.Tag = "LBL_GASSFILTERSIZE";
            this.lblGaussFilterSize.Text = "高斯滤波尺寸";
            // 
            // numUpDwnWarnLevel
            // 
            this.numUpDwnWarnLevel.Location = new System.Drawing.Point(338, 206);
            this.numUpDwnWarnLevel.Margin = new System.Windows.Forms.Padding(2);
            this.numUpDwnWarnLevel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numUpDwnWarnLevel.Name = "numUpDwnWarnLevel";
            this.numUpDwnWarnLevel.Size = new System.Drawing.Size(90, 21);
            this.numUpDwnWarnLevel.TabIndex = 3;
            this.numUpDwnWarnLevel.Tag = "NUMUPDWN_WARNLEVEL";
            this.numUpDwnWarnLevel.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // cmbImageSetAccuracy
            // 
            this.cmbImageSetAccuracy.FormattingEnabled = true;
            this.cmbImageSetAccuracy.Items.AddRange(new object[] {
            "所有",
            "快速",
            "无"});
            this.cmbImageSetAccuracy.Location = new System.Drawing.Point(338, 126);
            this.cmbImageSetAccuracy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbImageSetAccuracy.Name = "cmbImageSetAccuracy";
            this.cmbImageSetAccuracy.Size = new System.Drawing.Size(92, 20);
            this.cmbImageSetAccuracy.TabIndex = 2;
            this.cmbImageSetAccuracy.Tag = "CMB_IMAGESETACCURACY";
            // 
            // cmbImageAccuracy
            // 
            this.cmbImageAccuracy.FormattingEnabled = true;
            this.cmbImageAccuracy.Items.AddRange(new object[] {
            "所有",
            "快速",
            "无"});
            this.cmbImageAccuracy.Location = new System.Drawing.Point(338, 49);
            this.cmbImageAccuracy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbImageAccuracy.Name = "cmbImageAccuracy";
            this.cmbImageAccuracy.Size = new System.Drawing.Size(92, 20);
            this.cmbImageAccuracy.TabIndex = 2;
            this.cmbImageAccuracy.Tag = "CMB_IMAGEACCURACY";
            // 
            // lblWarnLevel
            // 
            this.lblWarnLevel.Location = new System.Drawing.Point(344, 178);
            this.lblWarnLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarnLevel.Name = "lblWarnLevel";
            this.lblWarnLevel.Size = new System.Drawing.Size(75, 18);
            this.lblWarnLevel.TabIndex = 1;
            this.lblWarnLevel.Tag = "LBL_WARNLEVEL";
            this.lblWarnLevel.Text = "警告等级(%)";
            // 
            // lblTestOption
            // 
            this.lblTestOption.Location = new System.Drawing.Point(344, 106);
            this.lblTestOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTestOption.Name = "lblTestOption";
            this.lblTestOption.Size = new System.Drawing.Size(75, 18);
            this.lblTestOption.TabIndex = 1;
            this.lblTestOption.Tag = "LBL_TESTOPTION";
            this.lblTestOption.Text = "图集品质";
            // 
            // lblImageOption
            // 
            this.lblImageOption.Location = new System.Drawing.Point(344, 21);
            this.lblImageOption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageOption.Name = "lblImageOption";
            this.lblImageOption.Size = new System.Drawing.Size(75, 18);
            this.lblImageOption.TabIndex = 1;
            this.lblImageOption.Tag = "LBL_IMAGEOPTION";
            this.lblImageOption.Text = "单图品质";
            // 
            // lstbQualityCheck
            // 
            this.lstbQualityCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colScope,
            this.colDescr,
            this.colScore});
            this.lstbQualityCheck.Location = new System.Drawing.Point(4, 5);
            this.lstbQualityCheck.Margin = new System.Windows.Forms.Padding(2);
            this.lstbQualityCheck.Name = "lstbQualityCheck";
            this.lstbQualityCheck.Size = new System.Drawing.Size(320, 241);
            this.lstbQualityCheck.TabIndex = 0;
            this.lstbQualityCheck.UseCompatibleStateImageBehavior = false;
            this.lstbQualityCheck.View = System.Windows.Forms.View.Details;
            // 
            // colScope
            // 
            this.colScope.Text = "范围";
            // 
            // colDescr
            // 
            this.colDescr.Text = "描述";
            // 
            // colScore
            // 
            this.colScore.Text = "得分";
            // 
            // tbpResult
            // 
            this.tbpResult.Controls.Add(this.rdbtnSimulatedCoord);
            this.tbpResult.Controls.Add(this.rdbtnOriginalCoord);
            this.tbpResult.Controls.Add(this.grpbExternalCampara);
            this.tbpResult.Controls.Add(this.grpbInternalCampara);
            this.tbpResult.Controls.Add(this.lblMeanError);
            this.tbpResult.Controls.Add(this.lblPixelE);
            this.tbpResult.Controls.Add(this.lblErrorPrompt);
            this.tbpResult.Controls.Add(this.lblStatus);
            this.tbpResult.Controls.Add(this.lblResultStatusPrompt);
            this.tbpResult.Location = new System.Drawing.Point(4, 22);
            this.tbpResult.Margin = new System.Windows.Forms.Padding(2);
            this.tbpResult.Name = "tbpResult";
            this.tbpResult.Padding = new System.Windows.Forms.Padding(2);
            this.tbpResult.Size = new System.Drawing.Size(453, 600);
            this.tbpResult.TabIndex = 2;
            this.tbpResult.Tag = "TBP_CALIBRATIONRESULT";
            this.tbpResult.Text = "标定结果";
            this.tbpResult.UseVisualStyleBackColor = true;
            // 
            // rdbtnSimulatedCoord
            // 
            this.rdbtnSimulatedCoord.AutoSize = true;
            this.rdbtnSimulatedCoord.Location = new System.Drawing.Point(273, 574);
            this.rdbtnSimulatedCoord.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnSimulatedCoord.Name = "rdbtnSimulatedCoord";
            this.rdbtnSimulatedCoord.Size = new System.Drawing.Size(83, 16);
            this.rdbtnSimulatedCoord.TabIndex = 3;
            this.rdbtnSimulatedCoord.Tag = "RDBTN_SIMULATEDCOORDINATE";
            this.rdbtnSimulatedCoord.Text = "模拟坐标系";
            this.rdbtnSimulatedCoord.UseVisualStyleBackColor = true;
            // 
            // rdbtnOriginalCoord
            // 
            this.rdbtnOriginalCoord.AutoSize = true;
            this.rdbtnOriginalCoord.Checked = true;
            this.rdbtnOriginalCoord.Location = new System.Drawing.Point(26, 574);
            this.rdbtnOriginalCoord.Margin = new System.Windows.Forms.Padding(2);
            this.rdbtnOriginalCoord.Name = "rdbtnOriginalCoord";
            this.rdbtnOriginalCoord.Size = new System.Drawing.Size(83, 16);
            this.rdbtnOriginalCoord.TabIndex = 3;
            this.rdbtnOriginalCoord.TabStop = true;
            this.rdbtnOriginalCoord.Tag = "RDBTN_ORIGINALCOORDINATE";
            this.rdbtnOriginalCoord.Text = "原始坐标系";
            this.rdbtnOriginalCoord.UseVisualStyleBackColor = true;
            // 
            // grpbExternalCampara
            // 
            this.grpbExternalCampara.Controls.Add(this.btnSaveExternalParameter);
            this.grpbExternalCampara.Controls.Add(this.lblDegreeG);
            this.grpbExternalCampara.Controls.Add(this.lblPoseG);
            this.grpbExternalCampara.Controls.Add(this.lblPoseGPrompt);
            this.grpbExternalCampara.Controls.Add(this.lblMilliMeterZ);
            this.grpbExternalCampara.Controls.Add(this.lblDegreeB);
            this.grpbExternalCampara.Controls.Add(this.lblPoseZ);
            this.grpbExternalCampara.Controls.Add(this.chkbOriginAtImgCorner);
            this.grpbExternalCampara.Controls.Add(this.lblPoseB);
            this.grpbExternalCampara.Controls.Add(this.lblPoseZPrompt);
            this.grpbExternalCampara.Controls.Add(this.lblMilliMeterY);
            this.grpbExternalCampara.Controls.Add(this.lblPoseBPrompt);
            this.grpbExternalCampara.Controls.Add(this.lblDegreeA);
            this.grpbExternalCampara.Controls.Add(this.lblPoseY);
            this.grpbExternalCampara.Controls.Add(this.lblPoseA);
            this.grpbExternalCampara.Controls.Add(this.lblPoseYPrompt);
            this.grpbExternalCampara.Controls.Add(this.lblMilliMeterX);
            this.grpbExternalCampara.Controls.Add(this.lblPoseAPrompt);
            this.grpbExternalCampara.Controls.Add(this.lblPoseX);
            this.grpbExternalCampara.Controls.Add(this.lblPoseXPrompt);
            this.grpbExternalCampara.Location = new System.Drawing.Point(5, 431);
            this.grpbExternalCampara.Margin = new System.Windows.Forms.Padding(2);
            this.grpbExternalCampara.Name = "grpbExternalCampara";
            this.grpbExternalCampara.Padding = new System.Windows.Forms.Padding(2);
            this.grpbExternalCampara.Size = new System.Drawing.Size(441, 128);
            this.grpbExternalCampara.TabIndex = 2;
            this.grpbExternalCampara.TabStop = false;
            this.grpbExternalCampara.Text = "相机外参";
            // 
            // btnSaveExternalParameter
            // 
            this.btnSaveExternalParameter.Location = new System.Drawing.Point(353, 27);
            this.btnSaveExternalParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveExternalParameter.Name = "btnSaveExternalParameter";
            this.btnSaveExternalParameter.Size = new System.Drawing.Size(67, 27);
            this.btnSaveExternalParameter.TabIndex = 1;
            this.btnSaveExternalParameter.Tag = "BTN_SAVEEXTERNALPARAMETER";
            this.btnSaveExternalParameter.Text = "保存外参";
            this.btnSaveExternalParameter.UseVisualStyleBackColor = true;
            // 
            // lblDegreeG
            // 
            this.lblDegreeG.Location = new System.Drawing.Point(284, 87);
            this.lblDegreeG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegreeG.Name = "lblDegreeG";
            this.lblDegreeG.Size = new System.Drawing.Size(52, 23);
            this.lblDegreeG.TabIndex = 0;
            this.lblDegreeG.Tag = "LBL_DEGREE";
            this.lblDegreeG.Text = "°度";
            // 
            // lblPoseG
            // 
            this.lblPoseG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseG.Location = new System.Drawing.Point(209, 84);
            this.lblPoseG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseG.Name = "lblPoseG";
            this.lblPoseG.Size = new System.Drawing.Size(52, 23);
            this.lblPoseG.TabIndex = 0;
            this.lblPoseG.Text = "γ值";
            // 
            // lblPoseGPrompt
            // 
            this.lblPoseGPrompt.Location = new System.Drawing.Point(162, 88);
            this.lblPoseGPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseGPrompt.Name = "lblPoseGPrompt";
            this.lblPoseGPrompt.Size = new System.Drawing.Size(52, 23);
            this.lblPoseGPrompt.TabIndex = 0;
            this.lblPoseGPrompt.Text = "Gamma";
            // 
            // lblMilliMeterZ
            // 
            this.lblMilliMeterZ.Location = new System.Drawing.Point(112, 87);
            this.lblMilliMeterZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterZ.Name = "lblMilliMeterZ";
            this.lblMilliMeterZ.Size = new System.Drawing.Size(52, 23);
            this.lblMilliMeterZ.TabIndex = 0;
            this.lblMilliMeterZ.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterZ.Text = "毫米";
            // 
            // lblDegreeB
            // 
            this.lblDegreeB.Location = new System.Drawing.Point(284, 56);
            this.lblDegreeB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegreeB.Name = "lblDegreeB";
            this.lblDegreeB.Size = new System.Drawing.Size(52, 23);
            this.lblDegreeB.TabIndex = 0;
            this.lblDegreeB.Tag = "LBL_DEGREE";
            this.lblDegreeB.Text = "°度";
            // 
            // lblPoseZ
            // 
            this.lblPoseZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseZ.Location = new System.Drawing.Point(52, 87);
            this.lblPoseZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseZ.Name = "lblPoseZ";
            this.lblPoseZ.Size = new System.Drawing.Size(52, 23);
            this.lblPoseZ.TabIndex = 0;
            this.lblPoseZ.Text = "Z值";
            // 
            // chkbOriginAtImgCorner
            // 
            this.chkbOriginAtImgCorner.AutoSize = true;
            this.chkbOriginAtImgCorner.Location = new System.Drawing.Point(342, 86);
            this.chkbOriginAtImgCorner.Margin = new System.Windows.Forms.Padding(2);
            this.chkbOriginAtImgCorner.Name = "chkbOriginAtImgCorner";
            this.chkbOriginAtImgCorner.Size = new System.Drawing.Size(96, 16);
            this.chkbOriginAtImgCorner.TabIndex = 0;
            this.chkbOriginAtImgCorner.Tag = "CHKB_ORIGINATIMGCORNER";
            this.chkbOriginAtImgCorner.Text = "原点在左上角";
            this.chkbOriginAtImgCorner.UseVisualStyleBackColor = true;
            // 
            // lblPoseB
            // 
            this.lblPoseB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseB.Location = new System.Drawing.Point(209, 53);
            this.lblPoseB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseB.Name = "lblPoseB";
            this.lblPoseB.Size = new System.Drawing.Size(52, 23);
            this.lblPoseB.TabIndex = 0;
            this.lblPoseB.Text = "β值";
            // 
            // lblPoseZPrompt
            // 
            this.lblPoseZPrompt.Location = new System.Drawing.Point(20, 87);
            this.lblPoseZPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseZPrompt.Name = "lblPoseZPrompt";
            this.lblPoseZPrompt.Size = new System.Drawing.Size(27, 23);
            this.lblPoseZPrompt.TabIndex = 0;
            this.lblPoseZPrompt.Text = "Z";
            // 
            // lblMilliMeterY
            // 
            this.lblMilliMeterY.Location = new System.Drawing.Point(112, 56);
            this.lblMilliMeterY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterY.Name = "lblMilliMeterY";
            this.lblMilliMeterY.Size = new System.Drawing.Size(52, 23);
            this.lblMilliMeterY.TabIndex = 0;
            this.lblMilliMeterY.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterY.Text = "毫米";
            // 
            // lblPoseBPrompt
            // 
            this.lblPoseBPrompt.Location = new System.Drawing.Point(162, 57);
            this.lblPoseBPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseBPrompt.Name = "lblPoseBPrompt";
            this.lblPoseBPrompt.Size = new System.Drawing.Size(52, 23);
            this.lblPoseBPrompt.TabIndex = 0;
            this.lblPoseBPrompt.Text = "Beta";
            // 
            // lblDegreeA
            // 
            this.lblDegreeA.Location = new System.Drawing.Point(284, 30);
            this.lblDegreeA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegreeA.Name = "lblDegreeA";
            this.lblDegreeA.Size = new System.Drawing.Size(52, 23);
            this.lblDegreeA.TabIndex = 0;
            this.lblDegreeA.Tag = "LBL_DEGREE";
            this.lblDegreeA.Text = "°度";
            // 
            // lblPoseY
            // 
            this.lblPoseY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseY.Location = new System.Drawing.Point(52, 56);
            this.lblPoseY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseY.Name = "lblPoseY";
            this.lblPoseY.Size = new System.Drawing.Size(52, 23);
            this.lblPoseY.TabIndex = 0;
            this.lblPoseY.Text = "Y值";
            // 
            // lblPoseA
            // 
            this.lblPoseA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseA.Location = new System.Drawing.Point(209, 26);
            this.lblPoseA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseA.Name = "lblPoseA";
            this.lblPoseA.Size = new System.Drawing.Size(52, 23);
            this.lblPoseA.TabIndex = 0;
            this.lblPoseA.Text = "α值";
            // 
            // lblPoseYPrompt
            // 
            this.lblPoseYPrompt.Location = new System.Drawing.Point(20, 56);
            this.lblPoseYPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseYPrompt.Name = "lblPoseYPrompt";
            this.lblPoseYPrompt.Size = new System.Drawing.Size(27, 23);
            this.lblPoseYPrompt.TabIndex = 0;
            this.lblPoseYPrompt.Text = "Y";
            // 
            // lblMilliMeterX
            // 
            this.lblMilliMeterX.Location = new System.Drawing.Point(112, 30);
            this.lblMilliMeterX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterX.Name = "lblMilliMeterX";
            this.lblMilliMeterX.Size = new System.Drawing.Size(52, 23);
            this.lblMilliMeterX.TabIndex = 0;
            this.lblMilliMeterX.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterX.Text = "毫米";
            // 
            // lblPoseAPrompt
            // 
            this.lblPoseAPrompt.Location = new System.Drawing.Point(162, 30);
            this.lblPoseAPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseAPrompt.Name = "lblPoseAPrompt";
            this.lblPoseAPrompt.Size = new System.Drawing.Size(52, 23);
            this.lblPoseAPrompt.TabIndex = 0;
            this.lblPoseAPrompt.Text = "Alpha";
            // 
            // lblPoseX
            // 
            this.lblPoseX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoseX.Location = new System.Drawing.Point(52, 30);
            this.lblPoseX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseX.Name = "lblPoseX";
            this.lblPoseX.Size = new System.Drawing.Size(52, 23);
            this.lblPoseX.TabIndex = 0;
            this.lblPoseX.Text = "X值";
            // 
            // lblPoseXPrompt
            // 
            this.lblPoseXPrompt.Location = new System.Drawing.Point(20, 30);
            this.lblPoseXPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoseXPrompt.Name = "lblPoseXPrompt";
            this.lblPoseXPrompt.Size = new System.Drawing.Size(27, 23);
            this.lblPoseXPrompt.TabIndex = 0;
            this.lblPoseXPrompt.Text = "X";
            // 
            // grpbInternalCampara
            // 
            this.grpbInternalCampara.Controls.Add(this.pKappa);
            this.grpbInternalCampara.Controls.Add(this.btnSaveInternalParameter);
            this.grpbInternalCampara.Controls.Add(this.lblFocalLength);
            this.grpbInternalCampara.Controls.Add(this.lblImageHeight);
            this.grpbInternalCampara.Controls.Add(this.lblImageWidth);
            this.grpbInternalCampara.Controls.Add(this.lblCenterRow);
            this.grpbInternalCampara.Controls.Add(this.lblCenterCol);
            this.grpbInternalCampara.Controls.Add(this.lblMilliMeterL);
            this.grpbInternalCampara.Controls.Add(this.lblPixelIH);
            this.grpbInternalCampara.Controls.Add(this.lblPixelW);
            this.grpbInternalCampara.Controls.Add(this.lblPixelCY);
            this.grpbInternalCampara.Controls.Add(this.lblPixelCX);
            this.grpbInternalCampara.Controls.Add(this.lblCellHeight);
            this.grpbInternalCampara.Controls.Add(this.lblCellWidth);
            this.grpbInternalCampara.Controls.Add(this.lblMicroMeterSY);
            this.grpbInternalCampara.Controls.Add(this.lblMicroMeterSX);
            this.grpbInternalCampara.Controls.Add(this.lblFocalLengthPrompt2);
            this.grpbInternalCampara.Controls.Add(this.lblImageHeightPrompt);
            this.grpbInternalCampara.Controls.Add(this.lblImageWidthPrompt);
            this.grpbInternalCampara.Controls.Add(this.lblCenterRowPrompt);
            this.grpbInternalCampara.Controls.Add(this.lblCenterColPrompt);
            this.grpbInternalCampara.Controls.Add(this.lblCellHeightPrompt2);
            this.grpbInternalCampara.Controls.Add(this.lblCellWidthPrompt2);
            this.grpbInternalCampara.Location = new System.Drawing.Point(4, 78);
            this.grpbInternalCampara.Margin = new System.Windows.Forms.Padding(2);
            this.grpbInternalCampara.Name = "grpbInternalCampara";
            this.grpbInternalCampara.Padding = new System.Windows.Forms.Padding(2);
            this.grpbInternalCampara.Size = new System.Drawing.Size(441, 348);
            this.grpbInternalCampara.TabIndex = 1;
            this.grpbInternalCampara.TabStop = false;
            this.grpbInternalCampara.Text = "相机内参";
            // 
            // pKappa
            // 
            this.pKappa.Controls.Add(this.pLineScanResult);
            this.pKappa.Controls.Add(this.lblKappaPrompt);
            this.pKappa.Controls.Add(this.lblKappa);
            this.pKappa.Controls.Add(this.lblMeterKappa);
            this.pKappa.Location = new System.Drawing.Point(25, 201);
            this.pKappa.Margin = new System.Windows.Forms.Padding(2);
            this.pKappa.Name = "pKappa";
            this.pKappa.Size = new System.Drawing.Size(388, 133);
            this.pKappa.TabIndex = 6;
            // 
            // pLineScanResult
            // 
            this.pLineScanResult.Controls.Add(this.lblMicroMeterPerPixelZ2);
            this.pLineScanResult.Controls.Add(this.pAreaScanPolynormal);
            this.pLineScanResult.Controls.Add(this.lblSpeedX2);
            this.pLineScanResult.Controls.Add(this.lblSpeedY2);
            this.pLineScanResult.Controls.Add(this.lblSpeedZ2);
            this.pLineScanResult.Controls.Add(this.lblMicroMeterPerPixelX2);
            this.pLineScanResult.Controls.Add(this.lblMicroMeterPerPixelY2);
            this.pLineScanResult.Controls.Add(this.lblMotionVz);
            this.pLineScanResult.Controls.Add(this.lblMotionVy);
            this.pLineScanResult.Controls.Add(this.lblMotionVx);
            this.pLineScanResult.Location = new System.Drawing.Point(3, 2);
            this.pLineScanResult.Margin = new System.Windows.Forms.Padding(2);
            this.pLineScanResult.Name = "pLineScanResult";
            this.pLineScanResult.Size = new System.Drawing.Size(343, 94);
            this.pLineScanResult.TabIndex = 4;
            // 
            // lblMicroMeterPerPixelZ2
            // 
            this.lblMicroMeterPerPixelZ2.Location = new System.Drawing.Point(273, 59);
            this.lblMicroMeterPerPixelZ2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelZ2.Name = "lblMicroMeterPerPixelZ2";
            this.lblMicroMeterPerPixelZ2.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelZ2.TabIndex = 0;
            this.lblMicroMeterPerPixelZ2.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelZ2.Text = "微米/像素";
            this.lblMicroMeterPerPixelZ2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pAreaScanPolynormal
            // 
            this.pAreaScanPolynormal.Controls.Add(this.lblMeter6K3);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK1Prompt);
            this.pAreaScanPolynormal.Controls.Add(this.lblMeter2K1);
            this.pAreaScanPolynormal.Controls.Add(this.lblTangentialP2Prompt);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK3Prompt);
            this.pAreaScanPolynormal.Controls.Add(this.lblTangentialP1Prompt);
            this.pAreaScanPolynormal.Controls.Add(this.lblMeter4K2);
            this.pAreaScanPolynormal.Controls.Add(this.lblTangentialP2);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK2Prompt);
            this.pAreaScanPolynormal.Controls.Add(this.lblTangentialP1);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK1);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK2);
            this.pAreaScanPolynormal.Controls.Add(this.lblRadialK3);
            this.pAreaScanPolynormal.Controls.Add(this.lblMeter2P2);
            this.pAreaScanPolynormal.Controls.Add(this.lblMeter2P1);
            this.pAreaScanPolynormal.Location = new System.Drawing.Point(0, 2);
            this.pAreaScanPolynormal.Margin = new System.Windows.Forms.Padding(2);
            this.pAreaScanPolynormal.Name = "pAreaScanPolynormal";
            this.pAreaScanPolynormal.Size = new System.Drawing.Size(383, 126);
            this.pAreaScanPolynormal.TabIndex = 5;
            // 
            // lblMeter6K3
            // 
            this.lblMeter6K3.Location = new System.Drawing.Point(279, 58);
            this.lblMeter6K3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeter6K3.Name = "lblMeter6K3";
            this.lblMeter6K3.Size = new System.Drawing.Size(64, 25);
            this.lblMeter6K3.TabIndex = 0;
            this.lblMeter6K3.Text = "1/米^6";
            // 
            // lblRadialK1Prompt
            // 
            this.lblRadialK1Prompt.Location = new System.Drawing.Point(7, 10);
            this.lblRadialK1Prompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK1Prompt.Name = "lblRadialK1Prompt";
            this.lblRadialK1Prompt.Size = new System.Drawing.Size(100, 23);
            this.lblRadialK1Prompt.TabIndex = 0;
            this.lblRadialK1Prompt.Tag = "LBL_RADIALK1";
            this.lblRadialK1Prompt.Text = "径向畸变二阶(K1)";
            // 
            // lblMeter2K1
            // 
            this.lblMeter2K1.Location = new System.Drawing.Point(279, 10);
            this.lblMeter2K1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeter2K1.Name = "lblMeter2K1";
            this.lblMeter2K1.Size = new System.Drawing.Size(64, 25);
            this.lblMeter2K1.TabIndex = 0;
            this.lblMeter2K1.Text = "1/米^2";
            // 
            // lblTangentialP2Prompt
            // 
            this.lblTangentialP2Prompt.Location = new System.Drawing.Point(7, 118);
            this.lblTangentialP2Prompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTangentialP2Prompt.Name = "lblTangentialP2Prompt";
            this.lblTangentialP2Prompt.Size = new System.Drawing.Size(100, 23);
            this.lblTangentialP2Prompt.TabIndex = 0;
            this.lblTangentialP2Prompt.Tag = "LBL_TANGENTIALP2";
            this.lblTangentialP2Prompt.Text = "切向畸变二阶(P2)";
            // 
            // lblRadialK3Prompt
            // 
            this.lblRadialK3Prompt.Location = new System.Drawing.Point(7, 60);
            this.lblRadialK3Prompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK3Prompt.Name = "lblRadialK3Prompt";
            this.lblRadialK3Prompt.Size = new System.Drawing.Size(100, 23);
            this.lblRadialK3Prompt.TabIndex = 0;
            this.lblRadialK3Prompt.Tag = "LBL_RADIALK3";
            this.lblRadialK3Prompt.Text = "径向畸变六阶(K3)";
            // 
            // lblTangentialP1Prompt
            // 
            this.lblTangentialP1Prompt.Location = new System.Drawing.Point(7, 93);
            this.lblTangentialP1Prompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTangentialP1Prompt.Name = "lblTangentialP1Prompt";
            this.lblTangentialP1Prompt.Size = new System.Drawing.Size(100, 23);
            this.lblTangentialP1Prompt.TabIndex = 0;
            this.lblTangentialP1Prompt.Tag = "LBL_TANGENTIALP1";
            this.lblTangentialP1Prompt.Text = "切向畸变二阶(P1)";
            // 
            // lblMeter4K2
            // 
            this.lblMeter4K2.Location = new System.Drawing.Point(279, 35);
            this.lblMeter4K2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeter4K2.Name = "lblMeter4K2";
            this.lblMeter4K2.Size = new System.Drawing.Size(64, 25);
            this.lblMeter4K2.TabIndex = 0;
            this.lblMeter4K2.Text = "1/米^4";
            // 
            // lblTangentialP2
            // 
            this.lblTangentialP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTangentialP2.Location = new System.Drawing.Point(122, 118);
            this.lblTangentialP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTangentialP2.Name = "lblTangentialP2";
            this.lblTangentialP2.Size = new System.Drawing.Size(148, 25);
            this.lblTangentialP2.TabIndex = 0;
            this.lblTangentialP2.Text = "切向畸变二阶";
            // 
            // lblRadialK2Prompt
            // 
            this.lblRadialK2Prompt.Location = new System.Drawing.Point(7, 35);
            this.lblRadialK2Prompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK2Prompt.Name = "lblRadialK2Prompt";
            this.lblRadialK2Prompt.Size = new System.Drawing.Size(100, 23);
            this.lblRadialK2Prompt.TabIndex = 0;
            this.lblRadialK2Prompt.Tag = "LBL_RADIALK2";
            this.lblRadialK2Prompt.Text = "径向畸变四阶(K2)";
            // 
            // lblTangentialP1
            // 
            this.lblTangentialP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTangentialP1.Location = new System.Drawing.Point(122, 91);
            this.lblTangentialP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTangentialP1.Name = "lblTangentialP1";
            this.lblTangentialP1.Size = new System.Drawing.Size(148, 25);
            this.lblTangentialP1.TabIndex = 0;
            this.lblTangentialP1.Text = "切向畸变二阶";
            // 
            // lblRadialK1
            // 
            this.lblRadialK1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRadialK1.Location = new System.Drawing.Point(122, 10);
            this.lblRadialK1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK1.Name = "lblRadialK1";
            this.lblRadialK1.Size = new System.Drawing.Size(148, 25);
            this.lblRadialK1.TabIndex = 0;
            this.lblRadialK1.Text = "径向畸变二阶";
            // 
            // lblRadialK2
            // 
            this.lblRadialK2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRadialK2.Location = new System.Drawing.Point(122, 35);
            this.lblRadialK2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK2.Name = "lblRadialK2";
            this.lblRadialK2.Size = new System.Drawing.Size(148, 25);
            this.lblRadialK2.TabIndex = 0;
            this.lblRadialK2.Text = "径向畸变四阶";
            // 
            // lblRadialK3
            // 
            this.lblRadialK3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRadialK3.Location = new System.Drawing.Point(122, 58);
            this.lblRadialK3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRadialK3.Name = "lblRadialK3";
            this.lblRadialK3.Size = new System.Drawing.Size(148, 25);
            this.lblRadialK3.TabIndex = 0;
            this.lblRadialK3.Text = "径向畸变六阶";
            // 
            // lblMeter2P2
            // 
            this.lblMeter2P2.Location = new System.Drawing.Point(279, 118);
            this.lblMeter2P2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeter2P2.Name = "lblMeter2P2";
            this.lblMeter2P2.Size = new System.Drawing.Size(64, 25);
            this.lblMeter2P2.TabIndex = 0;
            this.lblMeter2P2.Text = "1/米^2";
            // 
            // lblMeter2P1
            // 
            this.lblMeter2P1.Location = new System.Drawing.Point(279, 91);
            this.lblMeter2P1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeter2P1.Name = "lblMeter2P1";
            this.lblMeter2P1.Size = new System.Drawing.Size(64, 25);
            this.lblMeter2P1.TabIndex = 0;
            this.lblMeter2P1.Text = "1/米^2";
            // 
            // lblSpeedX2
            // 
            this.lblSpeedX2.Location = new System.Drawing.Point(11, 6);
            this.lblSpeedX2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedX2.Name = "lblSpeedX2";
            this.lblSpeedX2.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedX2.TabIndex = 0;
            this.lblSpeedX2.Tag = "LBL_SPEEDX";
            this.lblSpeedX2.Text = "X方向速度(Vx)";
            // 
            // lblSpeedY2
            // 
            this.lblSpeedY2.Location = new System.Drawing.Point(11, 34);
            this.lblSpeedY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedY2.Name = "lblSpeedY2";
            this.lblSpeedY2.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedY2.TabIndex = 0;
            this.lblSpeedY2.Tag = "LBL_SPEEDY";
            this.lblSpeedY2.Text = "Y方向速度(Vy)";
            // 
            // lblSpeedZ2
            // 
            this.lblSpeedZ2.Location = new System.Drawing.Point(11, 62);
            this.lblSpeedZ2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpeedZ2.Name = "lblSpeedZ2";
            this.lblSpeedZ2.Size = new System.Drawing.Size(87, 18);
            this.lblSpeedZ2.TabIndex = 0;
            this.lblSpeedZ2.Tag = "LBL_SPEEDZ";
            this.lblSpeedZ2.Text = "Z方向速度(Vz)";
            // 
            // lblMicroMeterPerPixelX2
            // 
            this.lblMicroMeterPerPixelX2.Location = new System.Drawing.Point(273, 7);
            this.lblMicroMeterPerPixelX2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelX2.Name = "lblMicroMeterPerPixelX2";
            this.lblMicroMeterPerPixelX2.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelX2.TabIndex = 0;
            this.lblMicroMeterPerPixelX2.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelX2.Text = "微米/像素";
            this.lblMicroMeterPerPixelX2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMicroMeterPerPixelY2
            // 
            this.lblMicroMeterPerPixelY2.Location = new System.Drawing.Point(273, 34);
            this.lblMicroMeterPerPixelY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterPerPixelY2.Name = "lblMicroMeterPerPixelY2";
            this.lblMicroMeterPerPixelY2.Size = new System.Drawing.Size(61, 18);
            this.lblMicroMeterPerPixelY2.TabIndex = 0;
            this.lblMicroMeterPerPixelY2.Tag = "LBL_MICROMETERPERPIXEL";
            this.lblMicroMeterPerPixelY2.Text = "微米/像素";
            this.lblMicroMeterPerPixelY2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMotionVz
            // 
            this.lblMotionVz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMotionVz.Location = new System.Drawing.Point(95, 58);
            this.lblMotionVz.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMotionVz.Name = "lblMotionVz";
            this.lblMotionVz.Size = new System.Drawing.Size(148, 25);
            this.lblMotionVz.TabIndex = 0;
            this.lblMotionVz.Text = "Z方向速度";
            // 
            // lblMotionVy
            // 
            this.lblMotionVy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMotionVy.Location = new System.Drawing.Point(95, 34);
            this.lblMotionVy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMotionVy.Name = "lblMotionVy";
            this.lblMotionVy.Size = new System.Drawing.Size(148, 25);
            this.lblMotionVy.TabIndex = 0;
            this.lblMotionVy.Text = "Y方向速度";
            // 
            // lblMotionVx
            // 
            this.lblMotionVx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMotionVx.Location = new System.Drawing.Point(95, 3);
            this.lblMotionVx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMotionVx.Name = "lblMotionVx";
            this.lblMotionVx.Size = new System.Drawing.Size(148, 25);
            this.lblMotionVx.TabIndex = 0;
            this.lblMotionVx.Text = "X方向速度";
            // 
            // lblKappaPrompt
            // 
            this.lblKappaPrompt.Location = new System.Drawing.Point(20, 10);
            this.lblKappaPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKappaPrompt.Name = "lblKappaPrompt";
            this.lblKappaPrompt.Size = new System.Drawing.Size(100, 23);
            this.lblKappaPrompt.TabIndex = 0;
            this.lblKappaPrompt.Tag = "LBL_KAPPAPROMPT";
            this.lblKappaPrompt.Text = "畸变系数K";
            // 
            // lblKappa
            // 
            this.lblKappa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKappa.Location = new System.Drawing.Point(135, 10);
            this.lblKappa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKappa.Name = "lblKappa";
            this.lblKappa.Size = new System.Drawing.Size(148, 25);
            this.lblKappa.TabIndex = 0;
            this.lblKappa.Text = "畸变系数";
            // 
            // lblMeterKappa
            // 
            this.lblMeterKappa.Location = new System.Drawing.Point(292, 10);
            this.lblMeterKappa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeterKappa.Name = "lblMeterKappa";
            this.lblMeterKappa.Size = new System.Drawing.Size(64, 25);
            this.lblMeterKappa.TabIndex = 0;
            this.lblMeterKappa.Text = "1/米^2";
            // 
            // btnSaveInternalParameter
            // 
            this.btnSaveInternalParameter.Location = new System.Drawing.Point(356, 23);
            this.btnSaveInternalParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveInternalParameter.Name = "btnSaveInternalParameter";
            this.btnSaveInternalParameter.Size = new System.Drawing.Size(67, 27);
            this.btnSaveInternalParameter.TabIndex = 1;
            this.btnSaveInternalParameter.Tag = "BTN_SAVEINTERNALPARAMETER";
            this.btnSaveInternalParameter.Text = "保存内参";
            this.btnSaveInternalParameter.UseVisualStyleBackColor = true;
            // 
            // lblFocalLength
            // 
            this.lblFocalLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFocalLength.Location = new System.Drawing.Point(137, 174);
            this.lblFocalLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFocalLength.Name = "lblFocalLength";
            this.lblFocalLength.Size = new System.Drawing.Size(148, 25);
            this.lblFocalLength.TabIndex = 0;
            this.lblFocalLength.Text = "镜头焦距";
            // 
            // lblImageHeight
            // 
            this.lblImageHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblImageHeight.Location = new System.Drawing.Point(137, 150);
            this.lblImageHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageHeight.Name = "lblImageHeight";
            this.lblImageHeight.Size = new System.Drawing.Size(148, 25);
            this.lblImageHeight.TabIndex = 0;
            this.lblImageHeight.Text = "图像高度";
            // 
            // lblImageWidth
            // 
            this.lblImageWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblImageWidth.Location = new System.Drawing.Point(137, 126);
            this.lblImageWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageWidth.Name = "lblImageWidth";
            this.lblImageWidth.Size = new System.Drawing.Size(148, 25);
            this.lblImageWidth.TabIndex = 0;
            this.lblImageWidth.Text = "图像宽度";
            // 
            // lblCenterRow
            // 
            this.lblCenterRow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCenterRow.Location = new System.Drawing.Point(137, 99);
            this.lblCenterRow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCenterRow.Name = "lblCenterRow";
            this.lblCenterRow.Size = new System.Drawing.Size(148, 25);
            this.lblCenterRow.TabIndex = 0;
            this.lblCenterRow.Text = "中心坐标行";
            // 
            // lblCenterCol
            // 
            this.lblCenterCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCenterCol.Location = new System.Drawing.Point(137, 74);
            this.lblCenterCol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCenterCol.Name = "lblCenterCol";
            this.lblCenterCol.Size = new System.Drawing.Size(148, 25);
            this.lblCenterCol.TabIndex = 0;
            this.lblCenterCol.Text = "中心坐标列";
            // 
            // lblMilliMeterL
            // 
            this.lblMilliMeterL.Location = new System.Drawing.Point(295, 174);
            this.lblMilliMeterL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMilliMeterL.Name = "lblMilliMeterL";
            this.lblMilliMeterL.Size = new System.Drawing.Size(64, 25);
            this.lblMilliMeterL.TabIndex = 0;
            this.lblMilliMeterL.Tag = "LBL_MIlliMETER";
            this.lblMilliMeterL.Text = "毫米";
            // 
            // lblPixelIH
            // 
            this.lblPixelIH.Location = new System.Drawing.Point(295, 150);
            this.lblPixelIH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelIH.Name = "lblPixelIH";
            this.lblPixelIH.Size = new System.Drawing.Size(64, 25);
            this.lblPixelIH.TabIndex = 0;
            this.lblPixelIH.Tag = "LBL_PIXEL";
            this.lblPixelIH.Text = "像素";
            // 
            // lblPixelW
            // 
            this.lblPixelW.Location = new System.Drawing.Point(295, 126);
            this.lblPixelW.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelW.Name = "lblPixelW";
            this.lblPixelW.Size = new System.Drawing.Size(64, 25);
            this.lblPixelW.TabIndex = 0;
            this.lblPixelW.Tag = "LBL_PIXEL";
            this.lblPixelW.Text = "像素";
            // 
            // lblPixelCY
            // 
            this.lblPixelCY.Location = new System.Drawing.Point(295, 99);
            this.lblPixelCY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelCY.Name = "lblPixelCY";
            this.lblPixelCY.Size = new System.Drawing.Size(64, 25);
            this.lblPixelCY.TabIndex = 0;
            this.lblPixelCY.Tag = "LBL_PIXEL";
            this.lblPixelCY.Text = "像素";
            // 
            // lblPixelCX
            // 
            this.lblPixelCX.Location = new System.Drawing.Point(295, 74);
            this.lblPixelCX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelCX.Name = "lblPixelCX";
            this.lblPixelCX.Size = new System.Drawing.Size(64, 25);
            this.lblPixelCX.TabIndex = 0;
            this.lblPixelCX.Tag = "LBL_PIXEL";
            this.lblPixelCX.Text = "像素";
            // 
            // lblCellHeight
            // 
            this.lblCellHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCellHeight.Location = new System.Drawing.Point(137, 50);
            this.lblCellHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellHeight.Name = "lblCellHeight";
            this.lblCellHeight.Size = new System.Drawing.Size(148, 25);
            this.lblCellHeight.TabIndex = 0;
            this.lblCellHeight.Text = "像元高度";
            // 
            // lblCellWidth
            // 
            this.lblCellWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCellWidth.Location = new System.Drawing.Point(137, 26);
            this.lblCellWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellWidth.Name = "lblCellWidth";
            this.lblCellWidth.Size = new System.Drawing.Size(148, 25);
            this.lblCellWidth.TabIndex = 0;
            this.lblCellWidth.Text = "像元宽度";
            // 
            // lblMicroMeterSY
            // 
            this.lblMicroMeterSY.Location = new System.Drawing.Point(295, 50);
            this.lblMicroMeterSY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterSY.Name = "lblMicroMeterSY";
            this.lblMicroMeterSY.Size = new System.Drawing.Size(64, 25);
            this.lblMicroMeterSY.TabIndex = 0;
            this.lblMicroMeterSY.Tag = "LBL_MICROMETER";
            this.lblMicroMeterSY.Text = "微米";
            // 
            // lblMicroMeterSX
            // 
            this.lblMicroMeterSX.Location = new System.Drawing.Point(295, 26);
            this.lblMicroMeterSX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMicroMeterSX.Name = "lblMicroMeterSX";
            this.lblMicroMeterSX.Size = new System.Drawing.Size(64, 25);
            this.lblMicroMeterSX.TabIndex = 0;
            this.lblMicroMeterSX.Tag = "LBL_MICROMETER";
            this.lblMicroMeterSX.Text = "微米";
            // 
            // lblFocalLengthPrompt2
            // 
            this.lblFocalLengthPrompt2.Location = new System.Drawing.Point(22, 175);
            this.lblFocalLengthPrompt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFocalLengthPrompt2.Name = "lblFocalLengthPrompt2";
            this.lblFocalLengthPrompt2.Size = new System.Drawing.Size(76, 23);
            this.lblFocalLengthPrompt2.TabIndex = 0;
            this.lblFocalLengthPrompt2.Tag = "LBL_FOCALLENGTH";
            this.lblFocalLengthPrompt2.Text = "镜头焦距";
            // 
            // lblImageHeightPrompt
            // 
            this.lblImageHeightPrompt.Location = new System.Drawing.Point(22, 150);
            this.lblImageHeightPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageHeightPrompt.Name = "lblImageHeightPrompt";
            this.lblImageHeightPrompt.Size = new System.Drawing.Size(76, 23);
            this.lblImageHeightPrompt.TabIndex = 0;
            this.lblImageHeightPrompt.Tag = "LBL_IMAGEHEIGHT";
            this.lblImageHeightPrompt.Text = "图像高度";
            // 
            // lblImageWidthPrompt
            // 
            this.lblImageWidthPrompt.Location = new System.Drawing.Point(22, 126);
            this.lblImageWidthPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageWidthPrompt.Name = "lblImageWidthPrompt";
            this.lblImageWidthPrompt.Size = new System.Drawing.Size(76, 23);
            this.lblImageWidthPrompt.TabIndex = 0;
            this.lblImageWidthPrompt.Tag = "LBL_IMAGEWIDTH";
            this.lblImageWidthPrompt.Text = "图像宽度";
            // 
            // lblCenterRowPrompt
            // 
            this.lblCenterRowPrompt.Location = new System.Drawing.Point(22, 101);
            this.lblCenterRowPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCenterRowPrompt.Name = "lblCenterRowPrompt";
            this.lblCenterRowPrompt.Size = new System.Drawing.Size(88, 23);
            this.lblCenterRowPrompt.TabIndex = 0;
            this.lblCenterRowPrompt.Tag = "LBL_CENTERROW";
            this.lblCenterRowPrompt.Text = "中心坐标行(Cy)";
            // 
            // lblCenterColPrompt
            // 
            this.lblCenterColPrompt.Location = new System.Drawing.Point(22, 75);
            this.lblCenterColPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCenterColPrompt.Name = "lblCenterColPrompt";
            this.lblCenterColPrompt.Size = new System.Drawing.Size(88, 23);
            this.lblCenterColPrompt.TabIndex = 0;
            this.lblCenterColPrompt.Tag = "LBL_CENTERCOL";
            this.lblCenterColPrompt.Text = "中心坐标列(Cx)";
            // 
            // lblCellHeightPrompt2
            // 
            this.lblCellHeightPrompt2.Location = new System.Drawing.Point(22, 51);
            this.lblCellHeightPrompt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellHeightPrompt2.Name = "lblCellHeightPrompt2";
            this.lblCellHeightPrompt2.Size = new System.Drawing.Size(76, 23);
            this.lblCellHeightPrompt2.TabIndex = 0;
            this.lblCellHeightPrompt2.Tag = "LBL_CELLHEIGHT";
            this.lblCellHeightPrompt2.Text = "像元高度(Sy)";
            // 
            // lblCellWidthPrompt2
            // 
            this.lblCellWidthPrompt2.Location = new System.Drawing.Point(22, 26);
            this.lblCellWidthPrompt2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCellWidthPrompt2.Name = "lblCellWidthPrompt2";
            this.lblCellWidthPrompt2.Size = new System.Drawing.Size(76, 23);
            this.lblCellWidthPrompt2.TabIndex = 0;
            this.lblCellWidthPrompt2.Tag = "LBL_CELLWIDTH";
            this.lblCellWidthPrompt2.Text = "像元宽度(Sx)";
            // 
            // lblMeanError
            // 
            this.lblMeanError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMeanError.Location = new System.Drawing.Point(90, 51);
            this.lblMeanError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMeanError.Name = "lblMeanError";
            this.lblMeanError.Size = new System.Drawing.Size(285, 25);
            this.lblMeanError.TabIndex = 0;
            this.lblMeanError.Text = "标准误差";
            // 
            // lblPixelE
            // 
            this.lblPixelE.Location = new System.Drawing.Point(382, 51);
            this.lblPixelE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelE.Name = "lblPixelE";
            this.lblPixelE.Size = new System.Drawing.Size(64, 25);
            this.lblPixelE.TabIndex = 0;
            this.lblPixelE.Tag = "LBL_PIXEL";
            this.lblPixelE.Text = "像素";
            // 
            // lblErrorPrompt
            // 
            this.lblErrorPrompt.Location = new System.Drawing.Point(15, 51);
            this.lblErrorPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorPrompt.Name = "lblErrorPrompt";
            this.lblErrorPrompt.Size = new System.Drawing.Size(64, 25);
            this.lblErrorPrompt.TabIndex = 0;
            this.lblErrorPrompt.Tag = "LBL_ERROR";
            this.lblErrorPrompt.Text = "标准误差";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(90, 19);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(304, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "结果状态";
            // 
            // lblResultStatusPrompt
            // 
            this.lblResultStatusPrompt.Location = new System.Drawing.Point(15, 19);
            this.lblResultStatusPrompt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultStatusPrompt.Name = "lblResultStatusPrompt";
            this.lblResultStatusPrompt.Size = new System.Drawing.Size(53, 25);
            this.lblResultStatusPrompt.TabIndex = 0;
            this.lblResultStatusPrompt.Tag = "LBL_RESULTSTATUS";
            this.lblResultStatusPrompt.Text = "结果状态";
            // 
            // FrmCalibOnPlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 630);
            this.Controls.Add(this.tblpRoot);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmCalibOnPlate";
            this.Text = "FrmCalibOnPlate";
            this.tblpRoot.ResumeLayout(false);
            this.tblpResultDisplay.ResumeLayout(false);
            this.pResultOption.ResumeLayout(false);
            this.grpbViewOption.ResumeLayout(false);
            this.grpbViewOption.PerformLayout();
            this.grpbDiapalyParameter.ResumeLayout(false);
            this.grpbDiapalyParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnLineWidth)).EndInit();
            this.tbcCalibration.ResumeLayout(false);
            this.tbpImageAndModel.ResumeLayout(false);
            this.grpbCameraSetup.ResumeLayout(false);
            this.grpbCameraSetup.PerformLayout();
            this.pLineScanPreSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMotionVx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnFocalLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnCellHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnCellWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnThickness)).EndInit();
            this.tbpQualityCheck.ResumeLayout(false);
            this.grpbPlateExtractionParameter.ResumeLayout(false);
            this.grpbPlateExtractionParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMaxDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMinContourLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbSmoothFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbThresholdDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbInitThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkMinDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbMarkThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trcbGaussFilterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMaxDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMinContourLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnSmoothFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnThresholdDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnInitThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkMinDiameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMarkThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGaussFilterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnWarnLevel)).EndInit();
            this.tbpResult.ResumeLayout(false);
            this.tbpResult.PerformLayout();
            this.grpbExternalCampara.ResumeLayout(false);
            this.grpbExternalCampara.PerformLayout();
            this.grpbInternalCampara.ResumeLayout(false);
            this.pKappa.ResumeLayout(false);
            this.pLineScanResult.ResumeLayout(false);
            this.pAreaScanPolynormal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblpRoot;
        private System.Windows.Forms.TableLayoutPanel tblpResultDisplay;
        private HalconDotNet.HWindowControl hWndcDisplay;
        private System.Windows.Forms.Panel pResultOption;
        private System.Windows.Forms.Label lblStatusPrompt;
        private System.Windows.Forms.GroupBox grpbViewOption;
        private System.Windows.Forms.GroupBox grpbDiapalyParameter;
        private System.Windows.Forms.ComboBox cmbDrawMode;
        private System.Windows.Forms.Label lblLineWidth;
        private System.Windows.Forms.Label lblDrawMode;
        private System.Windows.Forms.ComboBox cmbCoordinateSystemColor;
        private System.Windows.Forms.ComboBox cmbMarkCenterColor;
        private System.Windows.Forms.ComboBox cmbPlateRegionColor;
        private System.Windows.Forms.CheckBox chkbCoordinateSystem;
        private System.Windows.Forms.CheckBox chkbMarkCenters;
        private System.Windows.Forms.CheckBox chkbPlateRegion;
        private System.Windows.Forms.NumericUpDown numUpDwnLineWidth;
        private System.Windows.Forms.RadioButton rdbtnMagnify;
        private System.Windows.Forms.RadioButton rdbtnZoom;
        private System.Windows.Forms.RadioButton rdbtnMove;
        private System.Windows.Forms.RadioButton rdbtnNone;
        private System.Windows.Forms.TabControl tbcCalibration;
        private System.Windows.Forms.TabPage tbpImageAndModel;
        private System.Windows.Forms.Button btnCalibrateCamera;
        private System.Windows.Forms.Button btnSetReference;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.ListView lstbImages;
        private System.Windows.Forms.ColumnHeader colRef;
        private System.Windows.Forms.ColumnHeader colImage;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.TabPage tbpQualityCheck;
        private System.Windows.Forms.GroupBox grpbCameraSetup;
        private System.Windows.Forms.NumericUpDown numUpDwnThickness;
        private System.Windows.Forms.TextBox txtbDescriptionFile;
        private System.Windows.Forms.Label lblPlateThickness;
        private System.Windows.Forms.Label lblDescriptionFile;
        private System.Windows.Forms.ComboBox cmbCameraType;
        private System.Windows.Forms.Label lblMilliMeterT;
        private System.Windows.Forms.Label lblSpeedZ1;
        private System.Windows.Forms.Label lblSpeedY1;
        private System.Windows.Forms.Label lblSpeedX1;
        private System.Windows.Forms.Label lblFocalLengthPrompt1;
        private System.Windows.Forms.Label lblCellHeightPrompt1;
        private System.Windows.Forms.Label lblCellWidthPrompt1;
        private System.Windows.Forms.Label lblCameraType;
        private System.Windows.Forms.NumericUpDown numUpDwnFocalLength;
        private System.Windows.Forms.NumericUpDown numUpDwnCellHeight;
        private System.Windows.Forms.NumericUpDown numUpDwnCellWidth;
        private System.Windows.Forms.Label lblMicroMeterH;
        private System.Windows.Forms.Label lblMicroMeterW;
        private System.Windows.Forms.CheckBox chkbTelecentric;
        private System.Windows.Forms.NumericUpDown numUpDwnMotionVz;
        private System.Windows.Forms.NumericUpDown numUpDwnMotionVy;
        private System.Windows.Forms.NumericUpDown numUpDwnMotionVx;
        private System.Windows.Forms.Label lblMicroMeterPerPixelZ1;
        private System.Windows.Forms.Label lblMicroMeterPerPixelY1;
        private System.Windows.Forms.Label lblMicroMeterPerPixelX1;
        private System.Windows.Forms.Label lblMilliMeterF;
        private System.Windows.Forms.Button btnResetParameter;
        private System.Windows.Forms.Button btnImportParameter;
        private System.Windows.Forms.Button btnLoadDescriptinFile;
        private System.Windows.Forms.ComboBox cmbImageSetAccuracy;
        private System.Windows.Forms.ComboBox cmbImageAccuracy;
        private System.Windows.Forms.Label lblWarnLevel;
        private System.Windows.Forms.Label lblTestOption;
        private System.Windows.Forms.Label lblImageOption;
        private System.Windows.Forms.ListView lstbQualityCheck;
        private System.Windows.Forms.TabPage tbpResult;
        private System.Windows.Forms.NumericUpDown numUpDwnWarnLevel;
        private System.Windows.Forms.GroupBox grpbPlateExtractionParameter;
        private System.Windows.Forms.NumericUpDown numUpDwnMarkMaxDiameter;
        private System.Windows.Forms.NumericUpDown numUpDwnMarkMinContourLength;
        private System.Windows.Forms.NumericUpDown numUpDwnSmoothFactor;
        private System.Windows.Forms.NumericUpDown numUpDwnMinThreshold;
        private System.Windows.Forms.NumericUpDown numUpDwnThresholdDecrease;
        private System.Windows.Forms.NumericUpDown numUpDwnInitThreshold;
        private System.Windows.Forms.NumericUpDown numUpDwnMarkMinDiameter;
        private System.Windows.Forms.NumericUpDown numUpDwnMarkThreshold;
        private System.Windows.Forms.NumericUpDown numUpDwnGaussFilterSize;
        private System.Windows.Forms.Label lblMarkMaxDiameter;
        private System.Windows.Forms.Label lblMarkMinContourLength;
        private System.Windows.Forms.Label lblSmoothFactor;
        private System.Windows.Forms.Label lblMinThreshold;
        private System.Windows.Forms.Label lblThresholdDecrease;
        private System.Windows.Forms.Label lblInitThreshold;
        private System.Windows.Forms.Label lblMarkMinDiameter;
        private System.Windows.Forms.Label lblMarkThreshold;
        private System.Windows.Forms.Label lblGaussFilterSize;
        private System.Windows.Forms.Button btnMarkMaxDiameter;
        private System.Windows.Forms.Button btnMarkMinContourLength;
        private System.Windows.Forms.Button btnSmoothFactor;
        private System.Windows.Forms.Button btnMinThreshold;
        private System.Windows.Forms.Button btnThresholdDecrease;
        private System.Windows.Forms.Button btnInitThreshold;
        private System.Windows.Forms.Button btnMarkMinDiameter;
        private System.Windows.Forms.Button btnMarkThreshold;
        private System.Windows.Forms.Button btnGaussFilterSize;
        private System.Windows.Forms.TrackBar trcbMarkMaxDiameter;
        private System.Windows.Forms.TrackBar trcbMarkMinContourLength;
        private System.Windows.Forms.TrackBar trcbSmoothFactor;
        private System.Windows.Forms.TrackBar trcbMinThreshold;
        private System.Windows.Forms.TrackBar trcbThresholdDecrease;
        private System.Windows.Forms.TrackBar trcbInitThreshold;
        private System.Windows.Forms.TrackBar trcbMarkMinDiameter;
        private System.Windows.Forms.TrackBar trcbMarkThreshold;
        private System.Windows.Forms.TrackBar trcbGaussFilterSize;
        private System.Windows.Forms.GroupBox grpbExternalCampara;
        private System.Windows.Forms.GroupBox grpbInternalCampara;
        private System.Windows.Forms.Label lblMeanError;
        private System.Windows.Forms.Label lblPixelE;
        private System.Windows.Forms.Label lblErrorPrompt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblResultStatusPrompt;
        private System.Windows.Forms.RadioButton rdbtnSimulatedCoord;
        private System.Windows.Forms.RadioButton rdbtnOriginalCoord;
        private System.Windows.Forms.Label lblPoseX;
        private System.Windows.Forms.Label lblPoseXPrompt;
        private System.Windows.Forms.Label lblDegreeG;
        private System.Windows.Forms.Label lblPoseG;
        private System.Windows.Forms.Label lblPoseGPrompt;
        private System.Windows.Forms.Label lblMilliMeterZ;
        private System.Windows.Forms.Label lblDegreeB;
        private System.Windows.Forms.Label lblPoseZ;
        private System.Windows.Forms.Label lblPoseB;
        private System.Windows.Forms.Label lblPoseZPrompt;
        private System.Windows.Forms.Label lblMilliMeterY;
        private System.Windows.Forms.Label lblPoseBPrompt;
        private System.Windows.Forms.Label lblDegreeA;
        private System.Windows.Forms.Label lblPoseY;
        private System.Windows.Forms.Label lblPoseA;
        private System.Windows.Forms.Label lblPoseYPrompt;
        private System.Windows.Forms.Label lblMilliMeterX;
        private System.Windows.Forms.Label lblPoseAPrompt;
        private System.Windows.Forms.Label lblRadialK3Prompt;
        private System.Windows.Forms.Label lblRadialK2Prompt;
        private System.Windows.Forms.Label lblRadialK1Prompt;
        private System.Windows.Forms.Label lblFocalLengthPrompt2;
        private System.Windows.Forms.Label lblImageHeightPrompt;
        private System.Windows.Forms.Label lblImageWidthPrompt;
        private System.Windows.Forms.Label lblCenterRowPrompt;
        private System.Windows.Forms.Label lblCenterColPrompt;
        private System.Windows.Forms.Label lblCellHeightPrompt2;
        private System.Windows.Forms.Label lblCellWidthPrompt2;
        private System.Windows.Forms.Label lblTangentialP2Prompt;
        private System.Windows.Forms.Label lblTangentialP1Prompt;
        private System.Windows.Forms.Label lblRadialK3;
        private System.Windows.Forms.Label lblRadialK2;
        private System.Windows.Forms.Label lblTangentialP2;
        private System.Windows.Forms.Label lblTangentialP1;
        private System.Windows.Forms.Label lblRadialK1;
        private System.Windows.Forms.Label lblFocalLength;
        private System.Windows.Forms.Label lblImageHeight;
        private System.Windows.Forms.Label lblImageWidth;
        private System.Windows.Forms.Label lblCenterRow;
        private System.Windows.Forms.Label lblCenterCol;
        private System.Windows.Forms.Label lblMeter6K3;
        private System.Windows.Forms.Label lblMeter4K2;
        private System.Windows.Forms.Label lblMeter2P2;
        private System.Windows.Forms.Label lblMeter2P1;
        private System.Windows.Forms.Label lblMeter2K1;
        private System.Windows.Forms.Label lblMilliMeterL;
        private System.Windows.Forms.Label lblPixelIH;
        private System.Windows.Forms.Label lblPixelW;
        private System.Windows.Forms.Label lblPixelCY;
        private System.Windows.Forms.Label lblPixelCX;
        private System.Windows.Forms.Label lblCellHeight;
        private System.Windows.Forms.Label lblCellWidth;
        private System.Windows.Forms.Label lblMicroMeterSY;
        private System.Windows.Forms.Label lblMicroMeterSX;
        private System.Windows.Forms.Button btnSaveExternalParameter;
        private System.Windows.Forms.Button btnSaveInternalParameter;
        private System.Windows.Forms.Panel pLineScanPreSet;
        private System.Windows.Forms.Panel pKappa;
        private System.Windows.Forms.Panel pLineScanResult;
        private System.Windows.Forms.Label lblMicroMeterPerPixelZ2;
        private System.Windows.Forms.Label lblSpeedX2;
        private System.Windows.Forms.Label lblSpeedY2;
        private System.Windows.Forms.Label lblSpeedZ2;
        private System.Windows.Forms.Label lblMicroMeterPerPixelX2;
        private System.Windows.Forms.Label lblMicroMeterPerPixelY2;
        private System.Windows.Forms.Label lblMotionVz;
        private System.Windows.Forms.Label lblMotionVy;
        private System.Windows.Forms.Label lblMotionVx;
        private System.Windows.Forms.Panel pAreaScanPolynormal;
        private System.Windows.Forms.Label lblKappaPrompt;
        private System.Windows.Forms.Label lblKappa;
        private System.Windows.Forms.Label lblMeterKappa;
        private System.Windows.Forms.CheckBox chkbOriginAtImgCorner;
        private System.Windows.Forms.ColumnHeader colScope;
        private System.Windows.Forms.ColumnHeader colDescr;
        private System.Windows.Forms.ColumnHeader colScore;
    }
}