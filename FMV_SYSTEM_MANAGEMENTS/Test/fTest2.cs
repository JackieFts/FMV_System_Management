using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
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

namespace FMV_SYSTEM_MANAGEMENTS.Test
{
    public partial class fTest2 : DevExpress.XtraEditors.XtraForm
    {
        public fTest2()
        {
            InitializeComponent();
        }

        FileInfo path = null;

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
                    File.AppendAllLines("Cus.txt", allSheets);
                    foreach (var item in allSheets)
                    {
                        //cbSheet.Items.Add(item);
                    }
                }
                XtraMessageBox.Show("a excel file already import","Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (path != null)
            {
                using (var package = new ExcelPackage(path))
                {
                    var worksheet = package.Workbook.Worksheets[cbSheet.Text];

                    // Tạo DataTable để lưu trữ dữ liệu từ Excel
                    var dataTable = new System.Data.DataTable();

                    dataTable.Columns.Add("key_parts_number", typeof(string));
                    dataTable.Columns.Add("00", typeof(string));
                    dataTable.Columns.Add("part number full", typeof(string));
                    dataTable.Columns.Add("partsname", typeof(string));
                    dataTable.Columns.Add("description full", typeof(string));
                    dataTable.Columns.Add("Remark-info-notice", typeof(string));
                    dataTable.Columns.Add(" ", typeof(string));
                    dataTable.Columns.Add("function_used", typeof(string));
                    dataTable.Columns.Add("Update", typeof(string));
                    dataTable.Columns.Add("New @Yen Price", typeof(string));
                    dataTable.Columns.Add("Net Weight (g)", typeof(string));

                    int rowCount = worksheet.Dimension.Rows;

                    try
                    {
                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].GetValue<string>() != null && worksheet.Cells[row, 2].GetValue<string>() != null)
                            {
                                // Lấy giá trị từ Excel
                                string key_parts_number = worksheet.Cells[row, 1].GetValue<string>();
                                string a00 = worksheet.Cells[row, 2].GetValue<string>();
                                string PartNumber = worksheet.Cells[row, 3].GetValue<string>();
                                string partsname = worksheet.Cells[row, 4].GetValue<string>();
                                string description = worksheet.Cells[row, 5].GetValue<string>();
                                string Remark = worksheet.Cells[row, 6].GetValue<string>();
                                string space = worksheet.Cells[row, 7].GetValue<string>();
                                string function_used = worksheet.Cells[row, 8].GetValue<string>();
                                string Update = worksheet.Cells[row, 9].GetValue<string>();
                                string Price = worksheet.Cells[row, 10].GetValue<string>();
                                string Weight = worksheet.Cells[row, 11].GetValue<string>();


                                // Tạo một dòng mới cho DataTable
                                var dataRow = dataTable.NewRow();
                                // Thêm giá trị vào dòng
                                dataRow[0] = key_parts_number;
                                dataRow[1] = a00;
                                dataRow[2] = PartNumber;
                                dataRow[3] = partsname;
                                dataRow[4] = description;
                                dataRow[5] = Remark;
                                dataRow[6] = space;
                                dataRow[7] = function_used;
                                dataRow[8] = Update;
                                dataRow[9] = Price;
                                dataRow[10] = Weight;

                                dataTable.Rows.Add(dataRow);

                            }
                        }
                        gcList.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Jig error : {0}", ex.Message);
                        Program.log.LogMsg(Logger.LogLevel.FATAL, "Import Jig error : {0}", ex.StackTrace);
                    }
                }
            }
        }
    }
}