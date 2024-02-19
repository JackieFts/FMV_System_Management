using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENT.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENT
{
    public partial class fDashboard : DevExpress.XtraEditors.XtraForm
    {
        public fDashboard()
        {
            InitializeComponent();
            gvStaff.ShowFindPanel();
            gvCustomer.ShowFindPanel();
        }

        COM_STAFF _staff;
        COM_CUSTOMER _customer;

        private async void fDashboard_Load(object sender, EventArgs e)
        {
            await this.loadStaff();
            await this.loadCus();
        }

        private async Task loadCus()
        {
            _customer = new COM_CUSTOMER();
            gcCustomer.DataSource = await _customer.getAll();
        }

        private async Task loadStaff()
        {
            _staff = new COM_STAFF();
            gcStaff.DataSource = await _staff.getAll();
        }
    }
}