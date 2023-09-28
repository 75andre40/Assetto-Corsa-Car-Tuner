using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assetto_Corsa_Car_Tuner.Classes
{
    internal class Class1
    {

        public static string root = Application.StartupPath + "\\files";
        public string assDir;
        public static string carsfol = "\\content\\cars";
        public static string carsn = "\\content\\cars\\";
        public string currentCar;
        public string currentTune;
        public string currentTuneFile;
        public string currentText;
        public bool changestate;
        public string[] pictures;
        public int currentPic;
        public string oldweight;
        public string olddrive;
        public string oldfinal;
        public string oldbrake;
        public string oldt1;
        public string oldt1mb;
        public string oldt1wg;
        public string oldt2;
        public string oldt2mb;
        public string oldt2wg;
        public string oldt3;
        public string oldt3mb;
        public string oldt3wg;
        public string oldt4;
        public string oldt4mb;
        public string oldt4wg;
        public string olddamage;
        private IContainer components;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem selectAssFolder;
        private TabControl tuningMode;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label selectCarLabel;
        private ComboBox menu;
        private Button back;
        private Button next;
        private PictureBox carPicture;
        private Panel panel1;
        private ComboBox selectTune;
        private Label selectTuneLabel;
        private Label label1;
        private TextBox newTuneName;
        private Button createNewTune;
        private Button deleteTune;
        private Panel panel2;
        private Panel panel3;
        private Label powerLabel;
        private Label increaseTorqueLabel;
        private TextBox torquePercentage;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TextBox maxBoost1;
        private TextBox wastegate1;
        private Label maxBoostLabel1;
        private Label wastegateLabel1;
        private Label turboLabel;
        private TextBox maxBoost2;
        private TextBox wastegate2;
        private Label wastegateLabel2;
        private Label maxBoostLabel2;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TextBox maxBoost3;
        private TextBox wastegate3;
        private Label wastegateLabel3;
        private Label maxBoostLabel3;
        private TextBox maxBoost4;
        private TextBox wastegate4;
        private Label wastegateLabel4;
        private Label maxBoostLabel4;
        private Label weightLabel;
        private TextBox weight;
        private Label weightLabel2;
        private TextBox engineDamage;
        private Label engineDamageLabel;
        private Label wheelDriveLabel;
        private Label wheelDriveLabel2;
        private Label finalDriveLabel;
        private Label finalDriveLabel2;
        private ComboBox wheelDrive;
        private TextBox finalDrive;
        private Label finalDriveExplain;
        private Label brakesLabel;
        private TextBox brakes;
        private Label brakesLabel2;
        private ComboBox chooseFile;
        private Label chooseFileLabel;
        private Panel panel4;
        private TextBox editFile;
        private Label label2;
        private Button apply;
        private Label engineDamageExplain;
        private TabPage tabPage4;
        private Button openCarFolder;
        private ComboBox enginelist;
        private Label engineswaplabel;
        private Label engineswaplabel2;
        private ComboBox soundswap;
        private Label soundSwap1;
        private Label swapenginesound;
        private Button importTune;

        private void copyDirectory(string strSource, string strDestination)
        {
            if (!Directory.Exists(strDestination))
                Directory.CreateDirectory(strDestination);
            DirectoryInfo directoryInfo = new DirectoryInfo(strSource);
            foreach (FileInfo file in directoryInfo.GetFiles())
                file.CopyTo(Path.Combine(strDestination, file.Name));
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                this.copyDirectory(Path.Combine(strSource, directory.Name), Path.Combine(strDestination, directory.Name));
        }

        private void reset()
        {
            this.newTuneName.Text = "";
            this.chooseFile.Text = "";
            this.torquePercentage.Text = "";
            this.maxBoost1.Text = "";
            this.maxBoost2.Text = "";
            this.maxBoost3.Text = "";
            this.maxBoost4.Text = "";
            this.wastegate1.Text = "";
            this.wastegate2.Text = "";
            this.wastegate3.Text = "";
            this.wastegate4.Text = "";
            this.engineDamage.Text = "";
            this.weight.Text = "";
            this.wheelDrive.Text = "";
            this.finalDrive.Text = "";
            this.brakes.Text = "";
            this.enginelist.Text = "";
            this.currentPic = 0;
            this.soundswap.Items.Clear();
            this.chooseFile.Items.Clear();
            this.wheelDrive.Items.Clear();
            this.enginelist.Items.Clear();
        }

        private void getPictures(string car)
        {
            this.pictures = Directory.GetDirectories(car + "\\skins");
            this.carPicture.Image = Image.FromFile(this.pictures[this.currentPic] + "\\preview.jpg");
        }

        private void getSound(string car)
        {
            string str1 = this.assDir + GUI.GUI.carsn + car;
            string fileName1 = Path.GetFileName(Path.GetDirectoryName(this.currentTune + "\\"));
            Directory.Delete(this.currentTune + "\\sfx", true);
            Directory.CreateDirectory(this.currentTune + "\\sfx");
            if (File.Exists(str1 + "\\sfx\\GUIDs.txt"))
            {
                string[] files = Directory.GetFiles(str1 + "\\sfx");
                for (int index = 0; index <= files.Length - 1; ++index)
                {
                    string fileName2 = Path.GetFileName(Path.GetDirectoryName(files[index] + "\\"));
                    File.Copy(files[index], this.currentTune + "\\sfx\\" + fileName2.Replace(car, fileName1), true);
                }
                File.WriteAllText(this.currentTune + "\\sfx\\GUIDs.txt", File.ReadAllText(this.currentTune + "\\sfx\\GUIDs.txt").Replace("/" + car + "/", "/" + fileName1 + "/"));
            }
            else
            {
                string[] files = Directory.GetFiles(str1 + "\\sfx");
                for (int index = 0; index <= files.Length - 1; ++index)
                {
                    Path.GetFileName(Path.GetDirectoryName(files[index] + "\\"));
                    File.Copy(files[index], this.currentTune + "\\sfx\\" + fileName1 + ".bank", true);
                }
                File.Copy(GUI.GUI.root + "\\GUIDs.txt", this.currentTune + "\\sfx\\GUIDs.txt");
                List<string> stringList = new List<string>();
                StreamReader streamReader = File.OpenText(this.assDir + "\\content\\sfx\\GUIDs.txt");
                while (!streamReader.EndOfStream)
                {
                    string str2 = streamReader.ReadLine();
                    if (str2.Contains("/" + car + "/"))
                        stringList.Add(str2);
                }
                string[] array = stringList.ToArray();
                string contents = File.ReadAllText(GUI.GUI.root + "\\GUIDs.txt");
                for (int index = 0; index <= array.Length - 1; ++index)
                    contents = contents + array[index].Replace(car, fileName1) + "\r \n";
                File.WriteAllText(this.currentTune + "\\sfx\\GUIDs.txt", contents);
            }
        }

        private void getCars(ComboBox box)
        {
            box.Items.Clear();
            string[] directories = Directory.GetDirectories(this.assDir + GUI.GUI.carsfol);
            for (int index = 0; index <= directories.Length - 1; ++index)
            {
                if (Directory.Exists(directories[index] + "\\sfx") && !File.Exists(directories[index] + "\\x.tuned"))
                {
                    string fileName = Path.GetFileName(Path.GetDirectoryName(directories[index] + "\\"));
                    box.Items.Add((object)fileName);
                }
            }
        }

        private void getTunes()
        {
            this.selectTune.Items.Clear();
            string[] directories = Directory.GetDirectories(this.assDir + GUI.GUI.carsfol);
            for (int index = 0; index <= directories.Length - 1; ++index)
            {
                if (directories[index].Contains(this.currentCar) && File.Exists(directories[index] + "\\x.tuned"))
                    this.selectTune.Items.Add((object)File.ReadAllText(directories[index] + "\\x.tuned"));
            }
        }

        private void createData(string car, bool engineswap)
        {
            string currentCarPath = this.assDir + GUI.GUI.carsn + car;
            string str = this.assDir + GUI.GUI.carsn + car + "\\TEMP";
            if (Directory.Exists(currentCarPath + "\\data"))
            {
                if (engineswap)
                {
                    File.Copy(currentCarPath + "\\data\\power.lut", this.currentTune + "\\data\\power.lut", true);
                    File.Copy(currentCarPath + "\\data\\engine.ini", this.currentTune + "\\data\\engine.ini", true);
                }
                else
                    this.copyDirectory(currentCarPath + "\\data", this.currentTune + "\\data");
            }
            else
            {
                Directory.CreateDirectory(str);
                Directory.CreateDirectory(this.currentTune + "\\data");
                QuickBMS.getData(GUI.GUI.root, currentCarPath, str);
                if (engineswap)
                {
                    File.Copy(str + "\\power.lut", this.currentTune + "\\data\\power.lut", true);
                    File.Copy(str + "\\engine.ini", this.currentTune + "\\data\\engine.ini", true);
                }
                else
                    this.copyDirectory(str, this.currentTune + "\\data");
                Directory.Delete(str, true);
            }
        }

        private void editUIcar(string name)
        {
            string oldValue = "";
            string str1 = "\t\"parent\": \"" + this.currentCar + "\",";
            using (StreamReader streamReader = File.OpenText(this.currentTune + "\\data\\car.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str2 = streamReader.ReadLine();
                    if (str2.Contains("SCREEN_NAME="))
                        oldValue = str2;
                }
            }
            if (!(oldValue == ""))
                File.WriteAllText(this.currentTune + "\\data\\car.ini", File.ReadAllText(this.currentTune + "\\data\\car.ini").Replace(oldValue, oldValue + " " + name.Replace("_", " ")));
            using (StreamReader streamReader = File.OpenText(this.currentTune + "\\ui\\ui_car.json"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str3 = streamReader.ReadLine();
                    if (str3.Contains("\"name\": "))
                        oldValue = str3;
                }
            }
            if (!(oldValue == ""))
                File.WriteAllText(this.currentTune + "\\ui\\ui_car.json", File.ReadAllText(this.currentTune + "\\ui\\ui_car.json").Replace(oldValue, oldValue.Replace("\",", "") + " " + name.Replace("_", " ") + "\", \n " + str1));
            File.Copy(GUI.GUI.root + "\\upgrade.png", this.currentTune + "\\ui\\upgrade.png", true);
        }

        private void selectAssettoCorsaCarFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK && Directory.Exists(folderBrowserDialog.SelectedPath + GUI.GUI.carsfol))
            {
                this.assDir = folderBrowserDialog.SelectedPath;
                File.WriteAllText(GUI.GUI.root + "\\root.ini", this.assDir);
                this.getCars(this.menu);
            }
            else if (!Directory.Exists(folderBrowserDialog.SelectedPath + GUI.GUI.carsfol))
                this.menu.Text = "The right folder was not selected!";
            else
                this.menu.Text = "No folder was selected.";
        }

        private void findItem(ComboBox box, string name)
        {
            int index = 0;
            while (!(box.Items[index].ToString() == name))
                ++index;
            box.SelectedItem = box.Items[index];
        }

        private void carSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentCar = this.menu.SelectedItem.ToString();
            string car = this.assDir + GUI.GUI.carsn + this.currentCar;
            this.changestate = true;
            this.editFile.Text = "";
            this.reset();
            this.selectTune.Items.Clear();
            this.selectTune.Text = "";
            this.getPictures(car);
            this.getTunes();
            this.changestate = false;
        }

        private void createNewTune_Click(object sender, EventArgs e)
        {
            this.changestate = true;
            string str = this.newTuneName.Text.Replace(" ", "_");
            string strSource = this.assDir + GUI.GUI.carsn + this.currentCar;
            this.currentTune = this.assDir + GUI.GUI.carsn + this.currentCar + "_" + str;
            if (!Directory.Exists(this.currentTune) && !(str == "") && !(str == "TEMP"))
            {
                Directory.CreateDirectory(this.currentTune);
                this.copyDirectory(strSource, this.currentTune);
                this.getSound(this.currentCar);
                if (!Directory.Exists(strSource + "\\data"))
                    this.createData(this.currentCar, false);
                File.Delete(this.currentTune + "\\data.acd");
                File.WriteAllText(this.currentTune + "\\x.tuned", str);
                this.editUIcar(str);
                this.getTunes();
                this.findItem(this.selectTune, str);
            }
            this.newTuneName.Text = "";
            this.changestate = false;
        }

        private void getTuningFiles()
        {
            string[] files = Directory.GetFiles(this.currentTune + "\\data");
            for (int index = 0; index <= files.Length - 1; ++index)
                this.chooseFile.Items.Add((object)Path.GetFileName(Path.GetDirectoryName(files[index] + "\\")));
        }

        private void getDataForBasic()
        {
            string str1 = this.currentTune + "\\data";
            this.getCars(this.soundswap);
            this.getCars(this.enginelist);
            this.enginelist.Text = "";
            this.soundswap.Text = "";
            this.getTuningFiles();
            this.changestate = true;
            this.findItem(this.chooseFile, "car.ini");
            this.changestate = false;
            using (StreamReader streamReader = File.OpenText(str1 + "\\car.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string input = streamReader.ReadLine();
                    if (input.Length >= 9 && input.Substring(0, 9) == "TOTALMASS")
                    {
                        this.oldweight = input;
                        input.Split(';');
                        this.weight.Text = Regex.Replace(input, "[^0-9]+", "");
                    }
                }
            }
            this.wheelDrive.Items.Add((object)"FWD ");
            this.wheelDrive.Items.Add((object)"RWD ");
            this.wheelDrive.Items.Add((object)"AWD ");
            this.wheelDrive.Items.Add((object)"AWD2");
            using (StreamReader streamReader = File.OpenText(str1 + "\\drivetrain.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str2 = streamReader.ReadLine();
                    if (str2.Length >= 4 && str2.Substring(0, 4) == "TYPE")
                    {
                        this.olddrive = str2;
                        string str3 = str2.Substring(5, 4);
                        if (str3.Substring(0, 3) == "FWD")
                            this.wheelDrive.SelectedItem = this.wheelDrive.Items[0];
                        else if (str3.Substring(0, 3) == "RWD")
                            this.wheelDrive.SelectedItem = this.wheelDrive.Items[1];
                        else if (str3.Substring(0, 3) == "AWD")
                            this.wheelDrive.SelectedItem = this.wheelDrive.Items[2];
                        else if (str3.Substring(0, 4) == "AWD2")
                            this.wheelDrive.SelectedItem = this.wheelDrive.Items[1];
                        else
                            this.wheelDrive.Text = "error";
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\drivetrain.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str4 = streamReader.ReadLine();
                    if (str4.Length >= 9 && str4.Substring(0, 5) == "FINAL")
                    {
                        this.oldfinal = str4;
                        this.finalDrive.Text = Regex.Replace(str4.Split(';')[0], "[^0-9\\.]", "");
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\brakes.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str5 = streamReader.ReadLine();
                    if (str5.Length >= 10 && str5.Substring(0, 10) == "MAX_TORQUE")
                    {
                        this.oldbrake = str5;
                        this.brakes.Text = Regex.Replace(str5.Split(';')[0], "[^0-9]+", "");
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\engine.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str6 = streamReader.ReadLine();
                    if (str6.Length >= 9 && str6.Substring(0, 9) == "[TURBO_0]")
                    {
                        this.oldt1 = str6 + "\n";
                        bool flag = false;
                        while (!flag)
                        {
                            string str7 = streamReader.ReadLine();
                            this.oldt1 = this.oldt1 + str7 + "\n";
                            if (str7.Length >= 9 && str7.Substring(0, 9) == "MAX_BOOST")
                            {
                                this.oldt1mb = str7;
                                this.maxBoost1.Text = Regex.Replace(str7.Split(';')[0], "[^0-9\\.]+", "");
                                string str8 = streamReader.ReadLine();
                                this.oldt1wg = str8 + "\n";
                                this.wastegate1.Text = Regex.Replace(str8.Split(';')[0], "[^0-9\\.]+", "");
                                flag = true;
                            }
                        }
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\engine.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str9 = streamReader.ReadLine();
                    if (str9.Length >= 9 && str9.Substring(0, 9) == "[TURBO_1]")
                    {
                        this.oldt2 = str9 + "\n";
                        bool flag = false;
                        while (!flag)
                        {
                            string str10 = streamReader.ReadLine();
                            this.oldt2 = this.oldt2 + str10 + "\n";
                            if (str10.Length >= 9 && str10.Substring(0, 9) == "MAX_BOOST")
                            {
                                this.oldt2mb = str10;
                                this.maxBoost2.Text = Regex.Replace(str10.Split(';')[0], "[^0-9\\.]+", "");
                                string str11 = streamReader.ReadLine();
                                this.oldt2wg = str11 + "\n";
                                this.wastegate2.Text = Regex.Replace(str11.Split(';')[0], "[^0-9\\.]+", "");
                                flag = true;
                            }
                        }
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\engine.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str12 = streamReader.ReadLine();
                    if (str12.Length >= 9 && str12.Substring(0, 9) == "[TURBO_2]")
                    {
                        this.oldt3 = str12 + "\n";
                        bool flag = false;
                        while (!flag)
                        {
                            string str13 = streamReader.ReadLine();
                            this.oldt3 = this.oldt3 + str13 + "\n";
                            if (str13.Length >= 9 && str13.Substring(0, 9) == "MAX_BOOST")
                            {
                                this.oldt3mb = str13;
                                this.maxBoost3.Text = Regex.Replace(str13.Split(';')[0], "[^0-9\\.]+", "");
                                string str14 = streamReader.ReadLine();
                                this.oldt3wg = str14 + "\n";
                                this.wastegate3.Text = Regex.Replace(str14.Split(';')[0], "[^0-9\\.]+", "");
                                flag = true;
                            }
                        }
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\engine.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str15 = streamReader.ReadLine();
                    if (str15.Length >= 9 && str15.Substring(0, 9) == "[TURBO_3]")
                    {
                        this.oldt4 = str15 + "\n";
                        bool flag = false;
                        while (!flag)
                        {
                            string str16 = streamReader.ReadLine();
                            this.oldt4 = this.oldt4 + str16 + "\n";
                            if (str16.Length >= 9 && str16.Substring(0, 9) == "MAX_BOOST")
                            {
                                this.oldt4mb = str16;
                                this.maxBoost4.Text = Regex.Replace(str16.Split(';')[0], "[^0-9\\.]+", "");
                                string str17 = streamReader.ReadLine();
                                this.oldt4wg = str17 + "\n";
                                this.wastegate4.Text = Regex.Replace(str17.Split(';')[0], "[^0-9\\.]+", "");
                                flag = true;
                            }
                        }
                    }
                }
            }
            using (StreamReader streamReader = File.OpenText(str1 + "\\engine.ini"))
            {
                while (!streamReader.EndOfStream)
                {
                    string str18 = streamReader.ReadLine();
                    if (str18.Length >= 21 && str18.Substring(0, 21) == "TURBO_BOOST_THRESHOLD")
                    {
                        this.olddamage = str18;
                        this.engineDamage.Text = Regex.Replace(str18.Split(';')[0], "[^0-9\\.]+", "");
                    }
                }
            }
        }

        private void selectTune_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentTune = this.assDir + GUI.GUI.carsn + this.currentCar + "_" + this.selectTune.Text;
            this.changestate = true;
            this.editFile.Text = "";
            this.reset();
            this.changestate = false;
            this.getDataForBasic();
        }

        private void deleteTune_Click(object sender, EventArgs e)
        {
            if (this.selectTune.Text == "")
                return;
            string fileName = Path.GetFileName(Path.GetDirectoryName(this.currentTune + "\\"));
            if (Directory.Exists(this.assDir + "\\server\\content\\cars\\" + fileName))
                Directory.Delete(this.assDir + "\\server\\content\\cars\\" + fileName, true);
            Directory.Delete(this.currentTune, true);
            this.reset();
            this.changestate = true;
            this.editFile.Text = "";
            this.changestate = false;
            this.selectTune.Text = "";
            this.getTunes();
        }

        private void installTuneServer_Click(object sender, EventArgs e)
        {
            string path = this.assDir + "\\server\\content\\cars\\" + Path.GetFileName(Path.GetDirectoryName(this.currentTune + "\\"));
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            if (this.selectTune.Text == "")
                return;
            Directory.CreateDirectory(path);
            this.copyDirectory(this.currentTune + "\\data", path + "\\data");
        }

        private void apply_Click(object sender, EventArgs e)
        {
            if (this.selectTune.Text == "")
                return;
            string str1 = this.currentTune + "\\data\\";
            if (!(this.enginelist.Text == ""))
            {
                string text = this.enginelist.Text;
                this.getSound(text);
                this.createData(text, true);
            }
            if (!(this.soundswap.Text == ""))
                this.getSound(this.soundswap.Text);
            string path = str1 + "power.lut";
            if (File.Exists(path) && !(this.torquePercentage.Text == ""))
            {
                double num1 = double.Parse(this.torquePercentage.Text);
                string end;
                using (StreamReader streamReader = File.OpenText(path))
                    end = streamReader.ReadToEnd();
                string[] strArray1 = end.Split('\n');
                string contents = "";
                for (int index = 0; index <= strArray1.Length - 1; ++index)
                {
                    if (!(strArray1[index] == ""))
                    {
                        try
                        {
                            string[] strArray2 = strArray1[index].Split('|');
                            int num2 = (int)(double.Parse(strArray2[1]) * (1.0 + num1 / 100.0));
                            contents += string.Format(strArray2[0] + "|" + (object)num2 + "    \r \n");
                        }
                        catch
                        {
                        }
                    }
                }
                File.WriteAllText(path, contents);
            }
            string str2 = File.ReadAllText(str1 + "car.ini");
            File.WriteAllText(str1 + "car.ini", str2.Replace(this.oldweight, "TOTALMASS=" + this.weight.Text));
            string str3 = File.ReadAllText(str1 + "drivetrain.ini");
            File.WriteAllText(str1 + "drivetrain.ini", str3.Replace(this.olddrive, "TYPE=" + this.wheelDrive.Text));
            string str4 = File.ReadAllText(str1 + "drivetrain.ini");
            File.WriteAllText(str1 + "drivetrain.ini", str4.Replace(this.oldfinal, "FINAL=" + this.finalDrive.Text));
            string str5 = File.ReadAllText(str1 + "brakes.ini");
            File.WriteAllText(str1 + "brakes.ini", str5.Replace(this.oldbrake, "MAX_TORQUE=" + this.brakes.Text));
            if (this.oldt1 != null)
            {
                string str6 = File.ReadAllText(str1 + "engine.ini");
                File.WriteAllText(str1 + "engine.ini", str6.Replace(this.oldt1 + this.oldt1wg, "[TURBO_0]\nMAX_BOOST=" + this.maxBoost1.Text + " \nWASTEGATE=" + this.wastegate1.Text + " \n"));
            }
            if (this.oldt2 != null)
            {
                string str7 = File.ReadAllText(str1 + "engine.ini");
                File.WriteAllText(str1 + "engine.ini", str7.Replace(this.oldt2 + this.oldt2wg, "[TURBO_1]\nMAX_BOOST=" + this.maxBoost2.Text + " \nWASTEGATE=" + this.wastegate2.Text + " \n"));
            }
            if (this.oldt3 != null)
            {
                string str8 = File.ReadAllText(str1 + "engine.ini");
                File.WriteAllText(str1 + "engine.ini", str8.Replace(this.oldt3 + this.oldt3wg, "[TURBO_2]\nMAX_BOOST=" + this.maxBoost3.Text + " \nWASTEGATE=" + this.wastegate3.Text + " \n"));
            }
            if (this.oldt4 != null)
            {
                string str9 = File.ReadAllText(str1 + "engine.ini");
                File.WriteAllText(str1 + "engine.ini", str9.Replace(this.oldt4 + this.oldt4wg, "[TURBO_3]\nMAX_BOOST=" + this.maxBoost4.Text + " \nWASTEGATE=" + this.wastegate4.Text + " \n"));
            }
            string str10 = File.ReadAllText(str1 + "engine.ini");
            try
            {
                File.WriteAllText(str1 + "engine.ini", str10.Replace(this.olddamage, "TURBO_BOOST_THRESHOLD=" + this.engineDamage.Text));
            }
            catch
            {
            }
            this.changestate = true;
            this.reset();
            this.getTuningFiles();
            this.findItem(this.chooseFile, "car.ini");
            this.getDataForBasic();
            this.changestate = false;
        }

        private void openCarFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.assDir + GUI.GUI.carsn))
                return;
            Process.Start("explorer.exe", "\"" + this.assDir + GUI.GUI.carsn + "\"");
        }

        private void importTune_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK || !Directory.Exists(folderBrowserDialog.SelectedPath + "\\data"))
                return;
            string fileName = Path.GetFileName(Path.GetDirectoryName(folderBrowserDialog.SelectedPath + "\\"));
            Directory.Move(folderBrowserDialog.SelectedPath, this.assDir + GUI.GUI.carsn + "\\" + fileName);
            this.getTunes();
        }

        public GUI()
        {
            using (StreamReader streamReader = File.OpenText(GUI.GUI.root + "\\root.ini"))
                this.assDir = streamReader.ReadLine();
            this.InitializeComponent();
            this.carPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!Directory.Exists(this.assDir + GUI.GUI.carsfol))
                return;
            this.getCars(this.menu);
        }

        private void chooseFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.chooseFile.SelectedItem.ToString();
            this.currentTuneFile = str;
            using (StreamReader streamReader = File.OpenText(this.currentTune + "\\data\\" + str))
            {
                this.currentText = streamReader.ReadToEnd().Replace("\n", "\r\n");
                this.editFile.Text = this.currentText;
            }
        }

        private void editFile_TextChanged(object sender, EventArgs e)
        {
            if (this.currentText == this.editFile.Text || this.changestate || this.selectTune.Text == "")
                return;
            this.currentText = this.editFile.Text;
            File.WriteAllText(this.currentTune + "\\data\\" + this.chooseFile.SelectedItem.ToString(), this.currentText);
        }

        private void back_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(this.pictures[this.currentPic] + "\\preview.jpg"))
                    return;
                if (this.currentPic == 0)
                {
                    this.currentPic = this.pictures.Length - 1;
                    this.carPicture.Image = Image.FromFile(this.pictures[this.currentPic] + "\\preview.jpg");
                }
                else
                {
                    --this.currentPic;
                    this.carPicture.Image = Image.FromFile(this.pictures[this.currentPic] + "\\preview.jpg");
                }
            }
            catch
            {
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(this.pictures[this.currentPic] + "\\preview.jpg"))
                    return;
                if (this.currentPic == this.pictures.Length - 1)
                {
                    this.currentPic = 0;
                    this.carPicture.Image = Image.FromFile(this.pictures[this.currentPic] + "\\preview.jpg");
                }
                else
                {
                    ++this.currentPic;
                    this.carPicture.Image = Image.FromFile(this.pictures[this.currentPic] + "\\preview.jpg");
                }
            }
            catch
            {
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(GUI.GUI));
            this.menuStrip1 = new MenuStrip();
            this.selectAssFolder = new ToolStripMenuItem();
            this.tuningMode = new TabControl();
            this.tabPage1 = new TabPage();
            this.panel2 = new Panel();
            this.apply = new Button();
            this.brakesLabel = new Label();
            this.brakes = new TextBox();
            this.brakesLabel2 = new Label();
            this.finalDriveExplain = new Label();
            this.finalDrive = new TextBox();
            this.finalDriveLabel = new Label();
            this.finalDriveLabel2 = new Label();
            this.wheelDrive = new ComboBox();
            this.wheelDriveLabel = new Label();
            this.wheelDriveLabel2 = new Label();
            this.weightLabel = new Label();
            this.weight = new TextBox();
            this.weightLabel2 = new Label();
            this.panel3 = new Panel();
            this.soundswap = new ComboBox();
            this.soundSwap1 = new Label();
            this.swapenginesound = new Label();
            this.enginelist = new ComboBox();
            this.engineswaplabel = new Label();
            this.engineDamageExplain = new Label();
            this.engineswaplabel2 = new Label();
            this.engineDamage = new TextBox();
            this.engineDamageLabel = new Label();
            this.tabControl1 = new TabControl();
            this.tabPage3 = new TabPage();
            this.maxBoost1 = new TextBox();
            this.wastegate1 = new TextBox();
            this.maxBoostLabel1 = new Label();
            this.wastegateLabel1 = new Label();
            this.tabPage4 = new TabPage();
            this.maxBoost2 = new TextBox();
            this.wastegate2 = new TextBox();
            this.wastegateLabel2 = new Label();
            this.maxBoostLabel2 = new Label();
            this.tabPage5 = new TabPage();
            this.maxBoost3 = new TextBox();
            this.wastegate3 = new TextBox();
            this.wastegateLabel3 = new Label();
            this.maxBoostLabel3 = new Label();
            this.tabPage6 = new TabPage();
            this.maxBoost4 = new TextBox();
            this.wastegate4 = new TextBox();
            this.wastegateLabel4 = new Label();
            this.maxBoostLabel4 = new Label();
            this.turboLabel = new Label();
            this.powerLabel = new Label();
            this.increaseTorqueLabel = new Label();
            this.torquePercentage = new TextBox();
            this.tabPage2 = new TabPage();
            this.label2 = new Label();
            this.panel4 = new Panel();
            this.editFile = new TextBox();
            this.chooseFile = new ComboBox();
            this.chooseFileLabel = new Label();
            this.selectCarLabel = new Label();
            this.menu = new ComboBox();
            this.back = new Button();
            this.next = new Button();
            this.carPicture = new PictureBox();
            this.panel1 = new Panel();
            this.selectTune = new ComboBox();
            this.selectTuneLabel = new Label();
            this.label1 = new Label();
            this.newTuneName = new TextBox();
            this.createNewTune = new Button();
            this.deleteTune = new Button();
            this.openCarFolder = new Button();
            this.importTune = new Button();
            this.menuStrip1.SuspendLayout();
            this.tuningMode.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((ISupportInitialize)this.carPicture).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.menuStrip1.BackColor = SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new Size(24, 24);
            this.menuStrip1.Items.AddRange(new ToolStripItem[1]
            {
        (ToolStripItem) this.selectAssFolder
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1608, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            this.selectAssFolder.Name = "selectAssFolder";
            this.selectAssFolder.Size = new Size(240, 29);
            this.selectAssFolder.Text = "Select Assetto Corsa Folder";
            this.selectAssFolder.Click += new EventHandler(this.selectAssettoCorsaCarFolderToolStripMenuItem_Click);
            this.tuningMode.Controls.Add((Control)this.tabPage1);
            this.tuningMode.Controls.Add((Control)this.tabPage2);
            this.tuningMode.Dock = DockStyle.Fill;
            this.tuningMode.Location = new Point(0, 0);
            this.tuningMode.Name = "tuningMode";
            this.tuningMode.SelectedIndex = 0;
            this.tuningMode.Size = new Size(1080, 892);
            this.tuningMode.TabIndex = 1;
            this.tabPage1.BackColor = Color.Transparent;
            this.tabPage1.Controls.Add((Control)this.panel2);
            this.tabPage1.Controls.Add((Control)this.panel3);
            this.tabPage1.Location = new Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new Padding(3);
            this.tabPage1.Size = new Size(1072, 859);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Tuning";
            this.panel2.Controls.Add((Control)this.apply);
            this.panel2.Controls.Add((Control)this.brakesLabel);
            this.panel2.Controls.Add((Control)this.brakes);
            this.panel2.Controls.Add((Control)this.brakesLabel2);
            this.panel2.Controls.Add((Control)this.finalDriveExplain);
            this.panel2.Controls.Add((Control)this.finalDrive);
            this.panel2.Controls.Add((Control)this.finalDriveLabel);
            this.panel2.Controls.Add((Control)this.finalDriveLabel2);
            this.panel2.Controls.Add((Control)this.wheelDrive);
            this.panel2.Controls.Add((Control)this.wheelDriveLabel);
            this.panel2.Controls.Add((Control)this.wheelDriveLabel2);
            this.panel2.Controls.Add((Control)this.weightLabel);
            this.panel2.Controls.Add((Control)this.weight);
            this.panel2.Controls.Add((Control)this.weightLabel2);
            this.panel2.Location = new Point(547, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(519, 846);
            this.panel2.TabIndex = 5;
            this.apply.Location = new Point(20, 413);
            this.apply.Name = "apply";
            this.apply.Size = new Size(475, 46);
            this.apply.TabIndex = 24;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new EventHandler(this.apply_Click);
            this.brakesLabel.AutoSize = true;
            this.brakesLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.brakesLabel.Location = new Point(16, 311);
            this.brakesLabel.Name = "brakesLabel";
            this.brakesLabel.Size = new Size(70, 20);
            this.brakesLabel.TabIndex = 23;
            this.brakesLabel.Text = "Brakes:";
            this.brakes.Location = new Point(20, 354);
            this.brakes.Name = "brakes";
            this.brakes.Size = new Size(475, 26);
            this.brakes.TabIndex = 22;
            this.brakesLabel2.AutoSize = true;
            this.brakesLabel2.Location = new Point(16, 331);
            this.brakesLabel2.Name = "brakesLabel2";
            this.brakesLabel2.Size = new Size(239, 20);
            this.brakesLabel2.TabIndex = 21;
            this.brakesLabel2.Text = "Set maximum brake torque (nm):";
            this.finalDriveExplain.Location = new Point(16, 256);
            this.finalDriveExplain.Name = "finalDriveExplain";
            this.finalDriveExplain.Size = new Size(479, 48);
            this.finalDriveExplain.TabIndex = 11;
            this.finalDriveExplain.Text = "Higher is quicker acceleration, but lower top speed. Lower is higher topspeed, but slower acceleration.";
            this.finalDrive.Location = new Point(20, 225);
            this.finalDrive.Name = "finalDrive";
            this.finalDrive.Size = new Size(475, 26);
            this.finalDrive.TabIndex = 20;
            this.finalDriveLabel.AutoSize = true;
            this.finalDriveLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.finalDriveLabel.Location = new Point(16, 182);
            this.finalDriveLabel.Name = "finalDriveLabel";
            this.finalDriveLabel.Size = new Size(99, 20);
            this.finalDriveLabel.TabIndex = 19;
            this.finalDriveLabel.Text = "Final Drive:";
            this.finalDriveLabel.UseMnemonic = false;
            this.finalDriveLabel2.AutoSize = true;
            this.finalDriveLabel2.Location = new Point(16, 202);
            this.finalDriveLabel2.Name = "finalDriveLabel2";
            this.finalDriveLabel2.Size = new Size(116, 20);
            this.finalDriveLabel2.TabIndex = 18;
            this.finalDriveLabel2.Text = "Set Final Drive:";
            this.wheelDrive.FormattingEnabled = true;
            this.wheelDrive.Location = new Point(20, 143);
            this.wheelDrive.Name = "wheelDrive";
            this.wheelDrive.Size = new Size(475, 28);
            this.wheelDrive.TabIndex = 17;
            this.wheelDriveLabel.AutoSize = true;
            this.wheelDriveLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.wheelDriveLabel.Location = new Point(16, 100);
            this.wheelDriveLabel.Name = "wheelDriveLabel";
            this.wheelDriveLabel.Size = new Size(110, 20);
            this.wheelDriveLabel.TabIndex = 16;
            this.wheelDriveLabel.Text = "Wheel Drive:";
            this.wheelDriveLabel.UseMnemonic = false;
            this.wheelDriveLabel2.AutoSize = true;
            this.wheelDriveLabel2.Location = new Point(16, 120);
            this.wheelDriveLabel2.Name = "wheelDriveLabel2";
            this.wheelDriveLabel2.Size = new Size(120, 20);
            this.wheelDriveLabel2.TabIndex = 14;
            this.wheelDriveLabel2.Text = "Set wheel drive:";
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.weightLabel.Location = new Point(16, 15);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new Size(70, 20);
            this.weightLabel.TabIndex = 13;
            this.weightLabel.Text = "Weight:";
            this.weight.Location = new Point(20, 58);
            this.weight.Name = "weight";
            this.weight.Size = new Size(475, 26);
            this.weight.TabIndex = 12;
            this.weightLabel2.AutoSize = true;
            this.weightLabel2.Location = new Point(16, 35);
            this.weightLabel2.Name = "weightLabel2";
            this.weightLabel2.Size = new Size(145, 20);
            this.weightLabel2.TabIndex = 11;
            this.weightLabel2.Text = "Set car weight (kg):";
            this.panel3.Controls.Add((Control)this.soundswap);
            this.panel3.Controls.Add((Control)this.soundSwap1);
            this.panel3.Controls.Add((Control)this.swapenginesound);
            this.panel3.Controls.Add((Control)this.enginelist);
            this.panel3.Controls.Add((Control)this.engineswaplabel);
            this.panel3.Controls.Add((Control)this.engineDamageExplain);
            this.panel3.Controls.Add((Control)this.engineswaplabel2);
            this.panel3.Controls.Add((Control)this.engineDamage);
            this.panel3.Controls.Add((Control)this.engineDamageLabel);
            this.panel3.Controls.Add((Control)this.tabControl1);
            this.panel3.Controls.Add((Control)this.turboLabel);
            this.panel3.Controls.Add((Control)this.powerLabel);
            this.panel3.Controls.Add((Control)this.increaseTorqueLabel);
            this.panel3.Controls.Add((Control)this.torquePercentage);
            this.panel3.Location = new Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(519, 846);
            this.panel3.TabIndex = 4;
            this.soundswap.FormattingEnabled = true;
            this.soundswap.Location = new Point(22, 622);
            this.soundswap.Name = "soundswap";
            this.soundswap.Size = new Size(475, 28);
            this.soundswap.TabIndex = 30;
            this.soundSwap1.AutoSize = true;
            this.soundSwap1.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.soundSwap1.Location = new Point(18, 579);
            this.soundSwap1.Name = "soundSwap1";
            this.soundSwap1.Size = new Size(155, 20);
            this.soundSwap1.TabIndex = 29;
            this.soundSwap1.Text = "Sound Only Swap:";
            this.soundSwap1.UseMnemonic = false;
            this.swapenginesound.AutoSize = true;
            this.swapenginesound.Location = new Point(18, 599);
            this.swapenginesound.Name = "swapenginesound";
            this.swapenginesound.Size = new Size(373, 20);
            this.swapenginesound.TabIndex = 28;
            this.swapenginesound.Text = "Only swap engine sound(May not work for all mods):";
            this.enginelist.FormattingEnabled = true;
            this.enginelist.Location = new Point(22, 536);
            this.enginelist.Name = "enginelist";
            this.enginelist.Size = new Size(475, 28);
            this.enginelist.TabIndex = 27;
            this.engineswaplabel.AutoSize = true;
            this.engineswaplabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.engineswaplabel.Location = new Point(18, 453);
            this.engineswaplabel.Name = "engineswaplabel";
            this.engineswaplabel.Size = new Size(119, 20);
            this.engineswaplabel.TabIndex = 26;
            this.engineswaplabel.Text = "Engine Swap:";
            this.engineswaplabel.UseMnemonic = false;
            this.engineDamageExplain.Location = new Point(18, 367);
            this.engineDamageExplain.Name = "engineDamageExplain";
            this.engineDamageExplain.Size = new Size(479, 63);
            this.engineDamageExplain.TabIndex = 10;
            this.engineDamageExplain.Text = "This number should be higher than the combined max boost of all turbos. For example, a car with two turbos each with a max boost of 2, should have a damage threshold of at least 4.";
            this.engineswaplabel2.Location = new Point(18, 473);
            this.engineswaplabel2.Name = "engineswaplabel2";
            this.engineswaplabel2.Size = new Size(479, 72);
            this.engineswaplabel2.TabIndex = 25;
            this.engineswaplabel2.Text = "Select which car's engine you want to install, changes torque, rpm and sound. (If the car is slower than it should be after swapping the engine, turn off traction control):";
            this.engineDamage.Location = new Point(22, 332);
            this.engineDamage.Name = "engineDamage";
            this.engineDamage.Size = new Size(475, 26);
            this.engineDamage.TabIndex = 9;
            this.engineDamageLabel.AutoSize = true;
            this.engineDamageLabel.Location = new Point(18, 309);
            this.engineDamageLabel.Name = "engineDamageLabel";
            this.engineDamageLabel.Size = new Size(239, 20);
            this.engineDamageLabel.TabIndex = 8;
            this.engineDamageLabel.Text = "Turbo Boost Damage Threshold:";
            this.tabControl1.Controls.Add((Control)this.tabPage3);
            this.tabControl1.Controls.Add((Control)this.tabPage4);
            this.tabControl1.Controls.Add((Control)this.tabPage5);
            this.tabControl1.Controls.Add((Control)this.tabPage6);
            this.tabControl1.Location = new Point(22, 135);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(475, 167);
            this.tabControl1.TabIndex = 8;
            this.tabPage3.BackColor = Color.Transparent;
            this.tabPage3.Controls.Add((Control)this.maxBoost1);
            this.tabPage3.Controls.Add((Control)this.wastegate1);
            this.tabPage3.Controls.Add((Control)this.maxBoostLabel1);
            this.tabPage3.Controls.Add((Control)this.wastegateLabel1);
            this.tabPage3.Location = new Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new Padding(3);
            this.tabPage3.Size = new Size(467, 134);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Turbo 1";
            this.maxBoost1.Location = new Point(6, 32);
            this.maxBoost1.Name = "maxBoost1";
            this.maxBoost1.Size = new Size(455, 26);
            this.maxBoost1.TabIndex = 5;
            this.wastegate1.Location = new Point(6, 81);
            this.wastegate1.Name = "wastegate1";
            this.wastegate1.Size = new Size(455, 26);
            this.wastegate1.TabIndex = 7;
            this.maxBoostLabel1.AutoSize = true;
            this.maxBoostLabel1.Location = new Point(2, 12);
            this.maxBoostLabel1.Name = "maxBoostLabel1";
            this.maxBoostLabel1.Size = new Size(88, 20);
            this.maxBoostLabel1.TabIndex = 3;
            this.maxBoostLabel1.Text = "Max Boost:";
            this.wastegateLabel1.AutoSize = true;
            this.wastegateLabel1.Location = new Point(2, 61);
            this.wastegateLabel1.Name = "wastegateLabel1";
            this.wastegateLabel1.Size = new Size(91, 20);
            this.wastegateLabel1.TabIndex = 6;
            this.wastegateLabel1.Text = "Wastegate:";
            this.tabPage4.BackColor = Color.Transparent;
            this.tabPage4.Controls.Add((Control)this.maxBoost2);
            this.tabPage4.Controls.Add((Control)this.wastegate2);
            this.tabPage4.Controls.Add((Control)this.wastegateLabel2);
            this.tabPage4.Controls.Add((Control)this.maxBoostLabel2);
            this.tabPage4.Location = new Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new Padding(3);
            this.tabPage4.Size = new Size(467, 134);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Turbo 2";
            this.maxBoost2.Location = new Point(6, 32);
            this.maxBoost2.Name = "maxBoost2";
            this.maxBoost2.Size = new Size(455, 26);
            this.maxBoost2.TabIndex = 9;
            this.wastegate2.Location = new Point(6, 81);
            this.wastegate2.Name = "wastegate2";
            this.wastegate2.Size = new Size(455, 26);
            this.wastegate2.TabIndex = 11;
            this.wastegateLabel2.AutoSize = true;
            this.wastegateLabel2.Location = new Point(2, 61);
            this.wastegateLabel2.Name = "wastegateLabel2";
            this.wastegateLabel2.Size = new Size(91, 20);
            this.wastegateLabel2.TabIndex = 10;
            this.wastegateLabel2.Text = "Wastegate:";
            this.maxBoostLabel2.AutoSize = true;
            this.maxBoostLabel2.Location = new Point(2, 12);
            this.maxBoostLabel2.Name = "maxBoostLabel2";
            this.maxBoostLabel2.Size = new Size(88, 20);
            this.maxBoostLabel2.TabIndex = 8;
            this.maxBoostLabel2.Text = "Max Boost:";
            this.tabPage5.BackColor = Color.Transparent;
            this.tabPage5.Controls.Add((Control)this.maxBoost3);
            this.tabPage5.Controls.Add((Control)this.wastegate3);
            this.tabPage5.Controls.Add((Control)this.wastegateLabel3);
            this.tabPage5.Controls.Add((Control)this.maxBoostLabel3);
            this.tabPage5.Location = new Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new Padding(3);
            this.tabPage5.Size = new Size(467, 134);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Turbo 3";
            this.maxBoost3.Location = new Point(6, 32);
            this.maxBoost3.Name = "maxBoost3";
            this.maxBoost3.Size = new Size(455, 26);
            this.maxBoost3.TabIndex = 13;
            this.wastegate3.Location = new Point(6, 81);
            this.wastegate3.Name = "wastegate3";
            this.wastegate3.Size = new Size(455, 26);
            this.wastegate3.TabIndex = 15;
            this.wastegateLabel3.AutoSize = true;
            this.wastegateLabel3.Location = new Point(2, 61);
            this.wastegateLabel3.Name = "wastegateLabel3";
            this.wastegateLabel3.Size = new Size(91, 20);
            this.wastegateLabel3.TabIndex = 14;
            this.wastegateLabel3.Text = "Wastegate:";
            this.maxBoostLabel3.AutoSize = true;
            this.maxBoostLabel3.Location = new Point(2, 12);
            this.maxBoostLabel3.Name = "maxBoostLabel3";
            this.maxBoostLabel3.Size = new Size(88, 20);
            this.maxBoostLabel3.TabIndex = 12;
            this.maxBoostLabel3.Text = "Max Boost:";
            this.tabPage6.BackColor = Color.Transparent;
            this.tabPage6.Controls.Add((Control)this.maxBoost4);
            this.tabPage6.Controls.Add((Control)this.wastegate4);
            this.tabPage6.Controls.Add((Control)this.wastegateLabel4);
            this.tabPage6.Controls.Add((Control)this.maxBoostLabel4);
            this.tabPage6.Location = new Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new Padding(3);
            this.tabPage6.Size = new Size(467, 134);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Turbo 4";
            this.maxBoost4.Location = new Point(6, 32);
            this.maxBoost4.Name = "maxBoost4";
            this.maxBoost4.Size = new Size(455, 26);
            this.maxBoost4.TabIndex = 13;
            this.wastegate4.Location = new Point(6, 81);
            this.wastegate4.Name = "wastegate4";
            this.wastegate4.Size = new Size(455, 26);
            this.wastegate4.TabIndex = 15;
            this.wastegateLabel4.AutoSize = true;
            this.wastegateLabel4.Location = new Point(2, 61);
            this.wastegateLabel4.Name = "wastegateLabel4";
            this.wastegateLabel4.Size = new Size(91, 20);
            this.wastegateLabel4.TabIndex = 14;
            this.wastegateLabel4.Text = "Wastegate:";
            this.maxBoostLabel4.AutoSize = true;
            this.maxBoostLabel4.Location = new Point(2, 12);
            this.maxBoostLabel4.Name = "maxBoostLabel4";
            this.maxBoostLabel4.Size = new Size(88, 20);
            this.maxBoostLabel4.TabIndex = 12;
            this.maxBoostLabel4.Text = "Max Boost:";
            this.turboLabel.AutoSize = true;
            this.turboLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.turboLabel.Location = new Point(18, 112);
            this.turboLabel.Name = "turboLabel";
            this.turboLabel.Size = new Size(60, 20);
            this.turboLabel.TabIndex = 4;
            this.turboLabel.Text = "Turbo:";
            this.powerLabel.AutoSize = true;
            this.powerLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.powerLabel.Location = new Point(18, 15);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new Size(63, 20);
            this.powerLabel.TabIndex = 2;
            this.powerLabel.Text = "Power:";
            this.increaseTorqueLabel.AutoSize = true;
            this.increaseTorqueLabel.Location = new Point(18, 35);
            this.increaseTorqueLabel.Name = "increaseTorqueLabel";
            this.increaseTorqueLabel.Size = new Size(234, 20);
            this.increaseTorqueLabel.TabIndex = 0;
            this.increaseTorqueLabel.Text = "Increase Torque by percentage:";
            this.torquePercentage.Location = new Point(22, 58);
            this.torquePercentage.Name = "torquePercentage";
            this.torquePercentage.Size = new Size(475, 26);
            this.torquePercentage.TabIndex = 1;
            this.tabPage2.BackColor = Color.Transparent;
            this.tabPage2.Controls.Add((Control)this.label2);
            this.tabPage2.Controls.Add((Control)this.panel4);
            this.tabPage2.Controls.Add((Control)this.chooseFile);
            this.tabPage2.Controls.Add((Control)this.chooseFileLabel);
            this.tabPage2.Location = new Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(1072, 859);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced Tuning";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(972, 34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(92, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "(autosaves)";
            this.panel4.Controls.Add((Control)this.editFile);
            this.panel4.Location = new Point(6, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(1058, 794);
            this.panel4.TabIndex = 20;
            this.editFile.AcceptsReturn = true;
            this.editFile.AcceptsTab = true;
            this.editFile.AllowDrop = true;
            this.editFile.Dock = DockStyle.Fill;
            this.editFile.Font = new Font("Courier New", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.editFile.Location = new Point(0, 0);
            this.editFile.Multiline = true;
            this.editFile.Name = "editFile";
            this.editFile.ScrollBars = ScrollBars.Both;
            this.editFile.Size = new Size(1058, 794);
            this.editFile.TabIndex = 0;
            this.editFile.TextChanged += new EventHandler(this.editFile_TextChanged);
            this.chooseFile.FormattingEnabled = true;
            this.chooseFile.Location = new Point(6, 26);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new Size(475, 28);
            this.chooseFile.TabIndex = 19;
            this.chooseFile.SelectedIndexChanged += new EventHandler(this.chooseFile_SelectedIndexChanged);
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.chooseFileLabel.Location = new Point(6, 3);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new Size(160, 20);
            this.chooseFileLabel.TabIndex = 18;
            this.chooseFileLabel.Text = "Choose file to edit:";
            this.chooseFileLabel.UseMnemonic = false;
            this.selectCarLabel.AutoSize = true;
            this.selectCarLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.selectCarLabel.Location = new Point(12, 42);
            this.selectCarLabel.Name = "selectCarLabel";
            this.selectCarLabel.Size = new Size(87, 20);
            this.selectCarLabel.TabIndex = 2;
            this.selectCarLabel.Text = "Select Car:";
            this.menu.FormattingEnabled = true;
            this.menu.Location = new Point(12, 65);
            this.menu.Name = "menu";
            this.menu.Size = new Size(509, 28);
            this.menu.TabIndex = 3;
            this.menu.SelectedIndexChanged += new EventHandler(this.carSelect_SelectedIndexChanged);
            this.back.Location = new Point(12, 211);
            this.back.Name = "back";
            this.back.Size = new Size(28, 45);
            this.back.TabIndex = 4;
            this.back.Text = "<";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new EventHandler(this.back_Click);
            this.next.FlatAppearance.BorderColor = Color.White;
            this.next.Location = new Point(493, 211);
            this.next.Name = "next";
            this.next.Size = new Size(28, 45);
            this.next.TabIndex = 5;
            this.next.Text = ">";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new EventHandler(this.next_Click);
            this.carPicture.Location = new Point(46, 108);
            this.carPicture.Name = "carPicture";
            this.carPicture.Size = new Size(441, 262);
            this.carPicture.TabIndex = 6;
            this.carPicture.TabStop = false;
            this.panel1.Controls.Add((Control)this.tuningMode);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new Point(528, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1080, 892);
            this.panel1.TabIndex = 7;
            this.selectTune.FormattingEnabled = true;
            this.selectTune.Location = new Point(12, 530);
            this.selectTune.Name = "selectTune";
            this.selectTune.Size = new Size(509, 28);
            this.selectTune.TabIndex = 9;
            this.selectTune.SelectedIndexChanged += new EventHandler(this.selectTune_SelectedIndexChanged);
            this.selectTuneLabel.AutoSize = true;
            this.selectTuneLabel.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.selectTuneLabel.Location = new Point(12, 507);
            this.selectTuneLabel.Name = "selectTuneLabel";
            this.selectTuneLabel.Size = new Size(98, 20);
            this.selectTuneLabel.TabIndex = 8;
            this.selectTuneLabel.Text = "Select Tune:";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 388);
            this.label1.Name = "label1";
            this.label1.Size = new Size(130, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "New Tune Name:";
            this.newTuneName.Location = new Point(12, 411);
            this.newTuneName.Name = "newTuneName";
            this.newTuneName.Size = new Size(509, 26);
            this.newTuneName.TabIndex = 11;
            this.createNewTune.Location = new Point(12, 443);
            this.createNewTune.Name = "createNewTune";
            this.createNewTune.Size = new Size(509, 49);
            this.createNewTune.TabIndex = 12;
            this.createNewTune.Text = "Create New Tune";
            this.createNewTune.UseVisualStyleBackColor = true;
            this.createNewTune.Click += new EventHandler(this.createNewTune_Click);
            this.deleteTune.Location = new Point(12, 872);
            this.deleteTune.Name = "deleteTune";
            this.deleteTune.Size = new Size(509, 49);
            this.deleteTune.TabIndex = 14;
            this.deleteTune.Text = "Delete Tune";
            this.deleteTune.UseVisualStyleBackColor = true;
            this.deleteTune.Click += new EventHandler(this.deleteTune_Click);
            this.openCarFolder.Location = new Point(12, 564);
            this.openCarFolder.Name = "openCarFolder";
            this.openCarFolder.Size = new Size(250, 49);
            this.openCarFolder.TabIndex = 17;
            this.openCarFolder.Text = "Open Cars Folder";
            this.openCarFolder.UseVisualStyleBackColor = true;
            this.openCarFolder.Click += new EventHandler(this.openCarFolder_Click);
            this.importTune.Location = new Point(271, 564);
            this.importTune.Name = "importTune";
            this.importTune.Size = new Size(250, 49);
            this.importTune.TabIndex = 18;
            this.importTune.Text = "Import Tune";
            this.importTune.UseVisualStyleBackColor = true;
            this.importTune.Click += new EventHandler(this.importTune_Click);
            this.AutoScaleDimensions = new SizeF(9f, 20f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1608, 925);
            this.Controls.Add((Control)this.importTune);
            this.Controls.Add((Control)this.openCarFolder);
            this.Controls.Add((Control)this.deleteTune);
            this.Controls.Add((Control)this.createNewTune);
            this.Controls.Add((Control)this.newTuneName);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.selectTune);
            this.Controls.Add((Control)this.selectTuneLabel);
            this.Controls.Add((Control)this.panel1);
            this.Controls.Add((Control)this.carPicture);
            this.Controls.Add((Control)this.next);
            this.Controls.Add((Control)this.back);
            this.Controls.Add((Control)this.menu);
            this.Controls.Add((Control)this.selectCarLabel);
            this.Controls.Add((Control)this.menuStrip1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MainMenuStrip = this.menuStrip1;
            this.Name = nameof(GUI);
            this.Text = "Assetto Corsa Car Tuner 1.50";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tuningMode.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((ISupportInitialize)this.carPicture).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
}
