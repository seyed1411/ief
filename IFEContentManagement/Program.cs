using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace IFEContentManagement
{
    
    static class Program
    {
        
        public static ProjectFolder currentProject;
        public static string latestPath;
        public static bool StatusSaved = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            latestPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Form1 firstWin = new Form1();
            firstWin.Show();
            Application.Run();
            //Application.Run(new Form1());            
        }
    }
}
