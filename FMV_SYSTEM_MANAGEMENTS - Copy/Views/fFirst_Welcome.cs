using DevExpress.XtraSplashScreen;
using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFirst_Welcome : SplashScreen
    {
        public fFirst_Welcome()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            timer = new System.Timers.Timer(100.0);
            timer.Start();
            timer.Elapsed += this.Start;
        }

        System.Timers.Timer timer = new System.Timers.Timer();
        int startPoint = 0;
        string Slogan = string.Empty;
        //SLOGAN _slogan;

        private void fWelcome_Load(object sender, EventArgs e)
        {
            //_slogan = new SLOGAN();
            Program.log.LogMsg(Logger.LogLevel.INFO, "******************************Start program******************************");
            //await tryToConnectDB();
        }

        private async void Start(object sender, ElapsedEventArgs e)
        {
            await runProgress();
        }
        //private async Task tryToConnectDB()
        //{
        //    await Task.Delay(100);
        //    Program.log.LogMsg(Logger.LogLevel.INFO, "Trying to connect DB");
        //    //if (MyFunc.OpenConnect())
        //    //    MyFunc.CloseConnect();

        //    Slogan = await _slogan.getSlogen();
        //}

        private async Task runProgress()
        {
            await Task.Delay(1);
            startPoint += 2;
            progressBarControl1.Position = startPoint;
            if (progressBarControl1.Position >= 100)
            {
                progressBarControl1.Position = 0;
                timer.Stop();
                Application.Exit();
                //Program.log.LogMsg(Logger.LogLevel.INFO, "Trying to load Login Form");
                //fLogin login = new fLogin();
                //login._Slogan = Slogan;
                this.Hide();
                //login.ShowDialog();
            }
        }
    }
}