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
            btnStartStop = new Button();
            btnToggleMusic = new Button();
            lblChord = new Label();
            lblStreak = new Label();
            btnSkip = new Button();
            lblEmptyHeart = new Label();
            lblHelper = new Label();
            lblErrorOut = new Label();
            btnHeart = new Button();
            lblTimer = new Label();
            lblTitle = new Label();
            sensitivitySlider = new TrackBar();
            ListenTick = new System.Windows.Forms.Timer(components);
            CountdownTimer = new System.Windows.Forms.Timer(components);
            tblLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sensitivitySlider).BeginInit();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.ColumnCount = 5;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.9766922F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.8690338F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.9533844F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.333332F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.777777F));
            tblLayout.Controls.Add(clbPacks, 0, 1);
            tblLayout.Controls.Add(btnStartStop, 3, 0);
            tblLayout.Controls.Add(btnToggleMusic, 0, 2);
            tblLayout.Controls.Add(lblChord, 2, 1);
            tblLayout.Controls.Add(lblStreak, 3, 1);
            tblLayout.Controls.Add(btnSkip, 3, 2);
            tblLayout.Controls.Add(lblEmptyHeart, 1, 0);
            tblLayout.Controls.Add(lblHelper, 2, 2);
            tblLayout.Controls.Add(lblErrorOut, 2, 3);
            tblLayout.Controls.Add(btnHeart, 1, 2);
            tblLayout.Controls.Add(lblTimer, 1, 1);
            tblLayout.Controls.Add(lblTitle, 2, 0);
            tblLayout.Controls.Add(sensitivitySlider, 0, 0);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 4;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 19.52118F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 62.43094F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 9.023941F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 8.839779F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLayout.Size = new Size(901, 543);
            tblLayout.TabIndex = 0;
            // 
            // clbPacks
            // 
            clbPacks.CausesValidation = false;
            clbPacks.CheckOnClick = true;
            clbPacks.Dock = DockStyle.Fill;
            clbPacks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clbPacks.FormattingEnabled = true;
            clbPacks.Location = new Point(3, 109);
            clbPacks.Name = "clbPacks";
            clbPacks.Size = new Size(183, 333);
            clbPacks.TabIndex = 1;
            clbPacks.SelectedIndexChanged += clbPacks_SelectedIndexChanged;
            // 
            // btnStartStop
            // 
            btnStartStop.AutoSize = true;
            tblLayout.SetColumnSpan(btnStartStop, 2);
            btnStartStop.Dock = DockStyle.Fill;
            btnStartStop.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartStop.Location = new Point(731, 3);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(167, 100);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // btnToggleMusic
            // 
            btnToggleMusic.AutoSize = true;
            btnToggleMusic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleMusic.BackgroundImage = (Image)resources.GetObject("btnToggleMusic.BackgroundImage");
            btnToggleMusic.BackgroundImageLayout = ImageLayout.Zoom;
            btnToggleMusic.Dock = DockStyle.Fill;
            btnToggleMusic.ImageAlign = ContentAlignment.TopCenter;
            btnToggleMusic.Location = new Point(3, 448);
            btnToggleMusic.Name = "btnToggleMusic";
            tblLayout.SetRowSpan(btnToggleMusic, 2);
            btnToggleMusic.Size = new Size(183, 92);
            btnToggleMusic.TabIndex = 4;
            btnToggleMusic.TextAlign = ContentAlignment.BottomCenter;
            btnToggleMusic.UseVisualStyleBackColor = true;
            // 
            // lblChord
            // 
            lblChord.AutoSize = true;
            lblChord.Dock = DockStyle.Fill;
            lblChord.Font = new Font("Segoe Print", 72F, FontStyle.Bold, GraphicsUnit.Point);
            lblChord.Location = new Point(353, 106);
            lblChord.Name = "lblChord";
            lblChord.Size = new Size(372, 339);
            lblChord.TabIndex = 6;
            lblChord.Text = "C#";
            lblChord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStreak
            // 
            lblStreak.AutoSize = true;
            tblLayout.SetColumnSpan(lblStreak, 2);
            lblStreak.Dock = DockStyle.Fill;
            lblStreak.Font = new Font("Microsoft Sans Serif", 71.99999F, FontStyle.Bold, GraphicsUnit.Point);
            lblStreak.Image = (Image)resources.GetObject("lblStreak.Image");
            lblStreak.ImageAlign = ContentAlignment.TopCenter;
            lblStreak.Location = new Point(731, 106);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new Size(167, 339);
            lblStreak.TabIndex = 7;
            lblStreak.Text = "0";
            lblStreak.TextAlign = ContentAlignment.BottomCenter;
            lblStreak.Click += lblStreak_Click;
            // 
            // btnSkip
            // 
            btnSkip.AutoSize = true;
            tblLayout.SetColumnSpan(btnSkip, 2);
            btnSkip.Dock = DockStyle.Fill;
            btnSkip.Font = new Font("Roboto", 36F, FontStyle.Regular, GraphicsUnit.Point);
            btnSkip.Location = new Point(731, 448);
            btnSkip.Name = "btnSkip";
            tblLayout.SetRowSpan(btnSkip, 2);
            btnSkip.Size = new Size(167, 92);
            btnSkip.TabIndex = 2;
            btnSkip.Text = "Skip";
            btnSkip.UseVisualStyleBackColor = true;
            btnSkip.Click += btnSkip_Click;
            // 
            // lblEmptyHeart
            // 
            lblEmptyHeart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblEmptyHeart.AutoSize = true;
            lblEmptyHeart.Image = (Image)resources.GetObject("lblEmptyHeart.Image");
            lblEmptyHeart.Location = new Point(192, 0);
            lblEmptyHeart.Name = "lblEmptyHeart";
            lblEmptyHeart.Size = new Size(0, 106);
            lblEmptyHeart.TabIndex = 8;
            // 
            // lblHelper
            // 
            lblHelper.AutoSize = true;
            lblHelper.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblHelper.Location = new Point(353, 445);
            lblHelper.Name = "lblHelper";
            lblHelper.Size = new Size(278, 25);
            lblHelper.TabIndex = 13;
            lblHelper.Text = "Hi! Select Chord Packs to begin!";
            // 
            // lblErrorOut
            // 
            lblErrorOut.AutoSize = true;
            lblErrorOut.Location = new Point(353, 494);
            lblErrorOut.Name = "lblErrorOut";
            lblErrorOut.Size = new Size(43, 15);
            lblErrorOut.TabIndex = 12;
            lblErrorOut.Text = "ERROR";
            // 
            // btnHeart
            // 
            btnHeart.AutoSize = true;
            btnHeart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHeart.BackgroundImage = Properties.Resources.emptyHeart_removebg_preview;
            btnHeart.BackgroundImageLayout = ImageLayout.Zoom;
            btnHeart.Dock = DockStyle.Fill;
            btnHeart.Location = new Point(192, 448);
            btnHeart.Name = "btnHeart";
            tblLayout.SetRowSpan(btnHeart, 2);
            btnHeart.Size = new Size(155, 92);
            btnHeart.TabIndex = 14;
            btnHeart.UseVisualStyleBackColor = true;
            btnHeart.Click += btnHeart_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Fill;
            lblTimer.Font = new Font("Microsoft Sans Serif", 71.99999F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimer.Location = new Point(192, 106);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(155, 339);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(444, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chordo";
            // 
            // sensitivitySlider
            // 
            sensitivitySlider.Location = new Point(3, 3);
            sensitivitySlider.Maximum = 100;
            sensitivitySlider.Name = "sensitivitySlider";
            sensitivitySlider.Size = new Size(183, 45);
            sensitivitySlider.TabIndex = 15;
            sensitivitySlider.Value = 10;
            sensitivitySlider.Scroll += sensitivitySlider_Scroll;
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
            MinimumSize = new Size(500, 250);
            Name = "ChordoMain";
            Text = "Chordo Window";
            tblLayout.ResumeLayout(false);
            tblLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sensitivitySlider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblLayout;
        private Label lblTitle;
        private Button btnStartStop;
        private Button btnSkip;
        private Button btnToggleMusic;
        private Label lblTimer;
        private Label lblChord;
        private Label lblStreak;
        private Label lblEmptyHeart;
        private System.Windows.Forms.Timer ListenTick;
        private System.Windows.Forms.Timer CountdownTimer;
        private CheckedListBox clbPacks;
        private Label lblErrorOut;
        private Label lblHelper;
        private Button btnHeart;
        private TrackBar sensitivitySlider;
    }
}