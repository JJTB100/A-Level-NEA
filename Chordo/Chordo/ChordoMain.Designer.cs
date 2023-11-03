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
            btnStartStop = new Button();
            btnToggleMusic = new Button();
            lblTimer = new Label();
            lblChord = new Label();
            lblStreak = new Label();
            button1 = new Button();
            button2 = new Button();
            lblEmptyHeart = new Label();
            panel1 = new Panel();
            pbFullHeart = new PictureBox();
            pbEmptyHeart = new PictureBox();
            tblLayout.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFullHeart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEmptyHeart).BeginInit();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.ColumnCount = 5;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.322974F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.433962F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.1531639F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.322974F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.766926F));
            tblLayout.Controls.Add(lblTitle, 2, 0);
            tblLayout.Controls.Add(btnStartStop, 3, 0);
            tblLayout.Controls.Add(btnToggleMusic, 0, 2);
            tblLayout.Controls.Add(lblTimer, 0, 0);
            tblLayout.Controls.Add(lblChord, 2, 1);
            tblLayout.Controls.Add(lblStreak, 3, 1);
            tblLayout.Controls.Add(button1, 4, 2);
            tblLayout.Controls.Add(button2, 3, 2);
            tblLayout.Controls.Add(lblEmptyHeart, 1, 0);
            tblLayout.Controls.Add(panel1, 1, 2);
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
            lblTitle.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(354, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chordo";
            // 
            // btnStartStop
            // 
            btnStartStop.AutoSize = true;
            tblLayout.SetColumnSpan(btnStartStop, 2);
            btnStartStop.Dock = DockStyle.Fill;
            btnStartStop.Location = new Point(732, 3);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(166, 56);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // btnToggleMusic
            // 
            btnToggleMusic.AutoSize = true;
            btnToggleMusic.BackgroundImage = (Image)resources.GetObject("btnToggleMusic.BackgroundImage");
            btnToggleMusic.BackgroundImageLayout = ImageLayout.Zoom;
            btnToggleMusic.Dock = DockStyle.Fill;
            btnToggleMusic.ImageAlign = ContentAlignment.TopCenter;
            btnToggleMusic.Location = new Point(3, 468);
            btnToggleMusic.Name = "btnToggleMusic";
            btnToggleMusic.Size = new Size(78, 72);
            btnToggleMusic.TabIndex = 4;
            btnToggleMusic.TextAlign = ContentAlignment.BottomCenter;
            btnToggleMusic.UseVisualStyleBackColor = true;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Fill;
            lblTimer.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimer.Location = new Point(3, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(78, 62);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // lblChord
            // 
            lblChord.AutoSize = true;
            lblChord.Dock = DockStyle.Fill;
            lblChord.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblChord.Location = new Point(172, 62);
            lblChord.Name = "lblChord";
            lblChord.Size = new Size(554, 403);
            lblChord.TabIndex = 6;
            lblChord.Text = "C#";
            lblChord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStreak
            // 
            lblStreak.AutoSize = true;
            tblLayout.SetColumnSpan(lblStreak, 2);
            lblStreak.Dock = DockStyle.Fill;
            lblStreak.Font = new Font("Roboto", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblStreak.Image = (Image)resources.GetObject("lblStreak.Image");
            lblStreak.Location = new Point(732, 62);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new Size(166, 403);
            lblStreak.TabIndex = 7;
            lblStreak.Text = "0";
            lblStreak.TextAlign = ContentAlignment.BottomCenter;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(816, 468);
            button1.Name = "button1";
            button1.Size = new Size(82, 72);
            button1.TabIndex = 2;
            button1.Text = "Skip";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(732, 468);
            button2.Name = "button2";
            button2.Size = new Size(78, 72);
            button2.TabIndex = 3;
            button2.Text = "Help!";
            button2.UseVisualStyleBackColor = true;
            // 
            // lblEmptyHeart
            // 
            lblEmptyHeart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblEmptyHeart.AutoSize = true;
            lblEmptyHeart.Image = (Image)resources.GetObject("lblEmptyHeart.Image");
            lblEmptyHeart.Location = new Point(87, 0);
            lblEmptyHeart.Name = "lblEmptyHeart";
            lblEmptyHeart.Size = new Size(0, 62);
            lblEmptyHeart.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(pbFullHeart);
            panel1.Controls.Add(pbEmptyHeart);
            panel1.Location = new Point(87, 468);
            panel1.Name = "panel1";
            panel1.Size = new Size(79, 72);
            panel1.TabIndex = 11;
            // 
            // pbFullHeart
            // 
            pbFullHeart.Dock = DockStyle.Fill;
            pbFullHeart.Image = (Image)resources.GetObject("pbFullHeart.Image");
            pbFullHeart.Location = new Point(0, 0);
            pbFullHeart.Name = "pbFullHeart";
            pbFullHeart.Size = new Size(79, 72);
            pbFullHeart.SizeMode = PictureBoxSizeMode.Zoom;
            pbFullHeart.TabIndex = 10;
            pbFullHeart.TabStop = false;
            pbFullHeart.Visible = false;
            pbFullHeart.Click += pbFullHeart_Click;
            // 
            // pbEmptyHeart
            // 
            pbEmptyHeart.Dock = DockStyle.Fill;
            pbEmptyHeart.Image = (Image)resources.GetObject("pbEmptyHeart.Image");
            pbEmptyHeart.Location = new Point(0, 0);
            pbEmptyHeart.Name = "pbEmptyHeart";
            pbEmptyHeart.Size = new Size(79, 72);
            pbEmptyHeart.SizeMode = PictureBoxSizeMode.Zoom;
            pbEmptyHeart.TabIndex = 9;
            pbEmptyHeart.TabStop = false;
            pbEmptyHeart.Click += pbEmptyHeart_Click;
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
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFullHeart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEmptyHeart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private Label lblTitle;
        private Button btnStartStop;
        private Button button1;
        private Button button2;
        private Button btnToggleMusic;
        private Label lblTimer;
        private Label lblChord;
        private Label lblStreak;
        private Label lblEmptyHeart;
        private PictureBox pbEmptyHeart;
        private PictureBox pbFullHeart;
        private Panel panel1;
    }
}