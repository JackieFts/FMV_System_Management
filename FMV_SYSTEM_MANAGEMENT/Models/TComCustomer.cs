using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_COM_CUSTOMER")]
    public partial class TComCustomer
    {
        [Key]
        [Column("IDCUSTOMER")]
        [StringLength(10)]
        public string Idcustomer { get; set; }
        [Column("CUSTOMERNAME")]
        [StringLength(100)]
        public string Customername { get; set; }
        [Column("CONTACTPERSON")]
        [StringLength(100)]
        public string Contactperson { get; set; }
        [Column("PHONE")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("CREATE_DATE", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("CREATE_BY")]
        public int? CreateBy { get; set; }
        [Column("UPDATE_DATE", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("UPDATE_BY")]
        public int? UpdateBy { get; set; }
    }
}
