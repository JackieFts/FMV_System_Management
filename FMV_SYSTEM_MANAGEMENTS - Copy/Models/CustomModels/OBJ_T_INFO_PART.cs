using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Models.CustomModels
{
    public class OBJ_T_INFO_PART
    {
        public int IDPART { get; set; }
        public string QRCODE { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string PARTNUMBER { get; set; }
        public string RANK { get; set; }
        public string FIXED_ASSET_NO { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<int> BALANCE { get; set; }
        public string PO_RQ { get; set; }
        public string QUOTATION { get; set; }
        public string REMARK { get; set; }
        public string LOCATION { get; set; }
        public Nullable<int> IDSTAFF { get; set; }
        public string IDCUSTOMER { get; set; }
        public Nullable<bool> STATUS { get; set; }
    }
}
