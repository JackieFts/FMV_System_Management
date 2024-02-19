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

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fCom_Customer : DevExpress.XtraEditors.XtraForm
    {
        public fCom_Customer()
        {
            InitializeComponent();
        }

        COM_CUSTOMER _cus;

        bool _add;
        string _idcus;

        private void fCustomer_Load(object sender, EventArgs e)
        {
            //await loadCus();
            //ShowHideControl(true);
            Program.log.LogMsg(Logger.LogLevel.FATAL, "Load Customer Form with User [{0}] ............", Program._userLogin);
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
            tbID.Text = string.Empty;
            tbName.Text = string.Empty;
            tbContact.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        public async Task loadCus()
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
                MessageBox.Show("Pls click into row data first !");
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            if(Program._userLogin == "a")
            {
                MessageBox.Show("You don't have permission to acces this function", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                    MessageBox.Show("Pls Type data first !");
                }
                else
                {
                    T_COM_CUSTOMER _newcus = new T_COM_CUSTOMER();
                    _newcus.IDCUSTOMER = tbID.Text;
                    _newcus.CUSTOMERNAME = tbName.Text;
                    _newcus.CONTACTPERSON = tbContact.Text;
                    _newcus.PHONE = tbPhone.Text;
                    _newcus.EMAIL = tbEmail.Text;
                    _newcus.CREATE_DATE = DateTime.Now;
                    _newcus.CREATE_BY = 1;

                    await _cus.Add(_newcus);
                }
            }
            else
            {
                if (_idcus == "" || _idcus == null)
                {
                    MessageBox.Show("Pls click into row data first !");
                }
                else
                {
                    T_COM_CUSTOMER _editcus = await _cus.getByID(_idcus);
                    _editcus.CUSTOMERNAME = tbName.Text;
                    _editcus.CONTACTPERSON = tbContact.Text;
                    _editcus.PHONE = tbPhone.Text;
                    _editcus.EMAIL = tbEmail.Text;
                    _editcus.UPDATE_DATE = DateTime.Now;
                    _editcus.UPDATE_BY = 1;
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

            fFirst_Dashboard frm = new fFirst_Dashboard();
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
                _idcus = gvCustomer.GetFocusedRowCellValue("IDCUSTOMER").ToString();
                tbID.Text = _idcus;
                tbName.Text = gvCustomer.GetFocusedRowCellValue("CUSTOMERNAME").ToString();
                tbContact.Text = gvCustomer.GetFocusedRowCellValue("CONTACTPERSON").ToString();
                tbPhone.Text = gvCustomer.GetFocusedRowCellValue("PHONE").ToString();
                tbEmail.Text = gvCustomer.GetFocusedRowCellValue("EMAIL").ToString();
            }
        }

        private void gvCustomer_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvCustomer); }));
            }
        }

        private void gvCustomer_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file|*.csv;*.xls;*.xlsx;...|All files(*.*)|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}