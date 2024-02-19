using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_INFO_JIG")]
    public partial class TInfoJig
    {
        [Key]
        [Column("IDJIG")]
        public int Idjig { get; set; }
        [Required]
        [Column("QRCODE")]
        [StringLength(8)]
        public string Qrcode { get; set; }
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(2000)]
        public string Description { get; set; }
        [Column("PARTNUMBER")]
        [StringLength(50)]
        public string Partnumber { get; set; }
        [Column("RANK")]
        [StringLength(50)]
        public string Rank { get; set; }
        [Column("FIXED_ASSET_NO")]
        [StringLength(50)]
        public string FixedAssetNo { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("BALANCE")]
        public int? Balance { get; set; }
        [Column("PICTURE")]
        public byte[] Picture { get; set; }
        [Column("PO_RQ")]
        [StringLength(50)]
        public string PoRq { get; set; }
        [Column("QUOTATION")]
        [StringLength(50)]
        public string Quotation { get; set; }
        [Column("REMARK")]
        [StringLength(2000)]
        public string Remark { get; set; }
        [Required]
        [Column("LOCATION")]
        [StringLength(50)]
        public string Location { get; set; }
        [Column("IDSTAFF")]
        public int Idstaff { get; set; }
        [Required]
        [Column("IDCUSTOMER")]
        [StringLength(10)]
        public string Idcustomer { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("CREATE_BY")]
        public int? CreateBy { get; set; }
        [Column("UPDATE_DATE", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("UPDATE_BY")]
        public int? UpdateBy { get; set; }
        [Column("STATUS")]
        public bool? Status { get; set; }
    }
}
