namespace ProVision.InteractiveROI
{
    partial class FrmInteractiveROI
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
            this.splitContainerRoot = new System.Windows.Forms.SplitContainer();
            this.hWndcDisplay = new HalconDotNet.HWindowControl();
            this.grpbViewOption = new System.Windows.Forms.GroupBox();
            this.rdbtnManify = new System.Windows.Forms.RadioButton();
            this.rdbtnMove = new System.Windows.Forms.RadioButton();
            this.rdbtnZoom = new System.Windows.Forms.RadioButton();
            this.rdbtnNone = new System.Windows.Forms.RadioButton();
            this.grpbShapeOption = new System.Windows.Forms.GroupBox();
            this.btnCircularArc = new System.Windows.Forms.Button();
            this.btnRectangle2 = new System.Windows.Forms.Button();
            this.btnRectangle1 = new System.Windows.Forms.Button();
            this.btnAnnulus = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.grpbOperation = new System.Windows.Forms.GroupBox();
            this.cmbROIList = new System.Windows.Forms.ComboBox();
            this.btnEraseROI = new System.Windows.Forms.Button();
            this.btnDeleteAllROI = new System.Windows.Forms.Button();
            this.btnDeleteActiveROI = new System.Windows.Forms.Button();
            this.btnResetWindow = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).BeginInit();
            this.splitContainerRoot.Panel1.SuspendLayout();
            this.splitContainerRoot.Panel2.SuspendLayout();
            this.splitContainerRoot.SuspendLayout();
            this.grpbViewOption.SuspendLayout();
            this.grpbShapeOption.SuspendLayout();
            this.grpbOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerRoot
            // 
            this.splitContainerRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRoot.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRoot.Name = "splitContainerRoot";
            // 
            // splitContainerRoot.Panel1
            // 
            this.splitContainerRoot.Panel1.Controls.Add(this.hWndcDisplay);
            // 
            // splitContainerRoot.Panel2
            // 
            this.splitContainerRoot.Panel2.Controls.Add(this.grpbViewOption);
            this.splitContainerRoot.Panel2.Controls.Add(this.grpbShapeOption);
            this.splitContainerRoot.Panel2.Controls.Add(this.grpbOperation);
            this.splitContainerRoot.Size = new System.Drawing.Size(876, 570);
            this.splitContainerRoot.SplitterDistance = 585;
            this.splitContainerRoot.TabIndex = 0;
            // 
            // hWndcDisplay
            // 
            this.hWndcDisplay.BackColor = System.Drawing.Color.Black;
            this.hWndcDisplay.BorderColor = System.Drawing.Color.Black;
            this.hWndcDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWndcDisplay.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWndcDisplay.Location = new System.Drawing.Point(0, 0);
            this.hWndcDisplay.Name = "hWndcDisplay";
            this.hWndcDisplay.Size = new System.Drawing.Size(585, 570);
            this.hWndcDisplay.TabIndex = 0;
            this.hWndcDisplay.WindowSize = new System.Drawing.Size(585, 570);
            // 
            // grpbViewOption
            // 
            this.grpbViewOption.Controls.Add(this.rdbtnManify);
            this.grpbViewOption.Controls.Add(this.rdbtnMove);
            this.grpbViewOption.Controls.Add(this.rdbtnZoom);
            this.grpbViewOption.Controls.Add(this.rdbtnNone);
            this.grpbViewOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbViewOption.Location = new System.Drawing.Point(0, 379);
            this.grpbViewOption.Name = "grpbViewOption";
            this.grpbViewOption.Size = new System.Drawing.Size(287, 188);
            this.grpbViewOption.TabIndex = 0;
            this.grpbViewOption.TabStop = false;
            this.grpbViewOption.Tag = "GRPB_VIEWOPTION";
            this.grpbViewOption.Text = "视图选项";
            // 
            // rdbtnManify
            // 
            this.rdbtnManify.AutoSize = true;
            this.rdbtnManify.Location = new System.Drawing.Point(157, 96);
            this.rdbtnManify.Name = "rdbtnManify";
            this.rdbtnManify.Size = new System.Drawing.Size(71, 16);
            this.rdbtnManify.TabIndex = 0;
            this.rdbtnManify.TabStop = true;
            this.rdbtnManify.Tag = "RDBTN_MAGNIFY";
            this.rdbtnManify.Text = "局部放大";
            this.rdbtnManify.UseVisualStyleBackColor = true;
            // 
            // rdbtnMove
            // 
            this.rdbtnMove.AutoSize = true;
            this.rdbtnMove.Location = new System.Drawing.Point(41, 96);
            this.rdbtnMove.Name = "rdbtnMove";
            this.rdbtnMove.Size = new System.Drawing.Size(71, 16);
            this.rdbtnMove.TabIndex = 0;
            this.rdbtnMove.TabStop = true;
            this.rdbtnMove.Tag = "RDBTN_MOVE";
            this.rdbtnMove.Text = "移动图形";
            this.rdbtnMove.UseVisualStyleBackColor = true;
            // 
            // rdbtnZoom
            // 
            this.rdbtnZoom.AutoSize = true;
            this.rdbtnZoom.Location = new System.Drawing.Point(157, 55);
            this.rdbtnZoom.Name = "rdbtnZoom";
            this.rdbtnZoom.Size = new System.Drawing.Size(71, 16);
            this.rdbtnZoom.TabIndex = 0;
            this.rdbtnZoom.TabStop = true;
            this.rdbtnZoom.Tag = "RDBTN_ZOOM";
            this.rdbtnZoom.Text = "缩放图形";
            this.rdbtnZoom.UseVisualStyleBackColor = true;
            // 
            // rdbtnNone
            // 
            this.rdbtnNone.AutoSize = true;
            this.rdbtnNone.Location = new System.Drawing.Point(41, 55);
            this.rdbtnNone.Name = "rdbtnNone";
            this.rdbtnNone.Size = new System.Drawing.Size(71, 16);
            this.rdbtnNone.TabIndex = 0;
            this.rdbtnNone.TabStop = true;
            this.rdbtnNone.Tag = "RDBTN_NONE";
            this.rdbtnNone.Text = "恢复初态";
            this.rdbtnNone.UseVisualStyleBackColor = true;
            // 
            // grpbShapeOption
            // 
            this.grpbShapeOption.Controls.Add(this.btnCircularArc);
            this.grpbShapeOption.Controls.Add(this.btnRectangle2);
            this.grpbShapeOption.Controls.Add(this.btnRectangle1);
            this.grpbShapeOption.Controls.Add(this.btnAnnulus);
            this.grpbShapeOption.Controls.Add(this.btnLine);
            this.grpbShapeOption.Controls.Add(this.btnCircle);
            this.grpbShapeOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbShapeOption.Location = new System.Drawing.Point(0, 161);
            this.grpbShapeOption.Name = "grpbShapeOption";
            this.grpbShapeOption.Size = new System.Drawing.Size(287, 218);
            this.grpbShapeOption.TabIndex = 0;
            this.grpbShapeOption.TabStop = false;
            this.grpbShapeOption.Tag = "GRPB_SHAPEOPTION";
            this.grpbShapeOption.Text = "形状选项";
            // 
            // btnCircularArc
            // 
            this.btnCircularArc.Location = new System.Drawing.Point(157, 146);
            this.btnCircularArc.Name = "btnCircularArc";
            this.btnCircularArc.Size = new System.Drawing.Size(95, 25);
            this.btnCircularArc.TabIndex = 0;
            this.btnCircularArc.Tag = "BTN_CIRULARARC";
            this.btnCircularArc.Text = "有向圆弧";
            this.btnCircularArc.UseVisualStyleBackColor = true;
            // 
            // btnRectangle2
            // 
            this.btnRectangle2.Location = new System.Drawing.Point(157, 93);
            this.btnRectangle2.Name = "btnRectangle2";
            this.btnRectangle2.Size = new System.Drawing.Size(95, 25);
            this.btnRectangle2.TabIndex = 0;
            this.btnRectangle2.Tag = "BTN_RECTANGLE2";
            this.btnRectangle2.Text = "仿射矩形";
            this.btnRectangle2.UseVisualStyleBackColor = true;
            // 
            // btnRectangle1
            // 
            this.btnRectangle1.Location = new System.Drawing.Point(157, 40);
            this.btnRectangle1.Name = "btnRectangle1";
            this.btnRectangle1.Size = new System.Drawing.Size(95, 25);
            this.btnRectangle1.TabIndex = 0;
            this.btnRectangle1.Tag = "BTN_RECTANGLE1";
            this.btnRectangle1.Text = "齐轴矩形";
            this.btnRectangle1.UseVisualStyleBackColor = true;
            // 
            // btnAnnulus
            // 
            this.btnAnnulus.Location = new System.Drawing.Point(41, 146);
            this.btnAnnulus.Name = "btnAnnulus";
            this.btnAnnulus.Size = new System.Drawing.Size(95, 25);
            this.btnAnnulus.TabIndex = 0;
            this.btnAnnulus.Tag = "BTN_ANNULUS";
            this.btnAnnulus.Text = "闭合圆环";
            this.btnAnnulus.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(41, 40);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(95, 25);
            this.btnLine.TabIndex = 0;
            this.btnLine.Tag = "BTN_LINE";
            this.btnLine.Text = "矢量线段";
            this.btnLine.UseVisualStyleBackColor = true;
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(41, 93);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(95, 25);
            this.btnCircle.TabIndex = 0;
            this.btnCircle.Tag = "BTN_CIRCLE";
            this.btnCircle.Text = "闭合圆形";
            this.btnCircle.UseVisualStyleBackColor = true;
            // 
            // grpbOperation
            // 
            this.grpbOperation.Controls.Add(this.cmbROIList);
            this.grpbOperation.Controls.Add(this.btnEraseROI);
            this.grpbOperation.Controls.Add(this.btnDeleteAllROI);
            this.grpbOperation.Controls.Add(this.btnDeleteActiveROI);
            this.grpbOperation.Controls.Add(this.btnResetWindow);
            this.grpbOperation.Controls.Add(this.btnLoadImage);
            this.grpbOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpbOperation.Location = new System.Drawing.Point(0, 0);
            this.grpbOperation.Name = "grpbOperation";
            this.grpbOperation.Size = new System.Drawing.Size(287, 161);
            this.grpbOperation.TabIndex = 0;
            this.grpbOperation.TabStop = false;
            this.grpbOperation.Tag = "GRPB_OPERATION";
            this.grpbOperation.Text = "操作功能";
            // 
            // cmbROIList
            // 
            this.cmbROIList.FormattingEnabled = true;
            this.cmbROIList.Location = new System.Drawing.Point(41, 122);
            this.cmbROIList.Name = "cmbROIList";
            this.cmbROIList.Size = new System.Drawing.Size(95, 20);
            this.cmbROIList.TabIndex = 1;
            this.cmbROIList.Visible = false;
            // 
            // btnEraseROI
            // 
            this.btnEraseROI.Location = new System.Drawing.Point(157, 117);
            this.btnEraseROI.Name = "btnEraseROI";
            this.btnEraseROI.Size = new System.Drawing.Size(95, 25);
            this.btnEraseROI.TabIndex = 0;
            this.btnEraseROI.Tag = "BTN_ERASESELECTEDROI";
            this.btnEraseROI.Text = "擦除选定ROI";
            this.btnEraseROI.UseVisualStyleBackColor = true;
            this.btnEraseROI.Visible = false;
            // 
            // btnDeleteAllROI
            // 
            this.btnDeleteAllROI.Location = new System.Drawing.Point(157, 74);
            this.btnDeleteAllROI.Name = "btnDeleteAllROI";
            this.btnDeleteAllROI.Size = new System.Drawing.Size(95, 25);
            this.btnDeleteAllROI.TabIndex = 0;
            this.btnDeleteAllROI.Tag = "BTN_DELETEALLROI";
            this.btnDeleteAllROI.Text = "删除所有ROI";
            this.btnDeleteAllROI.UseVisualStyleBackColor = true;
            // 
            // btnDeleteActiveROI
            // 
            this.btnDeleteActiveROI.Location = new System.Drawing.Point(157, 31);
            this.btnDeleteActiveROI.Name = "btnDeleteActiveROI";
            this.btnDeleteActiveROI.Size = new System.Drawing.Size(95, 25);
            this.btnDeleteActiveROI.TabIndex = 0;
            this.btnDeleteActiveROI.Tag = "BTN_DELETEACTIVEROI";
            this.btnDeleteActiveROI.Text = "删除活动ROI";
            this.btnDeleteActiveROI.UseVisualStyleBackColor = true;
            // 
            // btnResetWindow
            // 
            this.btnResetWindow.Location = new System.Drawing.Point(41, 74);
            this.btnResetWindow.Name = "btnResetWindow";
            this.btnResetWindow.Size = new System.Drawing.Size(95, 25);
            this.btnResetWindow.TabIndex = 0;
            this.btnResetWindow.Tag = "BTN_RESETWINDOW";
            this.btnResetWindow.Text = "重置窗口";
            this.btnResetWindow.UseVisualStyleBackColor = true;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(41, 31);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(95, 25);
            this.btnLoadImage.TabIndex = 0;
            this.btnLoadImage.Tag = "BTN_LOADIMAGE";
            this.btnLoadImage.Text = "加载图像";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // FrmInteractiveROI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 570);
            this.Controls.Add(this.splitContainerRoot);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInteractiveROI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "FRM_INTERACTIVEROI";
            this.Text = "FrmInteractiveROI";
            this.splitContainerRoot.Panel1.ResumeLayout(false);
            this.splitContainerRoot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRoot)).EndInit();
            this.splitContainerRoot.ResumeLayout(false);
            this.grpbViewOption.ResumeLayout(false);
            this.grpbViewOption.PerformLayout();
            this.grpbShapeOption.ResumeLayout(false);
            this.grpbOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerRoot;
        public HalconDotNet.HWindowControl hWndcDisplay;
        public System.Windows.Forms.GroupBox grpbViewOption;
        public System.Windows.Forms.GroupBox grpbShapeOption;
        public System.Windows.Forms.GroupBox grpbOperation;
        private System.Windows.Forms.Button btnCircularArc;
        private System.Windows.Forms.Button btnRectangle2;
        private System.Windows.Forms.Button btnRectangle1;
        private System.Windows.Forms.Button btnAnnulus;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnDeleteAllROI;
        private System.Windows.Forms.Button btnDeleteActiveROI;
        private System.Windows.Forms.Button btnResetWindow;
        public System.Windows.Forms.Button btnLoadImage;
        public System.Windows.Forms.RadioButton rdbtnZoom;
        public System.Windows.Forms.RadioButton rdbtnNone;
        public System.Windows.Forms.RadioButton rdbtnMove;
        public System.Windows.Forms.RadioButton rdbtnManify;
        private System.Windows.Forms.Button btnEraseROI;
        public System.Windows.Forms.ComboBox cmbROIList;
    }
}