namespace ProVision.Calibration
{
    partial class FrmCalibOnPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalibOnPoint));
            this.tblpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.dtgrdvPointPairList = new System.Windows.Forms.DataGridView();
            this.ColNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAxis1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAxis2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hWndcDisplay = new HalconDotNet.HWindowControl();
            this.pCalibrateOperation = new System.Windows.Forms.Panel();
            this.btnExitCalibration = new System.Windows.Forms.Button();
            this.btnAddCalibrationSolution = new System.Windows.Forms.Button();
            this.btnVerifyCalibration = new System.Windows.Forms.Button();
            this.btnMatchLocation = new System.Windows.Forms.Button();
            this.btnCalculateCalibration = new System.Windows.Forms.Button();
            this.btnSetMatchModel = new System.Windows.Forms.Button();
            this.btnAcquireImage = new System.Windows.Forms.Button();
            this.pFeaturePointAndCalibrateResult = new System.Windows.Forms.Panel();
            this.tbcCalibResult = new System.Windows.Forms.TabControl();
            this.tbpCalibResult = new System.Windows.Forms.TabPage();
            this.grpbCalibrateResult = new System.Windows.Forms.GroupBox();
            this.tblpCalibrateResult = new System.Windows.Forms.TableLayoutPanel();
            this.lblCalibratePixelError = new System.Windows.Forms.Label();
            this.txtbHorizontalScale = new System.Windows.Forms.TextBox();
            this.lblHorizontalScale = new System.Windows.Forms.Label();
            this.lblRotateAngle = new System.Windows.Forms.Label();
            this.lblHorizontalTranslate = new System.Windows.Forms.Label();
            this.lblVerticalScale = new System.Windows.Forms.Label();
            this.lblChamferAngle = new System.Windows.Forms.Label();
            this.lblVerticalTranslate = new System.Windows.Forms.Label();
            this.txtbRotateAngle = new System.Windows.Forms.TextBox();
            this.txtbHorizontalTranslate = new System.Windows.Forms.TextBox();
            this.txtbVerticalTranslate = new System.Windows.Forms.TextBox();
            this.txtbChamferAngle = new System.Windows.Forms.TextBox();
            this.txtbVerticalScale = new System.Windows.Forms.TextBox();
            this.lblPhysicalError = new System.Windows.Forms.Label();
            this.txtbPixelError = new System.Windows.Forms.TextBox();
            this.txtbPhysicalError = new System.Windows.Forms.TextBox();
            this.grpbFeaturePoint = new System.Windows.Forms.GroupBox();
            this.lblImgPositionC = new System.Windows.Forms.Label();
            this.lblPixelCoordPrompt = new System.Windows.Forms.Label();
            this.lblWldPositionY = new System.Windows.Forms.Label();
            this.lblImgPositionR = new System.Windows.Forms.Label();
            this.lblMechCoordPrompt = new System.Windows.Forms.Label();
            this.lblWldPositionX = new System.Windows.Forms.Label();
            this.chkbEnableVerifyCross = new System.Windows.Forms.CheckBox();
            this.chkbAcquisitionMode = new System.Windows.Forms.CheckBox();
            this.nmupdwnPositionStep = new System.Windows.Forms.NumericUpDown();
            this.lblPositionStep = new System.Windows.Forms.Label();
            this.rdbtnMobileFeaturePoint = new System.Windows.Forms.RadioButton();
            this.rdbtnFixedFeaturePoint = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkbEnableToolOffset = new System.Windows.Forms.CheckBox();
            this.btnToolOffset = new System.Windows.Forms.Button();
            this.numUpDwnAngleStep = new System.Windows.Forms.NumericUpDown();
            this.lblToolOffsetY = new System.Windows.Forms.Label();
            this.lblYCoord3 = new System.Windows.Forms.Label();
            this.lblToolOffsetX = new System.Windows.Forms.Label();
            this.lblYCoord2 = new System.Windows.Forms.Label();
            this.lblXCoord3 = new System.Windows.Forms.Label();
            this.lblYCoord1 = new System.Windows.Forms.Label();
            this.lblXCoord2 = new System.Windows.Forms.Label();
            this.lblXCoord1 = new System.Windows.Forms.Label();
            this.lblYPrompt = new System.Windows.Forms.Label();
            this.lblXPrompt = new System.Windows.Forms.Label();
            this.lblToolOffsetPrompt = new System.Windows.Forms.Label();
            this.lblAngleStep = new System.Windows.Forms.Label();
            this.lblCirclePointPrompt3 = new System.Windows.Forms.Label();
            this.lblCirclePointPrompt2 = new System.Windows.Forms.Label();
            this.lblCirclePointPrompt1 = new System.Windows.Forms.Label();
            this.ststrpOperation = new System.Windows.Forms.StatusStrip();
            this.tlstrpstlblOperation = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvPointPairList)).BeginInit();
            this.pCalibrateOperation.SuspendLayout();
            this.pFeaturePointAndCalibrateResult.SuspendLayout();
            this.tbcCalibResult.SuspendLayout();
            this.tbpCalibResult.SuspendLayout();
            this.grpbCalibrateResult.SuspendLayout();
            this.tblpCalibrateResult.SuspendLayout();
            this.grpbFeaturePoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmupdwnPositionStep)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleStep)).BeginInit();
            this.ststrpOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblpRoot
            // 
            resources.ApplyResources(this.tblpRoot, "tblpRoot");
            this.tblpRoot.Controls.Add(this.dtgrdvPointPairList, 0, 1);
            this.tblpRoot.Controls.Add(this.hWndcDisplay, 0, 0);
            this.tblpRoot.Controls.Add(this.pCalibrateOperation, 1, 1);
            this.tblpRoot.Controls.Add(this.pFeaturePointAndCalibrateResult, 1, 0);
            this.tblpRoot.Name = "tblpRoot";
            // 
            // dtgrdvPointPairList
            // 
            this.dtgrdvPointPairList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdvPointPairList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNo,
            this.ColRow,
            this.ColCol,
            this.ColAxis1,
            this.ColAxis2});
            resources.ApplyResources(this.dtgrdvPointPairList, "dtgrdvPointPairList");
            this.dtgrdvPointPairList.Name = "dtgrdvPointPairList";
            this.dtgrdvPointPairList.RowTemplate.Height = 27;
            // 
            // ColNo
            // 
            resources.ApplyResources(this.ColNo, "ColNo");
            this.ColNo.Name = "ColNo";
            this.ColNo.ReadOnly = true;
            // 
            // ColRow
            // 
            resources.ApplyResources(this.ColRow, "ColRow");
            this.ColRow.Name = "ColRow";
            this.ColRow.ReadOnly = true;
            // 
            // ColCol
            // 
            resources.ApplyResources(this.ColCol, "ColCol");
            this.ColCol.Name = "ColCol";
            this.ColCol.ReadOnly = true;
            // 
            // ColAxis1
            // 
            resources.ApplyResources(this.ColAxis1, "ColAxis1");
            this.ColAxis1.Name = "ColAxis1";
            // 
            // ColAxis2
            // 
            resources.ApplyResources(this.ColAxis2, "ColAxis2");
            this.ColAxis2.Name = "ColAxis2";
            // 
            // hWndcDisplay
            // 
            this.hWndcDisplay.BackColor = System.Drawing.Color.Salmon;
            this.hWndcDisplay.BorderColor = System.Drawing.Color.Salmon;
            resources.ApplyResources(this.hWndcDisplay, "hWndcDisplay");
            this.hWndcDisplay.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndcDisplay.Name = "hWndcDisplay";
            this.hWndcDisplay.WindowSize = new System.Drawing.Size(459, 363);
            // 
            // pCalibrateOperation
            // 
            this.pCalibrateOperation.Controls.Add(this.btnExitCalibration);
            this.pCalibrateOperation.Controls.Add(this.btnAddCalibrationSolution);
            this.pCalibrateOperation.Controls.Add(this.btnVerifyCalibration);
            this.pCalibrateOperation.Controls.Add(this.btnMatchLocation);
            this.pCalibrateOperation.Controls.Add(this.btnCalculateCalibration);
            this.pCalibrateOperation.Controls.Add(this.btnSetMatchModel);
            this.pCalibrateOperation.Controls.Add(this.btnAcquireImage);
            resources.ApplyResources(this.pCalibrateOperation, "pCalibrateOperation");
            this.pCalibrateOperation.Name = "pCalibrateOperation";
            // 
            // btnExitCalibration
            // 
            resources.ApplyResources(this.btnExitCalibration, "btnExitCalibration");
            this.btnExitCalibration.Name = "btnExitCalibration";
            this.btnExitCalibration.Tag = "BTN_EXITCALIBRATION";
            this.btnExitCalibration.UseVisualStyleBackColor = true;
            // 
            // btnAddCalibrationSolution
            // 
            resources.ApplyResources(this.btnAddCalibrationSolution, "btnAddCalibrationSolution");
            this.btnAddCalibrationSolution.Name = "btnAddCalibrationSolution";
            this.btnAddCalibrationSolution.Tag = "BTN_ADDCALIBRATIONSOLUTION";
            this.btnAddCalibrationSolution.UseVisualStyleBackColor = true;
            // 
            // btnVerifyCalibration
            // 
            resources.ApplyResources(this.btnVerifyCalibration, "btnVerifyCalibration");
            this.btnVerifyCalibration.Name = "btnVerifyCalibration";
            this.btnVerifyCalibration.Tag = "BTN_VARIFYCALIBRATION";
            this.btnVerifyCalibration.UseVisualStyleBackColor = true;
            // 
            // btnMatchLocation
            // 
            resources.ApplyResources(this.btnMatchLocation, "btnMatchLocation");
            this.btnMatchLocation.Name = "btnMatchLocation";
            this.btnMatchLocation.Tag = "BTN_MATCHLOCATION";
            this.btnMatchLocation.UseVisualStyleBackColor = true;
            // 
            // btnCalculateCalibration
            // 
            resources.ApplyResources(this.btnCalculateCalibration, "btnCalculateCalibration");
            this.btnCalculateCalibration.Name = "btnCalculateCalibration";
            this.btnCalculateCalibration.Tag = "BTN_CALCULATECALIBRATION";
            this.btnCalculateCalibration.UseVisualStyleBackColor = true;
            // 
            // btnSetMatchModel
            // 
            resources.ApplyResources(this.btnSetMatchModel, "btnSetMatchModel");
            this.btnSetMatchModel.Name = "btnSetMatchModel";
            this.btnSetMatchModel.Tag = "BTN_SETMATCHMODEL";
            this.btnSetMatchModel.UseVisualStyleBackColor = true;
            // 
            // btnAcquireImage
            // 
            resources.ApplyResources(this.btnAcquireImage, "btnAcquireImage");
            this.btnAcquireImage.Name = "btnAcquireImage";
            this.btnAcquireImage.Tag = "BTN_ACQUIREIMAGE";
            this.btnAcquireImage.UseVisualStyleBackColor = true;
            // 
            // pFeaturePointAndCalibrateResult
            // 
            this.pFeaturePointAndCalibrateResult.Controls.Add(this.tbcCalibResult);
            resources.ApplyResources(this.pFeaturePointAndCalibrateResult, "pFeaturePointAndCalibrateResult");
            this.pFeaturePointAndCalibrateResult.Name = "pFeaturePointAndCalibrateResult";
            // 
            // tbcCalibResult
            // 
            this.tbcCalibResult.Controls.Add(this.tbpCalibResult);
            this.tbcCalibResult.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tbcCalibResult, "tbcCalibResult");
            this.tbcCalibResult.Name = "tbcCalibResult";
            this.tbcCalibResult.SelectedIndex = 0;
            // 
            // tbpCalibResult
            // 
            this.tbpCalibResult.Controls.Add(this.grpbCalibrateResult);
            this.tbpCalibResult.Controls.Add(this.grpbFeaturePoint);
            resources.ApplyResources(this.tbpCalibResult, "tbpCalibResult");
            this.tbpCalibResult.Name = "tbpCalibResult";
            this.tbpCalibResult.Tag = "TBP_CALIBRESULT";
            this.tbpCalibResult.UseVisualStyleBackColor = true;
            // 
            // grpbCalibrateResult
            // 
            this.grpbCalibrateResult.Controls.Add(this.tblpCalibrateResult);
            resources.ApplyResources(this.grpbCalibrateResult, "grpbCalibrateResult");
            this.grpbCalibrateResult.Name = "grpbCalibrateResult";
            this.grpbCalibrateResult.TabStop = false;
            this.grpbCalibrateResult.Tag = "GRPB_CALIBRATERESULT";
            // 
            // tblpCalibrateResult
            // 
            resources.ApplyResources(this.tblpCalibrateResult, "tblpCalibrateResult");
            this.tblpCalibrateResult.Controls.Add(this.lblCalibratePixelError, 0, 3);
            this.tblpCalibrateResult.Controls.Add(this.txtbHorizontalScale, 1, 0);
            this.tblpCalibrateResult.Controls.Add(this.lblHorizontalScale, 0, 0);
            this.tblpCalibrateResult.Controls.Add(this.lblRotateAngle, 0, 1);
            this.tblpCalibrateResult.Controls.Add(this.lblHorizontalTranslate, 0, 2);
            this.tblpCalibrateResult.Controls.Add(this.lblVerticalScale, 2, 0);
            this.tblpCalibrateResult.Controls.Add(this.lblChamferAngle, 2, 1);
            this.tblpCalibrateResult.Controls.Add(this.lblVerticalTranslate, 2, 2);
            this.tblpCalibrateResult.Controls.Add(this.txtbRotateAngle, 1, 1);
            this.tblpCalibrateResult.Controls.Add(this.txtbHorizontalTranslate, 1, 2);
            this.tblpCalibrateResult.Controls.Add(this.txtbVerticalTranslate, 3, 2);
            this.tblpCalibrateResult.Controls.Add(this.txtbChamferAngle, 3, 1);
            this.tblpCalibrateResult.Controls.Add(this.txtbVerticalScale, 3, 0);
            this.tblpCalibrateResult.Controls.Add(this.lblPhysicalError, 2, 3);
            this.tblpCalibrateResult.Controls.Add(this.txtbPixelError, 1, 3);
            this.tblpCalibrateResult.Controls.Add(this.txtbPhysicalError, 3, 3);
            this.tblpCalibrateResult.Name = "tblpCalibrateResult";
            // 
            // lblCalibratePixelError
            // 
            resources.ApplyResources(this.lblCalibratePixelError, "lblCalibratePixelError");
            this.lblCalibratePixelError.Name = "lblCalibratePixelError";
            this.lblCalibratePixelError.Tag = "LBL_CALIBRATEPIXELERROR";
            // 
            // txtbHorizontalScale
            // 
            resources.ApplyResources(this.txtbHorizontalScale, "txtbHorizontalScale");
            this.txtbHorizontalScale.Name = "txtbHorizontalScale";
            this.txtbHorizontalScale.ReadOnly = true;
            // 
            // lblHorizontalScale
            // 
            resources.ApplyResources(this.lblHorizontalScale, "lblHorizontalScale");
            this.lblHorizontalScale.Name = "lblHorizontalScale";
            this.lblHorizontalScale.Tag = "LBL_SCALEX";
            // 
            // lblRotateAngle
            // 
            resources.ApplyResources(this.lblRotateAngle, "lblRotateAngle");
            this.lblRotateAngle.Name = "lblRotateAngle";
            this.lblRotateAngle.Tag = "LBL_ROTATEANGLE";
            // 
            // lblHorizontalTranslate
            // 
            resources.ApplyResources(this.lblHorizontalTranslate, "lblHorizontalTranslate");
            this.lblHorizontalTranslate.Name = "lblHorizontalTranslate";
            this.lblHorizontalTranslate.Tag = "LBL_TRANSLATEX";
            // 
            // lblVerticalScale
            // 
            resources.ApplyResources(this.lblVerticalScale, "lblVerticalScale");
            this.lblVerticalScale.Name = "lblVerticalScale";
            this.lblVerticalScale.Tag = "LBL_SCALEY";
            // 
            // lblChamferAngle
            // 
            resources.ApplyResources(this.lblChamferAngle, "lblChamferAngle");
            this.lblChamferAngle.Name = "lblChamferAngle";
            this.lblChamferAngle.Tag = "LBL_CHAMFERANGLE";
            // 
            // lblVerticalTranslate
            // 
            resources.ApplyResources(this.lblVerticalTranslate, "lblVerticalTranslate");
            this.lblVerticalTranslate.Name = "lblVerticalTranslate";
            this.lblVerticalTranslate.Tag = "LBL_TRANSLATEY";
            // 
            // txtbRotateAngle
            // 
            resources.ApplyResources(this.txtbRotateAngle, "txtbRotateAngle");
            this.txtbRotateAngle.Name = "txtbRotateAngle";
            this.txtbRotateAngle.ReadOnly = true;
            // 
            // txtbHorizontalTranslate
            // 
            resources.ApplyResources(this.txtbHorizontalTranslate, "txtbHorizontalTranslate");
            this.txtbHorizontalTranslate.Name = "txtbHorizontalTranslate";
            this.txtbHorizontalTranslate.ReadOnly = true;
            // 
            // txtbVerticalTranslate
            // 
            resources.ApplyResources(this.txtbVerticalTranslate, "txtbVerticalTranslate");
            this.txtbVerticalTranslate.Name = "txtbVerticalTranslate";
            this.txtbVerticalTranslate.ReadOnly = true;
            // 
            // txtbChamferAngle
            // 
            resources.ApplyResources(this.txtbChamferAngle, "txtbChamferAngle");
            this.txtbChamferAngle.Name = "txtbChamferAngle";
            this.txtbChamferAngle.ReadOnly = true;
            // 
            // txtbVerticalScale
            // 
            resources.ApplyResources(this.txtbVerticalScale, "txtbVerticalScale");
            this.txtbVerticalScale.Name = "txtbVerticalScale";
            this.txtbVerticalScale.ReadOnly = true;
            // 
            // lblPhysicalError
            // 
            resources.ApplyResources(this.lblPhysicalError, "lblPhysicalError");
            this.lblPhysicalError.Name = "lblPhysicalError";
            this.lblPhysicalError.Tag = "LBL_CALIBRATEPHYSICALERROR";
            // 
            // txtbPixelError
            // 
            resources.ApplyResources(this.txtbPixelError, "txtbPixelError");
            this.txtbPixelError.Name = "txtbPixelError";
            this.txtbPixelError.ReadOnly = true;
            // 
            // txtbPhysicalError
            // 
            resources.ApplyResources(this.txtbPhysicalError, "txtbPhysicalError");
            this.txtbPhysicalError.Name = "txtbPhysicalError";
            this.txtbPhysicalError.ReadOnly = true;
            // 
            // grpbFeaturePoint
            // 
            this.grpbFeaturePoint.Controls.Add(this.lblImgPositionC);
            this.grpbFeaturePoint.Controls.Add(this.lblPixelCoordPrompt);
            this.grpbFeaturePoint.Controls.Add(this.lblWldPositionY);
            this.grpbFeaturePoint.Controls.Add(this.lblImgPositionR);
            this.grpbFeaturePoint.Controls.Add(this.lblMechCoordPrompt);
            this.grpbFeaturePoint.Controls.Add(this.lblWldPositionX);
            this.grpbFeaturePoint.Controls.Add(this.chkbEnableVerifyCross);
            this.grpbFeaturePoint.Controls.Add(this.chkbAcquisitionMode);
            this.grpbFeaturePoint.Controls.Add(this.nmupdwnPositionStep);
            this.grpbFeaturePoint.Controls.Add(this.lblPositionStep);
            this.grpbFeaturePoint.Controls.Add(this.rdbtnMobileFeaturePoint);
            this.grpbFeaturePoint.Controls.Add(this.rdbtnFixedFeaturePoint);
            resources.ApplyResources(this.grpbFeaturePoint, "grpbFeaturePoint");
            this.grpbFeaturePoint.Name = "grpbFeaturePoint";
            this.grpbFeaturePoint.TabStop = false;
            this.grpbFeaturePoint.Tag = "GRPB_FEATUREPOINTTYPE";
            // 
            // lblImgPositionC
            // 
            resources.ApplyResources(this.lblImgPositionC, "lblImgPositionC");
            this.lblImgPositionC.Name = "lblImgPositionC";
            // 
            // lblPixelCoordPrompt
            // 
            resources.ApplyResources(this.lblPixelCoordPrompt, "lblPixelCoordPrompt");
            this.lblPixelCoordPrompt.Name = "lblPixelCoordPrompt";
            this.lblPixelCoordPrompt.Tag = "LBL_PIXCOORDPROMPT";
            // 
            // lblWldPositionY
            // 
            resources.ApplyResources(this.lblWldPositionY, "lblWldPositionY");
            this.lblWldPositionY.Name = "lblWldPositionY";
            // 
            // lblImgPositionR
            // 
            resources.ApplyResources(this.lblImgPositionR, "lblImgPositionR");
            this.lblImgPositionR.Name = "lblImgPositionR";
            // 
            // lblMechCoordPrompt
            // 
            resources.ApplyResources(this.lblMechCoordPrompt, "lblMechCoordPrompt");
            this.lblMechCoordPrompt.Name = "lblMechCoordPrompt";
            this.lblMechCoordPrompt.Tag = "LBL_MECHCOORDPROMPT";
            // 
            // lblWldPositionX
            // 
            resources.ApplyResources(this.lblWldPositionX, "lblWldPositionX");
            this.lblWldPositionX.Name = "lblWldPositionX";
            // 
            // chkbEnableVerifyCross
            // 
            resources.ApplyResources(this.chkbEnableVerifyCross, "chkbEnableVerifyCross");
            this.chkbEnableVerifyCross.Name = "chkbEnableVerifyCross";
            this.chkbEnableVerifyCross.Tag = "CHKB_ENABLEVERIDYCROSS";
            this.chkbEnableVerifyCross.UseVisualStyleBackColor = true;
            // 
            // chkbAcquisitionMode
            // 
            resources.ApplyResources(this.chkbAcquisitionMode, "chkbAcquisitionMode");
            this.chkbAcquisitionMode.Name = "chkbAcquisitionMode";
            this.chkbAcquisitionMode.Tag = "CHKB_ACQUIRECONTINUE";
            this.chkbAcquisitionMode.UseVisualStyleBackColor = true;
            // 
            // nmupdwnPositionStep
            // 
            this.nmupdwnPositionStep.DecimalPlaces = 2;
            this.nmupdwnPositionStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            resources.ApplyResources(this.nmupdwnPositionStep, "nmupdwnPositionStep");
            this.nmupdwnPositionStep.Name = "nmupdwnPositionStep";
            // 
            // lblPositionStep
            // 
            resources.ApplyResources(this.lblPositionStep, "lblPositionStep");
            this.lblPositionStep.Name = "lblPositionStep";
            this.lblPositionStep.Tag = "LBL_POSITIONSTEP";
            // 
            // rdbtnMobileFeaturePoint
            // 
            resources.ApplyResources(this.rdbtnMobileFeaturePoint, "rdbtnMobileFeaturePoint");
            this.rdbtnMobileFeaturePoint.Name = "rdbtnMobileFeaturePoint";
            this.rdbtnMobileFeaturePoint.TabStop = true;
            this.rdbtnMobileFeaturePoint.Tag = "RDBTN_MOBILEPOINT";
            this.rdbtnMobileFeaturePoint.UseVisualStyleBackColor = true;
            // 
            // rdbtnFixedFeaturePoint
            // 
            resources.ApplyResources(this.rdbtnFixedFeaturePoint, "rdbtnFixedFeaturePoint");
            this.rdbtnFixedFeaturePoint.Name = "rdbtnFixedFeaturePoint";
            this.rdbtnFixedFeaturePoint.TabStop = true;
            this.rdbtnFixedFeaturePoint.Tag = "RDBTN_FIXEDPOINT";
            this.rdbtnFixedFeaturePoint.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkbEnableToolOffset);
            this.tabPage2.Controls.Add(this.btnToolOffset);
            this.tabPage2.Controls.Add(this.numUpDwnAngleStep);
            this.tabPage2.Controls.Add(this.lblToolOffsetY);
            this.tabPage2.Controls.Add(this.lblYCoord3);
            this.tabPage2.Controls.Add(this.lblToolOffsetX);
            this.tabPage2.Controls.Add(this.lblYCoord2);
            this.tabPage2.Controls.Add(this.lblXCoord3);
            this.tabPage2.Controls.Add(this.lblYCoord1);
            this.tabPage2.Controls.Add(this.lblXCoord2);
            this.tabPage2.Controls.Add(this.lblXCoord1);
            this.tabPage2.Controls.Add(this.lblYPrompt);
            this.tabPage2.Controls.Add(this.lblXPrompt);
            this.tabPage2.Controls.Add(this.lblToolOffsetPrompt);
            this.tabPage2.Controls.Add(this.lblAngleStep);
            this.tabPage2.Controls.Add(this.lblCirclePointPrompt3);
            this.tabPage2.Controls.Add(this.lblCirclePointPrompt2);
            this.tabPage2.Controls.Add(this.lblCirclePointPrompt1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Tag = "TBP_TOOLCENTER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkbEnableToolOffset
            // 
            resources.ApplyResources(this.chkbEnableToolOffset, "chkbEnableToolOffset");
            this.chkbEnableToolOffset.Name = "chkbEnableToolOffset";
            this.chkbEnableToolOffset.Tag = "CHKB_ENABLETOOLOFFSET";
            this.chkbEnableToolOffset.UseVisualStyleBackColor = true;
            // 
            // btnToolOffset
            // 
            resources.ApplyResources(this.btnToolOffset, "btnToolOffset");
            this.btnToolOffset.Name = "btnToolOffset";
            this.btnToolOffset.Tag = "BTN_TOOLOFFSET";
            this.btnToolOffset.UseVisualStyleBackColor = true;
            // 
            // numUpDwnAngleStep
            // 
            this.numUpDwnAngleStep.DecimalPlaces = 2;
            resources.ApplyResources(this.numUpDwnAngleStep, "numUpDwnAngleStep");
            this.numUpDwnAngleStep.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numUpDwnAngleStep.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numUpDwnAngleStep.Name = "numUpDwnAngleStep";
            // 
            // lblToolOffsetY
            // 
            this.lblToolOffsetY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblToolOffsetY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblToolOffsetY, "lblToolOffsetY");
            this.lblToolOffsetY.Name = "lblToolOffsetY";
            // 
            // lblYCoord3
            // 
            this.lblYCoord3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYCoord3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblYCoord3, "lblYCoord3");
            this.lblYCoord3.Name = "lblYCoord3";
            // 
            // lblToolOffsetX
            // 
            this.lblToolOffsetX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblToolOffsetX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblToolOffsetX, "lblToolOffsetX");
            this.lblToolOffsetX.Name = "lblToolOffsetX";
            // 
            // lblYCoord2
            // 
            this.lblYCoord2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYCoord2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblYCoord2, "lblYCoord2");
            this.lblYCoord2.Name = "lblYCoord2";
            // 
            // lblXCoord3
            // 
            this.lblXCoord3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblXCoord3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblXCoord3, "lblXCoord3");
            this.lblXCoord3.Name = "lblXCoord3";
            // 
            // lblYCoord1
            // 
            this.lblYCoord1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYCoord1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblYCoord1, "lblYCoord1");
            this.lblYCoord1.Name = "lblYCoord1";
            // 
            // lblXCoord2
            // 
            this.lblXCoord2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblXCoord2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblXCoord2, "lblXCoord2");
            this.lblXCoord2.Name = "lblXCoord2";
            // 
            // lblXCoord1
            // 
            this.lblXCoord1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblXCoord1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.lblXCoord1, "lblXCoord1");
            this.lblXCoord1.Name = "lblXCoord1";
            // 
            // lblYPrompt
            // 
            resources.ApplyResources(this.lblYPrompt, "lblYPrompt");
            this.lblYPrompt.Name = "lblYPrompt";
            this.lblYPrompt.Tag = "LBL_YPROMPT";
            // 
            // lblXPrompt
            // 
            resources.ApplyResources(this.lblXPrompt, "lblXPrompt");
            this.lblXPrompt.Name = "lblXPrompt";
            this.lblXPrompt.Tag = "LBL_XPROMPT";
            // 
            // lblToolOffsetPrompt
            // 
            resources.ApplyResources(this.lblToolOffsetPrompt, "lblToolOffsetPrompt");
            this.lblToolOffsetPrompt.Name = "lblToolOffsetPrompt";
            this.lblToolOffsetPrompt.Tag = "LBL_TOOLOFFSETPROMPT";
            // 
            // lblAngleStep
            // 
            resources.ApplyResources(this.lblAngleStep, "lblAngleStep");
            this.lblAngleStep.Name = "lblAngleStep";
            this.lblAngleStep.Tag = "LBL_ANGLESTEP";
            // 
            // lblCirclePointPrompt3
            // 
            resources.ApplyResources(this.lblCirclePointPrompt3, "lblCirclePointPrompt3");
            this.lblCirclePointPrompt3.Name = "lblCirclePointPrompt3";
            this.lblCirclePointPrompt3.Tag = "LBL_CIRCLEPOINT1";
            // 
            // lblCirclePointPrompt2
            // 
            resources.ApplyResources(this.lblCirclePointPrompt2, "lblCirclePointPrompt2");
            this.lblCirclePointPrompt2.Name = "lblCirclePointPrompt2";
            this.lblCirclePointPrompt2.Tag = "LBL_CIRCLEPOINT1";
            // 
            // lblCirclePointPrompt1
            // 
            resources.ApplyResources(this.lblCirclePointPrompt1, "lblCirclePointPrompt1");
            this.lblCirclePointPrompt1.Name = "lblCirclePointPrompt1";
            this.lblCirclePointPrompt1.Tag = "LBL_CIRCLEPOINT1";
            // 
            // ststrpOperation
            // 
            this.ststrpOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ststrpOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpstlblOperation});
            resources.ApplyResources(this.ststrpOperation, "ststrpOperation");
            this.ststrpOperation.Name = "ststrpOperation";
            // 
            // tlstrpstlblOperation
            // 
            this.tlstrpstlblOperation.Name = "tlstrpstlblOperation";
            resources.ApplyResources(this.tlstrpstlblOperation, "tlstrpstlblOperation");
            // 
            // FrmCalibOnPoint
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ststrpOperation);
            this.Controls.Add(this.tblpRoot);
            this.Name = "FrmCalibOnPoint";
            this.Tag = "FRM_CALIBRATEPOINTBASED";
            this.tblpRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdvPointPairList)).EndInit();
            this.pCalibrateOperation.ResumeLayout(false);
            this.pFeaturePointAndCalibrateResult.ResumeLayout(false);
            this.tbcCalibResult.ResumeLayout(false);
            this.tbpCalibResult.ResumeLayout(false);
            this.grpbCalibrateResult.ResumeLayout(false);
            this.tblpCalibrateResult.ResumeLayout(false);
            this.tblpCalibrateResult.PerformLayout();
            this.grpbFeaturePoint.ResumeLayout(false);
            this.grpbFeaturePoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmupdwnPositionStep)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleStep)).EndInit();
            this.ststrpOperation.ResumeLayout(false);
            this.ststrpOperation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.TableLayoutPanel tblpRoot;
        protected internal System.Windows.Forms.DataGridView dtgrdvPointPairList;
        protected internal System.Windows.Forms.GroupBox grpbFeaturePoint;
        protected internal System.Windows.Forms.TableLayoutPanel tblpCalibrateResult;
        protected internal System.Windows.Forms.Panel pFeaturePointAndCalibrateResult;
        protected internal System.Windows.Forms.GroupBox grpbCalibrateResult;
        protected internal System.Windows.Forms.RadioButton rdbtnFixedFeaturePoint;
        protected internal System.Windows.Forms.RadioButton rdbtnMobileFeaturePoint;
        protected internal System.Windows.Forms.Label lblPositionStep;
        protected internal System.Windows.Forms.Label lblHorizontalScale;
        protected internal System.Windows.Forms.Label lblVerticalScale;
        protected internal System.Windows.Forms.Label lblHorizontalTranslate;
        protected internal System.Windows.Forms.Label lblRotateAngle;
        protected internal System.Windows.Forms.Label lblChamferAngle;
        protected internal System.Windows.Forms.Label lblVerticalTranslate;
        protected internal System.Windows.Forms.TextBox txtbHorizontalScale;
        protected internal System.Windows.Forms.TextBox txtbRotateAngle;
        protected internal System.Windows.Forms.TextBox txtbHorizontalTranslate;
        protected internal System.Windows.Forms.TextBox txtbVerticalTranslate;
        protected internal System.Windows.Forms.TextBox txtbChamferAngle;
        protected internal System.Windows.Forms.TextBox txtbVerticalScale;
        protected internal System.Windows.Forms.Panel pCalibrateOperation;
        protected internal System.Windows.Forms.Button btnAcquireImage;
        protected internal System.Windows.Forms.Button btnMatchLocation;
        protected internal System.Windows.Forms.Button btnSetMatchModel;
        protected internal System.Windows.Forms.Button btnAddCalibrationSolution;
        protected internal System.Windows.Forms.Button btnVerifyCalibration;
        protected internal System.Windows.Forms.Button btnCalculateCalibration;
        protected internal System.Windows.Forms.Button btnExitCalibration;
        protected internal System.Windows.Forms.Label lblCalibratePixelError;
        protected internal System.Windows.Forms.Label lblPhysicalError;
        protected internal System.Windows.Forms.TextBox txtbPixelError;
        protected internal System.Windows.Forms.TextBox txtbPhysicalError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAxis1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAxis2;
        protected internal System.Windows.Forms.StatusStrip ststrpOperation;
        protected internal System.Windows.Forms.ToolStripStatusLabel tlstrpstlblOperation;
        protected internal System.Windows.Forms.CheckBox chkbAcquisitionMode;
        protected internal System.Windows.Forms.CheckBox chkbEnableVerifyCross;
        protected internal System.Windows.Forms.Button btnToolOffset;
        public HalconDotNet.HWindowControl hWndcDisplay;
        protected internal System.Windows.Forms.Label lblWldPositionY;
        protected internal System.Windows.Forms.Label lblWldPositionX;
        protected internal System.Windows.Forms.Label lblMechCoordPrompt;
        protected internal System.Windows.Forms.TabControl tbcCalibResult;
        protected internal System.Windows.Forms.TabPage tbpCalibResult;
        private System.Windows.Forms.TabPage tabPage2;
        protected internal System.Windows.Forms.Label lblYCoord3;
        protected internal System.Windows.Forms.Label lblYCoord2;
        protected internal System.Windows.Forms.Label lblXCoord3;
        protected internal System.Windows.Forms.Label lblYCoord1;
        protected internal System.Windows.Forms.Label lblXCoord2;
        protected internal System.Windows.Forms.Label lblXCoord1;
        protected internal System.Windows.Forms.Label lblYPrompt;
        protected internal System.Windows.Forms.Label lblXPrompt;
        protected internal System.Windows.Forms.Label lblCirclePointPrompt3;
        protected internal System.Windows.Forms.Label lblCirclePointPrompt2;
        protected internal System.Windows.Forms.Label lblCirclePointPrompt1;
        protected internal System.Windows.Forms.Label lblAngleStep;
        protected internal System.Windows.Forms.NumericUpDown nmupdwnPositionStep;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnAngleStep;
        protected internal System.Windows.Forms.Label lblToolOffsetY;
        protected internal System.Windows.Forms.Label lblToolOffsetX;
        protected internal System.Windows.Forms.Label lblToolOffsetPrompt;
        protected internal System.Windows.Forms.CheckBox chkbEnableToolOffset;
        protected internal System.Windows.Forms.Label lblImgPositionC;
        protected internal System.Windows.Forms.Label lblPixelCoordPrompt;
        protected internal System.Windows.Forms.Label lblImgPositionR;
    }
}