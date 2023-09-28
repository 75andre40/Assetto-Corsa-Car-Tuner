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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            lblStatus = new Label();
            panel1 = new Panel();
            lblACFolder = new Label();
            pVehiclePics = new Panel();
            btnRightPic = new Button();
            btnLeftPic = new Button();
            picCurrentCarPaint = new PictureBox();
            pContent = new Panel();
            tpContent = new TabControl();
            tbBasic = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnTurbo = new Button();
            button1 = new Button();
            btnSwap = new Button();
            button3 = new Button();
            tbAdvanced = new TabPage();
            menuStrip1 = new MenuStrip();
            selectAssettoCorsaFolderToolStripMenuItem = new ToolStripMenuItem();
            StatusTimer = new System.Windows.Forms.Timer(components);
            cbCarList = new ComboBox();
            picReload = new PictureBox();
            lblCurrentCarPaint = new Label();
            cbCurrentTune = new ComboBox();
            gpModifyTune = new GroupBox();
            gpCreateTune = new GroupBox();
            btnCreateTune = new Button();
            txtCreateTune = new TextBox();
            panel1.SuspendLayout();
            pVehiclePics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCurrentCarPaint).BeginInit();
            pContent.SuspendLayout();
            tpContent.SuspendLayout();
            tbBasic.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picReload).BeginInit();
            gpModifyTune.SuspendLayout();
            gpCreateTune.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Left;
            lblStatus.FlatStyle = FlatStyle.Popup;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(576, 40);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Waiting...";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblACFolder);
            panel1.Controls.Add(lblStatus);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 575);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 40);
            panel1.TabIndex = 2;
            // 
            // lblACFolder
            // 
            lblACFolder.Dock = DockStyle.Right;
            lblACFolder.FlatStyle = FlatStyle.Popup;
            lblACFolder.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblACFolder.Location = new Point(605, 0);
            lblACFolder.Name = "lblACFolder";
            lblACFolder.Size = new Size(577, 40);
            lblACFolder.TabIndex = 2;
            lblACFolder.Text = "Assetto Corsa Path";
            lblACFolder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pVehiclePics
            // 
            pVehiclePics.Controls.Add(btnRightPic);
            pVehiclePics.Controls.Add(btnLeftPic);
            pVehiclePics.Controls.Add(picCurrentCarPaint);
            pVehiclePics.Location = new Point(11, 91);
            pVehiclePics.Margin = new Padding(3, 4, 3, 4);
            pVehiclePics.Name = "pVehiclePics";
            pVehiclePics.Size = new Size(400, 224);
            pVehiclePics.TabIndex = 3;
            // 
            // btnRightPic
            // 
            btnRightPic.Location = new Point(374, 92);
            btnRightPic.Margin = new Padding(3, 4, 3, 4);
            btnRightPic.Name = "btnRightPic";
            btnRightPic.Size = new Size(23, 40);
            btnRightPic.TabIndex = 2;
            btnRightPic.Text = ">";
            btnRightPic.UseVisualStyleBackColor = true;
            btnRightPic.Click += NextCarPaint;
            // 
            // btnLeftPic
            // 
            btnLeftPic.Location = new Point(3, 92);
            btnLeftPic.Margin = new Padding(3, 4, 3, 4);
            btnLeftPic.Name = "btnLeftPic";
            btnLeftPic.Size = new Size(23, 40);
            btnLeftPic.TabIndex = 1;
            btnLeftPic.Text = "<";
            btnLeftPic.UseVisualStyleBackColor = true;
            btnLeftPic.Click += PreviousCarPaint;
            // 
            // picCurrentCarPaint
            // 
            picCurrentCarPaint.BackColor = Color.White;
            picCurrentCarPaint.BackgroundImageLayout = ImageLayout.Stretch;
            picCurrentCarPaint.Image = Properties.Resources.PicBackground;
            picCurrentCarPaint.Location = new Point(29, 0);
            picCurrentCarPaint.Margin = new Padding(3, 4, 3, 4);
            picCurrentCarPaint.Name = "picCurrentCarPaint";
            picCurrentCarPaint.Size = new Size(343, 224);
            picCurrentCarPaint.SizeMode = PictureBoxSizeMode.StretchImage;
            picCurrentCarPaint.TabIndex = 0;
            picCurrentCarPaint.TabStop = false;
            // 
            // pContent
            // 
            pContent.Controls.Add(tpContent);
            pContent.Location = new Point(421, 48);
            pContent.Margin = new Padding(3, 4, 3, 4);
            pContent.Name = "pContent";
            pContent.Size = new Size(747, 519);
            pContent.TabIndex = 4;
            // 
            // tpContent
            // 
            tpContent.Controls.Add(tbBasic);
            tpContent.Controls.Add(tbAdvanced);
            tpContent.Dock = DockStyle.Fill;
            tpContent.HotTrack = true;
            tpContent.ItemSize = new Size(61, 20);
            tpContent.Location = new Point(0, 0);
            tpContent.Margin = new Padding(0);
            tpContent.Name = "tpContent";
            tpContent.SelectedIndex = 0;
            tpContent.Size = new Size(747, 519);
            tpContent.TabIndex = 0;
            // 
            // tbBasic
            // 
            tbBasic.BackColor = SystemColors.Control;
            tbBasic.Controls.Add(flowLayoutPanel1);
            tbBasic.Location = new Point(4, 24);
            tbBasic.Margin = new Padding(3, 4, 3, 4);
            tbBasic.Name = "tbBasic";
            tbBasic.Padding = new Padding(3, 4, 3, 4);
            tbBasic.Size = new Size(739, 491);
            tbBasic.TabIndex = 0;
            tbBasic.Text = "Basic";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnTurbo);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(btnSwap);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(733, 483);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnTurbo
            // 
            btnTurbo.Image = Properties.Resources.Turbo;
            btnTurbo.Location = new Point(8, 8);
            btnTurbo.Name = "btnTurbo";
            btnTurbo.Size = new Size(100, 111);
            btnTurbo.TabIndex = 0;
            btnTurbo.Text = "Turbo";
            btnTurbo.TextAlign = ContentAlignment.BottomCenter;
            btnTurbo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTurbo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(114, 8);
            button1.Name = "button1";
            button1.Size = new Size(100, 111);
            button1.TabIndex = 1;
            button1.Text = "Horsepower";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnSwap
            // 
            btnSwap.Image = Properties.Resources.Swap;
            btnSwap.Location = new Point(220, 8);
            btnSwap.Name = "btnSwap";
            btnSwap.Size = new Size(100, 111);
            btnSwap.TabIndex = 2;
            btnSwap.Text = "Swap";
            btnSwap.TextAlign = ContentAlignment.BottomCenter;
            btnSwap.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSwap.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(326, 8);
            button3.Name = "button3";
            button3.Size = new Size(100, 111);
            button3.TabIndex = 3;
            button3.Text = "Gearing";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.TextImageRelation = TextImageRelation.ImageAboveText;
            button3.UseVisualStyleBackColor = true;
            // 
            // tbAdvanced
            // 
            tbAdvanced.BackColor = SystemColors.Control;
            tbAdvanced.Location = new Point(4, 24);
            tbAdvanced.Margin = new Padding(3, 4, 3, 4);
            tbAdvanced.Name = "tbAdvanced";
            tbAdvanced.Padding = new Padding(3, 4, 3, 4);
            tbAdvanced.Size = new Size(739, 491);
            tbAdvanced.TabIndex = 1;
            tbAdvanced.Text = "Advanced";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { selectAssettoCorsaFolderToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1182, 30);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // selectAssettoCorsaFolderToolStripMenuItem
            // 
            selectAssettoCorsaFolderToolStripMenuItem.Name = "selectAssettoCorsaFolderToolStripMenuItem";
            selectAssettoCorsaFolderToolStripMenuItem.Size = new Size(212, 24);
            selectAssettoCorsaFolderToolStripMenuItem.Text = "Select Assetto Corsa Folder...";
            selectAssettoCorsaFolderToolStripMenuItem.Click += SelectACFolderMenu;
            // 
            // StatusTimer
            // 
            StatusTimer.Interval = 3000;
            StatusTimer.Tick += StatusTimer_Tick;
            // 
            // cbCarList
            // 
            cbCarList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarList.FormattingEnabled = true;
            cbCarList.Location = new Point(40, 48);
            cbCarList.MaxDropDownItems = 20;
            cbCarList.Name = "cbCarList";
            cbCarList.Size = new Size(342, 28);
            cbCarList.TabIndex = 6;
            cbCarList.SelectedIndexChanged += ChangedSelectedCar;
            // 
            // picReload
            // 
            picReload.Cursor = Cursors.Hand;
            picReload.Image = Properties.Resources.Reload;
            picReload.Location = new Point(387, 48);
            picReload.Name = "picReload";
            picReload.Size = new Size(28, 28);
            picReload.SizeMode = PictureBoxSizeMode.StretchImage;
            picReload.TabIndex = 7;
            picReload.TabStop = false;
            picReload.Click += ReloadCarList;
            // 
            // lblCurrentCarPaint
            // 
            lblCurrentCarPaint.FlatStyle = FlatStyle.Popup;
            lblCurrentCarPaint.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCurrentCarPaint.Location = new Point(11, 319);
            lblCurrentCarPaint.Name = "lblCurrentCarPaint";
            lblCurrentCarPaint.Size = new Size(400, 29);
            lblCurrentCarPaint.TabIndex = 3;
            lblCurrentCarPaint.Text = "Car paint 0 of 0";
            lblCurrentCarPaint.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbCurrentTune
            // 
            cbCurrentTune.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrentTune.FormattingEnabled = true;
            cbCurrentTune.Location = new Point(10, 33);
            cbCurrentTune.MaxDropDownItems = 20;
            cbCurrentTune.Name = "cbCurrentTune";
            cbCurrentTune.Size = new Size(384, 28);
            cbCurrentTune.TabIndex = 8;
            // 
            // gpModifyTune
            // 
            gpModifyTune.Controls.Add(cbCurrentTune);
            gpModifyTune.Location = new Point(11, 351);
            gpModifyTune.Name = "gpModifyTune";
            gpModifyTune.Size = new Size(400, 77);
            gpModifyTune.TabIndex = 11;
            gpModifyTune.TabStop = false;
            gpModifyTune.Text = "Modify";
            // 
            // gpCreateTune
            // 
            gpCreateTune.Controls.Add(btnCreateTune);
            gpCreateTune.Controls.Add(txtCreateTune);
            gpCreateTune.Location = new Point(11, 449);
            gpCreateTune.Name = "gpCreateTune";
            gpCreateTune.Size = new Size(400, 114);
            gpCreateTune.TabIndex = 12;
            gpCreateTune.TabStop = false;
            gpCreateTune.Text = "Create";
            // 
            // btnCreateTune
            // 
            btnCreateTune.Location = new Point(6, 68);
            btnCreateTune.Name = "btnCreateTune";
            btnCreateTune.Size = new Size(388, 40);
            btnCreateTune.TabIndex = 1;
            btnCreateTune.Text = "Create tune";
            btnCreateTune.UseVisualStyleBackColor = true;
            // 
            // txtCreateTune
            // 
            txtCreateTune.Location = new Point(6, 31);
            txtCreateTune.Name = "txtCreateTune";
            txtCreateTune.Size = new Size(388, 27);
            txtCreateTune.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1182, 615);
            Controls.Add(gpCreateTune);
            Controls.Add(gpModifyTune);
            Controls.Add(lblCurrentCarPaint);
            Controls.Add(picReload);
            Controls.Add(cbCarList);
            Controls.Add(pContent);
            Controls.Add(pVehiclePics);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assetto Corsa Car Tuner";
            Load += Form_Loaded;
            panel1.ResumeLayout(false);
            pVehiclePics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCurrentCarPaint).EndInit();
            pContent.ResumeLayout(false);
            tpContent.ResumeLayout(false);
            tbBasic.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picReload).EndInit();
            gpModifyTune.ResumeLayout(false);
            gpCreateTune.ResumeLayout(false);
            gpCreateTune.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Label lblACFolder;
        private Panel pVehiclePics;
        private Button btnLeftPic;
        private PictureBox picCurrentCarPaint;
        private Button btnRightPic;
        private Panel pContent;
        private TabControl tpContent;
        private TabPage tbBasic;
        private TabPage tbAdvanced;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem selectAssettoCorsaFolderToolStripMenuItem;
        public Label lblStatus;
        private System.Windows.Forms.Timer StatusTimer;
        private ComboBox cbCarList;
        private PictureBox picReload;
        public Label lblCurrentCarPaint;
        private ComboBox cbCurrentTune;
        private GroupBox gpModifyTune;
        private GroupBox gpCreateTune;
        private Button btnCreateTune;
        private TextBox txtCreateTune;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnTurbo;
        private Button button1;
        private Button btnSwap;
        private Button button3;
    }
}