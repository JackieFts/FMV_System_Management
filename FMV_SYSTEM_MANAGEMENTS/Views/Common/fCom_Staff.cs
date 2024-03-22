using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fCom_Staff : DevExpress.XtraEditors.XtraForm
    {
        public fCom_Staff()
        {
            InitializeComponent();
        }

        COM_STAFF _staff;
        bool _add;
        int _idstaff;

        private void fStaff_Load(object sender, EventArgs e)
        {
            //await loadStaff();
            //ShowHideControl(true);
            Program.log.LogMsg(Logger.LogLevel.INFO, "Loaded staff From");
        }

        public void ShowHideControl(bool t)
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

        public async Task loadStaff()
        {
            await Task.Delay(1);
            _staff = new COM_STAFF();
            gcStaff.DataSource = await _staff.getAll();
            //gvStaff.OptionsBehavior.Editable = false;
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
            if (Program._userLogin == "a")
            {
                XtraMessageBox.Show("You don't have permission to acces this function", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    T_COM_STAFF _newstaff = new T_COM_STAFF()
                    {
                        STAFFNAME = tbName.Text,
                        DEPARTMENT = tbDepartment.Text.Trim(),
                        POSITION = tbPosition.Text,
                        CCCD = tbCCCD.Text,
                        PHONE = tbPhone.Text,
                        EMAIL = tbEmail.Text
                    };
                    await _staff.Add(_newstaff);
                }
            }
            else
            {
                if (_idstaff > 0)
                {
                    T_COM_STAFF _editstaff = await _staff.getByID(_idstaff);
                    _editstaff.STAFFNAME = tbName.Text;
                    _editstaff.DEPARTMENT = tbDepartment.Text.Trim();
                    _editstaff.POSITION = tbPosition.Text;
                    _editstaff.CCCD = tbCCCD.Text;
                    _editstaff.PHONE = tbPhone.Text;
                    _editstaff.EMAIL = tbEmail.Text;
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

            fFirst_Dashboard frm = new fFirst_Dashboard();
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
                _idstaff = int.Parse(gvStaff.GetFocusedRowCellValue("IDSTAFF").ToString());
                tbName.Text = gvStaff.GetFocusedRowCellValue("STAFFNAME").ToString();
                tbDepartment.Text = gvStaff.GetFocusedRowCellValue("DEPARTMENT").ToString().Trim();
                tbPosition.Text = gvStaff.GetFocusedRowCellValue("POSITION").ToString();
                tbCCCD.Text = gvStaff.GetFocusedRowCellValue("CCCD").ToString();
                tbPhone.Text = gvStaff.GetFocusedRowCellValue("PHONE").ToString();
                tbEmail.Text = gvStaff.GetFocusedRowCellValue("EMAIL").ToString();
            }
        }

        private void gvStaff_ParseFindPanelText(object sender, DevExpress.Data.ParseFindPanelTextEventArgs e)
        {
            
        }

        private void gvStaff_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)  //if is indicator line
            {
                if (e.RowHandle < 0)
                {
                    e.Info.ImageIndex = 0;
                    e.Info.DisplayText = string.Empty;
                }
                else
                {
                    e.Info.ImageIndex = -1; //Not Display
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();  //STT tang 
                }
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);  //Get size of display text zone
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvStaff); }));
            }
        }

        private void gvStaff_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(gvStaff.GetFocusedRowCellValue("IDSTAFF").ToString());
        }
    }
}