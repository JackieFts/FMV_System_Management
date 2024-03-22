using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
    public partial class fTest1 : DevExpress.XtraEditors.XtraForm
    {
        public fTest1()
        {
            InitializeComponent();
            //AddDataToDataGridView();
        }

        private void createColumn( DataGridView dataGridView1, string _header, string _name)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = _header;
            column.Name = _name;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns.Add(column);
        }

        private void AddDataToDataGridView()
        {
            // Add columns to the DataGridView

            createColumn(dataGridView1, "Column 1", "Column1");
            createColumn(dataGridView1, "Column 2", "Column2");
            createColumn(dataGridView1, "Column 3", "Column3");


            //dataGridView1.Columns.Add("Column1", "Column 1");
            //dataGridView1.Columns.Add("Column2", "Column 2");
            //dataGridView1.Columns.Add("Column3", "Column 3");

            // Add rows to the DataGridView
            dataGridView1.Rows.Add("Row 1 Data 1", "Row 1 Data 2", "Row 1 Data 3");
            dataGridView1.Rows.Add("Row 2 Data 1", "Row 2 Data 2", "Row 2 Data 3");
            dataGridView1.Rows.Add("Row 3 Data 1", "Row 3 Data 2", "Row 3 Data 3");

            // You can also add data dynamically, for example, using a loop
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add($"Dynamic Row {i + 1} Data 1", $"Dynamic Row {i + 1} Data 2", $"Dynamic Row {i + 1} Data 3");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dataGridView1.SortedColumn != null && dataGridView1.SortedColumn.Index == e.ColumnIndex)
            //{
            //    // Reverse the current sort direction
            //    if (dataGridView1.SortOrder == SortOrder.Ascending)
            //    {
            //        dataGridView1.Sort(dataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
            //    }
            //    else
            //    {
            //        dataGridView1.Sort(dataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
            //    }
            //}
            //else
            //{
            //    // Set the column to be sorted and the sort order to ascending
            //    dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], System.ComponentModel.ListSortDirection.Ascending);
            //}
        }

        List<string> lst;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumnName = comboBox1.SelectedItem.ToString();

            //if (selectedColumName != "")
            {
                DataGridViewColumn column = dataGridView1.Columns[dataGridView1.SelectedCells[0].OwningColumn.Name];

                if (selectedColumnName != "Don't Import")
                {
                    if (column != null)
                    {
                        if (!column.Name.Contains("Column"))
                            comboBox1.Items.Add(column.Name);
                        column.Name = selectedColumnName;
                        column.HeaderText = selectedColumnName;
                        comboBox1.Items.Remove(selectedColumnName);
                    }
                }
                else
                {
                    if (column != null)
                    {
                        if (!column.Name.Contains("Column"))
                            comboBox1.Items.Add(column.Name);
                        column.Name = "Column" + (dataGridView1.SelectedCells[0].OwningColumn.Index + 1).ToString();
                        column.HeaderText = "Column " + (dataGridView1.SelectedCells[0].OwningColumn.Index + 1).ToString(); ;
                        //comboBox1.Items.Remove(selectedColumnName);
                    }
                }

            }
        }
        //string selectedColumName = "";
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ConvertDataGridViewToDataTable(dataGridView1);
            if (dt != null)
            {
                for (int i = dt.Columns.Count - 1; i >= 0; i--)
                {
                    DataColumn column = dt.Columns[i];
                    if (column.ColumnName.Contains("Column"))
                        dt.Columns.RemoveAt(i);
                }
                
                gridControl1.DataSource = dt;
            }
        }

        private DataTable ConvertDataGridViewToDataTable(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.Name, column.ValueType ?? typeof(string));
            }

            // Add rows to the DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        private void fTest1_Load(object sender, EventArgs e)
        {
            lst = new List<string>();
            foreach (var item in comboBox1.Items)
            {
                lst.Add(item.ToString());
            }
            
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
                    foreach (var item in allSheets)
                    {
                        cbSheet.Items.Add(item);
                    }
                }
            }
        }

        private void cbSheet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (path != null)
            {
                using (var package = new ExcelPackage(path))
                {
                    var worksheet = package.Workbook.Worksheets[cbSheet.Text];
                    DataTable dataTable = new DataTable();
                    int colCount = worksheet.Dimension.Columns;
                    int rowCount = worksheet.Dimension.Rows;
                    dataGridView1.Columns.Clear();
                    for (int i = 1; i < colCount; i++)
                    {
                        if (worksheet.Cells[1, i].GetValue<string>() != null)
                        {
                            createColumn(dataGridView1, "Column " + i.ToString(), "Column" + i.ToString());
                            dataTable.Columns.Add("Column " + i.ToString());
                        }
                    }
                    


                    //for (int row = 2; row <= rowCount; row++)
                    //{
                    //    if (worksheet.Cells[row, 6].GetValue<string>() != null)
                    //    {
                    //        // Lấy giá trị từ Excel
                    //        string Description = worksheet.Cells[row, 1].GetValue<string>();
                    //        string Name = worksheet.Cells[row, 2].GetValue<string>();
                    //        string PartNumber = worksheet.Cells[row, 3].GetValue<string>();
                    //        string Asset = worksheet.Cells[row, 4].GetValue<string>();
                    //        string Rank = worksheet.Cells[row, 5].GetValue<string>();
                    //        int Qty;
                    //        try
                    //        {
                    //            Qty = worksheet.Cells[row, 6].GetValue<int>();
                    //        }
                    //        catch { Qty = int.Parse(new string((worksheet.Cells[row, 6].GetValue<string>()).Where(char.IsDigit).ToArray())); }
                    //        int Balance;
                    //        try
                    //        {
                    //            Balance = worksheet.Cells[row, 7].GetValue<int>();
                    //        }
                    //        catch
                    //        {
                    //            Balance = int.Parse(new string((worksheet.Cells[row, 7].GetValue<string>()).Where(char.IsDigit).ToArray()));
                    //        }

                        //        Image image = null;
                        //        var excelPicture = worksheet.Drawings.FirstOrDefault(
                        //            picture => picture.From.Row == (row - 1) && picture.From.Column == 7) as ExcelPicture;

                        //        if (excelPicture != null)
                        //        {
                        //            using (MemoryStream ms = new MemoryStream(excelPicture.Image.ImageBytes))
                        //            {
                        //                image = Image.FromStream(ms);
                        //            }
                        //        }

                        //        string PO = worksheet.Cells[row, 9].GetValue<string>();
                        //        string Quotation = worksheet.Cells[row, 10].GetValue<string>();
                        //        string Remarks = worksheet.Cells[row, 11].GetValue<string>() + "\t\r\n" + worksheet.Cells[row, 13].GetValue<string>();
                        //        string Location = worksheet.Cells[row, 12].GetValue<string>();
                        //        string Barcode = sequence.ToString();

                        //        // Tạo một dòng mới cho DataTable
                        //        var dataRow = dataTable.NewRow();
                        //        // Thêm giá trị vào dòng
                        //        dataRow["DESCRIPTION"] = Description;
                        //        dataRow["NAME"] = Name;
                        //        dataRow["PARTNUMBER"] = PartNumber;
                        //        dataRow["FIXED_ASSET_NO"] = Asset;
                        //        dataRow["RANK"] = Rank;
                        //        dataRow["QTY"] = Qty;
                        //        dataRow["BALANCE"] = Balance;

                        //        if (excelPicture != null)
                        //            dataRow["PICTURE"] = MyFunc.ImageToByteArray(image);//excelPicture.Image.ImageBytes;//MyFunc.ByteArrayToImage(excelPicture.Image.ImageBytes);
                        //        dataRow["PO_RQ"] = PO;
                        //        dataRow["QUOTATION"] = Quotation;
                        //        dataRow["REMARK"] = Remarks;
                        //        dataRow["LOCATION"] = Location;
                        //        dataRow["QRCODE"] = Barcode;

                        //        dataTable.Rows.Add(dataRow);
                        //        sequence++;
                        //    }
                        //}
                }
            }
        }
    }
}