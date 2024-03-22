using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMV_SYSTEM_MANAGEMENTS.Test;
using FMV_SYSTEM_MANAGEMENTS.Views;
using FMV_SYSTEM_MANAGEMENTS.Views.Monthly;

namespace FMV_SYSTEM_MANAGEMENTS
{
    internal static class Program
    {
        public static FMV_SYSTEM_MANAGEMENTS.Logger log = new FMV_SYSTEM_MANAGEMENTS.Logger();
        public static string _userLogin = "";
        public static DateTime offset = new DateTime(2024, 05, 01, 00, 00, 00);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            if (DateTime.Now < offset)
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setadd.dat"))
                {
                    string a = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setadd.dat");
                    if (a.Contains("967+af6s"))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new fFirst_Login());
                        //Application.Run(new fMonthly());
                        //Application.Run(new fTest2());
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
