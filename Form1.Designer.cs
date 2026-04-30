namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            groupBox1 = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            groupBox2 = new GroupBox();
            cmbColor = new ComboBox();
            groupBox3 = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.MediumBlue;
            lblAppName.Location = new Point(12, 7);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(243, 50);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnRectangle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Location = new Point(12, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(245, 97);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.BackColor = Color.White;
            btnCircle.FlatAppearance.BorderColor = Color.White;
            btnCircle.FlatStyle = FlatStyle.Popup;
            btnCircle.Image = Properties.Resources.KakaoTalk_20260430_100205471_01;
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(162, 26);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(72, 56);
            btnCircle.TabIndex = 4;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCircle.UseVisualStyleBackColor = false;
            // 
            // btnRectangle
            // 
            btnRectangle.BackColor = Color.White;
            btnRectangle.BackgroundImageLayout = ImageLayout.Stretch;
            btnRectangle.FlatAppearance.BorderColor = Color.White;
            btnRectangle.Image = Properties.Resources.KakaoTalk_20260430_100205471;
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(84, 26);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(72, 56);
            btnRectangle.TabIndex = 3;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = false;
            // 
            // btnLine
            // 
            btnLine.BackgroundImageLayout = ImageLayout.Stretch;
            btnLine.FlatAppearance.BorderColor = Color.White;
            btnLine.Image = Properties.Resources.KakaoTalk_20260430_100205471_02;
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(6, 26);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(72, 56);
            btnLine.TabIndex = 2;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Location = new Point(263, 60);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(148, 97);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black", "Red", "Blue", "Green" });
            cmbColor.Location = new Point(6, 41);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(136, 28);
            cmbColor.TabIndex = 7;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLineWidth);
            groupBox3.Location = new Point(417, 60);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(197, 97);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 35);
            trbLineWidth.Minimum = 1;
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(185, 56);
            trbLineWidth.TabIndex = 9;
            trbLineWidth.Value = 2;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.Bisque;
            btnOpenFile.Font = new Font("맑은 고딕", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnOpenFile.Location = new Point(620, 99);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(81, 58);
            btnOpenFile.TabIndex = 5;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.PaleTurquoise;
            btnSaveFile.Font = new Font("맑은 고딕", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(707, 99);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(77, 58);
            btnSaveFile.TabIndex = 6;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // picCanvas
            // 
            picCanvas.Location = new Point(12, 163);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(769, 275);
            picCanvas.TabIndex = 8;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(793, 450);
            Controls.Add(picCanvas);
            Controls.Add(btnOpenFile);
            Controls.Add(btnSaveFile);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "Simple Paint v1.0";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
    }
}
