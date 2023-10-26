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
            tblLayout = new TableLayoutPanel();
            lblTitle = new Label();
            btnExit = new Button();
            button1 = new Button();
            button2 = new Button();
            tblLayout.SuspendLayout();
            SuspendLayout();
            // 
            // tblLayout
            // 
            tblLayout.ColumnCount = 3;
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.3928576F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.88393F));
            tblLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8348217F));
            tblLayout.Controls.Add(lblTitle, 1, 0);
            tblLayout.Controls.Add(btnExit, 2, 0);
            tblLayout.Controls.Add(button1, 2, 2);
            tblLayout.Controls.Add(button2, 1, 2);
            tblLayout.Dock = DockStyle.Fill;
            tblLayout.Location = new Point(0, 0);
            tblLayout.Name = "tblLayout";
            tblLayout.RowCount = 3;
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 17.4568958F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 82.5431061F));
            tblLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tblLayout.Size = new Size(901, 543);
            tblLayout.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Roboto", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(362, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(179, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chordo";
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Fill;
            btnExit.Location = new Point(787, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(111, 75);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(787, 471);
            button1.Name = "button1";
            button1.Size = new Size(111, 69);
            button1.TabIndex = 2;
            button1.Text = "Skip";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.Location = new Point(663, 471);
            button2.Name = "button2";
            button2.Size = new Size(118, 69);
            button2.TabIndex = 3;
            button2.Text = "Help!";
            button2.UseVisualStyleBackColor = true;
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
    }
}