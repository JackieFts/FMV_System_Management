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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFirst_Welcome : SplashScreen
    {
        public fFirst_Welcome()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }

        System.Timers.Timer timer = null;
        int startPoint = 0;
        //string Slogan = string.Empty;
        //SLOGAN _slogan;

        private void fWelcome_Load(object sender, EventArgs e)
        {
            //_slogan = new SLOGAN();
            Program.log.LogMsg(Logger.LogLevel.INFO, "*********************** Start Program **************************");
            //await tryToConnectDB();

            timer = new System.Timers.Timer(50.0);
            timer.Start();
            timer.Elapsed += this.Start;
        }

        private void Start(object sender, ElapsedEventArgs e)
        {
            runProgress();
        }

        private void runProgress()
        {
            startPoint += 2;
            progressBarControl1.Position = startPoint;
            if (progressBarControl1.Position >= 100)
            {
                progressBarControl1.Position = 0;
                timer.Stop();
                fFirst_Login login = (fFirst_Login)Application.OpenForms["fFirst_Login"];
                login.Show();
                this.Close();
            }
        }

        private void fFirst_Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
        //private async Task tryToConnectDB()
        //{
        //    await Task.Delay(100);
        //    Program.log.LogMsg(Logger.LogLevel.INFO, "Trying to connect DB");
        //    //if (MyFunc.OpenConnect())
        //    //    MyFunc.CloseConnect();

        //    Slogan = await _slogan.getSlogen();
        //}
    }
}