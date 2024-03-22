using DevExpress.DataAccess.Native.Data;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Interfaces.Drawing.Image;
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
using System.Windows.Documents;
using System.Windows.Forms;
using static FMV_SYSTEM_MANAGEMENTS.MyFunc;

namespace FMV_SYSTEM_MANAGEMENTS.Views
{
    public partial class fFunc_Export : DevExpress.XtraEditors.XtraForm
    {
        public fFunc_Export()
        {
            InitializeComponent();
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = DateTime.Now.ToString("yyyyMMdd_") + "Tools Jig Summary(FMV).xlsx";
            saveFile.Filter = "Excel Workbook|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                btnExport.Enabled = false;
                var pathsave = new FileInfo(saveFile.FileName);
                var pathfiletemp = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Temp\\TempExport.xlsx");

                File.Copy(pathfiletemp.ToString(), pathsave.ToString(), true);

                switch (radioGroup1.Properties.Items[radioGroup1.SelectedIndex].AccessibleName)
                {
                    case "ToolJig":
                        await exportJig(pathsave);
                        break;
                    case "Part":
                        await exportPart(pathsave);
                        break;
                    case "Both":
                        Task[] tasks = new Task[2];
                        tasks[0] = exportJig(pathsave);
                        tasks[1] = exportPart(pathsave);
                        await Task.WhenAll(tasks);
                        break;
                    default:
                        break;
                }
                btnExport.Enabled = true;
                XtraMessageBox.Show("done");
                this.Close();
            }
        }

        private async Task exportJig(FileInfo pathsave)
        {
            INFO_JIG _jig = new INFO_JIG();
            COM_STAFF _staff = new COM_STAFF();
            var data = await _jig.getAll();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = MyFunc.ConvertToDataTable(data);

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(pathsave);
            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];
            int RowRun = 2;

            fCom_ProgressBar _fProgressBar = new fCom_ProgressBar();
            ProgressbarControl progressbarControll = new ProgressbarControl(_fProgressBar, _fProgressBar.progressBar1);
            progressbarControll.InitProgressBar(0, dt.Rows.Count);
            Thread thread = new Thread(new ThreadStart(progressbarControll.ThreadProc));
            thread.Start();
            short num = 0;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                num++;
                progressbarControll.ReportProgress((int)num, this);

