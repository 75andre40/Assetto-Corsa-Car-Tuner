using Assetto_Corsa_Car_Tuner;
using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lib.Classes
{

    internal static class clsUtils
    {

        public static string ACFolder = "";


        public static void ChangeACFolderPath()
        {
            FolderBrowserDialog ofdACFolderPath = new FolderBrowserDialog();
            ofdACFolderPath.SelectedPath = @"C:\AssettoCorsa";
            ofdACFolderPath.ShowDialog();

            if (File.Exists(ofdACFolderPath.SelectedPath + "\\acs.exe")) { ACFolder = ofdACFolderPath.SelectedPath; }

        }

        public static void CheckUpdates()
        {
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/75andre40/Assetto-Corsa-Car-Tuner/main/VersionChecker.xml",System.Reflection.Assembly.GetExecutingAssembly());
        }

    }
}
