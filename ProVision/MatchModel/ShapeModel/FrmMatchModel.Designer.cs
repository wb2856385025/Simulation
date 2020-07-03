namespace ProVision.MatchModel
{
    partial class FrmMatchModel
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatchModel));
            this.spltRoot = new System.Windows.Forms.SplitContainer();
            this.spltOperation = new System.Windows.Forms.SplitContainer();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.cmbEraseOption = new System.Windows.Forms.ComboBox();
            this.numUpDwnHysteresisHigh = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnHysteresisLow = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnFilterAlpha = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.chkbFillErase = new System.Windows.Forms.CheckBox();
            this.chkbBrushShape = new System.Windows.Forms.CheckBox();
            this.chkbBrushOnOff = new System.Windows.Forms.CheckBox();
            this.cmbModelType = new System.Windows.Forms.ComboBox();
            this.cmbOptionLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEraseOption = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lblFilterAlpahPrompt = new System.Windows.Forms.Label();
            this.lblOperationLevel = new System.Windows.Forms.Label();
            this.btnClearModel = new System.Windows.Forms.Button();
            this.btnSaveMatchModel = new System.Windows.Forms.Button();
            this.btnRecreateModel = new System.Windows.Forms.Button();
            this.btnEraseRegion = new System.Windows.Forms.Button();
            this.btnApplyModel = new System.Windows.Forms.Button();
            this.btnCreateMatchModel = new System.Windows.Forms.Button();
            this.btnGenerateExtractRegion = new System.Windows.Forms.Button();
            this.btnGenerateSearchRegion = new System.Windows.Forms.Button();
            this.spltViewResult = new System.Windows.Forms.SplitContainer();
            this.lblCoordinateGrayValue = new System.Windows.Forms.Label();
            this.hWndcDisplay = new HalconDotNet.HWindowControl();
            this.ctxmstrpHwndDisplay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlstrpmiLoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiLoadModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpspOperationArray = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpmiROILine = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROIRectangle1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROIRectangle2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROICircle = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROICircularArc = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROIAnnulus = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiROIFreeDraw = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpspROIArray = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpmiVIEWNone = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiVIEWMove = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiVIEWZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiVIEWMagnify = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiVIEWClearROI = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpspModelArray = new System.Windows.Forms.ToolStripSeparator();
            this.tlstrpmiSetModelOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiConfirmModelOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstrpmiRecoverModelOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlModel = new System.Windows.Forms.TabControl();
            this.tbpCreateModelPara = new System.Windows.Forms.TabPage();
            this.pnlCreateModelPara = new System.Windows.Forms.Panel();
            this.chkbMinContrast = new System.Windows.Forms.CheckBox();
            this.chkbOption = new System.Windows.Forms.CheckBox();
            this.chkbNumLevel = new System.Windows.Forms.CheckBox();
            this.chkbAngleStep = new System.Windows.Forms.CheckBox();
            this.chkbScaleStep = new System.Windows.Forms.CheckBox();
            this.chkbContrast = new System.Windows.Forms.CheckBox();
            this.trkbMinContrast = new System.Windows.Forms.TrackBar();
            this.trkbStartAngle = new System.Windows.Forms.TrackBar();
            this.trkbScaleStep = new System.Windows.Forms.TrackBar();
            this.trkbNumLevels = new System.Windows.Forms.TrackBar();
            this.trkbMaxScale = new System.Windows.Forms.TrackBar();
            this.trkbAngleStep = new System.Windows.Forms.TrackBar();
            this.trkbMinScale = new System.Windows.Forms.TrackBar();
            this.trkbAngleExtent = new System.Windows.Forms.TrackBar();
            this.trkbContrast = new System.Windows.Forms.TrackBar();
            this.trkbDisplayLevel = new System.Windows.Forms.TrackBar();
            this.cmbOptimization = new System.Windows.Forms.ComboBox();
            this.cmbMetric = new System.Windows.Forms.ComboBox();
            this.numUpDwnMinContrast = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnAngleStep = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnAngleExtent = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMaxScale = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnStartAngle = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnNumLevels = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnMinScale = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnScaleStep = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnContrast = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnDisplayLevel = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbpFindModelPara = new System.Windows.Forms.TabPage();
            this.pnlFindModelPara = new System.Windows.Forms.Panel();
            this.cmbSubPixel = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.trkbLastLevel = new System.Windows.Forms.TrackBar();
            this.numUpDwnLastLevel = new System.Windows.Forms.NumericUpDown();
            this.trkbMaxOverlap = new System.Windows.Forms.TrackBar();
            this.numUpDwnMaxOverlap = new System.Windows.Forms.NumericUpDown();
            this.trkbGreediness = new System.Windows.Forms.TrackBar();
            this.numUpDwnGreediness = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.trkbNumToMatch = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.numUpDwnNumToMatch = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.trkbMinScore = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.numUpDwnMinScore = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.tbpInspectModel = new System.Windows.Forms.TabPage();
            this.spltInspect1 = new System.Windows.Forms.SplitContainer();
            this.spltInspect2 = new System.Windows.Forms.SplitContainer();
            this.lstbTestImages = new System.Windows.Forms.ListBox();
            this.pnlOperation = new System.Windows.Forms.Panel();
            this.chkbAlwaysFind = new System.Windows.Forms.CheckBox();
            this.btnFindModel = new System.Windows.Forms.Button();
            this.btnDisplayImage = new System.Windows.Forms.Button();
            this.btnClearImageList = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnLoadImageList = new System.Windows.Forms.Button();
            this.dgvMatchResult = new System.Windows.Forms.DataGridView();
            this.ColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpOptimize = new System.Windows.Forms.TabPage();
            this.pnlOptimization = new System.Windows.Forms.Panel();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblOptElapse = new System.Windows.Forms.Label();
            this.lblLastElapse = new System.Windows.Forms.Label();
            this.lblOptRecogRate = new System.Windows.Forms.Label();
            this.lblLastRecogRate = new System.Windows.Forms.Label();
            this.lblOptGreediness = new System.Windows.Forms.Label();
            this.lblLastGreediness = new System.Windows.Forms.Label();
            this.lblOptMinScore = new System.Windows.Forms.Label();
            this.lblLastMinScore = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblOptimizationStatus = new System.Windows.Forms.Label();
            this.grpbMatchModel = new System.Windows.Forms.GroupBox();
            this.trkbRecogRate = new System.Windows.Forms.TrackBar();
            this.cmbRecogRateOption = new System.Windows.Forms.ComboBox();
            this.numUpDwnRecogRate = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnSpecifiedNum = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.rdbtnMaxNum = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.rdbtnAtLeastOne = new System.Windows.Forms.RadioButton();
            this.rdbtnSpecifiedNum = new System.Windows.Forms.RadioButton();
            this.tbpStatistic = new System.Windows.Forms.TabPage();
            this.grpbStatistic = new System.Windows.Forms.GroupBox();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.numUpDwnMaxNumMatch = new System.Windows.Forms.NumericUpDown();
            this.lblInspectRangeColScale = new System.Windows.Forms.Label();
            this.lblInspectRangeRowScale = new System.Windows.Forms.Label();
            this.lblInspectMaxColScale = new System.Windows.Forms.Label();
            this.lblInspectMaxRowScale = new System.Windows.Forms.Label();
            this.lblInspectRangeAngle = new System.Windows.Forms.Label();
            this.lblInspectMinColScale = new System.Windows.Forms.Label();
            this.lblInspectMaxAngle = new System.Windows.Forms.Label();
            this.lblInspectRangeCol = new System.Windows.Forms.Label();
            this.lblInspectMinRowScale = new System.Windows.Forms.Label();
            this.lblInspectMaxCol = new System.Windows.Forms.Label();
            this.lblInspectRangeRow = new System.Windows.Forms.Label();
            this.lblInspectMinAngle = new System.Windows.Forms.Label();
            this.lblInspectMaxRow = new System.Windows.Forms.Label();
            this.lblInspectMinCol = new System.Windows.Forms.Label();
            this.lblInspectRangeElapse = new System.Windows.Forms.Label();
            this.lblInspectMinRow = new System.Windows.Forms.Label();
            this.lblInspectMaxElapse = new System.Windows.Forms.Label();
            this.lblInspectRangeScore = new System.Windows.Forms.Label();
            this.lblInspectMaxScore = new System.Windows.Forms.Label();
            this.lblInspectMinElapse = new System.Windows.Forms.Label();
            this.lblInspectMinScore = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.grpbRecogRate = new System.Windows.Forms.GroupBox();
            this.lblToMaxNum = new System.Windows.Forms.Label();
            this.lblToSpecifiedNum = new System.Windows.Forms.Label();
            this.lblMaxNum = new System.Windows.Forms.Label();
            this.lblSpecifiedNum = new System.Windows.Forms.Label();
            this.lblAtleastOne = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spltRoot)).BeginInit();
            this.spltRoot.Panel1.SuspendLayout();
            this.spltRoot.Panel2.SuspendLayout();
            this.spltRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltOperation)).BeginInit();
            this.spltOperation.Panel1.SuspendLayout();
            this.spltOperation.Panel2.SuspendLayout();
            this.spltOperation.SuspendLayout();
            this.pnlOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnHysteresisHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnHysteresisLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnFilterAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltViewResult)).BeginInit();
            this.spltViewResult.Panel1.SuspendLayout();
            this.spltViewResult.Panel2.SuspendLayout();
            this.spltViewResult.SuspendLayout();
            this.ctxmstrpHwndDisplay.SuspendLayout();
            this.tabControlModel.SuspendLayout();
            this.tbpCreateModelPara.SuspendLayout();
            this.pnlCreateModelPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbScaleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbNumLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbAngleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbDisplayLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleExtent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnNumLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnScaleStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDisplayLevel)).BeginInit();
            this.tbpFindModelPara.SuspendLayout();
            this.pnlFindModelPara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbLastLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnLastLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMaxOverlap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxOverlap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbGreediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGreediness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbNumToMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnNumToMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinScore)).BeginInit();
            this.tbpInspectModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltInspect1)).BeginInit();
            this.spltInspect1.Panel1.SuspendLayout();
            this.spltInspect1.Panel2.SuspendLayout();
            this.spltInspect1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltInspect2)).BeginInit();
            this.spltInspect2.Panel1.SuspendLayout();
            this.spltInspect2.Panel2.SuspendLayout();
            this.spltInspect2.SuspendLayout();
            this.pnlOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchResult)).BeginInit();
            this.tbpOptimize.SuspendLayout();
            this.pnlOptimization.SuspendLayout();
            this.grpbMatchModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbRecogRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnRecogRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnSpecifiedNum)).BeginInit();
            this.tbpStatistic.SuspendLayout();
            this.grpbStatistic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxNumMatch)).BeginInit();
            this.grpbRecogRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltRoot
            // 
            this.spltRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltRoot.IsSplitterFixed = true;
            this.spltRoot.Location = new System.Drawing.Point(0, 0);
            this.spltRoot.Name = "spltRoot";
            this.spltRoot.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltRoot.Panel1
            // 
            this.spltRoot.Panel1.Controls.Add(this.spltOperation);
            // 
            // spltRoot.Panel2
            // 
            this.spltRoot.Panel2.Controls.Add(this.spltViewResult);
            this.spltRoot.Size = new System.Drawing.Size(1508, 812);
            this.spltRoot.SplitterDistance = 137;
            this.spltRoot.TabIndex = 0;
            // 
            // spltOperation
            // 
            this.spltOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.spltOperation.Location = new System.Drawing.Point(0, 0);
            this.spltOperation.Name = "spltOperation";
            // 
            // spltOperation.Panel1
            // 
            this.spltOperation.Panel1.Controls.Add(this.pnlOption);
            // 
            // spltOperation.Panel2
            // 
            this.spltOperation.Panel2.Controls.Add(this.btnClearModel);
            this.spltOperation.Panel2.Controls.Add(this.btnSaveMatchModel);
            this.spltOperation.Panel2.Controls.Add(this.btnRecreateModel);
            this.spltOperation.Panel2.Controls.Add(this.btnEraseRegion);
            this.spltOperation.Panel2.Controls.Add(this.btnApplyModel);
            this.spltOperation.Panel2.Controls.Add(this.btnCreateMatchModel);
            this.spltOperation.Panel2.Controls.Add(this.btnGenerateExtractRegion);
            this.spltOperation.Panel2.Controls.Add(this.btnGenerateSearchRegion);
            this.spltOperation.Size = new System.Drawing.Size(1508, 137);
            this.spltOperation.SplitterDistance = 696;
            this.spltOperation.TabIndex = 0;
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.cmbEraseOption);
            this.pnlOption.Controls.Add(this.numUpDwnHysteresisHigh);
            this.pnlOption.Controls.Add(this.numUpDwnHysteresisLow);
            this.pnlOption.Controls.Add(this.numUpDwnFilterAlpha);
            this.pnlOption.Controls.Add(this.label50);
            this.pnlOption.Controls.Add(this.chkbFillErase);
            this.pnlOption.Controls.Add(this.chkbBrushShape);
            this.pnlOption.Controls.Add(this.chkbBrushOnOff);
            this.pnlOption.Controls.Add(this.cmbModelType);
            this.pnlOption.Controls.Add(this.cmbOptionLevel);
            this.pnlOption.Controls.Add(this.label1);
            this.pnlOption.Controls.Add(this.lblEraseOption);
            this.pnlOption.Controls.Add(this.label51);
            this.pnlOption.Controls.Add(this.lblFilterAlpahPrompt);
            this.pnlOption.Controls.Add(this.lblOperationLevel);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOption.Location = new System.Drawing.Point(0, 0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(696, 137);
            this.pnlOption.TabIndex = 0;
            // 
            // cmbEraseOption
            // 
            this.cmbEraseOption.FormattingEnabled = true;
            this.cmbEraseOption.Items.AddRange(new object[] {
            "搜索区域",
            "提取区域",
            "模板区域"});
            this.cmbEraseOption.Location = new System.Drawing.Point(120, 95);
            this.cmbEraseOption.Name = "cmbEraseOption";
            this.cmbEraseOption.Size = new System.Drawing.Size(121, 23);
            this.cmbEraseOption.TabIndex = 9;
            this.cmbEraseOption.Tag = "CMB_ERASEOPTION";
            this.cmbEraseOption.Text = "搜索区域";
            // 
            // numUpDwnHysteresisHigh
            // 
            this.numUpDwnHysteresisHigh.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDwnHysteresisHigh.Location = new System.Drawing.Point(562, 55);
            this.numUpDwnHysteresisHigh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnHysteresisHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnHysteresisHigh.Name = "numUpDwnHysteresisHigh";
            this.numUpDwnHysteresisHigh.Size = new System.Drawing.Size(103, 25);
            this.numUpDwnHysteresisHigh.TabIndex = 8;
            this.numUpDwnHysteresisHigh.Tag = "NUMUPDWN_HYSTERESISHIGH";
            this.numUpDwnHysteresisHigh.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numUpDwnHysteresisLow
            // 
            this.numUpDwnHysteresisLow.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDwnHysteresisLow.Location = new System.Drawing.Point(562, 97);
            this.numUpDwnHysteresisLow.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnHysteresisLow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnHysteresisLow.Name = "numUpDwnHysteresisLow";
            this.numUpDwnHysteresisLow.Size = new System.Drawing.Size(103, 25);
            this.numUpDwnHysteresisLow.TabIndex = 8;
            this.numUpDwnHysteresisLow.Tag = "NUMUPDWN_HYSTERESISLOW";
            this.numUpDwnHysteresisLow.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numUpDwnFilterAlpha
            // 
            this.numUpDwnFilterAlpha.DecimalPlaces = 1;
            this.numUpDwnFilterAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDwnFilterAlpha.Location = new System.Drawing.Point(562, 12);
            this.numUpDwnFilterAlpha.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDwnFilterAlpha.Name = "numUpDwnFilterAlpha";
            this.numUpDwnFilterAlpha.Size = new System.Drawing.Size(103, 25);
            this.numUpDwnFilterAlpha.TabIndex = 8;
            this.numUpDwnFilterAlpha.Tag = "NUMUPDWN_ALPHA";
            this.numUpDwnFilterAlpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(448, 99);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(100, 23);
            this.label50.TabIndex = 0;
            this.label50.Tag = "LBL_HYSTERESISLOWPROMPT";
            this.label50.Text = "阈值(低)>>";
            // 
            // chkbFillErase
            // 
            this.chkbFillErase.AutoSize = true;
            this.chkbFillErase.Location = new System.Drawing.Point(294, 97);
            this.chkbFillErase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbFillErase.Name = "chkbFillErase";
            this.chkbFillErase.Size = new System.Drawing.Size(89, 19);
            this.chkbFillErase.TabIndex = 7;
            this.chkbFillErase.Tag = "CHKB_FILLERASE";
            this.chkbFillErase.Text = "填充模式";
            this.chkbFillErase.UseVisualStyleBackColor = true;
            // 
            // chkbBrushShape
            // 
            this.chkbBrushShape.AutoSize = true;
            this.chkbBrushShape.Location = new System.Drawing.Point(294, 57);
            this.chkbBrushShape.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbBrushShape.Name = "chkbBrushShape";
            this.chkbBrushShape.Size = new System.Drawing.Size(89, 19);
            this.chkbBrushShape.TabIndex = 6;
            this.chkbBrushShape.Tag = "CHKB_BRUSHSHAPE";
            this.chkbBrushShape.Text = "圆形笔刷";
            this.chkbBrushShape.UseVisualStyleBackColor = true;
            // 
            // chkbBrushOnOff
            // 
            this.chkbBrushOnOff.AutoSize = true;
            this.chkbBrushOnOff.Location = new System.Drawing.Point(294, 17);
            this.chkbBrushOnOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbBrushOnOff.Name = "chkbBrushOnOff";
            this.chkbBrushOnOff.Size = new System.Drawing.Size(89, 19);
            this.chkbBrushOnOff.TabIndex = 2;
            this.chkbBrushOnOff.Tag = "CHKB_BRUSHONOFF";
            this.chkbBrushOnOff.Text = "笔刷禁用";
            this.chkbBrushOnOff.UseVisualStyleBackColor = true;
            // 
            // cmbModelType
            // 
            this.cmbModelType.FormattingEnabled = true;
            this.cmbModelType.Items.AddRange(new object[] {
            "区域形状",
            "轮廓形状",
            "NCC模型"});
            this.cmbModelType.Location = new System.Drawing.Point(120, 55);
            this.cmbModelType.Name = "cmbModelType";
            this.cmbModelType.Size = new System.Drawing.Size(121, 23);
            this.cmbModelType.TabIndex = 1;
            this.cmbModelType.Tag = "CMB_MODELTYPE";
            this.cmbModelType.Text = "区域形状";
            // 
            // cmbOptionLevel
            // 
            this.cmbOptionLevel.FormattingEnabled = true;
            this.cmbOptionLevel.Items.AddRange(new object[] {
            "普通用户",
            "专业用户"});
            this.cmbOptionLevel.Location = new System.Drawing.Point(120, 15);
            this.cmbOptionLevel.Name = "cmbOptionLevel";
            this.cmbOptionLevel.Size = new System.Drawing.Size(121, 23);
            this.cmbOptionLevel.TabIndex = 1;
            this.cmbOptionLevel.Tag = "CMB_OPTIONLEVEL";
            this.cmbOptionLevel.Text = "普通用户";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Tag = "LBL_MODELTYPEPROMPT";
            this.label1.Text = "模板类型>>";
            // 
            // lblEraseOption
            // 
            this.lblEraseOption.Location = new System.Drawing.Point(23, 96);
            this.lblEraseOption.Name = "lblEraseOption";
            this.lblEraseOption.Size = new System.Drawing.Size(100, 23);
            this.lblEraseOption.TabIndex = 0;
            this.lblEraseOption.Tag = "LBL_ERASEOPTIONPROMPT";
            this.lblEraseOption.Text = "擦除选项>>";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(448, 58);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(100, 23);
            this.label51.TabIndex = 0;
            this.label51.Tag = "LBL_HYSTERESISHIGHPROMPT";
            this.label51.Text = "阈值(高)>>";
            // 
            // lblFilterAlpahPrompt
            // 
            this.lblFilterAlpahPrompt.Location = new System.Drawing.Point(448, 15);
            this.lblFilterAlpahPrompt.Name = "lblFilterAlpahPrompt";
            this.lblFilterAlpahPrompt.Size = new System.Drawing.Size(100, 23);
            this.lblFilterAlpahPrompt.TabIndex = 0;
            this.lblFilterAlpahPrompt.Tag = "LBL_FILTERALPHAPROMPT";
            this.lblFilterAlpahPrompt.Text = "滤波系数>>";
            // 
            // lblOperationLevel
            // 
            this.lblOperationLevel.Location = new System.Drawing.Point(23, 18);
            this.lblOperationLevel.Name = "lblOperationLevel";
            this.lblOperationLevel.Size = new System.Drawing.Size(100, 23);
            this.lblOperationLevel.TabIndex = 0;
            this.lblOperationLevel.Tag = "LBL_OPERATIONLEVELPROMPT";
            this.lblOperationLevel.Text = "可见等级>>";
            // 
            // btnClearModel
            // 
            this.btnClearModel.Location = new System.Drawing.Point(590, 12);
            this.btnClearModel.Name = "btnClearModel";
            this.btnClearModel.Size = new System.Drawing.Size(180, 36);
            this.btnClearModel.TabIndex = 1;
            this.btnClearModel.Tag = "BTN_CLEARMATCHMODEL";
            this.btnClearModel.Text = "清空模型";
            this.btnClearModel.UseVisualStyleBackColor = true;
            // 
            // btnSaveMatchModel
            // 
            this.btnSaveMatchModel.Location = new System.Drawing.Point(404, 65);
            this.btnSaveMatchModel.Name = "btnSaveMatchModel";
            this.btnSaveMatchModel.Size = new System.Drawing.Size(180, 36);
            this.btnSaveMatchModel.TabIndex = 1;
            this.btnSaveMatchModel.Tag = "BTN_SAVEMATCHMODEL";
            this.btnSaveMatchModel.Text = "保存模型";
            this.btnSaveMatchModel.UseVisualStyleBackColor = true;
            // 
            // btnRecreateModel
            // 
            this.btnRecreateModel.Location = new System.Drawing.Point(590, 65);
            this.btnRecreateModel.Name = "btnRecreateModel";
            this.btnRecreateModel.Size = new System.Drawing.Size(180, 36);
            this.btnRecreateModel.TabIndex = 1;
            this.btnRecreateModel.Tag = "BTN_RECREATEMATCHMODEL";
            this.btnRecreateModel.Text = "重建模型";
            this.btnRecreateModel.UseVisualStyleBackColor = true;
            // 
            // btnEraseRegion
            // 
            this.btnEraseRegion.Location = new System.Drawing.Point(404, 15);
            this.btnEraseRegion.Name = "btnEraseRegion";
            this.btnEraseRegion.Size = new System.Drawing.Size(180, 36);
            this.btnEraseRegion.TabIndex = 1;
            this.btnEraseRegion.Tag = "BTN_ERASEREGION";
            this.btnEraseRegion.Text = "擦除区域";
            this.btnEraseRegion.UseVisualStyleBackColor = true;
            // 
            // btnApplyModel
            // 
            this.btnApplyModel.Location = new System.Drawing.Point(213, 65);
            this.btnApplyModel.Name = "btnApplyModel";
            this.btnApplyModel.Size = new System.Drawing.Size(180, 36);
            this.btnApplyModel.TabIndex = 1;
            this.btnApplyModel.Tag = "BTN_APPLYMATCHMODEL";
            this.btnApplyModel.Text = "4-应用匹配模型";
            this.btnApplyModel.UseVisualStyleBackColor = true;
            // 
            // btnCreateMatchModel
            // 
            this.btnCreateMatchModel.Location = new System.Drawing.Point(213, 14);
            this.btnCreateMatchModel.Name = "btnCreateMatchModel";
            this.btnCreateMatchModel.Size = new System.Drawing.Size(180, 36);
            this.btnCreateMatchModel.TabIndex = 1;
            this.btnCreateMatchModel.Tag = "BTN_CREATEMATCHMODEL";
            this.btnCreateMatchModel.Text = "3-创建匹配模型";
            this.btnCreateMatchModel.UseVisualStyleBackColor = true;
            // 
            // btnGenerateExtractRegion
            // 
            this.btnGenerateExtractRegion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGenerateExtractRegion.Location = new System.Drawing.Point(22, 65);
            this.btnGenerateExtractRegion.Name = "btnGenerateExtractRegion";
            this.btnGenerateExtractRegion.Size = new System.Drawing.Size(180, 36);
            this.btnGenerateExtractRegion.TabIndex = 0;
            this.btnGenerateExtractRegion.Tag = "BTN_GENERATEEXTRACTREGION";
            this.btnGenerateExtractRegion.Text = "2-创建模板提取区域";
            this.btnGenerateExtractRegion.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSearchRegion
            // 
            this.btnGenerateSearchRegion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGenerateSearchRegion.Location = new System.Drawing.Point(22, 12);
            this.btnGenerateSearchRegion.Name = "btnGenerateSearchRegion";
            this.btnGenerateSearchRegion.Size = new System.Drawing.Size(180, 36);
            this.btnGenerateSearchRegion.TabIndex = 0;
            this.btnGenerateSearchRegion.Tag = "BTN_GENERATESEARCHREGION";
            this.btnGenerateSearchRegion.Text = "1-创建模板搜索区域";
            this.btnGenerateSearchRegion.UseVisualStyleBackColor = true;
            // 
            // spltViewResult
            // 
            this.spltViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltViewResult.Location = new System.Drawing.Point(0, 0);
            this.spltViewResult.Name = "spltViewResult";
            // 
            // spltViewResult.Panel1
            // 
            this.spltViewResult.Panel1.Controls.Add(this.lblCoordinateGrayValue);
            this.spltViewResult.Panel1.Controls.Add(this.hWndcDisplay);
            // 
            // spltViewResult.Panel2
            // 
            this.spltViewResult.Panel2.Controls.Add(this.tabControlModel);
            this.spltViewResult.Size = new System.Drawing.Size(1508, 671);
            this.spltViewResult.SplitterDistance = 713;
            this.spltViewResult.TabIndex = 0;
            // 
            // lblCoordinateGrayValue
            // 
            this.lblCoordinateGrayValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCoordinateGrayValue.Location = new System.Drawing.Point(0, 642);
            this.lblCoordinateGrayValue.Name = "lblCoordinateGrayValue";
            this.lblCoordinateGrayValue.Size = new System.Drawing.Size(713, 25);
            this.lblCoordinateGrayValue.TabIndex = 4;
            this.lblCoordinateGrayValue.Text = "坐标与像素灰度值";
            // 
            // hWndcDisplay
            // 
            this.hWndcDisplay.BackColor = System.Drawing.SystemColors.GrayText;
            this.hWndcDisplay.BorderColor = System.Drawing.SystemColors.GrayText;
            this.hWndcDisplay.ContextMenuStrip = this.ctxmstrpHwndDisplay;
            this.hWndcDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.hWndcDisplay.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndcDisplay.Location = new System.Drawing.Point(0, 0);
            this.hWndcDisplay.Name = "hWndcDisplay";
            this.hWndcDisplay.Size = new System.Drawing.Size(713, 642);
            this.hWndcDisplay.TabIndex = 0;
            this.hWndcDisplay.WindowSize = new System.Drawing.Size(713, 642);
            // 
            // ctxmstrpHwndDisplay
            // 
            this.ctxmstrpHwndDisplay.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxmstrpHwndDisplay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlstrpmiLoadImage,
            this.tlstrpmiLoadModel,
            this.tlstrpspOperationArray,
            this.tlstrpmiROILine,
            this.tlstrpmiROIRectangle1,
            this.tlstrpmiROIRectangle2,
            this.tlstrpmiROICircle,
            this.tlstrpmiROICircularArc,
            this.tlstrpmiROIAnnulus,
            this.tlstrpmiROIFreeDraw,
            this.tlstrpspROIArray,
            this.tlstrpmiVIEWNone,
            this.tlstrpmiVIEWMove,
            this.tlstrpmiVIEWZoom,
            this.tlstrpmiVIEWMagnify,
            this.tlstrpmiVIEWClearROI,
            this.tlstrpspModelArray,
            this.tlstrpmiSetModelOrigin,
            this.tlstrpmiConfirmModelOrigin,
            this.tlstrpmiRecoverModelOrigin});
            this.ctxmstrpHwndDisplay.Name = "ctxmstrpHwndDisplay";
            this.ctxmstrpHwndDisplay.Size = new System.Drawing.Size(169, 430);
            // 
            // tlstrpmiLoadImage
            // 
            this.tlstrpmiLoadImage.Name = "tlstrpmiLoadImage";
            this.tlstrpmiLoadImage.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiLoadImage.Tag = "TLSTRPMI_LOADIMAGE";
            this.tlstrpmiLoadImage.Text = "加载图像";
            // 
            // tlstrpmiLoadModel
            // 
            this.tlstrpmiLoadModel.Name = "tlstrpmiLoadModel";
            this.tlstrpmiLoadModel.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiLoadModel.Tag = "TLSTRPMI_LOADMODEL";
            this.tlstrpmiLoadModel.Text = "加载模型";
            // 
            // tlstrpspOperationArray
            // 
            this.tlstrpspOperationArray.Name = "tlstrpspOperationArray";
            this.tlstrpspOperationArray.Size = new System.Drawing.Size(165, 6);
            // 
            // tlstrpmiROILine
            // 
            this.tlstrpmiROILine.Name = "tlstrpmiROILine";
            this.tlstrpmiROILine.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROILine.Tag = "TLSTRPMI_LINE";
            this.tlstrpmiROILine.Text = "直线段";
            // 
            // tlstrpmiROIRectangle1
            // 
            this.tlstrpmiROIRectangle1.Name = "tlstrpmiROIRectangle1";
            this.tlstrpmiROIRectangle1.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROIRectangle1.Tag = "TLSTRPMI_RECTANGLE1";
            this.tlstrpmiROIRectangle1.Text = "齐轴矩形";
            // 
            // tlstrpmiROIRectangle2
            // 
            this.tlstrpmiROIRectangle2.Name = "tlstrpmiROIRectangle2";
            this.tlstrpmiROIRectangle2.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROIRectangle2.Tag = "TLSTRPMI_RECTANGLE2";
            this.tlstrpmiROIRectangle2.Text = "仿射矩形";
            // 
            // tlstrpmiROICircle
            // 
            this.tlstrpmiROICircle.Name = "tlstrpmiROICircle";
            this.tlstrpmiROICircle.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROICircle.Tag = "TLSTRPMI_CIRCLE";
            this.tlstrpmiROICircle.Text = "闭合圆形";
            // 
            // tlstrpmiROICircularArc
            // 
            this.tlstrpmiROICircularArc.Name = "tlstrpmiROICircularArc";
            this.tlstrpmiROICircularArc.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROICircularArc.Tag = "TLSTRPMI_CIRCULARARC";
            this.tlstrpmiROICircularArc.Text = "有向圆弧";
            // 
            // tlstrpmiROIAnnulus
            // 
            this.tlstrpmiROIAnnulus.Name = "tlstrpmiROIAnnulus";
            this.tlstrpmiROIAnnulus.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROIAnnulus.Tag = "TLSTRPMI_ANNULUS";
            this.tlstrpmiROIAnnulus.Text = "闭合圆环";
            // 
            // tlstrpmiROIFreeDraw
            // 
            this.tlstrpmiROIFreeDraw.Name = "tlstrpmiROIFreeDraw";
            this.tlstrpmiROIFreeDraw.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiROIFreeDraw.Tag = "TLSTRPMI_FREEDRAW";
            this.tlstrpmiROIFreeDraw.Text = "自由绘制";
            // 
            // tlstrpspROIArray
            // 
            this.tlstrpspROIArray.Name = "tlstrpspROIArray";
            this.tlstrpspROIArray.Size = new System.Drawing.Size(165, 6);
            // 
            // tlstrpmiVIEWNone
            // 
            this.tlstrpmiVIEWNone.Name = "tlstrpmiVIEWNone";
            this.tlstrpmiVIEWNone.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiVIEWNone.Tag = "TLSTRPMI_NONE";
            this.tlstrpmiVIEWNone.Text = "恢复初态";
            // 
            // tlstrpmiVIEWMove
            // 
            this.tlstrpmiVIEWMove.Name = "tlstrpmiVIEWMove";
            this.tlstrpmiVIEWMove.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiVIEWMove.Tag = "TLSTRPMI_MOVE";
            this.tlstrpmiVIEWMove.Text = "移动图形";
            // 
            // tlstrpmiVIEWZoom
            // 
            this.tlstrpmiVIEWZoom.Name = "tlstrpmiVIEWZoom";
            this.tlstrpmiVIEWZoom.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiVIEWZoom.Tag = "TLSTRPMI_ZOOM";
            this.tlstrpmiVIEWZoom.Text = "缩放图形";
            // 
            // tlstrpmiVIEWMagnify
            // 
            this.tlstrpmiVIEWMagnify.Name = "tlstrpmiVIEWMagnify";
            this.tlstrpmiVIEWMagnify.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiVIEWMagnify.Tag = "TLSTRPMI_MAGNIFY";
            this.tlstrpmiVIEWMagnify.Text = "局部放大";
            // 
            // tlstrpmiVIEWClearROI
            // 
            this.tlstrpmiVIEWClearROI.Name = "tlstrpmiVIEWClearROI";
            this.tlstrpmiVIEWClearROI.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiVIEWClearROI.Tag = "TLSTRPMI_CLEAR";
            this.tlstrpmiVIEWClearROI.Text = "清空图形";
            // 
            // tlstrpspModelArray
            // 
            this.tlstrpspModelArray.Name = "tlstrpspModelArray";
            this.tlstrpspModelArray.Size = new System.Drawing.Size(165, 6);
            // 
            // tlstrpmiSetModelOrigin
            // 
            this.tlstrpmiSetModelOrigin.Name = "tlstrpmiSetModelOrigin";
            this.tlstrpmiSetModelOrigin.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiSetModelOrigin.Tag = "TLSTRPMI_SETMODELORIGIN";
            this.tlstrpmiSetModelOrigin.Text = "设置模板原点";
            // 
            // tlstrpmiConfirmModelOrigin
            // 
            this.tlstrpmiConfirmModelOrigin.Name = "tlstrpmiConfirmModelOrigin";
            this.tlstrpmiConfirmModelOrigin.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiConfirmModelOrigin.Tag = "TLSTRPMI_CONFIRMMODELORIGIN";
            this.tlstrpmiConfirmModelOrigin.Text = "确认模板原点";
            // 
            // tlstrpmiRecoverModelOrigin
            // 
            this.tlstrpmiRecoverModelOrigin.Name = "tlstrpmiRecoverModelOrigin";
            this.tlstrpmiRecoverModelOrigin.Size = new System.Drawing.Size(168, 24);
            this.tlstrpmiRecoverModelOrigin.Tag = "TLSTRPMI_RECOVERMODELORIGIN";
            this.tlstrpmiRecoverModelOrigin.Text = "恢复模板原点";
            // 
            // tabControlModel
            // 
            this.tabControlModel.Controls.Add(this.tbpCreateModelPara);
            this.tabControlModel.Controls.Add(this.tbpFindModelPara);
            this.tabControlModel.Controls.Add(this.tbpInspectModel);
            this.tabControlModel.Controls.Add(this.tbpOptimize);
            this.tabControlModel.Controls.Add(this.tbpStatistic);
            this.tabControlModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlModel.Location = new System.Drawing.Point(0, 0);
            this.tabControlModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlModel.Name = "tabControlModel";
            this.tabControlModel.SelectedIndex = 0;
            this.tabControlModel.Size = new System.Drawing.Size(791, 671);
            this.tabControlModel.TabIndex = 1;
            // 
            // tbpCreateModelPara
            // 
            this.tbpCreateModelPara.Controls.Add(this.pnlCreateModelPara);
            this.tbpCreateModelPara.Location = new System.Drawing.Point(4, 25);
            this.tbpCreateModelPara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpCreateModelPara.Name = "tbpCreateModelPara";
            this.tbpCreateModelPara.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpCreateModelPara.Size = new System.Drawing.Size(783, 642);
            this.tbpCreateModelPara.TabIndex = 0;
            this.tbpCreateModelPara.Text = "创建模型参数";
            this.tbpCreateModelPara.UseVisualStyleBackColor = true;
            // 
            // pnlCreateModelPara
            // 
            this.pnlCreateModelPara.Controls.Add(this.chkbMinContrast);
            this.pnlCreateModelPara.Controls.Add(this.chkbOption);
            this.pnlCreateModelPara.Controls.Add(this.chkbNumLevel);
            this.pnlCreateModelPara.Controls.Add(this.chkbAngleStep);
            this.pnlCreateModelPara.Controls.Add(this.chkbScaleStep);
            this.pnlCreateModelPara.Controls.Add(this.chkbContrast);
            this.pnlCreateModelPara.Controls.Add(this.trkbMinContrast);
            this.pnlCreateModelPara.Controls.Add(this.trkbStartAngle);
            this.pnlCreateModelPara.Controls.Add(this.trkbScaleStep);
            this.pnlCreateModelPara.Controls.Add(this.trkbNumLevels);
            this.pnlCreateModelPara.Controls.Add(this.trkbMaxScale);
            this.pnlCreateModelPara.Controls.Add(this.trkbAngleStep);
            this.pnlCreateModelPara.Controls.Add(this.trkbMinScale);
            this.pnlCreateModelPara.Controls.Add(this.trkbAngleExtent);
            this.pnlCreateModelPara.Controls.Add(this.trkbContrast);
            this.pnlCreateModelPara.Controls.Add(this.trkbDisplayLevel);
            this.pnlCreateModelPara.Controls.Add(this.cmbOptimization);
            this.pnlCreateModelPara.Controls.Add(this.cmbMetric);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnMinContrast);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnAngleStep);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnAngleExtent);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnMaxScale);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnStartAngle);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnNumLevels);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnMinScale);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnScaleStep);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnContrast);
            this.pnlCreateModelPara.Controls.Add(this.numUpDwnDisplayLevel);
            this.pnlCreateModelPara.Controls.Add(this.label12);
            this.pnlCreateModelPara.Controls.Add(this.label11);
            this.pnlCreateModelPara.Controls.Add(this.label8);
            this.pnlCreateModelPara.Controls.Add(this.label7);
            this.pnlCreateModelPara.Controls.Add(this.label10);
            this.pnlCreateModelPara.Controls.Add(this.label4);
            this.pnlCreateModelPara.Controls.Add(this.label6);
            this.pnlCreateModelPara.Controls.Add(this.label9);
            this.pnlCreateModelPara.Controls.Add(this.label3);
            this.pnlCreateModelPara.Controls.Add(this.label5);
            this.pnlCreateModelPara.Controls.Add(this.label2);
            this.pnlCreateModelPara.Controls.Add(this.label13);
            this.pnlCreateModelPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCreateModelPara.Location = new System.Drawing.Point(3, 2);
            this.pnlCreateModelPara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCreateModelPara.Name = "pnlCreateModelPara";
            this.pnlCreateModelPara.Size = new System.Drawing.Size(777, 638);
            this.pnlCreateModelPara.TabIndex = 0;
            // 
            // chkbMinContrast
            // 
            this.chkbMinContrast.AutoSize = true;
            this.chkbMinContrast.Location = new System.Drawing.Point(568, 549);
            this.chkbMinContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbMinContrast.Name = "chkbMinContrast";
            this.chkbMinContrast.Size = new System.Drawing.Size(89, 19);
            this.chkbMinContrast.TabIndex = 1;
            this.chkbMinContrast.Tag = "CHKB_MINCONTRAST";
            this.chkbMinContrast.Text = "手动调整";
            this.chkbMinContrast.UseVisualStyleBackColor = true;
            // 
            // chkbOption
            // 
            this.chkbOption.AutoSize = true;
            this.chkbOption.Location = new System.Drawing.Point(568, 500);
            this.chkbOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbOption.Name = "chkbOption";
            this.chkbOption.Size = new System.Drawing.Size(89, 19);
            this.chkbOption.TabIndex = 1;
            this.chkbOption.Tag = "CHKB_OPTIMIZATION";
            this.chkbOption.Text = "手动调整";
            this.chkbOption.UseVisualStyleBackColor = true;
            // 
            // chkbNumLevel
            // 
            this.chkbNumLevel.AutoSize = true;
            this.chkbNumLevel.Location = new System.Drawing.Point(568, 398);
            this.chkbNumLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbNumLevel.Name = "chkbNumLevel";
            this.chkbNumLevel.Size = new System.Drawing.Size(89, 19);
            this.chkbNumLevel.TabIndex = 1;
            this.chkbNumLevel.Tag = "CHKB_NUMLEVELS";
            this.chkbNumLevel.Text = "手动调整";
            this.chkbNumLevel.UseVisualStyleBackColor = true;
            // 
            // chkbAngleStep
            // 
            this.chkbAngleStep.AutoSize = true;
            this.chkbAngleStep.Location = new System.Drawing.Point(568, 350);
            this.chkbAngleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbAngleStep.Name = "chkbAngleStep";
            this.chkbAngleStep.Size = new System.Drawing.Size(89, 19);
            this.chkbAngleStep.TabIndex = 1;
            this.chkbAngleStep.Tag = "CHKB_ANGLESTEP";
            this.chkbAngleStep.Text = "手动调整";
            this.chkbAngleStep.UseVisualStyleBackColor = true;
            // 
            // chkbScaleStep
            // 
            this.chkbScaleStep.AutoSize = true;
            this.chkbScaleStep.Location = new System.Drawing.Point(568, 210);
            this.chkbScaleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbScaleStep.Name = "chkbScaleStep";
            this.chkbScaleStep.Size = new System.Drawing.Size(89, 19);
            this.chkbScaleStep.TabIndex = 1;
            this.chkbScaleStep.Tag = "CHKB_SCALESTEP";
            this.chkbScaleStep.Text = "手动调整";
            this.chkbScaleStep.UseVisualStyleBackColor = true;
            // 
            // chkbContrast
            // 
            this.chkbContrast.AutoSize = true;
            this.chkbContrast.Location = new System.Drawing.Point(568, 71);
            this.chkbContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbContrast.Name = "chkbContrast";
            this.chkbContrast.Size = new System.Drawing.Size(89, 19);
            this.chkbContrast.TabIndex = 1;
            this.chkbContrast.Tag = "CHKB_CONTRAST";
            this.chkbContrast.Text = "手动调整";
            this.chkbContrast.UseVisualStyleBackColor = true;
            // 
            // trkbMinContrast
            // 
            this.trkbMinContrast.AutoSize = false;
            this.trkbMinContrast.Location = new System.Drawing.Point(344, 542);
            this.trkbMinContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbMinContrast.Maximum = 30;
            this.trkbMinContrast.Name = "trkbMinContrast";
            this.trkbMinContrast.Size = new System.Drawing.Size(195, 31);
            this.trkbMinContrast.TabIndex = 3;
            this.trkbMinContrast.Tag = "TRKB_MINCONTRAST";
            this.trkbMinContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbMinContrast.Value = 10;
            // 
            // trkbStartAngle
            // 
            this.trkbStartAngle.AutoSize = false;
            this.trkbStartAngle.Location = new System.Drawing.Point(344, 249);
            this.trkbStartAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbStartAngle.Maximum = 180;
            this.trkbStartAngle.Minimum = -180;
            this.trkbStartAngle.Name = "trkbStartAngle";
            this.trkbStartAngle.Size = new System.Drawing.Size(195, 31);
            this.trkbStartAngle.TabIndex = 3;
            this.trkbStartAngle.Tag = "TRKB_STARTANGLE";
            this.trkbStartAngle.TickFrequency = 20;
            this.trkbStartAngle.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trkbScaleStep
            // 
            this.trkbScaleStep.AutoSize = false;
            this.trkbScaleStep.Location = new System.Drawing.Point(344, 204);
            this.trkbScaleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbScaleStep.Maximum = 190;
            this.trkbScaleStep.Minimum = 1;
            this.trkbScaleStep.Name = "trkbScaleStep";
            this.trkbScaleStep.Size = new System.Drawing.Size(195, 31);
            this.trkbScaleStep.TabIndex = 3;
            this.trkbScaleStep.Tag = "TRKB_SCALESTEP";
            this.trkbScaleStep.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbScaleStep.Value = 10;
            // 
            // trkbNumLevels
            // 
            this.trkbNumLevels.AutoSize = false;
            this.trkbNumLevels.Location = new System.Drawing.Point(344, 392);
            this.trkbNumLevels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbNumLevels.Maximum = 6;
            this.trkbNumLevels.Minimum = 1;
            this.trkbNumLevels.Name = "trkbNumLevels";
            this.trkbNumLevels.Size = new System.Drawing.Size(195, 31);
            this.trkbNumLevels.TabIndex = 3;
            this.trkbNumLevels.Tag = "TRKB_NUMLEVELS";
            this.trkbNumLevels.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbNumLevels.Value = 6;
            // 
            // trkbMaxScale
            // 
            this.trkbMaxScale.AutoSize = false;
            this.trkbMaxScale.Location = new System.Drawing.Point(344, 158);
            this.trkbMaxScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbMaxScale.Maximum = 200;
            this.trkbMaxScale.Minimum = 1;
            this.trkbMaxScale.Name = "trkbMaxScale";
            this.trkbMaxScale.Size = new System.Drawing.Size(195, 31);
            this.trkbMaxScale.TabIndex = 3;
            this.trkbMaxScale.Tag = "TRKB_MAXSCALE";
            this.trkbMaxScale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbMaxScale.Value = 100;
            // 
            // trkbAngleStep
            // 
            this.trkbAngleStep.AutoSize = false;
            this.trkbAngleStep.Location = new System.Drawing.Point(344, 344);
            this.trkbAngleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbAngleStep.Maximum = 112;
            this.trkbAngleStep.Minimum = 1;
            this.trkbAngleStep.Name = "trkbAngleStep";
            this.trkbAngleStep.Size = new System.Drawing.Size(195, 31);
            this.trkbAngleStep.TabIndex = 3;
            this.trkbAngleStep.Tag = "TRKB_ANGLESTEP";
            this.trkbAngleStep.TickFrequency = 10;
            this.trkbAngleStep.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbAngleStep.Value = 10;
            // 
            // trkbMinScale
            // 
            this.trkbMinScale.AutoSize = false;
            this.trkbMinScale.Location = new System.Drawing.Point(344, 109);
            this.trkbMinScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbMinScale.Maximum = 200;
            this.trkbMinScale.Minimum = 1;
            this.trkbMinScale.Name = "trkbMinScale";
            this.trkbMinScale.Size = new System.Drawing.Size(195, 31);
            this.trkbMinScale.TabIndex = 3;
            this.trkbMinScale.Tag = "TRKB_MINSCALE";
            this.trkbMinScale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbMinScale.Value = 100;
            // 
            // trkbAngleExtent
            // 
            this.trkbAngleExtent.AutoSize = false;
            this.trkbAngleExtent.Location = new System.Drawing.Point(344, 299);
            this.trkbAngleExtent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbAngleExtent.Maximum = 360;
            this.trkbAngleExtent.Name = "trkbAngleExtent";
            this.trkbAngleExtent.Size = new System.Drawing.Size(195, 31);
            this.trkbAngleExtent.TabIndex = 3;
            this.trkbAngleExtent.Tag = "TRKB_ANGLEEXTENT";
            this.trkbAngleExtent.TickFrequency = 20;
            this.trkbAngleExtent.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trkbContrast
            // 
            this.trkbContrast.AutoSize = false;
            this.trkbContrast.Location = new System.Drawing.Point(344, 65);
            this.trkbContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbContrast.Maximum = 255;
            this.trkbContrast.Name = "trkbContrast";
            this.trkbContrast.Size = new System.Drawing.Size(195, 31);
            this.trkbContrast.TabIndex = 3;
            this.trkbContrast.Tag = "TRKB_CONTRAST";
            this.trkbContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbContrast.Value = 30;
            // 
            // trkbDisplayLevel
            // 
            this.trkbDisplayLevel.AutoSize = false;
            this.trkbDisplayLevel.Location = new System.Drawing.Point(344, 20);
            this.trkbDisplayLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbDisplayLevel.Maximum = 6;
            this.trkbDisplayLevel.Minimum = 1;
            this.trkbDisplayLevel.Name = "trkbDisplayLevel";
            this.trkbDisplayLevel.Size = new System.Drawing.Size(195, 31);
            this.trkbDisplayLevel.TabIndex = 3;
            this.trkbDisplayLevel.Tag = "TRKB_DISPLAYLEVEL";
            this.trkbDisplayLevel.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbDisplayLevel.Value = 1;
            // 
            // cmbOptimization
            // 
            this.cmbOptimization.FormattingEnabled = true;
            this.cmbOptimization.Items.AddRange(new object[] {
            "none",
            "point_reduction_low",
            "point_reduction_medium",
            "point_reduction_high"});
            this.cmbOptimization.Location = new System.Drawing.Point(199, 498);
            this.cmbOptimization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbOptimization.Name = "cmbOptimization";
            this.cmbOptimization.Size = new System.Drawing.Size(340, 23);
            this.cmbOptimization.TabIndex = 2;
            this.cmbOptimization.Tag = "OPTIMIZATION";
            // 
            // cmbMetric
            // 
            this.cmbMetric.FormattingEnabled = true;
            this.cmbMetric.Items.AddRange(new object[] {
            "use_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity",
            "ignore_color_polarity"});
            this.cmbMetric.Location = new System.Drawing.Point(199, 448);
            this.cmbMetric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMetric.Name = "cmbMetric";
            this.cmbMetric.Size = new System.Drawing.Size(340, 23);
            this.cmbMetric.TabIndex = 2;
            this.cmbMetric.Tag = "METRIC";
            // 
            // numUpDwnMinContrast
            // 
            this.numUpDwnMinContrast.Location = new System.Drawing.Point(200, 546);
            this.numUpDwnMinContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMinContrast.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numUpDwnMinContrast.Name = "numUpDwnMinContrast";
            this.numUpDwnMinContrast.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnMinContrast.TabIndex = 1;
            this.numUpDwnMinContrast.Tag = "NUMUPDWN_MINCONTRAST";
            this.numUpDwnMinContrast.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numUpDwnAngleStep
            // 
            this.numUpDwnAngleStep.Location = new System.Drawing.Point(200, 348);
            this.numUpDwnAngleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnAngleStep.Maximum = new decimal(new int[] {
            112,
            0,
            0,
            0});
            this.numUpDwnAngleStep.Name = "numUpDwnAngleStep";
            this.numUpDwnAngleStep.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnAngleStep.TabIndex = 1;
            this.numUpDwnAngleStep.Tag = "NUMUPDWN_ANGLESTEP";
            this.numUpDwnAngleStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numUpDwnAngleExtent
            // 
            this.numUpDwnAngleExtent.Location = new System.Drawing.Point(200, 302);
            this.numUpDwnAngleExtent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnAngleExtent.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numUpDwnAngleExtent.Name = "numUpDwnAngleExtent";
            this.numUpDwnAngleExtent.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnAngleExtent.TabIndex = 1;
            this.numUpDwnAngleExtent.Tag = "NUMUPDWN_ANGLEEXTENT";
            this.numUpDwnAngleExtent.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // numUpDwnMaxScale
            // 
            this.numUpDwnMaxScale.Location = new System.Drawing.Point(200, 161);
            this.numUpDwnMaxScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMaxScale.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUpDwnMaxScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnMaxScale.Name = "numUpDwnMaxScale";
            this.numUpDwnMaxScale.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnMaxScale.TabIndex = 1;
            this.numUpDwnMaxScale.Tag = "NUMUPDWN_MAXSCALE";
            this.numUpDwnMaxScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUpDwnStartAngle
            // 
            this.numUpDwnStartAngle.Location = new System.Drawing.Point(200, 252);
            this.numUpDwnStartAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnStartAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numUpDwnStartAngle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numUpDwnStartAngle.Name = "numUpDwnStartAngle";
            this.numUpDwnStartAngle.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnStartAngle.TabIndex = 1;
            this.numUpDwnStartAngle.Tag = "NUMUPDWN_STARTANGLE";
            // 
            // numUpDwnNumLevels
            // 
            this.numUpDwnNumLevels.Location = new System.Drawing.Point(200, 395);
            this.numUpDwnNumLevels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnNumLevels.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUpDwnNumLevels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnNumLevels.Name = "numUpDwnNumLevels";
            this.numUpDwnNumLevels.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnNumLevels.TabIndex = 1;
            this.numUpDwnNumLevels.Tag = "NUMUPDWN_NUMLEVELS";
            this.numUpDwnNumLevels.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numUpDwnMinScale
            // 
            this.numUpDwnMinScale.Location = new System.Drawing.Point(200, 112);
            this.numUpDwnMinScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMinScale.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numUpDwnMinScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnMinScale.Name = "numUpDwnMinScale";
            this.numUpDwnMinScale.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnMinScale.TabIndex = 1;
            this.numUpDwnMinScale.Tag = "NUMUPDWN_MINSCALE";
            this.numUpDwnMinScale.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUpDwnScaleStep
            // 
            this.numUpDwnScaleStep.Location = new System.Drawing.Point(200, 208);
            this.numUpDwnScaleStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnScaleStep.Maximum = new decimal(new int[] {
            190,
            0,
            0,
            0});
            this.numUpDwnScaleStep.Name = "numUpDwnScaleStep";
            this.numUpDwnScaleStep.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnScaleStep.TabIndex = 1;
            this.numUpDwnScaleStep.Tag = "NUMUPDWN_SCALESTEP";
            this.numUpDwnScaleStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numUpDwnContrast
            // 
            this.numUpDwnContrast.Location = new System.Drawing.Point(200, 68);
            this.numUpDwnContrast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnContrast.Name = "numUpDwnContrast";
            this.numUpDwnContrast.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnContrast.TabIndex = 1;
            this.numUpDwnContrast.Tag = "NUMUPDWN_CONTRAST";
            this.numUpDwnContrast.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numUpDwnDisplayLevel
            // 
            this.numUpDwnDisplayLevel.Location = new System.Drawing.Point(200, 22);
            this.numUpDwnDisplayLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnDisplayLevel.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUpDwnDisplayLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnDisplayLevel.Name = "numUpDwnDisplayLevel";
            this.numUpDwnDisplayLevel.Size = new System.Drawing.Size(120, 25);
            this.numUpDwnDisplayLevel.TabIndex = 1;
            this.numUpDwnDisplayLevel.Tag = "NUMUPDWN_DISPLAYLEVEL";
            this.numUpDwnDisplayLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 551);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "最小对比度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "最优化选项";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "角步长(x10)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "角范围(度)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 452);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "度量选项";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大缩放系数(x100)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "起始角(度)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "最大金字塔等级数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "最小缩放系数(x100)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "缩放系数步长(x1000)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "对比度";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "显示图层等级";
            // 
            // tbpFindModelPara
            // 
            this.tbpFindModelPara.Controls.Add(this.pnlFindModelPara);
            this.tbpFindModelPara.Location = new System.Drawing.Point(4, 25);
            this.tbpFindModelPara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpFindModelPara.Name = "tbpFindModelPara";
            this.tbpFindModelPara.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpFindModelPara.Size = new System.Drawing.Size(790, 642);
            this.tbpFindModelPara.TabIndex = 1;
            this.tbpFindModelPara.Text = "查找模型参数";
            this.tbpFindModelPara.UseVisualStyleBackColor = true;
            // 
            // pnlFindModelPara
            // 
            this.pnlFindModelPara.Controls.Add(this.cmbSubPixel);
            this.pnlFindModelPara.Controls.Add(this.label18);
            this.pnlFindModelPara.Controls.Add(this.trkbLastLevel);
            this.pnlFindModelPara.Controls.Add(this.numUpDwnLastLevel);
            this.pnlFindModelPara.Controls.Add(this.trkbMaxOverlap);
            this.pnlFindModelPara.Controls.Add(this.numUpDwnMaxOverlap);
            this.pnlFindModelPara.Controls.Add(this.trkbGreediness);
            this.pnlFindModelPara.Controls.Add(this.numUpDwnGreediness);
            this.pnlFindModelPara.Controls.Add(this.label17);
            this.pnlFindModelPara.Controls.Add(this.trkbNumToMatch);
            this.pnlFindModelPara.Controls.Add(this.label16);
            this.pnlFindModelPara.Controls.Add(this.numUpDwnNumToMatch);
            this.pnlFindModelPara.Controls.Add(this.label15);
            this.pnlFindModelPara.Controls.Add(this.trkbMinScore);
            this.pnlFindModelPara.Controls.Add(this.label14);
            this.pnlFindModelPara.Controls.Add(this.numUpDwnMinScore);
            this.pnlFindModelPara.Controls.Add(this.label19);
            this.pnlFindModelPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFindModelPara.Location = new System.Drawing.Point(3, 2);
            this.pnlFindModelPara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFindModelPara.Name = "pnlFindModelPara";
            this.pnlFindModelPara.Size = new System.Drawing.Size(784, 638);
            this.pnlFindModelPara.TabIndex = 0;
            // 
            // cmbSubPixel
            // 
            this.cmbSubPixel.FormattingEnabled = true;
            this.cmbSubPixel.Items.AddRange(new object[] {
            "none",
            "interpolation",
            "least_squares",
            "least_squares_high",
            "least_squares_very_high"});
            this.cmbSubPixel.Location = new System.Drawing.Point(227, 279);
            this.cmbSubPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSubPixel.Name = "cmbSubPixel";
            this.cmbSubPixel.Size = new System.Drawing.Size(159, 23);
            this.cmbSubPixel.TabIndex = 8;
            this.cmbSubPixel.Tag = "SUBPIXEL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(51, 282);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 15);
            this.label18.TabIndex = 7;
            this.label18.Text = "亚像素等级";
            // 
            // trkbLastLevel
            // 
            this.trkbLastLevel.AutoSize = false;
            this.trkbLastLevel.Location = new System.Drawing.Point(467, 322);
            this.trkbLastLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbLastLevel.Maximum = 6;
            this.trkbLastLevel.Minimum = 1;
            this.trkbLastLevel.Name = "trkbLastLevel";
            this.trkbLastLevel.Size = new System.Drawing.Size(195, 31);
            this.trkbLastLevel.TabIndex = 6;
            this.trkbLastLevel.Tag = "TRKB_LASTLEVEL";
            this.trkbLastLevel.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbLastLevel.Value = 1;
            // 
            // numUpDwnLastLevel
            // 
            this.numUpDwnLastLevel.Location = new System.Drawing.Point(227, 328);
            this.numUpDwnLastLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnLastLevel.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDwnLastLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnLastLevel.Name = "numUpDwnLastLevel";
            this.numUpDwnLastLevel.Size = new System.Drawing.Size(159, 25);
            this.numUpDwnLastLevel.TabIndex = 5;
            this.numUpDwnLastLevel.Tag = "NUMUPDWN_LASTLEVEL";
            this.numUpDwnLastLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // trkbMaxOverlap
            // 
            this.trkbMaxOverlap.AutoSize = false;
            this.trkbMaxOverlap.Location = new System.Drawing.Point(467, 218);
            this.trkbMaxOverlap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbMaxOverlap.Maximum = 100;
            this.trkbMaxOverlap.Name = "trkbMaxOverlap";
            this.trkbMaxOverlap.Size = new System.Drawing.Size(195, 31);
            this.trkbMaxOverlap.TabIndex = 6;
            this.trkbMaxOverlap.Tag = "TRKB_MAXOVERLAP";
            this.trkbMaxOverlap.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbMaxOverlap.Value = 50;
            // 
            // numUpDwnMaxOverlap
            // 
            this.numUpDwnMaxOverlap.Location = new System.Drawing.Point(227, 218);
            this.numUpDwnMaxOverlap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMaxOverlap.Name = "numUpDwnMaxOverlap";
            this.numUpDwnMaxOverlap.Size = new System.Drawing.Size(159, 25);
            this.numUpDwnMaxOverlap.TabIndex = 5;
            this.numUpDwnMaxOverlap.Tag = "NUMUPDWN_MAXOVERLAP";
            this.numUpDwnMaxOverlap.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // trkbGreediness
            // 
            this.trkbGreediness.AutoSize = false;
            this.trkbGreediness.Location = new System.Drawing.Point(467, 154);
            this.trkbGreediness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbGreediness.Maximum = 100;
            this.trkbGreediness.Name = "trkbGreediness";
            this.trkbGreediness.Size = new System.Drawing.Size(195, 31);
            this.trkbGreediness.TabIndex = 6;
            this.trkbGreediness.Tag = "TRKB_GREEDINESS";
            this.trkbGreediness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbGreediness.Value = 75;
            // 
            // numUpDwnGreediness
            // 
            this.numUpDwnGreediness.Location = new System.Drawing.Point(227, 164);
            this.numUpDwnGreediness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnGreediness.Name = "numUpDwnGreediness";
            this.numUpDwnGreediness.Size = new System.Drawing.Size(159, 25);
            this.numUpDwnGreediness.TabIndex = 5;
            this.numUpDwnGreediness.Tag = "NUMUPDWN_GREEDINESS";
            this.numUpDwnGreediness.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(51, 338);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "上次金字塔等级";
            // 
            // trkbNumToMatch
            // 
            this.trkbNumToMatch.AutoSize = false;
            this.trkbNumToMatch.Location = new System.Drawing.Point(467, 104);
            this.trkbNumToMatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbNumToMatch.Maximum = 100;
            this.trkbNumToMatch.Name = "trkbNumToMatch";
            this.trkbNumToMatch.Size = new System.Drawing.Size(195, 31);
            this.trkbNumToMatch.TabIndex = 6;
            this.trkbNumToMatch.Tag = "TRKB_NUMTOMATCH";
            this.trkbNumToMatch.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbNumToMatch.Value = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(51, 226);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(145, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "最大重叠系数(x100)";
            // 
            // numUpDwnNumToMatch
            // 
            this.numUpDwnNumToMatch.Location = new System.Drawing.Point(227, 110);
            this.numUpDwnNumToMatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnNumToMatch.Name = "numUpDwnNumToMatch";
            this.numUpDwnNumToMatch.Size = new System.Drawing.Size(159, 25);
            this.numUpDwnNumToMatch.TabIndex = 5;
            this.numUpDwnNumToMatch.Tag = "NUMUPDWN_NUMTOMATCH";
            this.numUpDwnNumToMatch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "贪婪度系数(x100)";
            // 
            // trkbMinScore
            // 
            this.trkbMinScore.AutoSize = false;
            this.trkbMinScore.Location = new System.Drawing.Point(467, 50);
            this.trkbMinScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbMinScore.Maximum = 100;
            this.trkbMinScore.Name = "trkbMinScore";
            this.trkbMinScore.Size = new System.Drawing.Size(195, 31);
            this.trkbMinScore.TabIndex = 6;
            this.trkbMinScore.Tag = "TRKB_MINSCORE";
            this.trkbMinScore.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbMinScore.Value = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(51, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "预期匹配模型实例数";
            // 
            // numUpDwnMinScore
            // 
            this.numUpDwnMinScore.Location = new System.Drawing.Point(227, 56);
            this.numUpDwnMinScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMinScore.Name = "numUpDwnMinScore";
            this.numUpDwnMinScore.Size = new System.Drawing.Size(159, 25);
            this.numUpDwnMinScore.TabIndex = 5;
            this.numUpDwnMinScore.Tag = "NUMUPDWN_MINSCORE";
            this.numUpDwnMinScore.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(51, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(145, 15);
            this.label19.TabIndex = 4;
            this.label19.Text = "最小匹配得分(x100)";
            // 
            // tbpInspectModel
            // 
            this.tbpInspectModel.Controls.Add(this.spltInspect1);
            this.tbpInspectModel.Location = new System.Drawing.Point(4, 25);
            this.tbpInspectModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpInspectModel.Name = "tbpInspectModel";
            this.tbpInspectModel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpInspectModel.Size = new System.Drawing.Size(790, 642);
            this.tbpInspectModel.TabIndex = 2;
            this.tbpInspectModel.Text = "检测模型";
            this.tbpInspectModel.UseVisualStyleBackColor = true;
            // 
            // spltInspect1
            // 
            this.spltInspect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltInspect1.IsSplitterFixed = true;
            this.spltInspect1.Location = new System.Drawing.Point(3, 2);
            this.spltInspect1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spltInspect1.Name = "spltInspect1";
            this.spltInspect1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltInspect1.Panel1
            // 
            this.spltInspect1.Panel1.Controls.Add(this.spltInspect2);
            // 
            // spltInspect1.Panel2
            // 
            this.spltInspect1.Panel2.Controls.Add(this.dgvMatchResult);
            this.spltInspect1.Size = new System.Drawing.Size(784, 638);
            this.spltInspect1.SplitterDistance = 409;
            this.spltInspect1.TabIndex = 0;
            // 
            // spltInspect2
            // 
            this.spltInspect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltInspect2.Location = new System.Drawing.Point(0, 0);
            this.spltInspect2.Name = "spltInspect2";
            // 
            // spltInspect2.Panel1
            // 
            this.spltInspect2.Panel1.Controls.Add(this.lstbTestImages);
            // 
            // spltInspect2.Panel2
            // 
            this.spltInspect2.Panel2.Controls.Add(this.pnlOperation);
            this.spltInspect2.Size = new System.Drawing.Size(784, 409);
            this.spltInspect2.SplitterDistance = 533;
            this.spltInspect2.TabIndex = 0;
            // 
            // lstbTestImages
            // 
            this.lstbTestImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstbTestImages.FormattingEnabled = true;
            this.lstbTestImages.ItemHeight = 15;
            this.lstbTestImages.Location = new System.Drawing.Point(0, 0);
            this.lstbTestImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstbTestImages.Name = "lstbTestImages";
            this.lstbTestImages.Size = new System.Drawing.Size(533, 409);
            this.lstbTestImages.TabIndex = 0;
            // 
            // pnlOperation
            // 
            this.pnlOperation.Controls.Add(this.chkbAlwaysFind);
            this.pnlOperation.Controls.Add(this.btnFindModel);
            this.pnlOperation.Controls.Add(this.btnDisplayImage);
            this.pnlOperation.Controls.Add(this.btnClearImageList);
            this.pnlOperation.Controls.Add(this.btnDeleteImage);
            this.pnlOperation.Controls.Add(this.btnLoadImageList);
            this.pnlOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOperation.Location = new System.Drawing.Point(0, 0);
            this.pnlOperation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlOperation.Name = "pnlOperation";
            this.pnlOperation.Size = new System.Drawing.Size(247, 409);
            this.pnlOperation.TabIndex = 1;
            // 
            // chkbAlwaysFind
            // 
            this.chkbAlwaysFind.AutoSize = true;
            this.chkbAlwaysFind.Location = new System.Drawing.Point(71, 329);
            this.chkbAlwaysFind.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbAlwaysFind.Name = "chkbAlwaysFind";
            this.chkbAlwaysFind.Size = new System.Drawing.Size(89, 19);
            this.chkbAlwaysFind.TabIndex = 1;
            this.chkbAlwaysFind.Tag = "CHKB_ALWAYSFIND";
            this.chkbAlwaysFind.Text = "总是查找";
            this.chkbAlwaysFind.UseVisualStyleBackColor = true;
            // 
            // btnFindModel
            // 
            this.btnFindModel.Location = new System.Drawing.Point(71, 274);
            this.btnFindModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindModel.Name = "btnFindModel";
            this.btnFindModel.Size = new System.Drawing.Size(100, 30);
            this.btnFindModel.TabIndex = 0;
            this.btnFindModel.Tag = "BTN_FINDMODEL";
            this.btnFindModel.Text = "查找模板";
            this.btnFindModel.UseVisualStyleBackColor = true;
            // 
            // btnDisplayImage
            // 
            this.btnDisplayImage.Location = new System.Drawing.Point(71, 219);
            this.btnDisplayImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisplayImage.Name = "btnDisplayImage";
            this.btnDisplayImage.Size = new System.Drawing.Size(100, 30);
            this.btnDisplayImage.TabIndex = 0;
            this.btnDisplayImage.Tag = "BTN_DISPLAYTESTIMAGE";
            this.btnDisplayImage.Text = "显示图像";
            this.btnDisplayImage.UseVisualStyleBackColor = true;
            // 
            // btnClearImageList
            // 
            this.btnClearImageList.Location = new System.Drawing.Point(71, 164);
            this.btnClearImageList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearImageList.Name = "btnClearImageList";
            this.btnClearImageList.Size = new System.Drawing.Size(100, 30);
            this.btnClearImageList.TabIndex = 0;
            this.btnClearImageList.Tag = "BTN_CLEARTESTIMAGES";
            this.btnClearImageList.Text = "清空图像";
            this.btnClearImageList.UseVisualStyleBackColor = true;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(71, 109);
            this.btnDeleteImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteImage.TabIndex = 0;
            this.btnDeleteImage.Tag = "BTN_DELETETESTIMAGE";
            this.btnDeleteImage.Text = "删除图像";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            // 
            // btnLoadImageList
            // 
            this.btnLoadImageList.Location = new System.Drawing.Point(71, 54);
            this.btnLoadImageList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadImageList.Name = "btnLoadImageList";
            this.btnLoadImageList.Size = new System.Drawing.Size(100, 30);
            this.btnLoadImageList.TabIndex = 0;
            this.btnLoadImageList.Tag = "BTN_LOADTESTIMAGES";
            this.btnLoadImageList.Text = "图像列表";
            this.btnLoadImageList.UseVisualStyleBackColor = true;
            // 
            // dgvMatchResult
            // 
            this.dgvMatchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNumber,
            this.ColScore});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatchResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatchResult.Location = new System.Drawing.Point(0, 0);
            this.dgvMatchResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMatchResult.Name = "dgvMatchResult";
            this.dgvMatchResult.RowTemplate.Height = 27;
            this.dgvMatchResult.Size = new System.Drawing.Size(784, 225);
            this.dgvMatchResult.TabIndex = 0;
            // 
            // ColNumber
            // 
            this.ColNumber.HeaderText = "序号";
            this.ColNumber.Name = "ColNumber";
            this.ColNumber.ReadOnly = true;
            // 
            // ColScore
            // 
            this.ColScore.HeaderText = "得分";
            this.ColScore.Name = "ColScore";
            this.ColScore.ReadOnly = true;
            // 
            // tbpOptimize
            // 
            this.tbpOptimize.Controls.Add(this.pnlOptimization);
            this.tbpOptimize.Location = new System.Drawing.Point(4, 25);
            this.tbpOptimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpOptimize.Name = "tbpOptimize";
            this.tbpOptimize.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpOptimize.Size = new System.Drawing.Size(790, 642);
            this.tbpOptimize.TabIndex = 3;
            this.tbpOptimize.Text = "优化模型";
            this.tbpOptimize.UseVisualStyleBackColor = true;
            // 
            // pnlOptimization
            // 
            this.pnlOptimization.Controls.Add(this.btnOptimize);
            this.pnlOptimization.Controls.Add(this.label23);
            this.pnlOptimization.Controls.Add(this.label22);
            this.pnlOptimization.Controls.Add(this.label27);
            this.pnlOptimization.Controls.Add(this.label26);
            this.pnlOptimization.Controls.Add(this.lblOptElapse);
            this.pnlOptimization.Controls.Add(this.lblLastElapse);
            this.pnlOptimization.Controls.Add(this.lblOptRecogRate);
            this.pnlOptimization.Controls.Add(this.lblLastRecogRate);
            this.pnlOptimization.Controls.Add(this.lblOptGreediness);
            this.pnlOptimization.Controls.Add(this.lblLastGreediness);
            this.pnlOptimization.Controls.Add(this.lblOptMinScore);
            this.pnlOptimization.Controls.Add(this.lblLastMinScore);
            this.pnlOptimization.Controls.Add(this.label25);
            this.pnlOptimization.Controls.Add(this.label24);
            this.pnlOptimization.Controls.Add(this.label21);
            this.pnlOptimization.Controls.Add(this.lblOptimizationStatus);
            this.pnlOptimization.Controls.Add(this.grpbMatchModel);
            this.pnlOptimization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOptimization.Location = new System.Drawing.Point(3, 2);
            this.pnlOptimization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlOptimization.Name = "pnlOptimization";
            this.pnlOptimization.Size = new System.Drawing.Size(784, 638);
            this.pnlOptimization.TabIndex = 0;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(492, 522);
            this.btnOptimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(120, 42);
            this.btnOptimize.TabIndex = 4;
            this.btnOptimize.Tag = "BTN_OPTIMIZE";
            this.btnOptimize.Text = "开启优化";
            this.btnOptimize.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(515, 298);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 15);
            this.label23.TabIndex = 3;
            this.label23.Text = "优化运行结果";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(229, 298);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 15);
            this.label22.TabIndex = 3;
            this.label22.Text = "上次运行结果";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(36, 470);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 15);
            this.label27.TabIndex = 3;
            this.label27.Text = "平均耗时";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(36, 428);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 15);
            this.label26.TabIndex = 3;
            this.label26.Text = "识别率";
            // 
            // lblOptElapse
            // 
            this.lblOptElapse.BackColor = System.Drawing.Color.Tomato;
            this.lblOptElapse.Location = new System.Drawing.Point(515, 458);
            this.lblOptElapse.Name = "lblOptElapse";
            this.lblOptElapse.Size = new System.Drawing.Size(96, 28);
            this.lblOptElapse.TabIndex = 3;
            this.lblOptElapse.Text = "-";
            this.lblOptElapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastElapse
            // 
            this.lblLastElapse.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLastElapse.Location = new System.Drawing.Point(229, 458);
            this.lblLastElapse.Name = "lblLastElapse";
            this.lblLastElapse.Size = new System.Drawing.Size(96, 28);
            this.lblLastElapse.TabIndex = 3;
            this.lblLastElapse.Text = "-";
            this.lblLastElapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOptRecogRate
            // 
            this.lblOptRecogRate.BackColor = System.Drawing.Color.Tomato;
            this.lblOptRecogRate.Location = new System.Drawing.Point(515, 415);
            this.lblOptRecogRate.Name = "lblOptRecogRate";
            this.lblOptRecogRate.Size = new System.Drawing.Size(96, 28);
            this.lblOptRecogRate.TabIndex = 3;
            this.lblOptRecogRate.Text = "-";
            this.lblOptRecogRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastRecogRate
            // 
            this.lblLastRecogRate.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLastRecogRate.Location = new System.Drawing.Point(229, 415);
            this.lblLastRecogRate.Name = "lblLastRecogRate";
            this.lblLastRecogRate.Size = new System.Drawing.Size(96, 28);
            this.lblLastRecogRate.TabIndex = 3;
            this.lblLastRecogRate.Text = "-";
            this.lblLastRecogRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOptGreediness
            // 
            this.lblOptGreediness.BackColor = System.Drawing.Color.Tomato;
            this.lblOptGreediness.Location = new System.Drawing.Point(515, 372);
            this.lblOptGreediness.Name = "lblOptGreediness";
            this.lblOptGreediness.Size = new System.Drawing.Size(96, 28);
            this.lblOptGreediness.TabIndex = 3;
            this.lblOptGreediness.Text = "-";
            this.lblOptGreediness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastGreediness
            // 
            this.lblLastGreediness.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLastGreediness.Location = new System.Drawing.Point(229, 372);
            this.lblLastGreediness.Name = "lblLastGreediness";
            this.lblLastGreediness.Size = new System.Drawing.Size(96, 28);
            this.lblLastGreediness.TabIndex = 3;
            this.lblLastGreediness.Text = "-";
            this.lblLastGreediness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOptMinScore
            // 
            this.lblOptMinScore.BackColor = System.Drawing.Color.Tomato;
            this.lblOptMinScore.Location = new System.Drawing.Point(515, 329);
            this.lblOptMinScore.Name = "lblOptMinScore";
            this.lblOptMinScore.Size = new System.Drawing.Size(96, 28);
            this.lblOptMinScore.TabIndex = 3;
            this.lblOptMinScore.Text = "-";
            this.lblOptMinScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastMinScore
            // 
            this.lblLastMinScore.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLastMinScore.Location = new System.Drawing.Point(229, 329);
            this.lblLastMinScore.Name = "lblLastMinScore";
            this.lblLastMinScore.Size = new System.Drawing.Size(96, 28);
            this.lblLastMinScore.TabIndex = 3;
            this.lblLastMinScore.Text = "-";
            this.lblLastMinScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(36, 384);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 15);
            this.label25.TabIndex = 3;
            this.label25.Text = "贪婪度";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(36, 341);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(97, 15);
            this.label24.TabIndex = 3;
            this.label24.Text = "最小匹配得分";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(36, 298);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 15);
            this.label21.TabIndex = 3;
            this.label21.Text = "统计";
            // 
            // lblOptimizationStatus
            // 
            this.lblOptimizationStatus.BackColor = System.Drawing.SystemColors.Info;
            this.lblOptimizationStatus.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOptimizationStatus.Location = new System.Drawing.Point(35, 240);
            this.lblOptimizationStatus.Name = "lblOptimizationStatus";
            this.lblOptimizationStatus.Size = new System.Drawing.Size(644, 22);
            this.lblOptimizationStatus.TabIndex = 2;
            this.lblOptimizationStatus.Text = "优化状态:";
            // 
            // grpbMatchModel
            // 
            this.grpbMatchModel.Controls.Add(this.trkbRecogRate);
            this.grpbMatchModel.Controls.Add(this.cmbRecogRateOption);
            this.grpbMatchModel.Controls.Add(this.numUpDwnRecogRate);
            this.grpbMatchModel.Controls.Add(this.numUpDwnSpecifiedNum);
            this.grpbMatchModel.Controls.Add(this.label20);
            this.grpbMatchModel.Controls.Add(this.rdbtnMaxNum);
            this.grpbMatchModel.Controls.Add(this.label28);
            this.grpbMatchModel.Controls.Add(this.rdbtnAtLeastOne);
            this.grpbMatchModel.Controls.Add(this.rdbtnSpecifiedNum);
            this.grpbMatchModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbMatchModel.Location = new System.Drawing.Point(0, 0);
            this.grpbMatchModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbMatchModel.Name = "grpbMatchModel";
            this.grpbMatchModel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbMatchModel.Size = new System.Drawing.Size(784, 205);
            this.grpbMatchModel.TabIndex = 1;
            this.grpbMatchModel.TabStop = false;
            this.grpbMatchModel.Text = "匹配选项";
            // 
            // trkbRecogRate
            // 
            this.trkbRecogRate.AutoSize = false;
            this.trkbRecogRate.Location = new System.Drawing.Point(452, 135);
            this.trkbRecogRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkbRecogRate.Maximum = 100;
            this.trkbRecogRate.Minimum = 1;
            this.trkbRecogRate.Name = "trkbRecogRate";
            this.trkbRecogRate.Size = new System.Drawing.Size(224, 29);
            this.trkbRecogRate.TabIndex = 4;
            this.trkbRecogRate.Tag = "TRKB_RECOGRATE";
            this.trkbRecogRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkbRecogRate.Value = 100;
            // 
            // cmbRecogRateOption
            // 
            this.cmbRecogRateOption.FormattingEnabled = true;
            this.cmbRecogRateOption.Items.AddRange(new object[] {
            "=",
            ">="});
            this.cmbRecogRateOption.Location = new System.Drawing.Point(120, 141);
            this.cmbRecogRateOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRecogRateOption.Name = "cmbRecogRateOption";
            this.cmbRecogRateOption.Size = new System.Drawing.Size(105, 23);
            this.cmbRecogRateOption.TabIndex = 3;
            this.cmbRecogRateOption.Tag = "RECOGRATEOPTION";
            // 
            // numUpDwnRecogRate
            // 
            this.numUpDwnRecogRate.Location = new System.Drawing.Point(231, 141);
            this.numUpDwnRecogRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnRecogRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDwnRecogRate.Name = "numUpDwnRecogRate";
            this.numUpDwnRecogRate.Size = new System.Drawing.Size(149, 25);
            this.numUpDwnRecogRate.TabIndex = 2;
            this.numUpDwnRecogRate.Tag = "NUMUPDWN_RECOGRATE";
            this.numUpDwnRecogRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numUpDwnSpecifiedNum
            // 
            this.numUpDwnSpecifiedNum.Location = new System.Drawing.Point(581, 34);
            this.numUpDwnSpecifiedNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnSpecifiedNum.Name = "numUpDwnSpecifiedNum";
            this.numUpDwnSpecifiedNum.Size = new System.Drawing.Size(95, 25);
            this.numUpDwnSpecifiedNum.TabIndex = 2;
            this.numUpDwnSpecifiedNum.Tag = "NUMUPDWN_SPECIFIEDNUM";
            this.numUpDwnSpecifiedNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(31, 144);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "识别率";
            // 
            // rdbtnMaxNum
            // 
            this.rdbtnMaxNum.AutoSize = true;
            this.rdbtnMaxNum.Checked = true;
            this.rdbtnMaxNum.Location = new System.Drawing.Point(117, 104);
            this.rdbtnMaxNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnMaxNum.Name = "rdbtnMaxNum";
            this.rdbtnMaxNum.Size = new System.Drawing.Size(238, 19);
            this.rdbtnMaxNum.TabIndex = 1;
            this.rdbtnMaxNum.TabStop = true;
            this.rdbtnMaxNum.Tag = "FINDMAXNUM";
            this.rdbtnMaxNum.Text = "查找尽可能多的匹配模板的实例";
            this.rdbtnMaxNum.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(31, 36);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 15);
            this.label28.TabIndex = 0;
            this.label28.Text = "识别模式";
            // 
            // rdbtnAtLeastOne
            // 
            this.rdbtnAtLeastOne.AutoSize = true;
            this.rdbtnAtLeastOne.Location = new System.Drawing.Point(117, 69);
            this.rdbtnAtLeastOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnAtLeastOne.Name = "rdbtnAtLeastOne";
            this.rdbtnAtLeastOne.Size = new System.Drawing.Size(283, 19);
            this.rdbtnAtLeastOne.TabIndex = 1;
            this.rdbtnAtLeastOne.Tag = "FINDATLEASTONE";
            this.rdbtnAtLeastOne.Text = "查找每张图至少有一个匹配模板的实例";
            this.rdbtnAtLeastOne.UseVisualStyleBackColor = true;
            // 
            // rdbtnSpecifiedNum
            // 
            this.rdbtnSpecifiedNum.AutoSize = true;
            this.rdbtnSpecifiedNum.Location = new System.Drawing.Point(117, 34);
            this.rdbtnSpecifiedNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbtnSpecifiedNum.Name = "rdbtnSpecifiedNum";
            this.rdbtnSpecifiedNum.Size = new System.Drawing.Size(238, 19);
            this.rdbtnSpecifiedNum.TabIndex = 1;
            this.rdbtnSpecifiedNum.Tag = "FINDSPECIFIEDNUM";
            this.rdbtnSpecifiedNum.Text = "查找指定数目的匹配模板的实例";
            this.rdbtnSpecifiedNum.UseVisualStyleBackColor = true;
            // 
            // tbpStatistic
            // 
            this.tbpStatistic.Controls.Add(this.grpbStatistic);
            this.tbpStatistic.Controls.Add(this.grpbRecogRate);
            this.tbpStatistic.Location = new System.Drawing.Point(4, 25);
            this.tbpStatistic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpStatistic.Name = "tbpStatistic";
            this.tbpStatistic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpStatistic.Size = new System.Drawing.Size(790, 642);
            this.tbpStatistic.TabIndex = 4;
            this.tbpStatistic.Text = "测试统计";
            this.tbpStatistic.UseVisualStyleBackColor = true;
            // 
            // grpbStatistic
            // 
            this.grpbStatistic.Controls.Add(this.btnStatistic);
            this.grpbStatistic.Controls.Add(this.numUpDwnMaxNumMatch);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeColScale);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeRowScale);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxColScale);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxRowScale);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeAngle);
            this.grpbStatistic.Controls.Add(this.lblInspectMinColScale);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxAngle);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeCol);
            this.grpbStatistic.Controls.Add(this.lblInspectMinRowScale);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxCol);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeRow);
            this.grpbStatistic.Controls.Add(this.lblInspectMinAngle);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxRow);
            this.grpbStatistic.Controls.Add(this.lblInspectMinCol);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeElapse);
            this.grpbStatistic.Controls.Add(this.lblInspectMinRow);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxElapse);
            this.grpbStatistic.Controls.Add(this.lblInspectRangeScore);
            this.grpbStatistic.Controls.Add(this.lblInspectMaxScore);
            this.grpbStatistic.Controls.Add(this.lblInspectMinElapse);
            this.grpbStatistic.Controls.Add(this.lblInspectMinScore);
            this.grpbStatistic.Controls.Add(this.label38);
            this.grpbStatistic.Controls.Add(this.label37);
            this.grpbStatistic.Controls.Add(this.label36);
            this.grpbStatistic.Controls.Add(this.label47);
            this.grpbStatistic.Controls.Add(this.label46);
            this.grpbStatistic.Controls.Add(this.label44);
            this.grpbStatistic.Controls.Add(this.label43);
            this.grpbStatistic.Controls.Add(this.label45);
            this.grpbStatistic.Controls.Add(this.label41);
            this.grpbStatistic.Controls.Add(this.label42);
            this.grpbStatistic.Controls.Add(this.label40);
            this.grpbStatistic.Controls.Add(this.label39);
            this.grpbStatistic.Controls.Add(this.label35);
            this.grpbStatistic.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbStatistic.Location = new System.Drawing.Point(3, 206);
            this.grpbStatistic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbStatistic.Name = "grpbStatistic";
            this.grpbStatistic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbStatistic.Size = new System.Drawing.Size(784, 429);
            this.grpbStatistic.TabIndex = 1;
            this.grpbStatistic.TabStop = false;
            this.grpbStatistic.Text = "结果统计";
            // 
            // btnStatistic
            // 
            this.btnStatistic.Location = new System.Drawing.Point(543, 332);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(120, 42);
            this.btnStatistic.TabIndex = 6;
            this.btnStatistic.Tag = "BTN_STATISTIC";
            this.btnStatistic.Text = "开启统计";
            this.btnStatistic.UseVisualStyleBackColor = true;
            // 
            // numUpDwnMaxNumMatch
            // 
            this.numUpDwnMaxNumMatch.Location = new System.Drawing.Point(163, 331);
            this.numUpDwnMaxNumMatch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numUpDwnMaxNumMatch.Name = "numUpDwnMaxNumMatch";
            this.numUpDwnMaxNumMatch.Size = new System.Drawing.Size(95, 25);
            this.numUpDwnMaxNumMatch.TabIndex = 5;
            this.numUpDwnMaxNumMatch.Tag = "NUMUPDWN_MAXNUMTOMATCH";
            this.numUpDwnMaxNumMatch.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblInspectRangeColScale
            // 
            this.lblInspectRangeColScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeColScale.Location = new System.Drawing.Point(554, 289);
            this.lblInspectRangeColScale.Name = "lblInspectRangeColScale";
            this.lblInspectRangeColScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeColScale.TabIndex = 4;
            this.lblInspectRangeColScale.Text = "-";
            this.lblInspectRangeColScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeRowScale
            // 
            this.lblInspectRangeRowScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeRowScale.Location = new System.Drawing.Point(554, 256);
            this.lblInspectRangeRowScale.Name = "lblInspectRangeRowScale";
            this.lblInspectRangeRowScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeRowScale.TabIndex = 4;
            this.lblInspectRangeRowScale.Text = "-";
            this.lblInspectRangeRowScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxColScale
            // 
            this.lblInspectMaxColScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxColScale.Location = new System.Drawing.Point(357, 289);
            this.lblInspectMaxColScale.Name = "lblInspectMaxColScale";
            this.lblInspectMaxColScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxColScale.TabIndex = 4;
            this.lblInspectMaxColScale.Text = "-";
            this.lblInspectMaxColScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxRowScale
            // 
            this.lblInspectMaxRowScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxRowScale.Location = new System.Drawing.Point(357, 256);
            this.lblInspectMaxRowScale.Name = "lblInspectMaxRowScale";
            this.lblInspectMaxRowScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxRowScale.TabIndex = 4;
            this.lblInspectMaxRowScale.Text = "-";
            this.lblInspectMaxRowScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeAngle
            // 
            this.lblInspectRangeAngle.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeAngle.Location = new System.Drawing.Point(554, 222);
            this.lblInspectRangeAngle.Name = "lblInspectRangeAngle";
            this.lblInspectRangeAngle.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeAngle.TabIndex = 4;
            this.lblInspectRangeAngle.Text = "-";
            this.lblInspectRangeAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinColScale
            // 
            this.lblInspectMinColScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinColScale.Location = new System.Drawing.Point(163, 289);
            this.lblInspectMinColScale.Name = "lblInspectMinColScale";
            this.lblInspectMinColScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinColScale.TabIndex = 4;
            this.lblInspectMinColScale.Text = "-";
            this.lblInspectMinColScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxAngle
            // 
            this.lblInspectMaxAngle.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxAngle.Location = new System.Drawing.Point(357, 222);
            this.lblInspectMaxAngle.Name = "lblInspectMaxAngle";
            this.lblInspectMaxAngle.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxAngle.TabIndex = 4;
            this.lblInspectMaxAngle.Text = "-";
            this.lblInspectMaxAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeCol
            // 
            this.lblInspectRangeCol.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeCol.Location = new System.Drawing.Point(554, 190);
            this.lblInspectRangeCol.Name = "lblInspectRangeCol";
            this.lblInspectRangeCol.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeCol.TabIndex = 4;
            this.lblInspectRangeCol.Text = "-";
            this.lblInspectRangeCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinRowScale
            // 
            this.lblInspectMinRowScale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinRowScale.Location = new System.Drawing.Point(163, 256);
            this.lblInspectMinRowScale.Name = "lblInspectMinRowScale";
            this.lblInspectMinRowScale.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinRowScale.TabIndex = 4;
            this.lblInspectMinRowScale.Text = "-";
            this.lblInspectMinRowScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxCol
            // 
            this.lblInspectMaxCol.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxCol.Location = new System.Drawing.Point(357, 190);
            this.lblInspectMaxCol.Name = "lblInspectMaxCol";
            this.lblInspectMaxCol.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxCol.TabIndex = 4;
            this.lblInspectMaxCol.Text = "-";
            this.lblInspectMaxCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeRow
            // 
            this.lblInspectRangeRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeRow.Location = new System.Drawing.Point(554, 158);
            this.lblInspectRangeRow.Name = "lblInspectRangeRow";
            this.lblInspectRangeRow.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeRow.TabIndex = 4;
            this.lblInspectRangeRow.Text = "-";
            this.lblInspectRangeRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinAngle
            // 
            this.lblInspectMinAngle.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinAngle.Location = new System.Drawing.Point(163, 222);
            this.lblInspectMinAngle.Name = "lblInspectMinAngle";
            this.lblInspectMinAngle.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinAngle.TabIndex = 4;
            this.lblInspectMinAngle.Text = "-";
            this.lblInspectMinAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxRow
            // 
            this.lblInspectMaxRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxRow.Location = new System.Drawing.Point(357, 158);
            this.lblInspectMaxRow.Name = "lblInspectMaxRow";
            this.lblInspectMaxRow.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxRow.TabIndex = 4;
            this.lblInspectMaxRow.Text = "-";
            this.lblInspectMaxRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinCol
            // 
            this.lblInspectMinCol.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinCol.Location = new System.Drawing.Point(163, 190);
            this.lblInspectMinCol.Name = "lblInspectMinCol";
            this.lblInspectMinCol.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinCol.TabIndex = 4;
            this.lblInspectMinCol.Text = "-";
            this.lblInspectMinCol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeElapse
            // 
            this.lblInspectRangeElapse.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeElapse.Location = new System.Drawing.Point(554, 91);
            this.lblInspectRangeElapse.Name = "lblInspectRangeElapse";
            this.lblInspectRangeElapse.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeElapse.TabIndex = 4;
            this.lblInspectRangeElapse.Text = "-";
            this.lblInspectRangeElapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinRow
            // 
            this.lblInspectMinRow.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinRow.Location = new System.Drawing.Point(163, 158);
            this.lblInspectMinRow.Name = "lblInspectMinRow";
            this.lblInspectMinRow.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinRow.TabIndex = 4;
            this.lblInspectMinRow.Text = "-";
            this.lblInspectMinRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxElapse
            // 
            this.lblInspectMaxElapse.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxElapse.Location = new System.Drawing.Point(357, 91);
            this.lblInspectMaxElapse.Name = "lblInspectMaxElapse";
            this.lblInspectMaxElapse.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxElapse.TabIndex = 4;
            this.lblInspectMaxElapse.Text = "-";
            this.lblInspectMaxElapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectRangeScore
            // 
            this.lblInspectRangeScore.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectRangeScore.Location = new System.Drawing.Point(554, 58);
            this.lblInspectRangeScore.Name = "lblInspectRangeScore";
            this.lblInspectRangeScore.Size = new System.Drawing.Size(96, 28);
            this.lblInspectRangeScore.TabIndex = 4;
            this.lblInspectRangeScore.Text = "-";
            this.lblInspectRangeScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMaxScore
            // 
            this.lblInspectMaxScore.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMaxScore.Location = new System.Drawing.Point(357, 58);
            this.lblInspectMaxScore.Name = "lblInspectMaxScore";
            this.lblInspectMaxScore.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMaxScore.TabIndex = 4;
            this.lblInspectMaxScore.Text = "-";
            this.lblInspectMaxScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinElapse
            // 
            this.lblInspectMinElapse.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinElapse.Location = new System.Drawing.Point(163, 91);
            this.lblInspectMinElapse.Name = "lblInspectMinElapse";
            this.lblInspectMinElapse.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinElapse.TabIndex = 4;
            this.lblInspectMinElapse.Text = "-";
            this.lblInspectMinElapse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectMinScore
            // 
            this.lblInspectMinScore.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblInspectMinScore.Location = new System.Drawing.Point(163, 58);
            this.lblInspectMinScore.Name = "lblInspectMinScore";
            this.lblInspectMinScore.Size = new System.Drawing.Size(96, 28);
            this.lblInspectMinScore.TabIndex = 4;
            this.lblInspectMinScore.Text = "-";
            this.lblInspectMinScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(571, 32);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(67, 15);
            this.label38.TabIndex = 1;
            this.label38.Text = "范围区间";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(384, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(52, 15);
            this.label37.TabIndex = 1;
            this.label37.Text = "最大值";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(181, 32);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 15);
            this.label36.TabIndex = 1;
            this.label36.Text = "最小值";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(33, 332);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(82, 15);
            this.label47.TabIndex = 1;
            this.label47.Text = "最大匹配数";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(33, 295);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 15);
            this.label46.TabIndex = 1;
            this.label46.Text = "列缩放";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(33, 229);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(52, 15);
            this.label44.TabIndex = 1;
            this.label44.Text = "旋转角";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(33, 196);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 15);
            this.label43.TabIndex = 1;
            this.label43.Text = "列坐标";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(33, 262);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(52, 15);
            this.label45.TabIndex = 1;
            this.label45.Text = "行缩放";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(33, 130);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(67, 15);
            this.label41.TabIndex = 1;
            this.label41.Text = "位置边界";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(33, 162);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 15);
            this.label42.TabIndex = 1;
            this.label42.Text = "行坐标";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(33, 98);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(67, 15);
            this.label40.TabIndex = 1;
            this.label40.Text = "平均耗时";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(33, 64);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 15);
            this.label39.TabIndex = 1;
            this.label39.Text = "匹配得分";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(33, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 15);
            this.label35.TabIndex = 1;
            this.label35.Text = "识别";
            // 
            // grpbRecogRate
            // 
            this.grpbRecogRate.Controls.Add(this.lblToMaxNum);
            this.grpbRecogRate.Controls.Add(this.lblToSpecifiedNum);
            this.grpbRecogRate.Controls.Add(this.lblMaxNum);
            this.grpbRecogRate.Controls.Add(this.lblSpecifiedNum);
            this.grpbRecogRate.Controls.Add(this.lblAtleastOne);
            this.grpbRecogRate.Controls.Add(this.label29);
            this.grpbRecogRate.Controls.Add(this.label34);
            this.grpbRecogRate.Controls.Add(this.label33);
            this.grpbRecogRate.Controls.Add(this.label32);
            this.grpbRecogRate.Controls.Add(this.label31);
            this.grpbRecogRate.Controls.Add(this.label30);
            this.grpbRecogRate.Controls.Add(this.label48);
            this.grpbRecogRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbRecogRate.Location = new System.Drawing.Point(3, 2);
            this.grpbRecogRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbRecogRate.Name = "grpbRecogRate";
            this.grpbRecogRate.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbRecogRate.Size = new System.Drawing.Size(784, 204);
            this.grpbRecogRate.TabIndex = 0;
            this.grpbRecogRate.TabStop = false;
            this.grpbRecogRate.Text = "识别率";
            // 
            // lblToMaxNum
            // 
            this.lblToMaxNum.AutoSize = true;
            this.lblToMaxNum.Location = new System.Drawing.Point(325, 168);
            this.lblToMaxNum.Name = "lblToMaxNum";
            this.lblToMaxNum.Size = new System.Drawing.Size(199, 15);
            this.lblToMaxNum.TabIndex = 2;
            this.lblToMaxNum.Text = "100.00 % (1 of 1  model)";
            // 
            // lblToSpecifiedNum
            // 
            this.lblToSpecifiedNum.AutoSize = true;
            this.lblToSpecifiedNum.Location = new System.Drawing.Point(325, 138);
            this.lblToSpecifiedNum.Name = "lblToSpecifiedNum";
            this.lblToSpecifiedNum.Size = new System.Drawing.Size(199, 15);
            this.lblToSpecifiedNum.TabIndex = 2;
            this.lblToSpecifiedNum.Text = "100.00 % (1 of 1  model)";
            // 
            // lblMaxNum
            // 
            this.lblMaxNum.AutoSize = true;
            this.lblMaxNum.Location = new System.Drawing.Point(325, 98);
            this.lblMaxNum.Name = "lblMaxNum";
            this.lblMaxNum.Size = new System.Drawing.Size(199, 15);
            this.lblMaxNum.TabIndex = 2;
            this.lblMaxNum.Text = "100.00 % (1 of 1  image)";
            // 
            // lblSpecifiedNum
            // 
            this.lblSpecifiedNum.AutoSize = true;
            this.lblSpecifiedNum.Location = new System.Drawing.Point(325, 62);
            this.lblSpecifiedNum.Name = "lblSpecifiedNum";
            this.lblSpecifiedNum.Size = new System.Drawing.Size(199, 15);
            this.lblSpecifiedNum.TabIndex = 2;
            this.lblSpecifiedNum.Text = "100.00 % (1 of 1  image)";
            // 
            // lblAtleastOne
            // 
            this.lblAtleastOne.AutoSize = true;
            this.lblAtleastOne.Location = new System.Drawing.Point(325, 29);
            this.lblAtleastOne.Name = "lblAtleastOne";
            this.lblAtleastOne.Size = new System.Drawing.Size(199, 15);
            this.lblAtleastOne.TabIndex = 2;
            this.lblAtleastOne.Text = "100.00 % (1 of 1  image)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(33, 138);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 15);
            this.label29.TabIndex = 1;
            this.label29.Text = "匹配";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(124, 168);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(187, 15);
            this.label34.TabIndex = 1;
            this.label34.Text = "相对最大数目的匹配的比例";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(124, 138);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(187, 15);
            this.label33.TabIndex = 1;
            this.label33.Text = "相对指定数目的匹配的比例";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(124, 98);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(187, 15);
            this.label32.TabIndex = 1;
            this.label32.Text = "尽可能多的匹配模板的实例";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(124, 62);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(187, 15);
            this.label31.TabIndex = 1;
            this.label31.Text = "指定数目的匹配模板的实例";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(124, 29);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(187, 15);
            this.label30.TabIndex = 1;
            this.label30.Text = "至少有一个匹配模板的实例";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(33, 29);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(52, 15);
            this.label48.TabIndex = 1;
            this.label48.Text = "图像：";
            // 
            // FrmMatchModel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1508, 812);
            this.Controls.Add(this.spltRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMatchModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "FRM_MATCHMODEL";
            this.Text = "模板匹配工具";
            this.spltRoot.Panel1.ResumeLayout(false);
            this.spltRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltRoot)).EndInit();
            this.spltRoot.ResumeLayout(false);
            this.spltOperation.Panel1.ResumeLayout(false);
            this.spltOperation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltOperation)).EndInit();
            this.spltOperation.ResumeLayout(false);
            this.pnlOption.ResumeLayout(false);
            this.pnlOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnHysteresisHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnHysteresisLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnFilterAlpha)).EndInit();
            this.spltViewResult.Panel1.ResumeLayout(false);
            this.spltViewResult.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltViewResult)).EndInit();
            this.spltViewResult.ResumeLayout(false);
            this.ctxmstrpHwndDisplay.ResumeLayout(false);
            this.tabControlModel.ResumeLayout(false);
            this.tbpCreateModelPara.ResumeLayout(false);
            this.pnlCreateModelPara.ResumeLayout(false);
            this.pnlCreateModelPara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbScaleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbNumLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbAngleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbDisplayLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnAngleExtent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnNumLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnScaleStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnDisplayLevel)).EndInit();
            this.tbpFindModelPara.ResumeLayout(false);
            this.pnlFindModelPara.ResumeLayout(false);
            this.pnlFindModelPara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbLastLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnLastLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMaxOverlap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxOverlap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbGreediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnGreediness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbNumToMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnNumToMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkbMinScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMinScore)).EndInit();
            this.tbpInspectModel.ResumeLayout(false);
            this.spltInspect1.Panel1.ResumeLayout(false);
            this.spltInspect1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltInspect1)).EndInit();
            this.spltInspect1.ResumeLayout(false);
            this.spltInspect2.Panel1.ResumeLayout(false);
            this.spltInspect2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltInspect2)).EndInit();
            this.spltInspect2.ResumeLayout(false);
            this.pnlOperation.ResumeLayout(false);
            this.pnlOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatchResult)).EndInit();
            this.tbpOptimize.ResumeLayout(false);
            this.pnlOptimization.ResumeLayout(false);
            this.pnlOptimization.PerformLayout();
            this.grpbMatchModel.ResumeLayout(false);
            this.grpbMatchModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkbRecogRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnRecogRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnSpecifiedNum)).EndInit();
            this.tbpStatistic.ResumeLayout(false);
            this.grpbStatistic.ResumeLayout(false);
            this.grpbStatistic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnMaxNumMatch)).EndInit();
            this.grpbRecogRate.ResumeLayout(false);
            this.grpbRecogRate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltRoot;
        protected internal System.Windows.Forms.ContextMenuStrip ctxmstrpHwndDisplay;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiLoadImage;
        private System.Windows.Forms.ToolStripSeparator tlstrpspOperationArray;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROILine;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROIRectangle1;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROIRectangle2;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROICircle;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROICircularArc;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROIAnnulus;
        private System.Windows.Forms.ToolStripSeparator tlstrpspROIArray;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiVIEWNone;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiVIEWMove;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiVIEWZoom;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiVIEWMagnify;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiVIEWClearROI;
        private System.Windows.Forms.SplitContainer spltOperation;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOperationLevel;
        protected internal System.Windows.Forms.ComboBox cmbOptionLevel;
        protected internal System.Windows.Forms.ComboBox cmbModelType;
        private System.Windows.Forms.CheckBox chkbBrushOnOff;
        private System.Windows.Forms.CheckBox chkbBrushShape;
        private System.Windows.Forms.CheckBox chkbFillErase;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnFilterAlpha;
        protected internal System.Windows.Forms.Button btnGenerateExtractRegion;
        protected internal System.Windows.Forms.Button btnGenerateSearchRegion;
        protected internal System.Windows.Forms.Button btnCreateMatchModel;
        protected internal System.Windows.Forms.Button btnSaveMatchModel;
        protected internal System.Windows.Forms.Button btnApplyModel;
        protected internal System.Windows.Forms.Button btnClearModel;
        private System.Windows.Forms.ComboBox cmbEraseOption;
        private System.Windows.Forms.Label lblEraseOption;
        private System.Windows.Forms.SplitContainer spltViewResult;
        private HalconDotNet.HWindowControl hWndcDisplay;
        private System.Windows.Forms.DataGridView dgvMatchResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScore;
        private System.Windows.Forms.TabControl tabControlModel;
        protected internal System.Windows.Forms.TabPage tbpCreateModelPara;
        private System.Windows.Forms.Panel pnlCreateModelPara;
        private System.Windows.Forms.CheckBox chkbMinContrast;
        private System.Windows.Forms.CheckBox chkbOption;
        private System.Windows.Forms.CheckBox chkbNumLevel;
        private System.Windows.Forms.CheckBox chkbAngleStep;
        private System.Windows.Forms.CheckBox chkbScaleStep;
        private System.Windows.Forms.CheckBox chkbContrast;
        protected internal System.Windows.Forms.TrackBar trkbMinContrast;
        protected internal System.Windows.Forms.TrackBar trkbStartAngle;
        protected internal System.Windows.Forms.TrackBar trkbScaleStep;
        protected internal System.Windows.Forms.TrackBar trkbNumLevels;
        protected internal System.Windows.Forms.TrackBar trkbMaxScale;
        protected internal System.Windows.Forms.TrackBar trkbAngleStep;
        protected internal System.Windows.Forms.TrackBar trkbMinScale;
        protected internal System.Windows.Forms.TrackBar trkbAngleExtent;
        protected internal System.Windows.Forms.TrackBar trkbContrast;
        protected internal System.Windows.Forms.TrackBar trkbDisplayLevel;
        protected internal System.Windows.Forms.ComboBox cmbOptimization;
        protected internal System.Windows.Forms.ComboBox cmbMetric;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMinContrast;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnAngleStep;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnAngleExtent;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMaxScale;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnStartAngle;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnNumLevels;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMinScale;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnScaleStep;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnContrast;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnDisplayLevel;
        protected internal System.Windows.Forms.Label label12;
        protected internal System.Windows.Forms.Label label11;
        protected internal System.Windows.Forms.Label label8;
        protected internal System.Windows.Forms.Label label7;
        protected internal System.Windows.Forms.Label label10;
        protected internal System.Windows.Forms.Label label4;
        protected internal System.Windows.Forms.Label label6;
        protected internal System.Windows.Forms.Label label9;
        protected internal System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tbpFindModelPara;
        protected internal System.Windows.Forms.Panel pnlFindModelPara;
        protected internal System.Windows.Forms.ComboBox cmbSubPixel;
        protected internal System.Windows.Forms.Label label18;
        protected internal System.Windows.Forms.TrackBar trkbLastLevel;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnLastLevel;
        protected internal System.Windows.Forms.TrackBar trkbMaxOverlap;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMaxOverlap;
        protected internal System.Windows.Forms.TrackBar trkbGreediness;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnGreediness;
        protected internal System.Windows.Forms.Label label17;
        protected internal System.Windows.Forms.TrackBar trkbNumToMatch;
        protected internal System.Windows.Forms.Label label16;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnNumToMatch;
        protected internal System.Windows.Forms.Label label15;
        protected internal System.Windows.Forms.TrackBar trkbMinScore;
        protected internal System.Windows.Forms.Label label14;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMinScore;
        protected internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tbpInspectModel;
        private System.Windows.Forms.SplitContainer spltInspect1;
        private System.Windows.Forms.SplitContainer spltInspect2;
        protected internal System.Windows.Forms.ListBox lstbTestImages;
        protected internal System.Windows.Forms.Panel pnlOperation;
        private System.Windows.Forms.CheckBox chkbAlwaysFind;
        private System.Windows.Forms.Button btnFindModel;
        private System.Windows.Forms.Button btnDisplayImage;
        private System.Windows.Forms.Button btnClearImageList;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnLoadImageList;
        private System.Windows.Forms.TabPage tbpOptimize;
        protected internal System.Windows.Forms.Panel pnlOptimization;
        private System.Windows.Forms.Button btnOptimize;
        protected internal System.Windows.Forms.Label label23;
        protected internal System.Windows.Forms.Label label22;
        protected internal System.Windows.Forms.Label label27;
        protected internal System.Windows.Forms.Label label26;
        protected internal System.Windows.Forms.Label lblOptElapse;
        protected internal System.Windows.Forms.Label lblLastElapse;
        protected internal System.Windows.Forms.Label lblOptRecogRate;
        protected internal System.Windows.Forms.Label lblLastRecogRate;
        protected internal System.Windows.Forms.Label lblOptGreediness;
        protected internal System.Windows.Forms.Label lblLastGreediness;
        protected internal System.Windows.Forms.Label lblOptMinScore;
        protected internal System.Windows.Forms.Label lblLastMinScore;
        protected internal System.Windows.Forms.Label label25;
        protected internal System.Windows.Forms.Label label24;
        protected internal System.Windows.Forms.Label label21;
        protected internal System.Windows.Forms.Label lblOptimizationStatus;
        private System.Windows.Forms.GroupBox grpbMatchModel;
        private System.Windows.Forms.TrackBar trkbRecogRate;
        protected internal System.Windows.Forms.ComboBox cmbRecogRateOption;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnRecogRate;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnSpecifiedNum;
        protected internal System.Windows.Forms.Label label20;
        protected internal System.Windows.Forms.RadioButton rdbtnMaxNum;
        protected internal System.Windows.Forms.Label label28;
        protected internal System.Windows.Forms.RadioButton rdbtnAtLeastOne;
        protected internal System.Windows.Forms.RadioButton rdbtnSpecifiedNum;
        private System.Windows.Forms.TabPage tbpStatistic;
        protected internal System.Windows.Forms.GroupBox grpbStatistic;
        private System.Windows.Forms.Button btnStatistic;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnMaxNumMatch;
        protected internal System.Windows.Forms.Label lblInspectRangeColScale;
        protected internal System.Windows.Forms.Label lblInspectRangeRowScale;
        protected internal System.Windows.Forms.Label lblInspectMaxColScale;
        protected internal System.Windows.Forms.Label lblInspectMaxRowScale;
        protected internal System.Windows.Forms.Label lblInspectRangeAngle;
        protected internal System.Windows.Forms.Label lblInspectMinColScale;
        protected internal System.Windows.Forms.Label lblInspectMaxAngle;
        protected internal System.Windows.Forms.Label lblInspectRangeCol;
        protected internal System.Windows.Forms.Label lblInspectMinRowScale;
        protected internal System.Windows.Forms.Label lblInspectMaxCol;
        protected internal System.Windows.Forms.Label lblInspectRangeRow;
        protected internal System.Windows.Forms.Label lblInspectMinAngle;
        protected internal System.Windows.Forms.Label lblInspectMaxRow;
        protected internal System.Windows.Forms.Label lblInspectMinCol;
        protected internal System.Windows.Forms.Label lblInspectRangeElapse;
        protected internal System.Windows.Forms.Label lblInspectMinRow;
        protected internal System.Windows.Forms.Label lblInspectMaxElapse;
        protected internal System.Windows.Forms.Label lblInspectRangeScore;
        protected internal System.Windows.Forms.Label lblInspectMaxScore;
        protected internal System.Windows.Forms.Label lblInspectMinElapse;
        protected internal System.Windows.Forms.Label lblInspectMinScore;
        protected internal System.Windows.Forms.Label label38;
        protected internal System.Windows.Forms.Label label37;
        protected internal System.Windows.Forms.Label label36;
        protected internal System.Windows.Forms.Label label47;
        protected internal System.Windows.Forms.Label label46;
        protected internal System.Windows.Forms.Label label44;
        protected internal System.Windows.Forms.Label label43;
        protected internal System.Windows.Forms.Label label45;
        protected internal System.Windows.Forms.Label label41;
        protected internal System.Windows.Forms.Label label42;
        protected internal System.Windows.Forms.Label label40;
        protected internal System.Windows.Forms.Label label39;
        protected internal System.Windows.Forms.Label label35;
        protected internal System.Windows.Forms.GroupBox grpbRecogRate;
        protected internal System.Windows.Forms.Label lblToMaxNum;
        protected internal System.Windows.Forms.Label lblToSpecifiedNum;
        protected internal System.Windows.Forms.Label lblMaxNum;
        protected internal System.Windows.Forms.Label lblSpecifiedNum;
        protected internal System.Windows.Forms.Label lblAtleastOne;
        protected internal System.Windows.Forms.Label label29;
        protected internal System.Windows.Forms.Label label34;
        protected internal System.Windows.Forms.Label label33;
        protected internal System.Windows.Forms.Label label32;
        protected internal System.Windows.Forms.Label label31;
        protected internal System.Windows.Forms.Label label30;
        protected internal System.Windows.Forms.Label label48;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnHysteresisHigh;
        protected internal System.Windows.Forms.NumericUpDown numUpDwnHysteresisLow;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label lblFilterAlpahPrompt;
        protected internal System.Windows.Forms.Label lblCoordinateGrayValue;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiLoadModel;
        protected internal System.Windows.Forms.Button btnEraseRegion;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiROIFreeDraw;
        protected internal System.Windows.Forms.Button btnRecreateModel;
        private System.Windows.Forms.ToolStripSeparator tlstrpspModelArray;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiSetModelOrigin;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiConfirmModelOrigin;
        private System.Windows.Forms.ToolStripMenuItem tlstrpmiRecoverModelOrigin;
    }
}