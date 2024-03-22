using DevExpress.Utils;
using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
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
    public partial class fFunc_JigPart : DevExpress.XtraEditors.XtraForm
    {
        public fFunc_JigPart()
        {
            InitializeComponent();
        }

        //COM_STAFF _staff;
        //COM_CUSTOMER _customer;
        INFO_JIG _jig;


        bool Drag = false;
        Point Point = new Point(0, 0);
        int zoomFacet = 150;
        public bool _add;
        public int _idjig = 0;

        #region FE
        private void btnQuit_Click(object sender, EventArgs e)
        {
            _add = false;
            this.Close();
        }

        private void tbBalance_ValueChanged(object sender, EventArgs e)
        {
            if (tbBalance.Value > tbQty.Value)
            {
                tbBalance.Value = tbQty.Value;
            }
        }

        private void pictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            if (pictureEdit1.Image != null)
                flyoutPanel1.ShowPopup();
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            if (pictureEdit1.Image != null)
                flyoutPanel1.HidePopup();
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureEdit1.Image != null)
            {
                if (!flyoutPanel1.IsPopupOpen)
                    flyoutPanel1.ShowPopup();
                Point offsetLocation = pictureEdit1.ViewportToImage(e.Location);

                offsetLocation.X -= zoomFacet / 2;
                offsetLocation.Y -= zoomFacet / 2;

                offsetLocation.X = offsetLocation.X + zoomFacet > pictureEdit1.Image.Width
                    ? pictureEdit1.Image.Width - zoomFacet : offsetLocation.X;
                offsetLocation.X = offsetLocation.X < 0 ? 0 : offsetLocation.X;
                offsetLocation.Y = offsetLocation.Y + zoomFacet > pictureEdit1.Image.Height
                    ? pictureEdit1.Image.Height - zoomFacet : offsetLocation.Y;
                offsetLocation.Y = offsetLocation.Y < 0 ? 0 : offsetLocation.Y;

                try
                {
                    pictureEdit2.Image = cropImage(pictureEdit1.Image,
                        new Rectangle(offsetLocation, new Size(zoomFacet, zoomFacet)));
                }
                catch
                {
                    try
                    {
                        Image resizedImage = ResizeImage(pictureEdit1.Image, 150, 150);
                        pictureEdit2.Image = cropImage(resizedImage,
                            new Rectangle(offsetLocation, new Size(zoomFacet, zoomFacet)));
                    }
                    catch
                    {
                        try
                        {
                            Image resizedImage = ResizeImage(pictureEdit1.Image, 60, 60);
                            pictureEdit2.Image = cropImage(resizedImage,
                                new Rectangle(offsetLocation, new Size(zoomFacet, zoomFacet)));
                        }
                        catch { }
                    }
                }
            }
        }

        public static Bitmap ResizeImage(Image originalImage, int newWidth, int newHeight)
        {
            // Create a new Bitmap with the desired dimensions
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            // Create a Graphics object to draw on the new Bitmap
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // Set the interpolation mode for better quality
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new Bitmap with the desired dimensions
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            using (Bitmap bmpImage = new Bitmap(img))
            {
                return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            }

        }

        private void groupControl1_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }

        private void groupControl1_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            Point = new Point(e.X, e.Y);
        }

        private void groupControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - Point.X, p.Y - Point.Y);
            }
        }
        #endregion

        private void fInfo_JigPart_Load(object sender, EventArgs e)
        {
            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Size = new Size(700, 700);
            flyoutPanel1.Options.Location = new Point(250, 0);
            flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual;
            flyoutPanel1.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;


            //await this.loadStaff();
            //await this.loadCus();
            _jig = new INFO_JIG();
        }

        public async Task loadStaff()
        {
            COM_STAFF _staff = new COM_STAFF();
            var data = await _staff.getAll();
            data.Add(new Models.T_COM_STAFF()
            {
                IDSTAFF = 0,
                STAFFNAME = ""
            });
            tbEngineer.DataSource = data;
            tbEngineer.DisplayMember = "STAFFNAME";
            tbEngineer.ValueMember = "IDSTAFF";
        }

        public async Task loadCus()
        {
            COM_CUSTOMER _customer = new COM_CUSTOMER();
            var data = await _customer.getAll();
            data.Add(new Models.T_COM_CUSTOMER()
            {
                IDCUSTOMER = "",
                CUSTOMERNAME = ""
            });
            tbCustomer.DataSource = data;
            tbCustomer.DisplayMember = "CUSTOMERNAME";
            tbCustomer.ValueMember = "IDCUSTOMER";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_add)
            {
                if (tbName.Text == "" || tbPartnumber.Text == "" || tbLocation.Text == "")
                {
                    XtraMessageBox.Show("Pls Type info first !");
                }
                else
                {
                    COM_SEQUENCE _count = new COM_SEQUENCE();
                    int sequence = await _count.getSequenceByName("JIGPART");
                    T_INFO_JIG _newjig = new T_INFO_JIG();
                    _newjig.QRCODE = sequence.ToString();
                    _newjig.NAME = tbName.Text;
                    _newjig.DESCRIPTION = tbDescription.Text;
                    _newjig.PARTNUMBER = tbPartnumber.Text;
                    _newjig.RANK = tbRank.Text;
                    _newjig.FIXED_ASSET_NO = tbAsset.Text;
                    _newjig.QTY = Convert.ToInt32(tbQty.Value.ToString());
                    _newjig.BALANCE = Convert.ToInt32(tbBalance.Value.ToString());
                    _newjig.PO_RQ = tbPO.Text;
                    _newjig.QUOTATION = tbQuotation.Text;
                    _newjig.REMARK = tbRemark.Text;
                    _newjig.LOCATION = tbLocation.Text;
                    if (tbEngineer.Text != "")
                        _newjig.IDSTAFF = int.Parse(tbEngineer.SelectedValue.ToString());
                    if (tbCustomer.Text != "")
                        _newjig.IDCUSTOMER = tbCustomer.SelectedValue.ToString();
                    _newjig.CREATE_DATE = DateTime.Now;
                    _newjig.CREATE_BY = 1;
                    if (tbBalance.Value > 0)
                        _newjig.STATUS = true;
                    else
                        _newjig.STATUS = false;
                    if (pictureEdit1.Image != null)
                    {
                        byte[] imageBytes = MyFunc.ImageToByteArray(pictureEdit1.Image);
                        _newjig.PICTURE = imageBytes;
                    }

                    await _jig.Add(_newjig);

                    await _count.updateValue("JIGPART", sequence + 1);

                    fInfo_Jigs frm = (fInfo_Jigs)Application.OpenForms["fInfo_Jigs"];
                    await frm.loadJig();
                }
            }
            else
            {
                T_INFO_JIG _newjig = await _jig.getByID(_idjig);
                _newjig.NAME = tbName.Text;
                _newjig.DESCRIPTION = tbDescription.Text;
                _newjig.PARTNUMBER = tbPartnumber.Text;
                _newjig.RANK = tbRank.Text;
                _newjig.FIXED_ASSET_NO = tbAsset.Text;
                _newjig.QTY = Convert.ToInt32(tbQty.Value.ToString());
                _newjig.BALANCE = Convert.ToInt32(tbBalance.Value.ToString());
                _newjig.PO_RQ = tbPO.Text;
                _newjig.QUOTATION = tbQuotation.Text;
                _newjig.REMARK = tbRemark.Text;
                _newjig.LOCATION = tbLocation.Text;
                if (tbEngineer.Text != "")
                    _newjig.IDSTAFF = int.Parse(tbEngineer.SelectedValue.ToString());
                if (tbCustomer.Text != "")
                    _newjig.IDCUSTOMER = tbCustomer.SelectedValue.ToString();
                _newjig.UPDATE_DATE = DateTime.Now;
                _newjig.UPDATE_BY = 1;
                if (tbBalance.Value > 0)
                    _newjig.STATUS = true;
                else
                    _newjig.STATUS = false;
                
                {
                    if (pictureEdit1.Image != null)
                    {
                        byte[] imageBytes = MyFunc.ImageToByteArray(pictureEdit1.Image);
                        _newjig.PICTURE = imageBytes;
                    }
                }

                await _jig.Update(_newjig);

                _add = false;
                fInfo_Jigs frm = (fInfo_Jigs)Application.OpenForms["fInfo_Jigs"];
                if (frm != null)
                    await frm.loadJig();

                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fInfo_Jigs _jiginfo = (fInfo_Jigs)Application.OpenForms["fInfo_Jigs"];
            _add = false;
            _jiginfo._idjig = 0;
            this.Close();
        }
    }
}