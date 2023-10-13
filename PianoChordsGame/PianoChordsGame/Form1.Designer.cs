namespace PianoChordsGame
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
            components = new System.ComponentModel.Container();
            pbVolume = new ProgressBar();
            comboBox1 = new ComboBox();
            btnStart = new Button();
            timerUpdateGraph = new System.Windows.Forms.Timer(components);
            ScottPCM = new ScottPlot.FormsPlot();
            ScottFFT = new ScottPlot.FormsPlot();
            lblNotesPlayed = new Label();
            SuspendLayout();
            // 
            // pbVolume
            // 
            pbVolume.Location = new Point(522, 12);
            pbVolume.Name = "pbVolume";
            pbVolume.Size = new Size(266, 23);
            pbVolume.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(275, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // timerUpdateGraph
            // 
            timerUpdateGraph.Interval = 10;
            timerUpdateGraph.Tick += timerUpdateGraph_Tick;
            // 
            // ScottPCM
            // 
            ScottPCM.Location = new Point(12, 65);
            ScottPCM.Margin = new Padding(4, 3, 4, 3);
            ScottPCM.Name = "ScottPCM";
            ScottPCM.Size = new Size(696, 269);
            ScottPCM.TabIndex = 3;
            // 
            // ScottFFT
            // 
            ScottFFT.Location = new Point(13, 353);
            ScottFFT.Margin = new Padding(4, 3, 4, 3);
            ScottFFT.Name = "ScottFFT";
            ScottFFT.Size = new Size(696, 269);
            ScottFFT.TabIndex = 3;
            // 
            // lblNotesPlayed
            // 
            lblNotesPlayed.AutoSize = true;
            lblNotesPlayed.Location = new Point(799, 90);
            lblNotesPlayed.Name = "lblNotesPlayed";
            lblNotesPlayed.Size = new Size(38, 15);
            lblNotesPlayed.TabIndex = 4;
            lblNotesPlayed.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 707);
            Controls.Add(lblNotesPlayed);
            Controls.Add(ScottFFT);
            Controls.Add(ScottPCM);
            Controls.Add(btnStart);
            Controls.Add(comboBox1);
            Controls.Add(pbVolume);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pbVolume;
        private ComboBox comboBox1;
        private Button btnStart;
        private System.Windows.Forms.Timer timerUpdateGraph;
        private ScottPlot.FormsPlot ScottPCM;
        private ScottPlot.FormsPlot ScottFFT;
        private Label lblNotesPlayed;
    }
}