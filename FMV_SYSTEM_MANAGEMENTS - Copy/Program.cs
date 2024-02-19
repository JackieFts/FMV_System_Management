using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMV_SYSTEM_MANAGEMENTS.Views;

namespace FMV_SYSTEM_MANAGEMENTS
{
    internal static class Program
    {
        public static FMV_SYSTEM_MANAGEMENTS.Logger log = new FMV_SYSTEM_MANAGEMENTS.Logger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime offset = new DateTime(2024, 04, 01, 00, 00, 00);
            if (DateTime.Now < offset)
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setadd.dat"))
                {
                    string a = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setadd.dat");
                    if (a.Contains("967+af6s"))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new fMain());
                    }
                }
            }
            else
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "setadd.dat");
            }
        }
    }
}
