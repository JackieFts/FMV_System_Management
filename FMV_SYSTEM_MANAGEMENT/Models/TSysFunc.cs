using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_SYS_FUNC")]
    public partial class TSysFunc
    {
        [Key]
        [Column("FUNC_CODE")]
        [StringLength(50)]
        public string FuncCode { get; set; }
        [Key]
        [Column("SORT")]
        public int Sort { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(200)]
        public string Description { get; set; }
        [Column("ISGROUP")]
        public bool? Isgroup { get; set; }
        [Column("PARENT")]
        [StringLength(50)]
        public string Parent { get; set; }
        [Column("MENU")]
        public bool? Menu { get; set; }
        [Column("TIPS")]
        public string Tips { get; set; }
    }
}
