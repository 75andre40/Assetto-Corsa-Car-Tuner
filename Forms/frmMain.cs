using lib.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assetto_Corsa_Car_Tuner
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form_Loaded(object sender, EventArgs e)
        {

        }

        private void ChangeACFolderPath()
        {
            FolderBrowserDialog ofdACFolderPath = new FolderBrowserDialog();
            ofdACFolderPath.SelectedPath = @"C:\AssettoCorsa";
            ofdACFolderPath.ShowDialog();

            if (File.Exists(ofdACFolderPath.SelectedPath + "\\acs.exe")) { clsUtils.ACFolder = ofdACFolderPath.SelectedPath; }

        }

        private void CheckForUpdates()
        {

        }
        //ChangeACFolderPath();
        //lblStatus.Text = clsUtils.ACFolder;
    }
}

