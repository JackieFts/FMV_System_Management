using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public fMain()
        {
            InitializeComponent();
        }

        SYS_FUNC _func;

        bool checkmove = false;

        private async void fMain_Load(object sender, EventArgs e)
        {
            //await this.loadLeftMenu();
            await loadChild();

        }

        public async Task loadLeftMenu()
        {
            _func = new SYS_FUNC();
            await Task.Delay(10);
            int i = 0;
            var _lsParent = await _func.getParent();
            foreach (var _pr in _lsParent)
            {
                AccordionControlElement group = new AccordionControlElement();
                group.Text = _pr.DESCRIPTION;
                group.Tag = _pr.FUNC_CODE;
                group.Name = _pr.FUNC_CODE;
                group.ImageOptions.Image = imageList1.Images[i];
                i++;
                if (i >= imageList1.Images.Count)
                    i = 0;

                var _lsChild = await _func.getChild(_pr.FUNC_CODE);
                foreach (var _ch in _lsChild)
                {
                    AccordionControlElement item = new AccordionControlElement(ElementStyle.Item);
                    item.Text = _ch.DESCRIPTION;
                    item.Tag = _ch.FUNC_CODE;
                    item.Name = _ch.FUNC_CODE;
                    item.Appearance.Default.Font = new Font("Tahoma", 10);
                    item.ImageOptions.Image = imageList2.Images[0];
                    group.Elements.Add(item);
                }
                NavMain.Elements.Add(group);
            }

            //NavMain.ExpandAll();



        }

        public async Task loadChild()
        {
            fFirst_Dashboard frm = new fFirst_Dashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            await frm.loadCus();
            await frm.loadStaff();
            fluentDesignFormContainer1.Controls.Add(frm);
            frm.Show();
        }

        private async void NavMain_ElementClick(object sender, ElementClickEventArgs e)
        {
            AccordionControlElement element = e.Element;
            if (element.Style == ElementStyle.Item)
            {
                string func_code = e.Element.Tag as string;

                Form embeddedForm = new Form();
                if (fluentDesignFormContainer1.Controls.Count > 0)
                {
                    embeddedForm = (Form)fluentDesignFormContainer1.Controls[0];
                }
                Program.log.LogMsg(Logger.LogLevel.INFO, "Navbar Click : [{0}]", func_code);
                switch (func_code)
                {
                    case "STAFF":
                        embeddedForm.Close();
                        fCom_Staff frm = new fCom_Staff();
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.WindowState = FormWindowState.Maximized;
                        await frm.loadStaff();
                        frm.ShowHideControl(true);
                        frm.groupControl1.Visible = false;
                        fluentDesignFormContainer1.Controls.Add(frm);
                        frm.Show();
                        frm.Parent = fluentDesignFormContainer1;
                        break;
                    case "CUSTOMER":
                        embeddedForm.Close();
                        fCom_Customer frm2 = new fCom_Customer();
                        frm2.TopLevel = false;
                        frm2.FormBorderStyle = FormBorderStyle.None;
                        frm2.WindowState = FormWindowState.Maximized;
                        await frm2.loadCus();
                        frm2.ShowHideControl(true);
                        frm2.groupControl1.Visible = false;
                        fluentDesignFormContainer1.Controls.Add(frm2);
                        frm2.Show();
                        frm2.Parent = fluentDesignFormContainer1;
                        break;
                    case "JIG":
                        embeddedForm.Close();
                        fInfo_Jigs frm3 = new fInfo_Jigs();
                        frm3.TopLevel = false;
                        frm3.FormBorderStyle = FormBorderStyle.None;
                        frm3.WindowState = FormWindowState.Maximized;
                        await frm3.loadJig();
                        await frm3.loadCus();
                        await frm3.loadStaff();
                        fluentDesignFormContainer1.Controls.Add(frm3);
                        frm3.Show();
                        frm3.Parent = fluentDesignFormContainer1;
                        break;
                    case "PART":
                        embeddedForm.Close();
                        fInfo_Parts frm6 = new fInfo_Parts();
                        frm6.TopLevel = false;
                        frm6.FormBorderStyle = FormBorderStyle.None;
                        frm6.WindowState = FormWindowState.Maximized;
                        await frm6.loadPart();
                        await frm6.loadCus();
                        await frm6.loadStaff();
                        fluentDesignFormContainer1.Controls.Add(frm6);
                        frm6.Show();
                        frm6.Parent = fluentDesignFormContainer1;
                        break;
                    case "PARTOUT":
                        embeddedForm.Close();
                        fHis_PartOut frm4 = new fHis_PartOut();
                        frm4.TopLevel = false;
                        frm4.FormBorderStyle = FormBorderStyle.None;
                        frm4.WindowState = FormWindowState.Maximized;
                        await frm4.loadView();
                        await frm4.loadCus();
                        frm4.dtFrom.Value = MyFunc.getFirstDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                        fluentDesignFormContainer1.Controls.Add(frm4);
                        frm4.Show();
                        frm4.checkLoaded = true;
                        frm4.Parent = fluentDesignFormContainer1;
                        break;
                    case "PARTIN":
                        embeddedForm.Close();
                        fHis_PartIn frm5 = new fHis_PartIn();
                        frm5.TopLevel = false;
                        frm5.FormBorderStyle = FormBorderStyle.None;
                        frm5.WindowState = FormWindowState.Maximized;
                        await frm5.loadView();
                        frm5.dtFrom.Value = MyFunc.getFirstDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                        fluentDesignFormContainer1.Controls.Add(frm5);
                        frm5.Show();
                        frm5.checkLoaded = true;
                        frm5.Parent = fluentDesignFormContainer1;
                        break;
                    default:
                        MessageBox.Show("You dont have permission to access this function");
                        break;
                }
            }
        }

        private void NavMain_StateChanged(object sender, EventArgs e)
        {
            if (fluentDesignFormContainer1.Controls.Count > 0)
            {
                Form embeddedForm = (Form)fluentDesignFormContainer1.Controls[0];
                embeddedForm.WindowState = FormWindowState.Minimized;
                Task.Delay(100).Wait();
                embeddedForm.WindowState = FormWindowState.Maximized;
            }
        }

        private void fMain_SizeChanged(object sender, EventArgs e)
        {
            if (fluentDesignFormContainer1.Controls.Count > 0)
            {
                Form embeddedForm = (Form)fluentDesignFormContainer1.Controls[0];
                embeddedForm.WindowState = FormWindowState.Minimized;
                Task.Delay(100).Wait();
                embeddedForm.WindowState = FormWindowState.Maximized;
            }
        }


        private void NavMain_MouseMove(object sender, MouseEventArgs e)
        {
            //Task.Delay(100).Wait();
            checkmove = true;
            NavMain.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
        }

        private async void NavMain_MouseLeave(object sender, EventArgs e)
        {
            checkmove = false;
            await waitSlide(5000);
        }

        public async Task waitSlide(int t)
        {
            await Task.Delay(t);
            Task.WaitAll();
            if (checkmove) { return; }
            NavMain.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form embeddedForm = new Form();
            if (fluentDesignFormContainer1.Controls.Count > 0)
            {
                embeddedForm = (Form)fluentDesignFormContainer1.Controls[0];
                embeddedForm.Close();
            }

            fFirst_Dashboard frm = new fFirst_Dashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            fluentDesignFormContainer1.Controls.Add(frm);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.Parent = fluentDesignFormContainer1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string msg = "FUJI MACHINE VIETNAM CO.,LTD \r\n        Product by FMV - Tai";
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.log.LogMsg(Logger.LogLevel.FATAL, "Application exit with User [{0}]", Program._userLogin);
            Application.Exit();
        }
    }
}