                var result = new Models.T_COM_STAFF();
                try
                {
                    result = await _staff.getByID(int.Parse(dt.Rows[i]["IDSTAFF"].ToString()));
                }
                catch { }
                string staff = "";
                if (result != null)
                {
                    staff = result.STAFFNAME;
                }
                excelWorksheet.Cells["A" + RowRun.ToString()].Value = dt.Rows[i]["DESCRIPTION"].ToString();
                excelWorksheet.Cells["B" + RowRun.ToString()].Value = dt.Rows[i]["NAME"].ToString();
                excelWorksheet.Cells["C" + RowRun.ToString()].Value = dt.Rows[i]["PARTNUMBER"].ToString();
                excelWorksheet.Cells["D" + RowRun.ToString()].Value = dt.Rows[i]["FIXED_ASSET_NO"].ToString();
                excelWorksheet.Cells["E" + RowRun.ToString()].Value = dt.Rows[i]["RANK"].ToString();
                excelWorksheet.Cells["F" + RowRun.ToString()].Value = dt.Rows[i]["QTY"].ToString();
                excelWorksheet.Cells["G" + RowRun.ToString()].Value = dt.Rows[i]["BALANCE"].ToString();
                if (!Convert.IsDBNull(dt.Rows[i]["PICTURE"]))
                {
                    byte[] imageBytes = (byte[])dt.Rows[i]["PICTURE"];
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(imageBytes);
                        ExcelPicture setpicture = excelWorksheet.Drawings.AddPicture($"Photo_{RowRun}", ms);
                        setpicture.SetPosition(RowRun - 1, 0, 7, 20);
                        setpicture.SetSize(80, 80);

                        //excelWorksheet.Cells["H" + RowRun.ToString()].Value = excelWorksheet.Drawings.AddPicture($"Photo_{RowRun}", ms);
                    }
                }
                excelWorksheet.Cells["I" + RowRun.ToString()].Value = dt.Rows[i]["PO_RQ"].ToString();
                excelWorksheet.Cells["J" + RowRun.ToString()].Value = dt.Rows[i]["QUOTATION"].ToString();
                excelWorksheet.Cells["K" + RowRun.ToString()].Value = dt.Rows[i]["REMARK"].ToString();
                excelWorksheet.Cells["L" + RowRun.ToString()].Value = dt.Rows[i]["LOCATION"].ToString();
                excelWorksheet.Cells["M" + RowRun.ToString()].Value = staff;
                RowRun++;
            }

            excelWorksheet.Protection.IsProtected = false;
            excelWorksheet.Protection.AllowSelectLockedCells = false;
            package.Save();

            progressbarControll.ClosedProgressForm(this);
        }
        private async Task exportPart(FileInfo pathsave)
        {
            INFO_PART _jig = new INFO_PART();
            COM_STAFF _staff = new COM_STAFF();
            var data = await _jig.getAll();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = MyFunc.ConvertToDataTable(data);

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(pathsave);
            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[1];
            int RowRun = 2;

            fCom_ProgressBar _fProgressBar = new fCom_ProgressBar();
            ProgressbarControl progressbarControll = new ProgressbarControl(_fProgressBar, _fProgressBar.progressBar1);
            progressbarControll.InitProgressBar(0, dt.Rows.Count);
            Thread thread = new Thread(new ThreadStart(progressbarControll.ThreadProc));
            thread.Start();
            short num = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                num++;
                progressbarControll.ReportProgress((int)num, this);

                var result = new Models.T_COM_STAFF();
                try
                {
                    result = await _staff.getByID(int.Parse(dt.Rows[i]["IDSTAFF"].ToString()));
                }
                catch { }
                string staff = "";
                if (result != null)
                {
                    staff = result.STAFFNAME;
                }
                excelWorksheet.Cells["A" + RowRun.ToString()].Value = dt.Rows[i]["DESCRIPTION"].ToString();
                excelWorksheet.Cells["B" + RowRun.ToString()].Value = dt.Rows[i]["NAME"].ToString();
                excelWorksheet.Cells["C" + RowRun.ToString()].Value = dt.Rows[i]["PARTNUMBER"].ToString();
                //excelWorksheet.Cells["D" + RowRun.ToString()].Value = dt.Rows[i]["FIXED_ASSET_NO"].ToString();
                excelWorksheet.Cells["D" + RowRun.ToString()].Value = dt.Rows[i]["RANK"].ToString();
                excelWorksheet.Cells["E" + RowRun.ToString()].Value = dt.Rows[i]["QTY"].ToString();
                excelWorksheet.Cells["F" + RowRun.ToString()].Value = dt.Rows[i]["BALANCE"].ToString();
                if (!Convert.IsDBNull(dt.Rows[i]["PICTURE"]))
                {
                    byte[] imageBytes = (byte[])dt.Rows[i]["PICTURE"];
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(imageBytes);
                        ExcelPicture setpicture = excelWorksheet.Drawings.AddPicture($"Photo_{RowRun}", ms);
                        setpicture.SetPosition(RowRun - 1, 0, 6, 20);
                        setpicture.SetSize(80, 80);

                        //excelWorksheet.Cells["H" + RowRun.ToString()].Value = excelWorksheet.Drawings.AddPicture($"Photo_{RowRun}", ms);
                    }
                }
                excelWorksheet.Cells["H" + RowRun.ToString()].Value = dt.Rows[i]["PO_RQ"].ToString();
                excelWorksheet.Cells["I" + RowRun.ToString()].Value = dt.Rows[i]["QUOTATION"].ToString();
                excelWorksheet.Cells["J" + RowRun.ToString()].Value = dt.Rows[i]["REMARK"].ToString();
                excelWorksheet.Cells["K" + RowRun.ToString()].Value = dt.Rows[i]["LOCATION"].ToString();
                excelWorksheet.Cells["L" + RowRun.ToString()].Value = staff;
                RowRun++;
            }

            excelWorksheet.Protection.IsProtected = false;
            excelWorksheet.Protection.AllowSelectLockedCells = false;
            package.Save();

            progressbarControll.ClosedProgressForm(this);
        }
        private async Task exportBoth()
        {
            await Task.Delay(1);
        }
    }
}