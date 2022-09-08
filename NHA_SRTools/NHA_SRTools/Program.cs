using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace NHA_SRTools{
    internal static class Program{

public static void ScrollToEnd(this RichTextBox T) { 
T.SelectionStart= T.TextLength;
T.ScrollToCaret();
}


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args){
            Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (!File.Exists(Environment.CurrentDirectory + "\\NHA_SrTools"))
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\NHA_SrTools");
            Environment.CurrentDirectory += "\\NHA_SrTools";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Extract The Assets From The External Folder
            Assembly.GetExecutingAssembly().LoadAll("External\\");
            Application.Run(new MainWindow(Args));
        }
    }
}
