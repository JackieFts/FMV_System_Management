using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DashboardCommon.Viewer;
using DevExpress.Security;
using DevExpress.Xpo.DB;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Interfaces.Drawing.Image;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using ZXing;
using static FMV_SYSTEM_MANAGEMENTS.MyFunc;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fInfo_Jigs : DevExpress.XtraEditors.XtraForm
    {
        public fInfo_Jigs()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        COM_STAFF _staff;
        COM_CUSTOMER _customer;
        INFO_JIG _jig;
        HIS_PARTOUT _partout;
        GridHitInfo downHitInfo = null;

        private int selectedRowHandle = GridControl.InvalidRowHandle;
        //bool _add;
        public int _idjig = 0;
        int _idtemp = 0;
        int _currentBalance = 0;
        int maxQtyOut = 0;

        private void fJigInfo_Load(object sender, EventArgs e)
        {
            //await this.loadJig();
            //await this.loadStaff();
            //await this.loadCus();
            dtEstimate.Value = DateTime.Now.AddDays(30);
        }

        public async Task loadJig()
        {
            _jig = new INFO_JIG();
            DataTable dt = new DataTable();
            dt = MyFunc.ConvertToDataTable(await _jig.getAll());
            gcJig.DataSource = dt;
            //gcJig.RefreshDataSource();
            gvJig.OptionsBehavior.Editable = false;
            gvJig.ClearSelection();

            gcPartOut.DataSource = dt.Clone();
        }

        public async Task loadStaff()
        {
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


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            fFunc_JigPart _JigPart = new fFunc_JigPart();
            _JigPart._add = true;
            _JigPart._idjig = 0;
            await _JigPart.loadStaff();
            _JigPart.tbEngineer.SelectedValue = "";
            await _JigPart.loadCus();
            _JigPart.tbCustomer.SelectedValue = "";
            loadEnable(_JigPart, true);
            _JigPart.ShowDialog();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_idjig > 0)
            {
                fFunc_JigPart _jigpart = new fFunc_JigPart();

                _jigpart._add = false;
                _jigpart._idjig = _idjig;
                await loadDatatoForm(_jigpart);
                loadEnable(_jigpart, true);

                _jigpart.ShowDialog();
                _idjig = 0;
            }
            else
            {
                MessageBox.Show("Pls click into row data first and then click Update !");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_idjig > 0)
            {
                if (MessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _jig.Delete(_idjig);
                    await this.loadJig();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A Staff : {0}", _idjig);
                    _idjig = 0;
                }
            }
            else
            {
                MessageBox.Show("Pls click into row data first and then click Delete !");
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (Program._userLogin == "a")
            {
                MessageBox.Show("You don't have permission to acces this function", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MyFunc.truncateTable("dbo.T_INFO_JIG");
                await loadJig();
            }
        }

        private async void btnOut_Click(object sender, EventArgs e)
        {
            _partout = new HIS_PARTOUT();
            _jig = new INFO_JIG();
            T_HIS_PARTOUT _lstPartOut;
            COM_SEQUENCE _count;

            //Bitmap qrCode = GenerateQRCode(sequence.ToString());
            //string additionalText = "Scan me!";
            //Bitmap finalImage = AddTextBelowQRCode(qrCode, additionalText, Color.White);

            //finalImage.Save("C:\\Users\\JACKIE\\Desktop\\a.png");

            if (gvPartOut.RowCount > 0)
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
                    for (int k = 0; k < gvPartOut.RowCount; k++)
                    {
                        excelWorksheet.Cells["B" + RowRun.ToString()].Value = gvPartOut.GetRowCellValue(k, "PARTNUMBER").ToString();
                        excelWorksheet.Cells["F" + RowRun.ToString()].Value = gvPartOut.GetRowCellValue(k, "NAME").ToString();
                        excelWorksheet.Cells["G" + RowRun.ToString()].Value = gvPartOut.GetRowCellValue(k, "BALANCE").ToString();
                        excelWorksheet.Cells["I" + RowRun.ToString()].Value = gvPartOut.GetRowCellValue(k, "LOCATION").ToString();
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

                    for (int j = 0; j < gvPartOut.RowCount; j++)
                    {
                        int i = j;
                        await Task.Run(async () =>
                        {
                            if (int.Parse(gvPartOut.GetRowCellValue(i, "BALANCE").ToString()) > 0)
                            {
                                _lstPartOut = new T_HIS_PARTOUT();
                                _lstPartOut.IDJIGPART = int.Parse(gvPartOut.GetRowCellValue(i, "IDJIG").ToString());
                                _lstPartOut.CATEGORY = "T_INFO_JIG";
                                _lstPartOut.QRCODE = sequence.ToString();
                                _lstPartOut.QRCODESUB = gvPartOut.GetRowCellValue(i, "QRCODE").ToString();
                                _lstPartOut.NAME = gvPartOut.GetRowCellValue(i, "NAME").ToString();
                                _lstPartOut.PARTNUMBER = gvPartOut.GetRowCellValue(i, "PARTNUMBER").ToString();
                                _lstPartOut.LOCATION = gvPartOut.GetRowCellValue(i, "LOCATION").ToString();
                                _lstPartOut.QTY = int.Parse(gvPartOut.GetRowCellValue(i, "BALANCE").ToString());
                                _lstPartOut.SAVEQTY = int.Parse(gvPartOut.GetRowCellValue(i, "BALANCE").ToString());
                                _lstPartOut.DATEOUT = DateTime.Now;
                                _lstPartOut.ESTIMATEDIN = dtEstimate.Value;
                                _lstPartOut.IDUSER = 1;
                                _lstPartOut.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                _lstPartOut.REMARK = tbRemark.Text;
                                _lstPartOut.STATUS = true;

                                await _partout.Add(_lstPartOut);

                                int balance = await _jig.getBalancebyID(int.Parse(gvPartOut.GetRowCellValue(i, "IDJIG").ToString()));
                                int update = balance - int.Parse(gvPartOut.GetRowCellValue(i, "BALANCE").ToString());

                                var result = await _jig.getByID(int.Parse(gvPartOut.GetRowCellValue(i, "IDJIG").ToString()));
                                result.BALANCE = update;
                                if (update == 0)
                                    result.STATUS = false;
                                result.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                result.IDSTAFF = int.Parse(cbStaff.SelectedValue.ToString());
                                await _jig.Update(result);
                            }
                        });
                    }
                    await _count.updateValue("OUT", sequence + 1);
                    await loadJig();
                    tbRemark.Text = "";
                    cbStaff.Text = "";
                    cbCustomer.Text = "";

                    MessageBox.Show("done");
                }
            }
        }

        private async void gvJig_DoubleClick(object sender, EventArgs e)
        {
            if (gvJig.RowCount > 0)
            {
                fFunc_JigPart _jigpart = new fFunc_JigPart();

                await loadDatatoForm(_jigpart);
                loadEnable(_jigpart, false);

                _jigpart.ShowDialog();
                _idjig = 0;
            }
        }

        private void gvJig_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvJig.RowCount > 0)
                    _idjig = int.Parse(gvJig.GetFocusedRowCellValue("IDJIG").ToString());
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvJig Click error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvJig Click error : {0}", ex.StackTrace);
            }
        }

        private async Task loadDatatoForm(fFunc_JigPart _jigpart)
        {
            await _jigpart.loadStaff();
            await _jigpart.loadCus();
            _jigpart.tbName.Text = gvJig.GetFocusedRowCellValue("NAME").ToString();
            _jigpart.tbDescription.Text = gvJig.GetFocusedRowCellValue("DESCRIPTION").ToString();
            _jigpart.tbPartnumber.Text = gvJig.GetFocusedRowCellValue("PARTNUMBER").ToString();
            _jigpart.tbRank.Text = gvJig.GetFocusedRowCellValue("RANK").ToString();
            _jigpart.tbAsset.Text = gvJig.GetFocusedRowCellValue("FIXED_ASSET_NO").ToString();
            _jigpart.tbQty.Value = int.Parse(gvJig.GetFocusedRowCellValue("QTY").ToString());
            _jigpart.tbBalance.Value = int.Parse(gvJig.GetFocusedRowCellValue("BALANCE").ToString());
            _jigpart.tbPO.Text = gvJig.GetFocusedRowCellValue("PO_RQ").ToString();
            _jigpart.tbQuotation.Text = gvJig.GetFocusedRowCellValue("QUOTATION").ToString();
            _jigpart.tbLocation.Text = gvJig.GetFocusedRowCellValue("LOCATION").ToString();
            _jigpart.tbEngineer.SelectedValue = gvJig.GetFocusedRowCellValue("IDSTAFF");
            _jigpart.tbCustomer.SelectedValue = gvJig.GetFocusedRowCellValue("IDCUSTOMER");
            _jigpart.tbRemark.Text = gvJig.GetFocusedRowCellValue("REMARK").ToString();

            // Get the image data from the selected row
            Image image = await GetImageFromRow(selectedRowHandle);

            if (image != null)
            {
                // Display the image in the PictureEdit control
                _jigpart.pictureEdit1.Image = image;
            }
        }

        private async Task<Image> GetImageFromRow(int rowHandle)
        {
            int _idjigtemp = int.Parse(gvJig.GetRowCellValue(rowHandle, "IDJIG").ToString());
            object imageData = (await _jig.getByID(_idjigtemp)).PICTURE;

            if (imageData != null && imageData != DBNull.Value)
            {
                return MyFunc.ByteArrayToImage((byte[])imageData);
            }

            return null;
        }

        private void loadEnable(fFunc_JigPart _jigpart, bool t)
        {
            _jigpart.btnSave.Enabled = t;
            _jigpart.btnCancel.Enabled = t;
        }

        private void gvJig_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectedRowHandle = e.RowHandle;
        }

        private void gvJig_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvJig); }));
            }
        }

        private void gvPartOut_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvPartOut); }));
            }
        }


        private void gvJig_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        private void gvPartOut_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.RowHandle % 2 == 1)
                e.Appearance.BackColor = Color.DeepSkyBlue;
        }

        #region drag drop gridcontrol 1
        //Gridcontrol 1
        private void gvJig_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = new GridView();
            view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
                //if (downHitInfo.InRow)
                //{
                //    // Get the underlying row data
                //    object rowData = view.GetRow(downHitInfo.RowHandle);

                //    _idtemp = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "IDJIG").ToString());
                //    _currentBalance = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "BALANCE").ToString());
                //}
            }
        }

        private void gvJig_MouseDown(object sender, MouseEventArgs e)
        {


            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }

            if (downHitInfo != null && downHitInfo.InRow)
            {
                // Get the underlying row data
                object rowData = view.GetRow(downHitInfo.RowHandle);

                _idtemp = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "IDJIG").ToString());
                _currentBalance = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "BALANCE").ToString());
            }

            //if (gvJig.RowCount > 0)
            //{
            //    _idtemp = int.Parse(gvJig.GetFocusedRowCellValue("IDJIG").ToString());
            //    _currentBalance = int.Parse(gvJig.GetFocusedRowCellValue("BALANCE").ToString());
            //}
        }

        private void gcJig_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                //table.ImportRow(row);
                row.Delete();
            }

        }

        private void gcJig_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        #endregion

        #region drag drop gridcontrol 2
        //Gridcontrol2

        private void gvPartOut_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }


        }

        private void gvPartOut_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
            {
                downHitInfo = hitInfo;
            }

        }

        private bool checkduplicate(int check)
        {
            List<int> duplicates = new List<int>();
            for (int i = 0; i < gvPartOut.RowCount; i++)
            {
                duplicates.Add(int.Parse(gvPartOut.GetRowCellValue(i, "IDJIG").ToString()));
            }
            if (duplicates.Count > 0 && duplicates.Contains(check))
                return true;
            return false;
        }

        private void gcPartOut_DragDrop(object sender, DragEventArgs e)
        {
            if (checkduplicate(_idtemp))
            {
                _idtemp = 0;
                return;
            }

            if (_currentBalance <= 0)
            {
                MessageBox.Show("This part does not avaliable", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                //row.Delete();
            }

        }

        private void gcPartOut_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        #endregion


        private async void gvPartOut_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "BALANCE")
            {
                int id = int.Parse(gvPartOut.GetFocusedRowCellValue("IDJIG").ToString());
                INFO_JIG _JIG = new INFO_JIG();
                maxQtyOut = await _JIG.getBalancebyID(id);
                int qtyOut = int.Parse(e.Value.ToString());

                if (qtyOut < 0 || qtyOut > maxQtyOut)
                {
                    MessageBox.Show(string.Format("you only can out max {0} PCS", maxQtyOut), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gvPartOut.SetRowCellValue(gvPartOut.FocusedRowHandle, "BALANCE", maxQtyOut);
                }
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
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

        private void btnPartIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_ToolJigInOut frm = new fFunc_ToolJigInOut();
            frm.Text = "TOOLS & JIGS";
            frm.groupControl1.Text = "PART IN";
            frm.btnPartOut.Enabled = false;
            frm.tbQRCode.Focus();
            frm.btnDelete.Visible = false;
            frm.ShowDialog();
        }

        private async void btnPartOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_ToolJigInOut frm = new fFunc_ToolJigInOut();
            frm.Text = "TOOLS & JIGS";
            frm.groupControl1.Text = "PART OUT";
            frm.btnPartIn.Enabled = false;
            frm.tbQRCode.Focus();
            frm.panel2.Visible = true;
            await frm.loadCus();
            await frm.loadStaff();
            frm.ShowDialog();
        }

        private void generateQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvJig.RowCount > 0 && gvJig.SelectedRowsCount > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = MyFunc.SanitizePath(gvJig.GetFocusedRowCellValue("PARTNUMBER").ToString()) + "_" +
                   gvJig.GetFocusedRowCellValue("QRCODE").ToString() + ".png";
                saveFile.Filter = "Image Files|*.png";
                string QRCode = gvJig.GetFocusedRowCellValue("QRCODE").ToString();
                string NAME = gvJig.GetFocusedRowCellValue("NAME").ToString();
                string DESCRIPTION = gvJig.GetFocusedRowCellValue("DESCRIPTION").ToString();
                string PARTNUMBER = gvJig.GetFocusedRowCellValue("PARTNUMBER").ToString();
                string LOCATION = gvJig.GetFocusedRowCellValue("LOCATION").ToString();
                string printQRCode = QRCode + ".\r\nName : " + NAME + "\r\nDescription : "
                    + DESCRIPTION + "\r\nPartnumber : " + PARTNUMBER + "\r\nLocation : " + LOCATION;
                string Caption = PARTNUMBER;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    var pathsave = new FileInfo(saveFile.FileName);
                    Bitmap qrCode = MyFunc.GenerateQRCodeBitmap(printQRCode);
                    Bitmap finalImage = MyFunc.AddTextBelowQRCode(qrCode, Caption, Color.White);

                    finalImage.Save(pathsave.ToString());
                }

            }
        }

        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (gvJig.SelectedRowsCount > 0)
            {
                if (MessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _jig.Delete(int.Parse(gvJig.GetFocusedRowCellValue("IDJIG").ToString()));
                    await this.loadJig();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A JIG : {0}", gvJig.GetFocusedRowCellValue("IDJIG").ToString());
                }
            }
        }

        private void gvJig_ParseFindPanelText(object sender, DevExpress.Data.ParseFindPanelTextEventArgs e)
        {
            if (e.FindPanelText.Contains("."))
            {
                gcJig.Focus();
                gvJig.FindFilterText = e.FindPanelText.Substring(0, e.FindPanelText.IndexOf("."));
            }
        }

        private async void btnGenerateAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (FolderBrowserDialog openFile = new FolderBrowserDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (gvJig.RowCount > 0)
                        await this.printQRCode(openFile.SelectedPath);
                }
            }

        }

        private async Task printQRCode(string selectedPath)
        {
            int start = 0;
            int end = gvJig.RowCount - 1;

            int numThreads = 5;
            int rangePerThread = Math.Max(1, (int)Math.Ceiling((double)((Convert.ToDouble(end) - Convert.ToDouble(start) + 1.0) / Convert.ToDouble(numThreads))));
            numThreads = Math.Min(numThreads, (int)Math.Ceiling((double)((Convert.ToDouble(end) - Convert.ToDouble(start) + 1.0) / Convert.ToDouble(rangePerThread))));

            fFunc_ProgressBar _fProgressBar = new fFunc_ProgressBar();
            ProgressbarControl progressbarControll = new ProgressbarControl(_fProgressBar, _fProgressBar.progressBar1);
            progressbarControll.InitProgressBar(0, numThreads);
            Thread thread = new Thread(new ThreadStart(progressbarControll.ThreadProc));
            thread.Start();
            short num = 0;

            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                num++;
                progressbarControll.ReportProgress((int)num, this);

                int threadStart = start + i * rangePerThread;
                int threadEnd = Math.Min(start + (i + 1) * rangePerThread - 1, end);

                tasks[i] = ProcessRangeAsync(threadStart, threadEnd, selectedPath);
            }
            await Task.WhenAll(tasks);

            progressbarControll.ClosedProgressForm(this);

        }

        private async Task ProcessRangeAsync(int start, int end, string selectedPath)
        {
            for (int i = start; i <= end; i++)
            {
                await ProcessIndexAsync(i, selectedPath);
            }
        }

        private async Task ProcessIndexAsync(int i, string selectedPath)
        {
            await Task.Delay(1);
            string QRCode = gvJig.GetRowCellValue(i, "QRCODE").ToString();
            string NAME = gvJig.GetRowCellValue(i, "NAME").ToString();
            string DESCRIPTION = gvJig.GetRowCellValue(i, "DESCRIPTION").ToString();
            string PARTNUMBER = gvJig.GetRowCellValue(i, "PARTNUMBER").ToString();
            string LOCATION = gvJig.GetRowCellValue(i, "LOCATION").ToString();
            string printQRCode = QRCode + ".\r\nName : " + NAME + "\r\nDescription : "
                + DESCRIPTION + "\r\nPartnumber : " + PARTNUMBER + "\r\nLocation : " + LOCATION;
            string Caption = PARTNUMBER;
            string temp = selectedPath + "\\" + MyFunc.SanitizePath(PARTNUMBER) + "_" + QRCode + ".png";
            var pathsave = new FileInfo(temp);
            Bitmap qrCode = MyFunc.GenerateQRCodeBitmap(printQRCode);
            Bitmap finalImage = MyFunc.AddTextBelowQRCode(qrCode, Caption, Color.White);

            finalImage.Save(pathsave.ToString());
        }



        private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_Import _fImport = new fFunc_Import();
            _fImport.ShowDialog();
        }

        private void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_Export _fExport = new fFunc_Export();
            _fExport.ShowDialog();
        }


        private void btnImportbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_Import _fImport = new fFunc_Import();
            _fImport.ShowDialog();
        }

        private void btnExportbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            fFunc_Export _fExport = new fFunc_Export();
            _fExport.ShowDialog();
        }
    }
}