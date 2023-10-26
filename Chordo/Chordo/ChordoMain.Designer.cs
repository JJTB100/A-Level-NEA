namespace Chordo
{
    partial class ChordoMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChordoMain));
            tblLayout = new TableLayoutPanel();
            lblTitle = new Label();
            btnExit = new Button();
            button1 = new Button();
            button2 = new Button();
            btnToggleMusic = new Button();
            lblTimer = new Label();
            lblChord = new Label();
            tblLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.ColumnCount = 3;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.988901F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.13651F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8348217F));
            tblLayout.Controls.Add(lblTitle, 1, 0);
            tblLayout.Controls.Add(btnExit, 2, 0);
            tblLayout.Controls.Add(button1, 2, 2);
            tblLayout.Controls.Add(button2, 1, 2);
            tblLayout.Controls.Add(btnToggleMusic, 0, 2);
            tblLayout.Controls.Add(lblTimer, 0, 0);
            tblLayout.Controls.Add(lblChord, 1, 1);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 3;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 86.6666641F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
            tblLayout.Size = new Size(901, 543);
            tblLayout.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Roboto Medium", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(344, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chordo";
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Dock = DockStyle.Fill;
            btnExit.Location = new Point(788, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 56);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(788, 468);
            button1.Name = "button1";
            button1.Size = new Size(110, 72);
            button1.TabIndex = 2;
            button1.Text = "Skip";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(664, 468);
            button2.Name = "button2";
            button2.Size = new Size(118, 72);
            button2.TabIndex = 3;
            button2.Text = "Help!";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnToggleMusic
            // 
            btnToggleMusic.AutoSize = true;
            btnToggleMusic.BackgroundImage = (Image)resources.GetObject("btnToggleMusic.BackgroundImage");
            btnToggleMusic.BackgroundImageLayout = ImageLayout.Stretch;
            btnToggleMusic.Dock = DockStyle.Fill;
            btnToggleMusic.ImageAlign = ContentAlignment.TopCenter;
            btnToggleMusic.Location = new Point(3, 468);
            btnToggleMusic.Name = "btnToggleMusic";
            btnToggleMusic.Size = new Size(84, 72);
            btnToggleMusic.TabIndex = 4;
            btnToggleMusic.TextAlign = ContentAlignment.BottomCenter;
            btnToggleMusic.UseVisualStyleBackColor = true;
            btnToggleMusic.Click += btnToggleMusic_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Fill;
            lblTimer.Font = new Font("Roboto Medium", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimer.Location = new Point(3, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(84, 62);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // lblChord
            // 
            lblChord.AutoSize = true;
            lblChord.Dock = DockStyle.Fill;
            lblChord.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblChord.Location = new Point(93, 62);
            lblChord.Name = "lblChord";
            lblChord.Size = new Size(689, 403);
            lblChord.TabIndex = 6;
            lblChord.Text = "C#";
            lblChord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChordoMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 543);
            Controls.Add(tblLayout);
            Name = "ChordoMain";
            Text = "Chordo Window";
            tblLayout.ResumeLayout(false);
            tblLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private Label lblTitle;
        private Button btnExit;
        private Button button1;
        private Button button2;
        private Button btnToggleMusic;
        private Label lblTimer;
        private Label lblChord;
    }
}