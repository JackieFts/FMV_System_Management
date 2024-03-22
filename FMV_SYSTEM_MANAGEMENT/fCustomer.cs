using DevExpress.XtraEditors;
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
    public partial class fCustomer : DevExpress.XtraEditors.XtraForm
    {
        public fCustomer()
        {
            InitializeComponent();
            gvCustomer.ShowFindPanel();
        }

        COM_CUSTOMER _cus;

        bool _add;
        string _idcus;

        private async void fCustomer_Load(object sender, EventArgs e)
        {
            await loadCus();
            ShowHideControl(true);
            Program.log.LogMsg(Logger.LogLevel.INFO, "Loaded Customer From");
        }

        private void ShowHideControl(bool t)
        {
            btnAdd.Visible = t;
            btnUpdate.Visible = t;
            btnDelete.Visible = t;
            btnClear.Visible = t;
            btnSave.Visible = !t;
            btnCancel.Visible = !t;
            btnQuit.Visible = t;
        }

        private void _reset()
        {
            tbID.Text = string.Empty;
            tbName.Text = string.Empty;
            tbContact.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        private async Task loadCus()
        {
            await Task.Delay(1);
            _cus = new COM_CUSTOMER();
            gcCustomer.DataSource = await _cus.getAll();
            gvCustomer.OptionsBehavior.Editable = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _add = true;
            _idcus = "";
            _reset();
            tbID.ReadOnly = false;
            groupControl1.Visible = true;
            this.ShowHideControl(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _add = false;
            _reset();
            tbID.ReadOnly = true;
            _idcus = "";
            groupControl1.Visible = true;
            this.ShowHideControl(false);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_idcus == "" || _idcus == null)
            {
                XtraMessageBox.Show("Pls click into row data first !");
            }
            else
            {
                if (XtraMessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _cus.Delete(_idcus);
                    await this.loadCus();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A Customer : {0}", _idcus);
                    _idcus = "";
                }
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MyFunc.truncateTable("dbo.T_COM_CUSTOMER");
                await loadCus();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                if (tbID.Text == "" || tbName.Text == "")
                {
                    XtraMessageBox.Show("Pls Type data first !");
                }
                else
                {
                    TComCustomer _newcus = new TComCustomer();
                    _newcus.Idcustomer = tbID.Text;
                    _newcus.Customername = tbName.Text;
                    _newcus.Contactperson = tbContact.Text;
                    _newcus.Phone = tbPhone.Text;
                    _newcus.Email = tbEmail.Text;
                    _newcus.CreateDate = DateTime.Now;
                    _newcus.CreateBy = 1;

                    await _cus.Add(_newcus);
                }
            }
            else
            {
                if (_idcus == "" || _idcus == null)
                {
                    XtraMessageBox.Show("Pls click into row data first !");
                }
                else
                {
                    TComCustomer _editcus = await _cus.getByID(_idcus);
                    _editcus.Customername = tbName.Text;
                    _editcus.Contactperson = tbContact.Text;
                    _editcus.Phone = tbPhone.Text;
                    _editcus.Email = tbEmail.Text;
                    _editcus.UpdateDate = DateTime.Now;
                    _editcus.UpdateBy = 1;
                    await _cus.Update(_editcus);
                    _idcus = "";
                }
            }
            _add = false;
            await this.loadCus();
            groupControl1.Visible = false;
            this.ShowHideControl(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _add = false;
            _idcus = "";
            groupControl1.Visible = false;
            this.ShowHideControl(true);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();

            fMain main = (fMain)Application.OpenForms["fMain"];

            fDashboard frm = new fDashboard();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            main.fluentDesignFormContainer1.Controls.Add(frm);
            frm.Show();
            frm.Parent = main.fluentDesignFormContainer1;

        }

        private void gvCustomer_Click(object sender, EventArgs e)
        {
            if (gvCustomer.RowCount > 0)
            {
                _idcus = gvCustomer.GetFocusedRowCellValue("Idcustomer").ToString();
                tbID.Text = _idcus;
                tbName.Text = gvCustomer.GetFocusedRowCellValue("Customername").ToString();
                tbContact.Text = gvCustomer.GetFocusedRowCellValue("Contactperson").ToString();
                tbPhone.Text = gvCustomer.GetFocusedRowCellValue("Phone").ToString();
                tbEmail.Text = gvCustomer.GetFocusedRowCellValue("Email").ToString();
            }
        }
    }
}