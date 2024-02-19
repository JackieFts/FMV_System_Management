using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FMV_SYSTEM_MANAGEMENTS.MyFunc;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fInfo_Parts : DevExpress.XtraEditors.XtraForm
    {
        public fInfo_Parts()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        COM_STAFF _staff;
        COM_CUSTOMER _customer;
        INFO_PART _part;
        HIS_PARTOUT _partout;
        GridHitInfo downHitInfo = null;

        private int selectedRowHandle = GridControl.InvalidRowHandle;
        //bool _add;
        public int _idpart = 0;
        int _idtemp = 0;
        int _currentBalance = 0;
        int maxQtyOut = 0;

        private void fInfo_Parts_Load(object sender, EventArgs e)
        {
            dtEstimate.Value = DateTime.Now.AddDays(30);
        }

        public async Task loadPart()
        {
            _part = new INFO_PART();
            DataTable dt = new DataTable();
            dt = MyFunc.ConvertToDataTable(await _part.getAll());
            gcPart.DataSource = dt;
            //gcJig.RefreshDataSource();
            gvPart.OptionsBehavior.Editable = false;
            gvPart.ClearSelection();

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
            if (_idpart > 0)
            {
                fFunc_JigPart _jigpart = new fFunc_JigPart();

                _jigpart._add = false;
                _jigpart._idjig = _idpart;
                await loadDatatoForm(_jigpart);
                loadEnable(_jigpart, true);

                _jigpart.ShowDialog();
                _idpart = 0;
            }
            else
            {
                MessageBox.Show("Pls click into row data first and then click Update !");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_idpart > 0)
            {
                if (MessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _part.Delete(_idpart);
                    await this.loadPart();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A Staff : {0}", _idpart);
                    _idpart = 0;
                }
            }
            else
            {
                MessageBox.Show("Pls click into row data first and then click Delete !");
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Clear Database ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MyFunc.truncateTable("dbo.T_INFO_PART");
                await loadPart();
            }
        }

        private async void btnOut_Click(object sender, EventArgs e)
        {
            _partout = new HIS_PARTOUT();
            _part = new INFO_PART();
            T_HIS_PARTOUT _lstPartOut;
            COM_SEQUENCE _count;

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
                                _lstPartOut.IDJIGPART = int.Parse(gvPartOut.GetRowCellValue(i, "IDPART").ToString());
                                _lstPartOut.CATEGORY = "T_INFO_PART";
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

                                int balance = await _part.getBalancebyID(int.Parse(gvPartOut.GetRowCellValue(i, "IDPART").ToString()));
                                int update = balance - int.Parse(gvPartOut.GetRowCellValue(i, "BALANCE").ToString());

                                var result = await _part.getByID(int.Parse(gvPartOut.GetRowCellValue(i, "IDPART").ToString()));
                                result.BALANCE = update;
                                if (update == 0)
                                    result.STATUS = false;
                                result.IDCUSTOMER = cbCustomer.SelectedValue.ToString();
                                result.IDSTAFF = int.Parse(cbStaff.SelectedValue.ToString());
                                await _part.Update(result);
                            }
                        });
                    }
                    await _count.updateValue("OUT", sequence + 1);
                    await loadPart();
                    tbRemark.Text = "";
                    cbStaff.Text = "";
                    cbCustomer.Text = "";

                    MessageBox.Show("done");
                }
            }
        }

        private async void gvPart_DoubleClick(object sender, EventArgs e)
        {
            if (gvPart.RowCount > 0)
            {
                fFunc_JigPart _jigpart = new fFunc_JigPart();

                await loadDatatoForm(_jigpart);
                loadEnable(_jigpart, false);

                _jigpart.ShowDialog();
                _idpart = 0;
            }
        }

        private void gvPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPart.RowCount > 0)
                    _idpart = int.Parse(gvPart.GetFocusedRowCellValue("IDPART").ToString());
            }
            catch (Exception ex)
            {
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvPart Click error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "gvPart Click error : {0}", ex.StackTrace);
            }
        }

        private async Task loadDatatoForm(fFunc_JigPart _jigpart)
        {
            await _jigpart.loadStaff();
            await _jigpart.loadCus();
            _jigpart.tbName.Text = gvPart.GetFocusedRowCellValue("NAME").ToString();
            _jigpart.tbDescription.Text = gvPart.GetFocusedRowCellValue("DESCRIPTION").ToString();
            _jigpart.tbPartnumber.Text = gvPart.GetFocusedRowCellValue("PARTNUMBER").ToString();
            _jigpart.tbRank.Text = gvPart.GetFocusedRowCellValue("RANK").ToString();
            _jigpart.tbAsset.Text = gvPart.GetFocusedRowCellValue("FIXED_ASSET_NO").ToString();
            _jigpart.tbQty.Value = int.Parse(gvPart.GetFocusedRowCellValue("QTY").ToString());
            _jigpart.tbBalance.Value = int.Parse(gvPart.GetFocusedRowCellValue("BALANCE").ToString());
            _jigpart.tbPO.Text = gvPart.GetFocusedRowCellValue("PO_RQ").ToString();
            _jigpart.tbQuotation.Text = gvPart.GetFocusedRowCellValue("QUOTATION").ToString();
            _jigpart.tbLocation.Text = gvPart.GetFocusedRowCellValue("LOCATION").ToString();
            _jigpart.tbEngineer.SelectedValue = gvPart.GetFocusedRowCellValue("IDSTAFF");
            _jigpart.tbCustomer.SelectedValue = gvPart.GetFocusedRowCellValue("IDCUSTOMER");
            _jigpart.tbRemark.Text = gvPart.GetFocusedRowCellValue("REMARK").ToString();

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
            int _idjigtemp = int.Parse(gvPart.GetRowCellValue(rowHandle, "IDPART").ToString());
            object imageData = (await _part.getByID(_idjigtemp)).PICTURE;

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

        private void gvPart_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            selectedRowHandle = e.RowHandle;
        }

        private void gvPart_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
                BeginInvoke(new MethodInvoker(delegate { MyFunc.cal(_Width, gvPart); }));
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

        private void gvPart_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
        private void gvPart_MouseMove(object sender, MouseEventArgs e)
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

        private void gvPart_MouseDown(object sender, MouseEventArgs e)
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

                _idtemp = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "IDPART").ToString());
                _currentBalance = int.Parse(view.GetRowCellValue(downHitInfo.RowHandle, "BALANCE").ToString());
            }

            //if (gvJig.RowCount > 0)
            //{
            //    _idtemp = int.Parse(gvJig.GetFocusedRowCellValue("IDJIG").ToString());
            //    _currentBalance = int.Parse(gvJig.GetFocusedRowCellValue("BALANCE").ToString());
            //}
        }

        private void gcPart_DragDrop(object sender, DragEventArgs e)
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

        private void gcPart_DragOver(object sender, DragEventArgs e)
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
                duplicates.Add(int.Parse(gvPartOut.GetRowCellValue(i, "IDPART").ToString()));
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
                int id = int.Parse(gvPartOut.GetFocusedRowCellValue("IDPART").ToString());
                INFO_PART _JIG = new INFO_PART();
                maxQtyOut = await _JIG.getBalancebyID(id);
                int qtyOut = int.Parse(e.Value.ToString());

                if (qtyOut < 0 || qtyOut > maxQtyOut)
                {
                    MessageBox.Show(string.Format("you only can out max {0} PCS", maxQtyOut), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gvPartOut.SetRowCellValue(gvPartOut.FocusedRowHandle, "BALANCE", maxQtyOut);
                }
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnPartIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_ToolJigInOut frm = new fFunc_ToolJigInOut();
            frm.Text = "PARTS";
            frm.groupControl1.Text = "PART IN";
            frm.btnPartOut.Enabled = false;
            frm.tbQRCode.Focus();
            frm.btnDelete.Visible = false;
            frm.ShowDialog();
        }

        private async void btnPartOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_ToolJigInOut frm = new fFunc_ToolJigInOut();
            frm.Text = "PARTS";
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
            if (gvPart.RowCount > 0 && gvPart.SelectedRowsCount > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = MyFunc.SanitizePath(gvPart.GetFocusedRowCellValue("PARTNUMBER").ToString()) + "_" +
                   gvPart.GetFocusedRowCellValue("QRCODE").ToString() + ".png";
                saveFile.Filter = "Image Files|*.png";
                string QRCode = gvPart.GetFocusedRowCellValue("QRCODE").ToString();
                string NAME = gvPart.GetFocusedRowCellValue("NAME").ToString();
                string DESCRIPTION = gvPart.GetFocusedRowCellValue("DESCRIPTION").ToString();
                string PARTNUMBER = gvPart.GetFocusedRowCellValue("PARTNUMBER").ToString();
                string LOCATION = gvPart.GetFocusedRowCellValue("LOCATION").ToString();
                string printQRCode = QRCode + ".\nName : " + NAME + "\nDescription : "
                    + DESCRIPTION + "\nPartnumber : " + PARTNUMBER + "\nLocation : " + LOCATION;
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
            if (gvPart.SelectedRowsCount > 0)
            {
                if (MessageBox.Show("Are you sure to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _part.Delete(int.Parse(gvPart.GetFocusedRowCellValue("IDPART").ToString()));
                    await this.loadPart();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Delete A PART : {0}", gvPart.GetFocusedRowCellValue("IDPART").ToString());
                }
            }
        }

        private void gvPart_ParseFindPanelText(object sender, DevExpress.Data.ParseFindPanelTextEventArgs e)
        {
            if (e.FindPanelText.Contains("."))
            {
                gvPart.Focus();
                gvPart.FindFilterText = e.FindPanelText.Substring(0, e.FindPanelText.IndexOf("."));
            }
        }

        private async void btnGenerateAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FolderBrowserDialog openFile = new FolderBrowserDialog())
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (gvPart.RowCount > 0)
                        await this.printQRCode(openFile.SelectedPath);
                }
            }
        }

        private async Task printQRCode(string selectedPath)
        {
            int start = 0;
            int end = gvPart.RowCount - 1;

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
            string QRCode = gvPart.GetRowCellValue(i, "QRCODE").ToString();
            string NAME = gvPart.GetRowCellValue(i, "NAME").ToString();
            string DESCRIPTION = gvPart.GetRowCellValue(i, "DESCRIPTION").ToString();
            string PARTNUMBER = gvPart.GetRowCellValue(i, "PARTNUMBER").ToString();
            string LOCATION = gvPart.GetRowCellValue(i, "LOCATION").ToString();
            string printQRCode = QRCode + ".\nName : " + NAME + "\nDescription : "
                + DESCRIPTION + "\nPartnumber : " + PARTNUMBER + "\nLocation : " + LOCATION;
            string Caption = PARTNUMBER;
            string temp = selectedPath + "\\" + MyFunc.SanitizePath(PARTNUMBER) + "_" + QRCode + ".png";
            var pathsave = new FileInfo(temp);
            Bitmap qrCode = MyFunc.GenerateQRCodeBitmap(printQRCode);
            Bitmap finalImage = MyFunc.AddTextBelowQRCode(qrCode, Caption, Color.White);

            finalImage.Save(pathsave.ToString());
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_Import _fImport = new fFunc_Import();
            _fImport.ShowDialog();
        }

        private void btnImportbar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_Import _fImport = new fFunc_Import();
            _fImport.ShowDialog();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_Export _fExport = new fFunc_Export();
            _fExport.ShowDialog();
        }

        private void btnExportbar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fFunc_Export _fExport = new fFunc_Export();
            _fExport.ShowDialog();
        }

        private void btnExitbar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}