using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace FMV_SYSTEM_MANAGEMENTS
{
    public class MyFunc
    {
        private static SqlConnection conn = new SqlConnection();
        private static string connString = "Data Source=123.24.143.156;Initial Catalog=MyStockDB;User ID=sa;Password=Tai@1234;TrustServerCertificate=True";

        public static bool OpenConnect()
        {
            conn.ConnectionString = connString;
            try
            {
                conn.Open();
                return true;
            }
            catch { return false; }
        }
        public static void CloseConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public static DataTable getDatatoDT(string qr)
        {
            OpenConnect();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = new SqlCommand(qr, conn);
            sqlDataAdapter.Fill(dt);
            CloseConnect();
            return dt;
        }

        public static DataTable ConvertToDataTable<T>(IEnumerable<T> collection)
        {
            DataTable dataTable = new DataTable();

            // Check if the collection is not empty
            if (collection == null || !collection.GetEnumerator().MoveNext())
            {
                //throw new ArgumentException("Collection is empty or null.");
            }

            // Get the properties of the type T
            var properties = typeof(T).GetProperties();

            // Create columns in DataTable based on the properties of type T
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Populate the DataTable with data from the collection
            foreach (var item in collection)
            {
                DataRow row = dataTable.NewRow();

                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static void truncateTable(string tableName)
        {
            conn.ConnectionString = connString;
            try
            {
                conn.Open();

                string truncateTableQuery = "TRUNCATE TABLE " + tableName;
                using (SqlCommand command = new SqlCommand(truncateTableQuery, conn))
                {
                    command.ExecuteNonQuery();
                    Program.log.LogMsg(Logger.LogLevel.INFO, "Table truncated successfully.");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                Program.log.LogMsg(Logger.LogLevel.FATAL, "truncateTable error : {0}", ex.Message);
                Program.log.LogMsg(Logger.LogLevel.FATAL, "truncateTable detail : {0}", ex.StackTrace);
            }
        }

        public static bool cal(Int32 _Width, GridView _view)
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _Width ? _Width : _view.IndicatorWidth;
            return true;
        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Image newImage = new Bitmap(image);
                newImage.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Bitmap GenerateQRCodeBitmap(string data)
        {
            // Use ZXing.Net library to generate a QR code
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = new ZXing.QrCode.QrCodeEncodingOptions
            {
                Width = 150,
                Height = 150,
            };
            Bitmap qrCodeBitmap = barcodeWriter.Write(data);

            return qrCodeBitmap;

        }

        public static Bitmap AddTextBelowQRCode(Bitmap qrCode, string additionalText, Color backgroundColor)
        {
            int qrCodeWidth = qrCode.Width;
            int qrCodeHeight = qrCode.Height;
            int totalHeight = qrCodeHeight + 30; // Adjust as needed for the space below the QR code

            Bitmap finalImage = new Bitmap(qrCodeWidth, totalHeight);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.DrawImage(qrCode, new Point(0, 0));

                // Add text below QR code with background color
                using (Font font = new Font("Arial", 12))
                using (Brush backgroundBrush = new SolidBrush(backgroundColor))
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    SizeF textSize = g.MeasureString(additionalText, font);
                    int textX = (qrCodeWidth - (int)textSize.Width) / 2;
                    int textY = qrCodeHeight + 5; // Adjust as needed for the distance from the QR code

                    // Draw background rectangle
                    g.FillRectangle(backgroundBrush, new Rectangle(textX, textY, (int)textSize.Width, (int)textSize.Height));

                    // Draw text on top of the background
                    g.DrawString(additionalText, font, textBrush, new Point(textX, textY));
                }
            }

            return finalImage;
        }

        public static DateTime getFirstDayInMonth(int year, int month)
        {
            return new DateTime(year, month, 1, 0, 1, 0);
        }
        public static DateTime getLastDayInMonth(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        #region Progress Bar
        internal class ProgressbarControl
        {
            public ProgressbarControl(Form form, System.Windows.Forms.ProgressBar ProgressBar)
            {
                m_ProgressForm = form;
                m_ProgressBar = ProgressBar;
            }

            public void InitProgressBar(int min, int max)
            {
                m_ProgressBar.Minimum = min;
                m_ProgressBar.Maximum = max;
                m_ProgressBar.Value = min;
            }

            public void ReportProgress(int Progress, Form CallForm)
            {
                CallForm.Invoke(new ProgressbarControl.DelegateReportProgress(SetProgress), new object[]
                {
                Progress
                });
            }

            private void SetProgress(int Progress)
            {
                m_ProgressBar.Value = Progress;
            }

            public void ClosedProgressForm(Form CallForm)
            {
                CallForm.Invoke(new ProgressbarControl.DelegateClosedProgressForm(ClosedForm));
            }

            private void ClosedForm()
            {
                m_ProgressForm.Close();
            }

            public void ThreadProc()
            {
                m_ProgressForm.ShowDialog();
            }

            private Form m_ProgressForm;

            private System.Windows.Forms.ProgressBar m_ProgressBar;

            public delegate void DelegateReportProgress(int Progress);

            public delegate void DelegateClosedProgressForm();
        }
        #endregion

        public static string SanitizePath(string path)
        {
            // Define a regular expression pattern for illegal characters in file or directory names
            string illegalCharactersPattern = "[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]";

            // Replace illegal characters with an underscore
            string sanitizedPath = Regex.Replace(path, illegalCharactersPattern, "_");

            return sanitizedPath;
        }
        public static string RemoveInvalidChars(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}
