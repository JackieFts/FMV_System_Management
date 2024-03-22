using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers.MONTHLY;
using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENTS.Views.Monthly
{
    public partial class fMonthly : DevExpress.XtraEditors.XtraForm
    {
        public fMonthly()
        {
            InitializeComponent();
        }

        COM_STAFF _staff;
        COM_CUSTOMER _customer;
        REP_MCTYPE _mctype;
        REP_MONTHLY _monthly;

        private bool checkLoad = false;
        int _idmonth = -1;

        private void fMonthly_Load(object sender, EventArgs e)
        {
            this.initConfig();
        }

        private async void initConfig()
        {
            dtDate.DateTime = DateTime.Now;
            dtFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTo.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            await loadMonthNow();
            await loadStaff();
            await loadCus();
            await loadMCType();
            checkLoad = true;
        }
        public async Task loadMonthNow()
        {
            await Task.Delay(1);
            _monthly = new REP_MONTHLY();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            gcList.DataSource = await _monthly.getForSearch(new DateTime(year, month, 1), new DateTime(year, month, DateTime.DaysInMonth(year, month)));
            //gvStaff.OptionsBehavior.Editable = false;
        }

        private async Task loadMonthCreate()
        {
            await Task.Delay(1);
            _monthly = new REP_MONTHLY();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            gcList.DataSource = await _monthly.getForSearch(new DateTime(year, month, 1));
        }

        private async Task loadMCType()
        {
            _mctype = new REP_MCTYPE();
            var data = await _mctype.getAll();
            tbMcType.DataSource = data;
            tbMcType.DisplayMember = "MCTYPE";
            tbMcType.ValueMember = "IDMCTYPE";
            tbMcType.SelectedIndex = -1;
        }

        public async Task loadStaff()
        {
            _staff = new COM_STAFF();
            var data = await _staff.getAll();
            tbEngineer.DataSource = data;
            tbEngineer.DisplayMember = "STAFFNAME";
            tbEngineer.ValueMember = "IDSTAFF";
            tbEngineer.SelectedIndex = -1;
        }

        public async Task loadCus()
        {
            _customer = new COM_CUSTOMER();
            var data = await _customer.getAll();
            tbCus.DataSource = data;
            tbCus.DisplayMember = "CUSTOMERNAME";
            tbCus.ValueMember = "IDCUSTOMER";
            tbCus.SelectedIndex = -1;
        }

        private void tbNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbNature.Text == "No-charge visit/support" || tbNature.Text == "Warranty visit/support")
            {
                tbCharge.Text = "";
                tbCharge.ReadOnly = true;
            }
            else
                tbCharge.ReadOnly = false;
        }

        //private void testDate()
        //{
        //    int month = dateTimeOffsetEdit1.DateTimeOffset.Month;
        //    int year = dateTimeOffsetEdit1.DateTimeOffset.Year;
        //    DateTime firstDayOfMonth = new DateTime(year, month, 1);
        //    DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        //    XtraMessageBox.Show(firstDayOfMonth.ToShortDateString() + "\r\n" + lastDayOfMonth.ToShortDateString());

        //    string EnName = string.Empty;
        //    string[] arr = tbEngineer.Text.Split(' ');
        //    if (arr.Length == 2)
        //    {
        //        arr[0] = arr[0].Remove(1);
        //        EnName = arr[0] + "." + arr[1];
        //    }
        //    else if (arr.Length == 3)
        //    {
        //        arr[1] = arr[1].Remove(1);
        //        EnName = arr[1] + "." + arr[2];
        //    }
        //    else
        //    {
        //        arr[2] = arr[2].Remove(1);
        //        EnName = arr[2] + "." + arr[3];
        //    }

        //    MessageBox.Show(EnName);
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            _idmonth = -1;
        }

        private async void btnAddType_Click(object sender, EventArgs e)
        {
            fMCType _mcType = new fMCType();
            _mcType.ShowDialog();
            await loadMCType();
        }

        private void btnClearIn_Click(object sender, EventArgs e)
        {
            reset();
            _idmonth = -1;
        }

        private void reset()
        {
            tbCus.SelectedIndex = -1;
            dtDate.DateTime = DateTime.Now;
            tbDay.SelectedItem = "WD";
            dtIn.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00);
            dtOut.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 45, 00);
            tbEngineer.SelectedIndex = -1;
            tbMcType.SelectedIndex = -1;
            tbLineNo.Text = "";
            tbInstallDate.Text = "";
            tbEntryQty.Value = 0;
            tbSR.Text = "";
            tbNature.SelectedIndex = -1;
            tbCharge.Text = "";
            tbCharge.ReadOnly = false;
            tbDes.Text = "";
        }

        private async void dtFrom_EditValueChangedAsync(object sender, EventArgs e)
        {
            if (!checkLoad)
                return;
            if (dtFrom.DateTime > dtTo.DateTime)
            {
                XtraMessageBox.Show("Invalid datetime");
                dtFrom.DateTime = new DateTime(dtTo.DateTime.Year, dtTo.DateTime.Month, 1);
            }
            await loadList();
        }

        private async Task loadList()
        {
            await Task.Delay(1);
            _monthly = new REP_MONTHLY();
            gcList.DataSource = await _monthly.getForSearch(dtFrom.DateTime, dtTo.DateTime);
        }

        private async void dtTo_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkLoad)
                return;
            if (dtFrom.DateTime > dtTo.DateTime)
            {
                XtraMessageBox.Show("Invalid datetime");
                dtTo.DateTime = new DateTime(dtFrom.DateTime.Year, dtFrom.DateTime.Month, DateTime.DaysInMonth(dtFrom.DateTime.Year, dtFrom.DateTime.Month));
            }
            await loadList();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            _idmonth = -1;
            if (tbCus.SelectedIndex == -1 || dtDate.Text == "" || tbEngineer.SelectedIndex == -1 || tbDes.Text == "")
            {
                XtraMessageBox.Show("Pls type all data", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _monthly = new REP_MONTHLY();
            T_REP_MONTHLY _newMon = new T_REP_MONTHLY();
            _newMon.IDCUSTOMER = tbCus.SelectedValue.ToString();
            _newMon.IDSTAFF = int.Parse(tbEngineer.SelectedValue.ToString());
            _newMon.DATE = dtDate.DateTime;
            _newMon.DAY = tbDay.Text;
            _newMon.CHECKIN = new TimeSpan(dtIn.Value.Hour, dtIn.Value.Minute, dtIn.Value.Second);
            _newMon.CHECKOUT = new TimeSpan(dtOut.Value.Hour, dtOut.Value.Minute, dtOut.Value.Second);
            if (tbMcType.SelectedIndex != -1)
                _newMon.IDMCTYPE = int.Parse(tbMcType.SelectedValue.ToString());
            _newMon.LINE_NO = tbLineNo.Text;
            if (tbInstallDate.Text != "")
                _newMon.INSTALLATION_DATE = tbInstallDate.DateTime;
            _newMon.ACTIVITY = tbDes.Text;
            _newMon.TRANSPORT = int.Parse(tbEntryQty.Value.ToString());
            _newMon.SRNO = tbSR.Text;
            _newMon.NATURE = tbNature.Text;
            try
            {
                if (tbCharge.Text != "")
                    _newMon.CHARGEABLE = int.Parse(tbCharge.Text);
            }
            catch
            {
                _newMon.CHARGEABLE = null;
            }
            _newMon.CREATE_DATE = DateTime.Now;
            _newMon.CREATE_BY = 1;

            await _monthly.Add(_newMon);
            await loadMonthCreate();
            dtDate.DateTime = dtDate.DateTime.AddDays(1);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if(_idmonth == -1)
            {
                XtraMessageBox.Show("Pls click row data first. After that edit data and then click Update button", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            T_REP_MONTHLY _updateMonthly = await _monthly.getByID(_idmonth);
            _updateMonthly.IDCUSTOMER = tbCus.SelectedValue.ToString();
            _updateMonthly.IDSTAFF = int.Parse(tbEngineer.SelectedValue.ToString());
            _updateMonthly.DATE = dtDate.DateTime;
            _updateMonthly.DAY = tbDay.Text;
            _updateMonthly.CHECKIN = new TimeSpan(dtIn.Value.Hour, dtIn.Value.Minute, dtIn.Value.Second);
            _updateMonthly.CHECKOUT = new TimeSpan(dtOut.Value.Hour, dtOut.Value.Minute, dtOut.Value.Second);
            if (tbMcType.SelectedIndex != -1)
                _updateMonthly.IDMCTYPE = int.Parse(tbMcType.SelectedValue.ToString());
            else
                _updateMonthly.IDMCTYPE = null;
            _updateMonthly.LINE_NO = tbLineNo.Text;
            if (tbInstallDate.Text != "")
                _updateMonthly.INSTALLATION_DATE = tbInstallDate.DateTime;
            else
                _updateMonthly.INSTALLATION_DATE = null;
            _updateMonthly.ACTIVITY = tbDes.Text;
            _updateMonthly.TRANSPORT = int.Parse(tbEntryQty.Value.ToString());
            _updateMonthly.SRNO = tbSR.Text;
            _updateMonthly.NATURE = tbNature.Text;
            try
            {
                if (tbCharge.Text != "")
                    _updateMonthly.CHARGEABLE = int.Parse(tbCharge.Text);
            }
            catch
            {
                _updateMonthly.CHARGEABLE = null;
            }
            _updateMonthly.UPDATE_DATE = DateTime.Now;
            _updateMonthly.UPDATE_BY = 1;
            await _monthly.Update(_updateMonthly);
            await loadMonthNow();

            _idmonth = -1;
        }

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        private void gvList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvList); }));
            }
        }

        private async void gvList_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvList.RowCount > 0)
                {
                    _idmonth = int.Parse(gvList.GetFocusedRowCellValue("IDMONTHLY").ToString());
                    var data = await _monthly.getByID(_idmonth);
                    tbCus.SelectedValue = gvList.GetFocusedRowCellValue("IDCUSTOMER").ToString();
                    dtDate.DateTime = DateTime.Parse(gvList.GetFocusedRowCellValue("DATE").ToString());
                    tbDay.SelectedItem = gvList.GetFocusedRowCellValue("DAY").ToString();
                    dtIn.Value = DateTime.Parse(gvList.GetFocusedRowCellValue("CHECKIN").ToString());
                    dtOut.Value = DateTime.Parse(gvList.GetFocusedRowCellValue("CHECKOUT").ToString());
                    tbEngineer.SelectedValue = gvList.GetFocusedRowCellValue("IDSTAFF");
                    if (gvList.GetFocusedRowCellValue("IDMCTYPE") != null)
                        tbMcType.SelectedValue = gvList.GetFocusedRowCellValue("IDMCTYPE");
                    tbLineNo.Text = gvList.GetFocusedRowCellValue("LINE_NO").ToString();
                    try
                    {
                        if (data.INSTALLATION_DATE != null)
                            tbInstallDate.DateTime = DateTime.Parse(gvList.GetFocusedRowCellValue("INSTALLATION_DATE").ToString());
                        else
                            tbInstallDate.Text = "";
                    }
                    catch { tbInstallDate.Text = ""; }
                    tbEntryQty.Value = int.Parse(gvList.GetFocusedRowCellValue("TRANSPORT").ToString());
                    tbSR.Text = gvList.GetFocusedRowCellValue("SRNO").ToString();
                    tbNature.Text = gvList.GetFocusedRowCellValue("NATURE").ToString();
                    try
                    {
                        if (data.CHARGEABLE == null)
                            tbCharge.Text = "";
                        else
                        {
                            int.Parse(gvList.GetFocusedRowCellValue("CHARGEABLE").ToString().Substring(0, gvList.GetFocusedRowCellValue("CHARGEABLE").ToString().IndexOf('.')));
                            tbCharge.Text = gvList.GetFocusedRowCellValue("CHARGEABLE").ToString().Substring(0, gvList.GetFocusedRowCellValue("CHARGEABLE").ToString().IndexOf('.'));
                        }
                    }
                    catch {
                        tbCharge.Text = "";
                    }
                    tbDes.Text = gvList.GetFocusedRowCellValue("ACTIVITY").ToString();
                }
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvList Click error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvList Click error : {0}", ex.StackTrace);
            }
        }

        private void tbCharge_TextChanged(object sender, EventArgs e)
        {
            tbCharge.Text = Regex.Replace(tbCharge.Text, "[^0-9]", "");
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _monthly.Delete(int.Parse(gvList.GetFocusedRowCellValue("IDMONTHLY").ToString()));
                await this.loadList();
                Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A Monthly data : {0}", int.Parse(gvList.GetFocusedRowCellValue("IDMONTHLY").ToString()));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _monthly.TrunCate();
            }
        }

        private async void dtSearch_EditValueChanged(object sender, EventArgs e)
        {
            int month = dtSearch.DateTimeOffset.Month;
            int year = dtSearch.DateTimeOffset.Year;
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            gcList.DataSource = await _monthly.getForSearch(firstDayOfMonth, lastDayOfMonth);
        }
    }
}