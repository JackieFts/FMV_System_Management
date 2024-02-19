using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using FMV_SYSTEM_MANAGEMENTS.Controlers;
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
    public partial class fHis_PartOut : DevExpress.XtraEditors.XtraForm
    {
        public fHis_PartOut()
        {
            InitializeComponent();
        }

        COM_CUSTOMER _customer;
        V_HIS_PARTOUT _viewHisPartOut;

        public bool checkLoaded = false;

        private void fHisPartOut_Load(object sender, EventArgs e)
        {
            
            //await loadView();
        }

        public async Task loadView()
        {
            _viewHisPartOut = new V_HIS_PARTOUT();
            gcPartOut.DataSource = await _viewHisPartOut.getAll();
            gvPartOut.OptionsBehavior.Editable = false;
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


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await loadView();
        }

        private void gvPartOut_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue != null)
            {
                if (e.Column.Name == "STATUS" && bool.Parse(e.CellValue.ToString()) == true)
                {
                    Image img = Properties.Resources.icons8_x_16;
                    e.Graphics.DrawImage(img, e.Bounds.Width / 2, e.Bounds.Y);
                    e.Handled = true;
                }
                else if (e.Column.Name == "STATUS" && bool.Parse(e.CellValue.ToString()) == false)
                {
                    Image img = Properties.Resources.icons8_tick_16;
                    e.Graphics.DrawImage(img, e.Bounds.Width / 2, e.Bounds.Y);
                    e.Handled = true;
                }
            }
        }

        private async void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show("Invalid datetime");
                return;
            }
            else
            {
                await loadList();
            }
        }

        private async void dtFrom_Leave(object sender, EventArgs e)
        {
            if (dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show("Invalid datetime");
                return;
            }
            else
            {
                await loadList();
            }
        }

        private async void dtTo_Leave(object sender, EventArgs e)
        {
            if (dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show("Invalid datetime");
                return;
            }
            else
            {
                await loadList();
            }
        }

        private async void dtTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtFrom.Value > dtTo.Value)
            {
                MessageBox.Show("Invalid datetime");
                return;
            }
            else
            {
                await loadList();
            }
        }

        private async Task loadList()
        {
            if (checkLoaded)
            {
                _viewHisPartOut = new V_HIS_PARTOUT();
                var result = await _viewHisPartOut.getByCon(dtFrom.Value, dtTo.Value, cbCustomer.SelectedValue.ToString());
                gcPartOut.DataSource = result;
                gvPartOut.OptionsBehavior.Editable = false;
            }
        }

        private async void cbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            await loadList();
        }
    }
}