using Manufaktura.Controls.Model;

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
            ScottFFT = new ScottPlot.FormsPlot();
            lblNotesPlayed = new Label();
            btnHelp = new Button();
            SuspendLayout();

            
            // 
            // pbVolume
            // 
            pbVolume.Location = new Point(643, 12);
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
            // ScottFFT
            // 
            ScottFFT.Location = new Point(13, 55);
            ScottFFT.Margin = new Padding(4, 3, 4, 3);
            ScottFFT.Name = "ScottFFT";
            ScottFFT.Size = new Size(312, 127);
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
            // btnHelp
            // 
            btnHelp.Location = new Point(737, 482);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 23);
            btnHelp.TabIndex = 5;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 517);
            Controls.Add(btnHelp);
            Controls.Add(lblNotesPlayed);
            Controls.Add(ScottFFT);
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
        private ScottPlot.FormsPlot ScottFFT;
        private Label lblNotesPlayed;
        private Button btnHelp;
    }
}