//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FMV_SYSTEM_MANAGEMENTS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_INFO_FMV_STK
    {
        public int IDFMVSTK { get; set; }
        public string MCTYPE { get; set; }
        public string STATUS { get; set; }
        public string PARTNO { get; set; }
        public string DESCRIPTION { get; set; }
        public string SERIALNO { get; set; }
        public string RATING { get; set; }
        public Nullable<int> BALANCE { get; set; }
        public Nullable<decimal> UNIT_COST { get; set; }
        public string REMARK { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> UPDATE_BY { get; set; }
        public Nullable<bool> READY { get; set; }
        public string QRCODE { get; set; }
    }
}
