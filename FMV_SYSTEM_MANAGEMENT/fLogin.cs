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
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();
            gvList.ShowFindPanel();
        }

        COM_STAFF _staff;

        public string _Slogan;

        private void fMain_Load(object sender, EventArgs e)
        {
            this.Text = _Slogan;
            _staff = new COM_STAFF();
            loadFunc();
        }

        private async void loadFunc()
        {
            gcList.DataSource = await _staff.getAll();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}