using DevExpress.XtraEditors;
using FMV_SYSTEM_MANAGEMENTS.Controlers.MONTHLY;
using FMV_SYSTEM_MANAGEMENTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMV_SYSTEM_MANAGEMENTS.Views.Monthly
{
    public partial class fMCType : DevExpress.XtraEditors.XtraForm
    {
        public fMCType()
        {
            InitializeComponent();
        }

        REP_MCTYPE _mctype;
        BindingList<T_REP_MCTYPE> _mcList = new BindingList<T_REP_MCTYPE>();

        private async void fMCType_Load(object sender, EventArgs e)
        {
            await loadMCType();
        }

        private async Task loadMCType()
        {
            _mctype = new REP_MCTYPE();
            _mcList = new BindingList<T_REP_MCTYPE>();
            var data = await _mctype.getAll();
            foreach(var item in data)
            {
                _mcList.Add(item);
            }
            gcList.DataSource = _mcList;
        }

        private async void btnOut_Click(object sender, EventArgs e)
        {
            _mctype.TrunCate();
            Thread.Sleep(100);
            var data = gcList.DataSource as BindingList<T_REP_MCTYPE>;
            await _mctype.AddRange(data);
            XtraMessageBox.Show("Save done !");
            this.Close();
        }
    }
}