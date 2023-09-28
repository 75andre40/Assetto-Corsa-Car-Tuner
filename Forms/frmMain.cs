using lib.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Text;
using System.Reflection;
using System.Xml;

namespace Assetto_Corsa_Car_Tuner
{
    public partial class frmMain : Form
    {

        private string RootFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\files\\root.ini";

        private string ACFolder = "";

        private List<Cars> CarsList = new List<Cars>();

        private NumericUpDown CarPaint = new NumericUpDown();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form_Loaded(object sender, EventArgs e)
        {
            InitializeEvents();
            if (CheckRootFile() == true)
            {
                GetCarList();
            }
        }

        private void ClearFields()
        {
            picCurrentCarPaint.BackgroundImage = null;
            lblCurrentCarPaint.Text = "Car paint 0 of 0";
        }

        private void InitializeEvents()
        {
            CarPaint.ValueChanged += NumericPaintChanged;
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Waiting...";
            lblStatus.ForeColor = Color.Black;
        }

        private void ChangeCurrentStatus(string message, int importance)
        {
            StatusTimer.Stop();
            /*
            //Importance:
            //1 - Critical - Red (Used in errors) 
            //2 - Information - Black (Used to show general information)
            //3 - Succed - Green (Used to show a succed message)
            */


            lblStatus.Text = message;

            switch (importance)
            {
                case 1:
                    lblStatus.ForeColor = Color.DarkRed;
                    break;
                case 2:
                    lblStatus.ForeColor = Color.DarkBlue;
                    break;
                case 3:
                    lblStatus.ForeColor = Color.DarkGreen;
                    break;
            }

            StatusTimer.Start();

        }

        private bool CheckRootFile()
        {
            if (File.Exists(RootFilePath))
            {
                try
                {
                    using (StreamReader streamReader = File.OpenText(RootFilePath))
                        ACFolder = streamReader.ReadLine();
                    lblACFolder.Text = ACFolder;
                    ChangeCurrentStatus("Assetto Corsa path loaded from file.", 3);
                    return true;
                }
                catch (Exception ex)
                {
                    string exceptionToString = ex.ToString();
                    return false;
                }
            }
            else { return false; }
        }


        private void ChangeACFolderPath()
        {
            FolderBrowserDialog ofdACFolderPath = new FolderBrowserDialog();
            ofdACFolderPath.SelectedPath = @"C:\AssettoCorsa";
            if (ofdACFolderPath.ShowDialog() == DialogResult.OK && File.Exists(ofdACFolderPath.SelectedPath + "\\acs.exe"))
            {
                ACFolder = ofdACFolderPath.SelectedPath;
                if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\files"))
                {
                    MessageBox.Show("Some files are missing. Please re-download the software.", "Assetto Corsa Car Tuner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if (!File.Exists(RootFilePath))
                {
                    using (File.Create(RootFilePath)) { }
                }
                using (StreamWriter writer = new StreamWriter(RootFilePath))
                {
                    writer.WriteLine(ACFolder);
                }
                lblACFolder.Text = ACFolder;
                ChangeCurrentStatus("Assetto Corsa path was changed.", 3);
                GetCarList();
            }
            else if (!File.Exists(ofdACFolderPath.SelectedPath + "\\acs.exe"))
            {
                ChangeCurrentStatus("The selected folder is invalid. Please try again.", 1);
            }
        }

        private bool GetCarList()
        {
            try
            {
                CarsList.Clear();
                cbCarList.Items.Clear();
                ClearFields();

                string[] directories = Directory.GetDirectories(this.ACFolder + "\\content\\cars");
                for (int i = 0; i <= directories.Length - 1; i++)
                {
                    if (Directory.Exists(directories[i] + "\\sfx") && !File.Exists(directories[i] + "\\x.tuned"))
                    {

                        string jsonText = File.ReadAllText(directories[i] + "\\ui\\ui_car.json");
                        JObject jsonObj = JObject.Parse(jsonText);
                        string? carName = (string?)jsonObj["name"];
                        if (carName == null)
                        {
                            carName = Path.GetFileName(Path.GetDirectoryName(directories[i] + "\\"));
                        }

                        var tempCarImagePath = Directory.GetDirectories(directories[i] + "\\skins");
                        List<string> carImagePath = new List<string>();
                        foreach (string folderPath in tempCarImagePath)
                        {
                            carImagePath.Add(folderPath + "\\preview.jpg");
                        }



                        Cars tempCarList = new Cars();
                        tempCarList.CarName = carName;
                        tempCarList.CarImagePath = carImagePath.ToArray();
                        tempCarList.CarPath = directories[i];
                        CarsList.Add(tempCarList);

                    }
                }

                CarsList.Sort((a, b) => string.Compare(a.CarName, b.CarName));

                foreach (var car in CarsList)
                {
                    cbCarList.Items.Add(car.CarName);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private void CheckUpdates()
        {

        }

        private void SelectACFolderMenu(object sender, EventArgs e)
        {
            ChangeACFolderPath();
        }

        private void ChangedSelectedCar(object sender, EventArgs e)
        {
            CarPaint.Minimum = 0;
            try
            {
                CarPaint.Maximum = CarsList[cbCarList.SelectedIndex].CarImagePath.Length - 1;
            }
            catch (Exception ex)
            {
                CarPaint.Maximum = 0;
            }
            CarPaint.Value = 0;
            NumericPaintChanged(this, EventArgs.Empty);
        }

        private void NumericPaintChanged(object sender, EventArgs e)
        {
            picCurrentCarPaint.BackgroundImage = Image.FromFile(CarsList[cbCarList.SelectedIndex].CarImagePath[(int)CarPaint.Value]);
            lblCurrentCarPaint.Text = "Car paint " + (CarPaint.Value + 1) + " of " + (CarPaint.Maximum + 1);
        }

        private void ReloadCarList(object sender, EventArgs e)
        {
            if (lblACFolder.Text == "Assetto Corsa Path") 
            {
                ChangeCurrentStatus("Please select your assetto corsa folder first.", 1);
            }
            else 
            { 
                if (GetCarList() == true) { ChangeCurrentStatus("Reloaded with success.", 3); }
                else { ChangeCurrentStatus("An error ocurred while reloading.", 1); }
            }
        }

        private void NextCarPaint(object sender, EventArgs e)
        {
            if (CarPaint.Value < CarPaint.Maximum) { CarPaint.Value++; }
        }

        private void PreviousCarPaint(object sender, EventArgs e)
        {

            if (CarPaint.Value > CarPaint.Minimum) { CarPaint.Value--; }
        }
    }


    public class Cars
    {
        public string? CarName { get; set; }
        public string[]? CarImagePath { get; set; }
        public string? CarPath { get; set; }
    }
}

