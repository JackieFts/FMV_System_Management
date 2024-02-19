using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_HIS_PARTOUT")]
    public partial class THisPartout
    {
        [Key]
        [Column("IDOUT")]
        public int Idout { get; set; }
        [Column("IDJIGPART")]
        public int Idjigpart { get; set; }
        [Required]
        [Column("CATEGORY")]
        [StringLength(50)]
        public string Category { get; set; }
        [Required]
        [Column("QRCODE")]
        [StringLength(8)]
        public string Qrcode { get; set; }
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("PARTNUMBER")]
        [StringLength(50)]
        public string Partnumber { get; set; }
        [Column("LOCATION")]
        [StringLength(50)]
        public string Location { get; set; }
        [Column("QTY")]
        public int? Qty { get; set; }
        [Column("DATEOUT", TypeName = "datetime")]
        public DateTime? Dateout { get; set; }
        [Column("IDUSER")]
        public int Iduser { get; set; }
        [Column("IDCUSTOMER")]
        public int Idcustomer { get; set; }
        [Column("REMARK")]
        [StringLength(2000)]
        public string Remark { get; set; }
    }
}
