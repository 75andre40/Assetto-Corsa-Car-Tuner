using lib.Classes;
using System.Xml;

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

        private void button1_Click(object sender, EventArgs e)
        {

            clsUtils.CheckUpdates();
        }
        //ChangeACFolderPath();
        //lblStatus.Text = clsUtils.ACFolder;
    }
}

