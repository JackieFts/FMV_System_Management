using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Logger log = new Logger();
        public static System.Timers.Timer timer = null;
        public static DateTime offset = new DateTime(2024, 04, 01, 00, 00, 00);
        public static TimeSpan dis;
        public static string remainTime = string.Empty;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            timer = new System.Timers.Timer(1000.0);
            timer.Start();
            timer.Elapsed += Start;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Start(object sender, ElapsedEventArgs e)
        {
            dis = offset - DateTime.Now;
            remainTime = string.Format($"Số Ngày Dùng Thử còn lại : {(int)dis.TotalDays} Days {dis.Hours}:{dis.Minutes}:{dis.Seconds}");
        }
    }
}
