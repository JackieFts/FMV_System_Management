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
    
    public partial class T_HIS_PARTOUT
    {
        public int IDOUT { get; set; }
        public int IDJIGPART { get; set; }
        public string CATEGORY { get; set; }
        public string QRCODE { get; set; }
        public string QRCODESUB { get; set; }
        public string NAME { get; set; }
        public string PARTNUMBER { get; set; }
        public string LOCATION { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<int> SAVEQTY { get; set; }
        public Nullable<System.DateTime> DATEOUT { get; set; }
        public Nullable<System.DateTime> ESTIMATEDIN { get; set; }
        public int IDUSER { get; set; }
        public string IDCUSTOMER { get; set; }
        public string REMARK { get; set; }
        public Nullable<bool> STATUS { get; set; }
    }
}
