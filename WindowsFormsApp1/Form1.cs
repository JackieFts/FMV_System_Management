using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;

            Icon icon = new Icon("jackie.ico");

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = icon;
            notifyIcon.Text = "My Application";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Show", (sender, e) => ShowForm());
            contextMenu.MenuItems.Add("Exit", (sender, e) => ExitApplication());

            notifyIcon.ContextMenu = contextMenu;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void ExitApplication()
        {
            notifyIcon.Visible = false;
            System.Windows.Forms.Application.Exit();
        }

        private void ShowForm()
        {
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        System.Timers.Timer timer = new System.Timers.Timer();
        private NotifyIcon notifyIcon;

        int run = 0;
        //private MyClass myObject;

        public class MyEventArgs : EventArgs
        {
            public string MyData { get; }

            public MyEventArgs(string data)
            {
                MyData = data;
            }
        }

        public class MyClass
        {
            public event EventHandler<MyEventArgs> MyEvent;

            protected virtual void OnMyEvent(string data)
            {
                MyEvent?.Invoke(this, new MyEventArgs(data));
            }

            public void PerformAction(string data)
            {
                OnMyEvent(data);
            }
        }

        private void MyEventHandler(object sender, MyEventArgs e)
        {
            //BeginInvoke(new Action(delegate ()
            //{
            //    System.Windows.Forms.Label label = this.label1;
            //    label.Text += e.MyData;
            //}));
            Random random = new Random();

            int red = random.Next(256);
            int green = random.Next(256);
            int blue = random.Next(256);
            Color randomColor = Color.FromArgb(red, green, blue);
            label1.ForeColor = Color.FromArgb(red, green, blue);

            DateTime offset = new DateTime(2024, 04, 01, 00, 00, 00);
            TimeSpan dis = offset - DateTime.Now;
            string remainTime = string.Format($"Remaining trial days : {(int)dis.TotalDays} Days {dis.Hours}:{dis.Minutes}:{dis.Seconds}");

            label1.Text = remainTime;
        }

        private void OnRun(object sender, ElapsedEventArgs e)
        {
            //run++;
            //myObject.PerformAction(Program.remainTime);
        }

        //============================================================================================================================

        AsyncCallback updateCallback;
        private void UpdateDateTimeLabelInRealTime(IAsyncResult ar)
        {
            Thread.Sleep(1000);
            if (updateCallback != null)
            {
                BeginInvoke(new UpdateDateTimeLabelDelegate(UpdateDateTimeLabel), DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                updateCallback.BeginInvoke(ar, new AsyncCallback(UpdateDateTimeLabelInRealTime), null);
            }

        }

        private delegate void UpdateDateTimeLabelDelegate(string text);
        private void UpdateDateTimeLabel(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.label1.BeginInvoke(new UpdateDateTimeLabelDelegate(UpdateDateTimeLabel), new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }






        //============================================================================================================================


        private void Form1_Load(object sender, EventArgs e)
        {
            //timer = new System.Timers.Timer(3000.0);
            //timer.Start();
            //timer.Elapsed += this.Start;
            //label1.Text = Program.remainTime;

            //myObject = new MyClass();
            //myObject.MyEvent += MyEventHandler;
            //System.Timers.Timer timer = new System.Timers.Timer(1000.0);
            //timer.Start();
            //timer.Elapsed += this.OnRun;

            updateCallback = new AsyncCallback(UpdateDateTimeLabelInRealTime);
            updateCallback.BeginInvoke(null, null, null);
            BeginInvoke(new UpdateDateTimeLabelDelegate(UpdateDateTimeLabel), DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }

        private void Start(object sender, ElapsedEventArgs e)
        {
            run++;
            DateTime offset = new DateTime(2024, 04, 01, 00, 00, 00);
            DateTime timeNow = DateTime.Now;
            TimeSpan dis = offset - timeNow;
            Program.log.LogMsg(Logger.LogLevel.INFO, "Number of up : [{0} {1}:{2}:{3}]", (int)dis.TotalDays, dis.Hours, dis.Minutes, dis.Seconds);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
