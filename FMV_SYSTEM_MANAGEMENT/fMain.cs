using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENT
{
    public partial class fMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public fMain()
        {
            InitializeComponent();
        }

        SYS_FUNC _func;

        private async void fMain_Load(object sender, EventArgs e)
        {
            await this.loadLeftMenu();
        }

        private async Task loadLeftMenu()
        {
            _func = new SYS_FUNC();
            await Task.Delay(10);
            int i = 0;
            var _lsParent = await _func.getParent();
            foreach (var _pr in _lsParent)
            {
                AccordionControlElement group = new AccordionControlElement();
                group.Text = _pr.Description;
                group.Tag = _pr.FuncCode;
                group.Name = _pr.FuncCode;
                group.ImageOptions.Image = imageList1.Images[i];
                i++;
                if (i >= imageList1.Images.Count)
                    i = 0;

                var _lsChild = await _func.getChild(_pr.FuncCode);
                foreach (var _ch in _lsChild)
                {
                    AccordionControlElement item = new AccordionControlElement(ElementStyle.Item);
                    item.Text = _ch.Description;
                    item.Tag = _ch.FuncCode;
                    item.Name = _ch.FuncCode;
                    item.Appearance.Default.Font = new Font("Tahoma", 10);
                    item.ImageOptions.Image = imageList2.Images[0];
                    group.Elements.Add(item);
                }
                NavMain.Elements.Add(group);
            }

            NavMain.ExpandAll();

            fDashboard frm = new fDashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            fluentDesignFormContainer1.Controls.Add(frm);
            frm.Show();

        }

        private void NavMain_ElementClick(object sender, ElementClickEventArgs e)
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

                switch (func_code)
                {
                    case "STAFF":
                        embeddedForm.Close();
                        fStaff frm = new fStaff();
                        frm.TopLevel = false;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.groupControl1.Visible = false;
                        fluentDesignFormContainer1.Controls.Add(frm);
                        frm.Show();
                        frm.Parent = fluentDesignFormContainer1;
                        break;
                    case "CUSTOMER":
                        embeddedForm.Close();
                        fCustomer frm2 = new fCustomer();
                        frm2.TopLevel = false;
                        frm2.FormBorderStyle = FormBorderStyle.None;
                        frm2.WindowState = FormWindowState.Maximized;
                        frm2.groupControl1.Visible = false;
                        fluentDesignFormContainer1.Controls.Add(frm2);
                        frm2.Show();
                        frm2.Parent = fluentDesignFormContainer1;
                        break;
                    default:
                        XtraMessageBox.Show("You dont have permission to access this function");
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

        private void NavMain_MouseHover(object sender, EventArgs e)
        {
            Task.Delay(100).Wait();
            NavMain.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
        }

        private void NavMain_MouseLeave(object sender, EventArgs e)
        {
            Task.Delay(500).Wait();
            NavMain.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
        }

        private void NavMain_MouseMove(object sender, MouseEventArgs e)
        {
            Task.Delay(100).Wait();
            NavMain.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form embeddedForm = new Form();
            if (fluentDesignFormContainer1.Controls.Count > 0)
            {
                embeddedForm = (Form)fluentDesignFormContainer1.Controls[0];
                embeddedForm.Close();
            }

            fDashboard frm = new fDashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            fluentDesignFormContainer1.Controls.Add(frm);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.Parent = fluentDesignFormContainer1;
        }
    }
}
