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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChordoMain));
            tblLayout = new TableLayoutPanel();
            clbPacks = new CheckedListBox();
            lblTitle = new Label();
            btnStartStop = new Button();
            btnToggleMusic = new Button();
            lblTimer = new Label();
            lblChord = new Label();
            lblStreak = new Label();
            btnSkip = new Button();
            btnHelp = new Button();
            lblEmptyHeart = new Label();
            panelHeartContainer = new Panel();
            pbFullHeart = new PictureBox();
            pbEmptyHeart = new PictureBox();
            ListenTick = new System.Windows.Forms.Timer(components);
            CountdownTimer = new System.Windows.Forms.Timer(components);
            tblLayout.SuspendLayout();
            panelHeartContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFullHeart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEmptyHeart).BeginInit();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.ColumnCount = 5;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.7580471F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.99445057F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.0466156F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.322974F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.766926F));
            tblLayout.Controls.Add(clbPacks, 0, 1);
            tblLayout.Controls.Add(lblTitle, 2, 0);
            tblLayout.Controls.Add(btnStartStop, 3, 0);
            tblLayout.Controls.Add(btnToggleMusic, 0, 2);
            tblLayout.Controls.Add(lblTimer, 0, 0);
            tblLayout.Controls.Add(lblChord, 2, 1);
            tblLayout.Controls.Add(lblStreak, 3, 1);
            tblLayout.Controls.Add(btnSkip, 4, 2);
            tblLayout.Controls.Add(btnHelp, 3, 2);
            tblLayout.Controls.Add(lblEmptyHeart, 1, 0);
            tblLayout.Controls.Add(panelHeartContainer, 1, 2);
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
            // clbPacks
            // 
            clbPacks.Dock = DockStyle.Fill;
            clbPacks.FormattingEnabled = true;
            clbPacks.Location = new Point(3, 65);
            clbPacks.Name = "clbPacks";
            clbPacks.Size = new Size(154, 397);
            clbPacks.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(372, 0);
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
            btnStartStop.Location = new Point(731, 3);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(167, 56);
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
            btnToggleMusic.Size = new Size(154, 72);
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
            lblTimer.Size = new Size(154, 62);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // lblChord
            // 
            lblChord.AutoSize = true;
            lblChord.Dock = DockStyle.Fill;
            lblChord.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblChord.Location = new Point(208, 62);
            lblChord.Name = "lblChord";
            lblChord.Size = new Size(517, 403);
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
            lblStreak.Location = new Point(731, 62);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new Size(167, 403);
            lblStreak.TabIndex = 7;
            lblStreak.Text = "0";
            lblStreak.TextAlign = ContentAlignment.BottomCenter;
            // 
            // btnSkip
            // 
            btnSkip.AutoSize = true;
            btnSkip.Dock = DockStyle.Fill;
            btnSkip.Location = new Point(815, 468);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(83, 72);
            btnSkip.TabIndex = 2;
            btnSkip.Text = "Skip";
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Click += btnSkip_Click;
            // 
            // btnHelp
            // 
            btnHelp.AutoSize = true;
            btnHelp.Dock = DockStyle.Fill;
            btnHelp.Location = new Point(731, 468);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(78, 72);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "Help!";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // lblEmptyHeart
            // 
            lblEmptyHeart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblEmptyHeart.AutoSize = true;
            lblEmptyHeart.Image = (Image)resources.GetObject("lblEmptyHeart.Image");
            lblEmptyHeart.Location = new Point(163, 0);
            lblEmptyHeart.Name = "lblEmptyHeart";
            lblEmptyHeart.Size = new Size(0, 62);
            lblEmptyHeart.TabIndex = 8;
            // 
            // panelHeartContainer
            // 
            panelHeartContainer.Controls.Add(pbFullHeart);
            panelHeartContainer.Controls.Add(pbEmptyHeart);
            panelHeartContainer.Location = new Point(163, 468);
            panelHeartContainer.Name = "panelHeartContainer";
            panelHeartContainer.Size = new Size(39, 72);
            panelHeartContainer.TabIndex = 11;
            // 
            // pbFullHeart
            // 
            pbFullHeart.Dock = DockStyle.Fill;
            pbFullHeart.Image = (Image)resources.GetObject("pbFullHeart.Image");
            pbFullHeart.Location = new Point(0, 0);
            pbFullHeart.Name = "pbFullHeart";
            pbFullHeart.Size = new Size(39, 72);
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
            pbEmptyHeart.Size = new Size(39, 72);
            pbEmptyHeart.SizeMode = PictureBoxSizeMode.Zoom;
            pbEmptyHeart.TabIndex = 9;
            pbEmptyHeart.TabStop = false;
            pbEmptyHeart.Click += pbEmptyHeart_Click;
            // 
            // ListenTick
            // 
            ListenTick.Interval = 20;
            ListenTick.Tick += ListenTick_Tick;
            // 
            // CountdownTimer
            // 
            CountdownTimer.Interval = 1000;
            CountdownTimer.Tick += CountdownTimer_Tick;
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
            panelHeartContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFullHeart).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEmptyHeart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private Label lblTitle;
        private Button btnStartStop;
        private Button btnSkip;
        private Button btnHelp;
        private Button btnToggleMusic;
        private Label lblTimer;
        private Label lblChord;
        private Label lblStreak;
        private Label lblEmptyHeart;
        private PictureBox pbEmptyHeart;
        private PictureBox pbFullHeart;
        private Panel panelHeartContainer;
        private System.Windows.Forms.Timer ListenTick;
        private System.Windows.Forms.Timer CountdownTimer;
        private CheckedListBox clbPacks;
    }
}