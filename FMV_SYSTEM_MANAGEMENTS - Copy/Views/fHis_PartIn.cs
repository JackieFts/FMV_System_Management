using DevExpress.XtraEditors;
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
    public partial class fHis_PartIn : DevExpress.XtraEditors.XtraForm
    {
        public fHis_PartIn()
        {
            InitializeComponent();
        }

        V_HIS_PARTIN _viewHisPartIn;
        public bool checkLoaded = false;

        private void fHisPartIn_Load(object sender, EventArgs e)
        {

        }

        public async Task loadView()
        {
            _viewHisPartIn = new V_HIS_PARTIN();
            gcPartIn.DataSource = await _viewHisPartIn.getAll();
            gvPartIn.OptionsBehavior.Editable = false;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await loadView();
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

        private async Task loadList()
        {
            if (checkLoaded)
            {
                _viewHisPartIn = new V_HIS_PARTIN();
                var result = await _viewHisPartIn.getByCon(dtFrom.Value, dtTo.Value);
                gcPartIn.DataSource = result;
                gvPartIn.OptionsBehavior.Editable = false;
            }
        }
    }
}