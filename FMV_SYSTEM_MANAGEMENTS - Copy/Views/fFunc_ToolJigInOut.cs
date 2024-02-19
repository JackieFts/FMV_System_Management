using DevExpress.DashboardCommon;
using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFunc_ToolJigInOut : DevExpress.XtraEditors.XtraForm
    {
        public fFunc_ToolJigInOut()
        {
            InitializeComponent();
        }

        HIS_PARTOUT _partout;
        HIS_PARTIN _partin;
        INFO_JIG _jig;
        List<T_INFO_JIG> _jigList = new List<T_INFO_JIG>();
        INFO_PART _part;
        List<T_INFO_PART> _partList = new List<T_INFO_PART>();
        COM_STAFF _staff;
        COM_CUSTOMER _customer;

        int maxQtyOut = 0;

        public async Task loadStaff()
        {
            dtEstimate.Value = DateTime.Now.AddDays(30);
            _staff = new COM_STAFF();
            var data = await _staff.getAll();
            data.Add(new Models.T_COM_STAFF()
            {
                IDSTAFF = 0,
                STAFFNAME = ""
            });
            cbStaff.DataSource = data;
            cbStaff.DisplayMember = "STAFFNAME";
            cbStaff.ValueMember = "IDSTAFF";
            cbStaff.Text = "";
        }

        public async Task loadCus()
        {
            _customer = new COM_CUSTOMER();
            var data = await _customer.getAll();
            data.Add(new Models.T_COM_CUSTOMER()
            {
                IDCUSTOMER = "",
                CUSTOMERNAME = ""
            });
            cbCustomer.DataSource = data;
            cbCustomer.DisplayMember = "CUSTOMERNAME";
            cbCustomer.ValueMember = "IDCUSTOMER";
            cbCustomer.Text = "";
        }

        private async void tbQRCode_TextChanged(object sender, EventArgs e)
        {
            if (groupControl1.Text == "PART IN")
            {
                if (tbQRCode.Text.Contains("."))
                {
                    _partout = new HIS_PARTOUT();
                    string QRCode = tbQRCode.Text.Replace(".", "");
                    var result = await _partout.getOutByQRCode(QRCode);
                    if (result.Count <= 0)
                    {
                        if (gcList.DataSource is ICollection<T_HIS_PARTOUT> collection)
                        {
                            collection.Clear();
                            gvList.RefreshData();
                        }
                        MessageBox.Show("QRCode is not match or this part request already in inventory", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        gcList.DataSource = result;
                    }

                    tbQRCode.Text = "";
                    tbQRCode.Focus();
                }
            }
            else if (this.Text == "TOOLS & JIGS" && groupControl1.Text == "PART OUT")
            {
                if (tbQRCode.Text.Contains("."))
                {
                    tbQRCode.ReadOnly = true;
                    _jig = new INFO_JIG();
                    string QRCode = tbQRCode.Text.Substring(0, tbQRCode.Text.IndexOf("."));
                    var result = await _jig.getJigbyQRCode(QRCode);
                    if (result == null)
                    {
                        MessageBox.Show("QRCode is not match or this part is not avaliable", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!checkduplicate(result.IDJIG))
                        {
                            _jigList.Add(result);
                            gcList.DataSource = _jigList;
                            gvList.RefreshData();
                        }
                    }
                    tbQRCode.Text = "";
                    await Task.Delay(2000);
                    tbQRCode.ReadOnly = false;
                    tbQRCode.Focus();
                }
            }
            else if (this.Text == "PARTS" && groupControl1.Text == "PART OUT")
            {
                if (tbQRCode.Text.Contains("."))
                {
                    tbQRCode.ReadOnly = true;
                    _part = new INFO_PART();
                    string QRCode = tbQRCode.Text.Substring(0, tbQRCode.Text.IndexOf("."));
                    var result = await _part.getJigbyQRCode(QRCode);
                    if (result == null)
                    {
                        MessageBox.Show("QRCode is not match or this part is not avaliable", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!checkduplicate(result.IDPART))
                        {
                            _partList.Add(result);
                            gcList.DataSource = _partList;
                            gvList.RefreshData();
                        }
                    }
                    tbQRCode.Text = "";
                    await Task.Delay(2000);
                    tbQRCode.ReadOnly = false;
                    tbQRCode.Focus();
                }
            }
        }

        private bool checkduplicate(int check)
        {
            List<int> duplicates = new List<int>();
            for (int i = 0; i < gvList.RowCount; i++)
            {
                duplicates.Add(int.Parse(gvList.GetRowCellValue(i, "IDJIG").ToString()));
            }
            if (duplicates.Count > 0 && duplicates.Contains(check))
                return true;
            return false;
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

        private void gvList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Text == "TOOLS & JIGS" && groupControl1.Text == "PART OUT")
            {
                int selectedRowHandle = gvList.FocusedRowHandle;
                if (selectedRowHandle >= 0 && selectedRowHandle < gvList.RowCount)
                {
                    // Remove data from the data source based on the selected row
                    _jigList.RemoveAt(selectedRowHandle);

                    gcList.DataSource = _jigList;
                    // Refresh the GridView to reflect the changes
                    gvList.RefreshData();
                }
            }
            else if (this.Text == "PARTS" && groupControl1.Text == "PART OUT")
            {
                int selectedRowHandle = gvList.FocusedRowHandle;
                if (selectedRowHandle >= 0 && selectedRowHandle < gvList.RowCount)
                {
                    // Remove data from the data source based on the selected row
                    _partList.RemoveAt(selectedRowHandle);

                    gcList.DataSource = _partList;
                    // Refresh the GridView to reflect the changes
                    gvList.RefreshData();
                }
            }
        }

        private async void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "QTY")
            {
                if (groupControl1.Text == "PART IN")
                {
                    int id = int.Parse(gvList.GetFocusedRowCellValue("IDOUT").ToString());
                    HIS_PARTOUT _PARTOUT = new HIS_PARTOUT();
                    maxQtyOut = await _PARTOUT.getQtyByID(id);
                    int qtyIn = int.Parse(e.Value.ToString());
                    if (qtyIn < 0 || qtyIn > maxQtyOut)
                    {
                        MessageBox.Show(string.Format("you only can in max {0} PCS", maxQtyOut), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gvList.SetRowCellValue(gvList.FocusedRowHandle, "QTY", maxQtyOut);
                    }
                }
                else if (this.Text == "TOOLS & JIGS" && groupControl1.Text == "PART OUT")
                {
                    int id = int.Parse(gvList.GetFocusedRowCellValue("IDJIG").ToString());
                    INFO_JIG _JIG = new INFO_JIG();
                    maxQtyOut = await _JIG.getBalancebyID(id);
                    int qtyOut = int.Parse(e.Value.ToString());

                    if (qtyOut <= 0 || qtyOut > maxQtyOut)
                    {
                        MessageBox.Show(string.Format("you only can out max {0} PCS", maxQtyOut), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gvList.SetRowCellValue(gvList.FocusedRowHandle, "QTY", maxQtyOut);
                    }
                }
                else if (this.Text == "PARTS" && groupControl1.Text == "PART OUT")
                {
                    int id = int.Parse(gvList.GetFocusedRowCellValue("IDPART").ToString());
                    INFO_PART _JIG = new INFO_PART();
                    maxQtyOut = await _JIG.getBalancebyID(id);
                    int qtyOut = int.Parse(e.Value.ToString());

                    if (qtyOut <= 0 || qtyOut > maxQtyOut)
                    {
                        MessageBox.Show(string.Format("you only can out max {0} PCS", maxQtyOut), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        gvList.SetRowCellValue(gvList.FocusedRowHandle, "QTY", maxQtyOut);
                    }
                }
                maxQtyOut = 0;
            }
        }

        private async void btnPartIn_Click(object sender, EventArgs e)
        {
            _partin = new HIS_PARTIN();
            _partout = new HIS_PARTOUT();
            _jig = new INFO_JIG();
            _part = new INFO_PART();
            T_HIS_PARTIN _lstPartIn;

            if (gvList.RowCount > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = DateTime.Now.ToString("yyyyMMdd_") + "Part In.xlsx";

                saveFile.Filter = "Excel Workbook|*.xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var pathsave = new FileInfo(saveFile.FileName);
                    var pathfiletemp = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Temp\\FMV In.xlsx");

                    File.Copy(pathfiletemp.ToString(), pathsave.ToString(), true);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelPackage package = new ExcelPackage(pathsave);
                    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];
                    excelWorksheet.Cells["C14"].Value = DateTime.Now.ToString("dd-MMM-yyyy");
                    int RowRun = 19;
                    for (int k = 0; k < gvList.RowCount; k++)
                    {
                        if (int.Parse(gvList.GetRowCellValue(k, "QTY").ToString()) > 0)
                        {
                            excelWorksheet.Cells["B" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "PARTNUMBER").ToString();
                            excelWorksheet.Cells["F" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "NAME").ToString();
                            excelWorksheet.Cells["G" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "QTY").ToString();
                            excelWorksheet.Cells["I" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "LOCATION").ToString();
                            RowRun++;
                        }
                    }
                    excelWorksheet.DeleteRow(RowRun + 2, 54 - (RowRun + 2) + 1);

                    excelWorksheet.Protection.IsProtected = false;
                    excelWorksheet.Protection.AllowSelectLockedCells = false;
                    package.Save();

                    for (int j = 0; j < gvList.RowCount; j++)
                    {
                        int i = j;
                        await Task.Run(async () =>
                        {
                            if (int.Parse(gvList.GetRowCellValue(i, "QTY").ToString()) > 0)
                            {
                                if (this.Text == "TOOLS & JIGS") 
                                {
                                    //Update T_INFO_JIG
                                    int _idjig = int.Parse(gvList.GetRowCellValue(i, "IDJIGPART").ToString());
                                    int balance = await _jig.getBalancebyID(_idjig);
                                    int updateBalance = balance + int.Parse(gvList.GetRowCellValue(i, "QTY").ToString());

                                    var resultJIG = await _jig.getByID(_idjig);
                                    int total = int.Parse(resultJIG.QTY.ToString());
                                    resultJIG.BALANCE = updateBalance;
                                    if (updateBalance == total)
                                    {
                                        resultJIG.STATUS = true;
                                        resultJIG.IDCUSTOMER = null;
                                        resultJIG.IDSTAFF = null;
                                    }

                                    await _jig.Update(resultJIG);
                                }
                                else if (this.Text == "PARTS")
                                {
                                    //Update T_INFO_PART
                                    int _idjig = int.Parse(gvList.GetRowCellValue(i, "IDJIGPART").ToString());
                                    int balance = await _part.getBalancebyID(_idjig);
                                    int updateBalance = balance + int.Parse(gvList.GetRowCellValue(i, "QTY").ToString());

                                    var resultPART = await _part.getByID(_idjig);
                                    int total = int.Parse(resultPART.QTY.ToString());
                                    resultPART.BALANCE = updateBalance;
                                    if (updateBalance == total)
                                    {
                                        resultPART.STATUS = true;
                                        resultPART.IDCUSTOMER = null;
                                        resultPART.IDSTAFF = null;
                                    }

                                    await _part.Update(resultPART);
                                }


                                //Update T_HIS_PARTOUT
                                int _idout = int.Parse(gvList.GetRowCellValue(i, "IDOUT").ToString());
                                int outBalance = await _partout.getQtyByID(_idout);
                                int updateOutBalance = outBalance - int.Parse(gvList.GetRowCellValue(i, "QTY").ToString());

                                var resultOUT = await _partout.getByID(_idout);
                                resultOUT.QTY = updateOutBalance;
                                if (updateOutBalance == 0)
                                {
                                    resultOUT.STATUS = false;
                                }
                                await _partout.Update(resultOUT);

                                //push to T_HIS_PARTIN
                                _lstPartIn = new T_HIS_PARTIN();
                                _lstPartIn.IDJIGPART = int.Parse(gvList.GetRowCellValue(i, "IDJIGPART").ToString());
                                _lstPartIn.CATEGORY = "T_INFO_JIG";
                                _lstPartIn.QRCODE = gvList.GetRowCellValue(i, "QRCODE").ToString();
                                _lstPartIn.QRCODESUB = gvList.GetRowCellValue(i, "QRCODESUB").ToString();
                                _lstPartIn.NAME = gvList.GetRowCellValue(i, "NAME").ToString();
                                _lstPartIn.PARTNUMBER = gvList.GetRowCellValue(i, "PARTNUMBER").ToString();
                                _lstPartIn.LOCATION = gvList.GetRowCellValue(i, "LOCATION").ToString();
                                _lstPartIn.QTY = int.Parse(gvList.GetRowCellValue(i, "QTY").ToString());
                                _lstPartIn.DATEIN = DateTime.Now;
                                _lstPartIn.IDUSER = 1;

                                await _partin.Add(_lstPartIn);
                            }

                        });
                    }
                    if (gcList.DataSource is ICollection<T_HIS_PARTOUT> collection)
                    {
                        collection.Clear();
                        gvList.RefreshData();
                    }

                    MessageBox.Show("done");
                }
            }

        }

        private async void btnPartOut_Click(object sender, EventArgs e)
        {
            _partout = new HIS_PARTOUT();
            _jig = new INFO_JIG();
            T_HIS_PARTOUT _lstPartOut;
            COM_SEQUENCE _count;

            if (gvList.RowCount > 0)
            {
                _count = new COM_SEQUENCE();
                int sequence = await _count.getSequenceByName("OUT");

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = DateTime.Now.ToString("yyyyMMdd_") + "Part Request.xlsx";

                saveFile.Filter = "Excel Workbook|*.xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var pathsave = new FileInfo(saveFile.FileName);
                    var pathfiletemp = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Temp\\FMV Out.xlsx");

                    File.Copy(pathfiletemp.ToString(), pathsave.ToString(), true);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelPackage package = new ExcelPackage(pathsave);
                    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];
                    excelWorksheet.Cells["C14"].Value = DateTime.Now.ToString("dd-MMM-yyyy");
                    int RowRun = 19;
                    for (int k = 0; k < gvList.RowCount; k++)
                    {
                        excelWorksheet.Cells["B" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "PARTNUMBER").ToString();
                        excelWorksheet.Cells["F" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "NAME").ToString();
                        excelWorksheet.Cells["G" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "BALANCE").ToString();
                        excelWorksheet.Cells["I" + RowRun.ToString()].Value = gvList.GetRowCellValue(k, "LOCATION").ToString();
                        excelWorksheet.Cells["K" + RowRun.ToString()].Value = tbRemark.Text;
                        RowRun++;
                    }
                    excelWorksheet.DeleteRow(RowRun + 2, 54 - (RowRun + 2) + 1);

                    Bitmap qrCodeBitmap = MyFunc.GenerateQRCodeBitmap(sequence.ToString() + ".");

                    // Save the QR code image to a temporary file
                    string tempImagePath = sequence.ToString() + ".png";
                    qrCodeBitmap.Save(tempImagePath);

                    // Insert the QR code image into the Excel worksheet
                    var picture = excelWorksheet.Drawings.AddPicture("QRCode", new FileInfo(tempImagePath));
                    picture.From.Column = 6;
                    picture.From.Row = 11;
                    picture.SetSize(110, 110); // Adjust the size as needed

                    excelWorksheet.Protection.IsProtected = false;
                    excelWorksheet.Protection.AllowSelectLockedCells = false;
                    package.Save();

                    using (Bitmap tempBitmap = new Bitmap(tempImagePath)) { }
                    await Task.Delay(10);
                    File.Delete(tempImagePath);

                    for (int j = 0; j < gvList.RowCount; j++)
                    {
                        int i = j;
                        await Task.Run(async () =>
                        {
                            if (int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString()) > 0)
                            {
                                //Add T_HIS_PARTOUT
                                _lstPartOut = new T_HIS_PARTOUT();
                                if (this.Text == "TOOLS & JIGS")
                                {
                                    _lstPartOut.IDJIGPART = int.Parse(gvList.GetRowCellValue(i, "IDJIG").ToString());
                                    _lstPartOut.CATEGORY = "T_INFO_JIG";
                                }
                                else if (this.Text == "PARTS")
                                {
                                    _lstPartOut.IDJIGPART = int.Parse(gvList.GetRowCellValue(i, "IDPART").ToString());
                                    _lstPartOut.CATEGORY = "T_INFO_PART";
                                }
                                _lstPartOut.QRCODE = sequence.ToString();
                                _lstPartOut.QRCODESUB = gvList.GetRowCellValue(i, "QRCODE").ToString();
                                _lstPartOut.NAME = gvList.GetRowCellValue(i, "NAME").ToString();
                                _lstPartOut.PARTNUMBER = gvList.GetRowCellValue(i, "PARTNUMBER").ToString();
                                _lstPartOut.LOCATION = gvList.GetRowCellValue(i, "LOCATION").ToString();
                                _lstPartOut.QTY = int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString());
                                _lstPartOut.SAVEQTY = int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString());
                                _lstPartOut.DATEOUT = DateTime.Now;
                                _lstPartOut.ESTIMATEDIN = dtEstimate.Value;
                                _lstPartOut.IDUSER = 1;
                                _lstPartOut.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                _lstPartOut.REMARK = tbRemark.Text;
                                _lstPartOut.STATUS = true;

                                await _partout.Add(_lstPartOut);

                                if (this.Text == "TOOLS & JIGS")
                                {
                                    //Update T_INFO_JIG
                                    int balance = await _jig.getBalancebyID(int.Parse(gvList.GetRowCellValue(i, "IDJIG").ToString()));
                                    int update = balance - int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString());

                                    var result = await _jig.getByID(int.Parse(gvList.GetRowCellValue(i, "IDJIG").ToString()));
                                    result.BALANCE = update;
                                    if (update == 0)
                                        result.STATUS = false;
                                    result.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                    result.IDSTAFF = int.Parse(cbStaff.SelectedValue.ToString());
                                    await _jig.Update(result);
                                }
                                else if (this.Text == "PARTS")
                                {
                                    //Update T_INFO_PART
                                    int balance = await _part.getBalancebyID(int.Parse(gvList.GetRowCellValue(i, "IDPART").ToString()));
                                    int update = balance - int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString());

                                    var result = await _part.getByID(int.Parse(gvList.GetRowCellValue(i, "IDPART").ToString()));
                                    result.BALANCE = update;
                                    if (update == 0)
                                        result.STATUS = false;
                                    result.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                    result.IDSTAFF = int.Parse(cbStaff.SelectedValue.ToString());
                                    await _part.Update(result);
                                }
                            }
                        });
                    }
                    await _count.updateValue("OUT", sequence + 1);
                    tbRemark.Text = "";
                    cbStaff.Text = "";
                    cbCustomer.Text = "";
                    if (gcList.DataSource is ICollection<T_INFO_JIG> collection)
                    {
                        collection.Clear();
                        gvList.RefreshData();
                    }

                    MessageBox.Show("done");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}