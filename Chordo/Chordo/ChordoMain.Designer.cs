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
            btnToggleHighContrast = new Button();
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
            tblLayout.Controls.Add(btnToggleHighContrast, 0, 2);
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
            tblLayout.Margin = new Padding(4);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 4;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.0526314F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70.92105F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 9.023941F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 8.839779F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tblLayout.Size = new Size(1158, 760);
            tblLayout.TabIndex = 0;
            // 
            // clbPacks
            // 
            clbPacks.CausesValidation = false;
            clbPacks.CheckOnClick = true;
            clbPacks.Dock = DockStyle.Fill;
            clbPacks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clbPacks.FormattingEnabled = true;
            clbPacks.Location = new Point(4, 88);
            clbPacks.Margin = new Padding(4);
            clbPacks.Name = "clbPacks";
            clbPacks.Size = new Size(235, 531);
            clbPacks.TabIndex = 1;
            clbPacks.SelectedIndexChanged += clbPacks_SelectedIndexChanged;
            // 
            // btnStartStop
            // 
            btnStartStop.AutoSize = true;
            tblLayout.SetColumnSpan(btnStartStop, 2);
            btnStartStop.Dock = DockStyle.Fill;
            btnStartStop.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartStop.Location = new Point(940, 4);
            btnStartStop.Margin = new Padding(4);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(214, 76);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // btnToggleHighContrast
            // 
            btnToggleHighContrast.AutoSize = true;
            btnToggleHighContrast.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnToggleHighContrast.BackColor = SystemColors.ActiveCaptionText;
            btnToggleHighContrast.BackgroundImageLayout = ImageLayout.Zoom;
            btnToggleHighContrast.Dock = DockStyle.Fill;
            btnToggleHighContrast.Font = new Font("OpenDyslexic 3", 17.9999981F, FontStyle.Regular, GraphicsUnit.Point);
            btnToggleHighContrast.ForeColor = SystemColors.Control;
            btnToggleHighContrast.ImageAlign = ContentAlignment.TopCenter;
            btnToggleHighContrast.Location = new Point(4, 627);
            btnToggleHighContrast.Margin = new Padding(4);
            btnToggleHighContrast.Name = "btnToggleHighContrast";
            tblLayout.SetRowSpan(btnToggleHighContrast, 2);
            btnToggleHighContrast.Size = new Size(235, 129);
            btnToggleHighContrast.TabIndex = 4;
            btnToggleHighContrast.Text = "High Contrast";
            btnToggleHighContrast.TextAlign = ContentAlignment.BottomCenter;
            btnToggleHighContrast.UseVisualStyleBackColor = false;
            btnToggleHighContrast.Click += btnToggleHighContrast_Click;
            // 
            // lblChord
            // 
            lblChord.AutoSize = true;
            lblChord.Dock = DockStyle.Fill;
            lblChord.Font = new Font("Segoe Print", 72F, FontStyle.Bold, GraphicsUnit.Point);
            lblChord.Location = new Point(454, 84);
            lblChord.Margin = new Padding(4, 0, 4, 0);
            lblChord.Name = "lblChord";
            lblChord.Size = new Size(478, 539);
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
            lblStreak.Location = new Point(940, 84);
            lblStreak.Margin = new Padding(4, 0, 4, 0);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new Size(214, 539);
            lblStreak.TabIndex = 7;
            lblStreak.Text = "0";
            lblStreak.TextAlign = ContentAlignment.BottomCenter;

            // 
            // btnSkip
            // 
            btnSkip.AutoSize = true;
            tblLayout.SetColumnSpan(btnSkip, 2);
            btnSkip.Dock = DockStyle.Fill;
            btnSkip.Font = new Font("Roboto", 36F, FontStyle.Regular, GraphicsUnit.Point);
            btnSkip.Location = new Point(940, 627);
            btnSkip.Margin = new Padding(4);
            btnSkip.Name = "btnSkip";
            tblLayout.SetRowSpan(btnSkip, 2);
            btnSkip.Size = new Size(214, 129);
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
            lblEmptyHeart.Location = new Point(247, 0);
            lblEmptyHeart.Margin = new Padding(4, 0, 4, 0);
            lblEmptyHeart.Name = "lblEmptyHeart";
            lblEmptyHeart.Size = new Size(0, 84);
            lblEmptyHeart.TabIndex = 8;
            // 
            // lblHelper
            // 
            lblHelper.AutoSize = true;
            lblHelper.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblHelper.Location = new Point(454, 623);
            lblHelper.Margin = new Padding(4, 0, 4, 0);
            lblHelper.Name = "lblHelper";
            lblHelper.Size = new Size(278, 25);
            lblHelper.TabIndex = 13;
            lblHelper.Text = "Hi! Select Chord Packs to begin!";
            // 
            // lblErrorOut
            // 
            lblErrorOut.AutoSize = true;
            lblErrorOut.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorOut.Location = new Point(454, 691);
            lblErrorOut.Margin = new Padding(4, 0, 4, 0);
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
            btnHeart.Location = new Point(247, 627);
            btnHeart.Margin = new Padding(4);
            btnHeart.Name = "btnHeart";
            tblLayout.SetRowSpan(btnHeart, 2);
            btnHeart.Size = new Size(199, 129);
            btnHeart.TabIndex = 14;
            btnHeart.UseVisualStyleBackColor = true;
            btnHeart.Click += btnHeart_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Dock = DockStyle.Fill;
            lblTimer.Font = new Font("Microsoft Sans Serif", 71.99999F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimer.Location = new Point(247, 84);
            lblTimer.Margin = new Padding(4, 0, 4, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(199, 539);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(598, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(189, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chordo";
            // 
            // sensitivitySlider
            // 
            sensitivitySlider.Location = new Point(4, 4);
            sensitivitySlider.Margin = new Padding(4);
            sensitivitySlider.Maximum = 100;
            sensitivitySlider.Name = "sensitivitySlider";
            sensitivitySlider.Size = new Size(235, 45);
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
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1158, 760);
            Controls.Add(tblLayout);
            Font = new Font("OpenDyslexic 3", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MinimumSize = new Size(638, 334);
            Name = "ChordoMain";
            StartPosition = FormStartPosition.Manual;
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
        private Button btnToggleHighContrast;
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