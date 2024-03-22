using DevExpress.Map.Kml.Model;
using DevExpress.XtraBars.FluentDesignSystem;
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
    public partial class fStaff : DevExpress.XtraEditors.XtraForm
    {
        public fStaff()
        {
            InitializeComponent();
            gvStaff.ShowFindPanel();
        }

        COM_STAFF _staff;
        bool _add;
        int _idstaff;

        private async void fStaff_Load(object sender, EventArgs e)
        {
            await loadStaff();
            ShowHideControl(true);
            Program.log.LogMsg(Logger.LogLevel.INFO, "Loaded staff From");
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
            tbName.Text = string.Empty;
            tbDepartment.Text = string.Empty;
            tbPosition.Text = string.Empty;
            tbCCCD.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        private async Task loadStaff()
        {
            await Task.Delay(1);
            _staff = new COM_STAFF();
            gcStaff.DataSource = await _staff.getAll();
            gvStaff.OptionsBehavior.Editable = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _add = true;
            _idstaff = 0;
            _reset();
            groupControl1.Visible = true;
            this.ShowHideControl(false);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _add = false;
            _reset();
            _idstaff = 0;
            groupControl1.Visible = true;
            this.ShowHideControl(false);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_idstaff > 0)
            {
                if (XtraMessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _staff.Delete(_idstaff);
                    await this.loadStaff();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A Staff : {0}", _idstaff);
                    _idstaff = 0;
                }
            }
            else
            {
                XtraMessageBox.Show("Pls click into row data first !");
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MyFunc.truncateTable("dbo.T_COM_STAFF");
                await loadStaff();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                if (tbName.Text == "" || tbDepartment.Text == "" || tbPosition.Text == "")
                {
                    XtraMessageBox.Show("Pls Type data first !");
                }
                else
                {
                    TComStaff _newstaff = new TComStaff()
                    {
                        Staffname = tbName.Text,
                        Department = tbDepartment.Text,
                        Position = tbPosition.Text,
                        CCCD = tbCCCD.Text,
                        Phone = tbPhone.Text,
                        Email = tbEmail.Text
                    };
                    await _staff.Add(_newstaff);
                }
            }
            else
            {
                if (_idstaff > 0)
                {
                    TComStaff _editstaff = await _staff.getByID(_idstaff);
                    _editstaff.Staffname = tbName.Text;
                    _editstaff.Department = tbDepartment.Text;
                    _editstaff.Position = tbPosition.Text;
                    _editstaff.CCCD = tbCCCD.Text;
                    _editstaff.Phone = tbPhone.Text;
                    _editstaff.Email = tbEmail.Text;
                    await _staff.Update(_editstaff);
                    _idstaff = 0;
                }
                else
                {
                    XtraMessageBox.Show("Pls click into row data first !");
                }
            }
            _add = false;
            await this.loadStaff();
            groupControl1.Visible = false;
            this.ShowHideControl(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _add = false;
            _idstaff = 0;
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

        private void gvStaff_Click(object sender, EventArgs e)
        {
            if (gvStaff.RowCount > 0)
            {
                _idstaff = int.Parse(gvStaff.GetFocusedRowCellValue("Idstaff").ToString());
                tbName.Text = gvStaff.GetFocusedRowCellValue("Staffname").ToString();
                tbDepartment.Text = gvStaff.GetFocusedRowCellValue("Department").ToString();
                tbPosition.Text = gvStaff.GetFocusedRowCellValue("Position").ToString();
                tbCCCD.Text = gvStaff.GetFocusedRowCellValue("CCCD").ToString();
                tbPhone.Text = gvStaff.GetFocusedRowCellValue("Phone").ToString();
                tbEmail.Text = gvStaff.GetFocusedRowCellValue("Email").ToString();
            }
        }

        private void gvStaff_ParseFindPanelText(object sender, DevExpress.Data.ParseFindPanelTextEventArgs e)
        {
            if (e.FindPanelText.Contains(";"))
            {
                gcStaff.Focus();
                gvStaff.FindFilterText = e.FindPanelText.Substring(0, e.FindPanelText.IndexOf(";"));
            }
        }

    }
}