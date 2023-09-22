namespace Assetto_Corsa_Car_Tuner
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            lblStatus = new Label();
            panel1 = new Panel();
            lblACFolder = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Left;
            lblStatus.FlatStyle = FlatStyle.Popup;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(401, 30);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status...";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblACFolder);
            panel1.Controls.Add(lblStatus);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 431);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 30);
            panel1.TabIndex = 2;
            // 
            // lblACFolder
            // 
            lblACFolder.Dock = DockStyle.Right;
            lblACFolder.FlatStyle = FlatStyle.Popup;
            lblACFolder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblACFolder.Location = new Point(407, 0);
            lblACFolder.Name = "lblACFolder";
            lblACFolder.Size = new Size(377, 30);
            lblACFolder.TabIndex = 2;
            lblACFolder.Text = "Assetto Corsa Path";
            lblACFolder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            button1.Location = new Point(196, 143);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(784, 461);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assetto Corsa Car Tuner";
            Load += Form_Loaded;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblStatus;
        private Panel panel1;
        private Label lblACFolder;
        private Button button1;
    }
}