using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Windows.Media;
using ZXing.QrCode.Internal;
using static FMV_SYSTEM_MANAGEMENTS.MyFunc;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFunc_Import : DevExpress.XtraEditors.XtraForm
    {
        public fFunc_Import()
        {
            InitializeComponent();
        }

        FileInfo path = null;

        int sequence = 0;

        private void btnBrower_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file|*.csv;*.xls;*.xlsx;...|All files(*.*)|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = new FileInfo(ofd.FileName);
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(path))
                {
                    var allSheets = package.Workbook.Worksheets.Select(sheet => sheet.Name).ToList();
                    cbSheet.Items.Clear();
                    foreach (var item in allSheets)
                    {
                        cbSheet.Items.Add(item);
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount > 0 &&
                MessageBox.Show("Are you sure to Save this table data to Server?", "INFORM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (cbSheet.Text.ToLower().Contains("jig"))
                {

                    fFunc_ProgressBar _fProgressBar = new fFunc_ProgressBar();
                    ProgressbarControl progressbarControll = new ProgressbarControl(_fProgressBar, _fProgressBar.progressBar1);
                    progressbarControll.InitProgressBar(0, gvList.RowCount);
                    Thread thread = new Thread(new ThreadStart(progressbarControll.ThreadProc));
                    thread.Start();
                    short num = 0;

                    List<T_INFO_JIG> _lstJig = new List<T_INFO_JIG>();
                    INFO_JIG _JIG = new INFO_JIG();
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        num++;
                        progressbarControll.ReportProgress((int)num, this);

                        if (!await _JIG.checkDuplicate(gvList.GetRowCellValue(i, "NAME").ToString().Trim(),
                            gvList.GetRowCellValue(i, "DESCRIPTION").ToString().Trim(),
                            gvList.GetRowCellValue(i, "PARTNUMBER").ToString().Trim()))
                        {
                            T_INFO_JIG _newjig = new T_INFO_JIG();
                            _newjig.QRCODE = gvList.GetRowCellValue(i, "QRCODE").ToString();
                            _newjig.NAME = gvList.GetRowCellValue(i, "NAME").ToString().Trim();
                            _newjig.DESCRIPTION = gvList.GetRowCellValue(i, "DESCRIPTION").ToString().Trim();
                            _newjig.PARTNUMBER = gvList.GetRowCellValue(i, "PARTNUMBER").ToString().Trim();
                            _newjig.RANK = gvList.GetRowCellValue(i, "RANK").ToString().Trim();
                            _newjig.FIXED_ASSET_NO = gvList.GetRowCellValue(i, "FIXED_ASSET_NO").ToString().Trim();
                            object imageData = gvList.GetRowCellValue(i, "PICTURE");
                            if (imageData != null && imageData != DBNull.Value)
                                _newjig.PICTURE = (byte[])imageData;
                            _newjig.QTY = int.Parse(gvList.GetRowCellValue(i, "QTY").ToString().Trim());
                            _newjig.BALANCE = int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString().Trim());
                            _newjig.PO_RQ = gvList.GetRowCellValue(i, "PO_RQ").ToString().Trim();
                            _newjig.QUOTATION = gvList.GetRowCellValue(i, "QUOTATION").ToString().Trim();
                            _newjig.REMARK = gvList.GetRowCellValue(i, "REMARK").ToString().Trim();
                            _newjig.LOCATION = gvList.GetRowCellValue(i, "LOCATION").ToString().Trim();
                            _newjig.CREATE_DATE = DateTime.Now;
                            _newjig.CREATE_BY = 1;
                            _newjig.STATUS = (int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString().Trim()) > 0) ? true : false;
                            _lstJig.Add(_newjig);
                        }
                    }

                    await _JIG.AddRange(_lstJig);
                    COM_SEQUENCE _count = new COM_SEQUENCE();
                    await _count.updateValue("JIGPART", sequence + 1);
                    MessageBox.Show("done!");
                    progressbarControll.ClosedProgressForm(this);
                }
                else if (cbSheet.Text.ToLower().Contains("part"))
                {
                    fFunc_ProgressBar _fProgressBar = new fFunc_ProgressBar();
                    ProgressbarControl progressbarControll = new ProgressbarControl(_fProgressBar, _fProgressBar.progressBar1);
                    progressbarControll.InitProgressBar(0, gvList.RowCount);
                    Thread thread = new Thread(new ThreadStart(progressbarControll.ThreadProc));
                    thread.Start();
                    short num = 0;

                    List<T_INFO_PART> _lstPart = new List<T_INFO_PART>();
                    INFO_PART _PART = new INFO_PART();
                    for (int i = 0; i < gvList.RowCount; i++)
                    {
                        num++;
                        progressbarControll.ReportProgress((int)num, this);

                        if (!await _PART.checkDuplicate(gvList.GetRowCellValue(i, "NAME").ToString().Trim(),
                            gvList.GetRowCellValue(i, "DESCRIPTION").ToString().Trim(),
                            gvList.GetRowCellValue(i, "PARTNUMBER").ToString().Trim()))
                        {
                            T_INFO_PART _newpart = new T_INFO_PART();
                            _newpart.QRCODE = gvList.GetRowCellValue(i, "QRCODE").ToString();
                            _newpart.NAME = gvList.GetRowCellValue(i, "NAME").ToString().Trim();
                            _newpart.DESCRIPTION = gvList.GetRowCellValue(i, "DESCRIPTION").ToString().Trim();
                            _newpart.PARTNUMBER = gvList.GetRowCellValue(i, "PARTNUMBER").ToString().Trim();
                            _newpart.RANK = gvList.GetRowCellValue(i, "RANK").ToString().Trim();
                            _newpart.FIXED_ASSET_NO = gvList.GetRowCellValue(i, "FIXED_ASSET_NO").ToString().Trim();
                            _newpart.QTY = int.Parse(gvList.GetRowCellValue(i, "QTY").ToString().Trim());
                            object imageData = gvList.GetRowCellValue(i, "PICTURE");
                            if (imageData != null && imageData != DBNull.Value)
                                _newpart.PICTURE = (byte[])imageData;
                            _newpart.BALANCE = int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString().Trim());
                            _newpart.PO_RQ = gvList.GetRowCellValue(i, "PO_RQ").ToString().Trim();
                            _newpart.QUOTATION = gvList.GetRowCellValue(i, "QUOTATION").ToString().Trim();
                            _newpart.REMARK = gvList.GetRowCellValue(i, "REMARK").ToString().Trim();
                            _newpart.LOCATION = gvList.GetRowCellValue(i, "LOCATION").ToString().Trim();
                            _newpart.CREATE_DATE = DateTime.Now;
                            _newpart.CREATE_BY = 1;
                            _newpart.STATUS = (int.Parse(gvList.GetRowCellValue(i, "BALANCE").ToString().Trim()) > 0) ? true : false;

                            _lstPart.Add(_newpart);
                        }
                    }

                    await _PART.AddRange(_lstPart);
                    COM_SEQUENCE _count = new COM_SEQUENCE();
                    await _count.updateValue("JIGPART", sequence + 1);
                    MessageBox.Show("done!");
                    progressbarControll.ClosedProgressForm(this);
                }
                else
                {
                    MessageBox.Show("You need to contact FMV-Tai if you want to save this sheet");
                    return;
                }
                this.Close();
            }
        }

        private async void cbSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (path != null)
            {
                using (var package = new ExcelPackage(path))
                {
                    var worksheet = package.Workbook.Worksheets[cbSheet.Text];

                    // Tạo DataTable để lưu trữ dữ liệu từ Excel
                    var dataTable = new System.Data.DataTable();

                    dataTable.Columns.Add("DESCRIPTION", typeof(string));
                    dataTable.Columns.Add("NAME", typeof(string));
                    dataTable.Columns.Add("PARTNUMBER", typeof(string));
                    dataTable.Columns.Add("FIXED_ASSET_NO", typeof(string));
                    dataTable.Columns.Add("RANK", typeof(string));
                    dataTable.Columns.Add("QTY", typeof(int));
                    dataTable.Columns.Add("BALANCE", typeof(int));
                    dataTable.Columns.Add("PICTURE", typeof(byte[]));
                    dataTable.Columns.Add("PO_RQ", typeof(string));
                    dataTable.Columns.Add("QUOTATION", typeof(string));
                    dataTable.Columns.Add("REMARK", typeof(string));
                    dataTable.Columns.Add("LOCATION", typeof(string));
                    dataTable.Columns.Add("QRCODE", typeof(string));

                    int rowCount = worksheet.Dimension.Rows;

                    COM_SEQUENCE _count = new COM_SEQUENCE();
                    sequence = await _count.getSequenceByName("JIGPART");
                    if (cbSheet.Text.ToLower().Contains("jig"))
                    {
                        // Lặp qua từng dòng trong tệp Excel và thêm vào DataTable
                        try
                        {
                            for (int row = 2; row <= rowCount; row++)
                            {
                                if (worksheet.Cells[row, 6].GetValue<string>() != null)
                                {
                                    // Lấy giá trị từ Excel
                                    string Description = worksheet.Cells[row, 1].GetValue<string>();
                                    string Name = worksheet.Cells[row, 2].GetValue<string>();
                                    string PartNumber = worksheet.Cells[row, 3].GetValue<string>();
                                    string Asset = worksheet.Cells[row, 4].GetValue<string>();
                                    string Rank = worksheet.Cells[row, 5].GetValue<string>();
                                    int Qty;
                                    try
                                    {
                                        Qty = worksheet.Cells[row, 6].GetValue<int>();
                                    }
                                    catch { Qty = int.Parse(new string((worksheet.Cells[row, 6].GetValue<string>()).Where(char.IsDigit).ToArray())); }
                                    int Balance;
                                    try
                                    {
                                        Balance = worksheet.Cells[row, 7].GetValue<int>();
                                    }
                                    catch
                                    {
                                        Balance = int.Parse(new string((worksheet.Cells[row, 7].GetValue<string>()).Where(char.IsDigit).ToArray()));
                                    }

                                    Image image = null;
                                    var excelPicture = worksheet.Drawings.FirstOrDefault(
                                        picture => picture.From.Row == (row - 1) && picture.From.Column == 7) as ExcelPicture;

                                    if (excelPicture != null)
                                    {
                                        using (MemoryStream ms = new MemoryStream(excelPicture.Image.ImageBytes))
                                        {
                                            image = Image.FromStream(ms);
                                        }
                                    }

                                    string PO = worksheet.Cells[row, 9].GetValue<string>();
                                    string Quotation = worksheet.Cells[row, 10].GetValue<string>();
                                    string Remarks = worksheet.Cells[row, 11].GetValue<string>() + "\t\r\n" + worksheet.Cells[row, 13].GetValue<string>();
                                    string Location = worksheet.Cells[row, 12].GetValue<string>();
                                    string Barcode = sequence.ToString();

                                    // Tạo một dòng mới cho DataTable
                                    var dataRow = dataTable.NewRow();
                                    // Thêm giá trị vào dòng
                                    dataRow["DESCRIPTION"] = Description;
                                    dataRow["NAME"] = Name;
                                    dataRow["PARTNUMBER"] = PartNumber;
                                    dataRow["FIXED_ASSET_NO"] = Asset;
                                    dataRow["RANK"] = Rank;
                                    dataRow["QTY"] = Qty;
                                    dataRow["BALANCE"] = Balance;

                                    if (excelPicture != null)
                                        dataRow["PICTURE"] = MyFunc.ImageToByteArray(image);//excelPicture.Image.ImageBytes;//MyFunc.ByteArrayToImage(excelPicture.Image.ImageBytes);
                                    dataRow["PO_RQ"] = PO;
                                    dataRow["QUOTATION"] = Quotation;
                                    dataRow["REMARK"] = Remarks;
                                    dataRow["LOCATION"] = Location;
                                    dataRow["QRCODE"] = Barcode;

                                    dataTable.Rows.Add(dataRow);
                                    sequence++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Jig error : {0}", ex.Message);
                            Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Jig error : {0}", ex.StackTrace);
                        }
                    }
                    else if (cbSheet.Text.ToLower().Contains("part"))
                    {
                        try
                        {
                            for (int row = 2; row <= rowCount; row++)
                            {
                                if (worksheet.Cells[row, 6].GetValue<string>() != null)
                                {
                                    // Lấy giá trị từ Excel
                                    string Description = worksheet.Cells[row, 1].GetValue<string>();
                                    string Name = worksheet.Cells[row, 2].GetValue<string>();
                                    string PartNumber = worksheet.Cells[row, 3].GetValue<string>();
                                    string Rank = worksheet.Cells[row, 4].GetValue<string>();
                                    int Qty;
                                    try
                                    {
                                        Qty = worksheet.Cells[row, 5].GetValue<int>();
                                    }
                                    catch { Qty = int.Parse(new string((worksheet.Cells[row, 5].GetValue<string>()).Where(char.IsDigit).ToArray())); }
                                    int Balance;
                                    try
                                    {
                                        Balance = worksheet.Cells[row, 6].GetValue<int>();
                                    }
                                    catch
                                    {
                                        Balance = int.Parse(new string((worksheet.Cells[row, 6].GetValue<string>()).Where(char.IsDigit).ToArray()));
                                    }
                                    //ExcelPicture excelPicture = null;
                                    //var image = worksheet.Drawings.FirstOrDefault(
                                    //    picture => picture.From.Row == (row - 1) && picture.From.Column == 6);

                                    //if (image != null)
                                    //{
                                    //    excelPicture = image as ExcelPicture;
                                    //}

                                    Image image = null;
                                    var excelPicture = worksheet.Drawings.FirstOrDefault(
                                        picture => picture.From.Row == (row - 1) && picture.From.Column == 6) as ExcelPicture;

                                    if (excelPicture != null)
                                    {
                                        using (MemoryStream ms = new MemoryStream(excelPicture.Image.ImageBytes))
                                        {
                                            image = Image.FromStream(ms);
                                        }
                                    }

                                    string PO = worksheet.Cells[row, 8].GetValue<string>();
                                    string Quotation = worksheet.Cells[row, 9].GetValue<string>();
                                    string Remarks = worksheet.Cells[row, 10].GetValue<string>() + "\t\r\n" + worksheet.Cells[row, 12].GetValue<string>();
                                    string Location = worksheet.Cells[row, 11].GetValue<string>();
                                    string Barcode = sequence.ToString();

                                    // Tạo một dòng mới cho DataTable
                                    var dataRow = dataTable.NewRow();

                                    // Thêm giá trị vào dòng
                                    dataRow["DESCRIPTION"] = Description;
                                    dataRow["NAME"] = Name;
                                    dataRow["PARTNUMBER"] = PartNumber;
                                    dataRow["RANK"] = Rank;
                                    dataRow["QTY"] = Qty;
                                    dataRow["BALANCE"] = Balance;
                                    if (excelPicture != null)
                                        dataRow["PICTURE"] = MyFunc.ImageToByteArray(image); //excelPicture.Image.ImageBytes;// MyFunc.ByteArrayToImage(excelPicture.Image.ImageBytes);
                                    dataRow["PO_RQ"] = PO;
                                    dataRow["QUOTATION"] = Quotation;
                                    dataRow["REMARK"] = Remarks;
                                    dataRow["LOCATION"] = Location;
                                    dataRow["QRCODE"] = Barcode;

                                    dataTable.Rows.Add(dataRow);
                                    sequence++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Part error : {0}", ex.Message);
                            Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Part error : {0}", ex.StackTrace);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You need to contact FMV-Tai if you want to save this sheet");
                    }

                    gcList.DataSource = dataTable;
                    gvList.OptionsBehavior.Editable = false;
                }
            }
        }

        //public Image ConvertExcelImageToSystemDrawingImage(ExcelImage excelImage)
        //{
        //    byte[] imageBytes = excelImage.ImageBytes;
        //    using (MemoryStream ms = new MemoryStream(imageBytes))
        //    {
        //        Image image = Image.FromStream(ms);
        //        return image;
        //    }
        //}

        //public static Image GetImage(string sheetname, ExcelPackage excelFile)
        //{
        //    var sheet = excelFile.Workbook.Worksheets[sheetname];
        //    var pic = sheet.Drawings["pic_001"] as ExcelPicture;
        //    return MyFunc.ByteArrayToImage(pic.Image.ImageBytes);
        //}

        //private static bool RowContainsImages(ExcelWorksheet worksheet, int row)
        //{
        //    foreach (var drawing in worksheet.Drawings)
        //    {
        //        if ((drawing.From.Row == row && drawing.From != null) || (drawing.To != null && drawing.To.Row == row))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

    }
}