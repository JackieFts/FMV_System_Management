using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS.Models.CustomModels
{
    public class OBJ_T_INFO_FMA_STK
    {
        public int IDFMASTK { get; set; }
        public string MCTYPE { get; set; }
        public string STATUS { get; set; }
        public string PRODCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string RATING { get; set; }
        public string SERIAL { get; set; }
        public Nullable<int> BALANCE { get; set; }
        public Nullable<decimal> UNIT_COST_SGD { get; set; }
        public string REMARK { get; set; }
        public string DIFF { get; set; }
        //IN
        public string CATEGORY { get; set; }
        public Nullable<int> QTY { get; set; }
        public string QTY_UNIT { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public string LOCATION_SHELFNO { get; set; }
        public string BOXNO { get; set; }
        public string FMVTJ_CODE { get; set; }
        public string RACK { get; set; }
        public string IN_REMARK { get; set; }
        //OUT
        public Nullable<int> OUT_QTY { get; set; }
        public Nullable<System.DateTime> OUT_DATE { get; set; }
        public string OUT_RACK { get; set; }
        public string HISTORY { get; set; }
        public string OUT_REMARK { get; set; }
    }
}
