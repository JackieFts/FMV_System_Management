using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_SYS_RIGHT")]
    public partial class TSysRight
    {
        [Key]
        [Column("FUNC_CODE")]
        [StringLength(50)]
        public string FuncCode { get; set; }
        [Key]
        [Column("IDUSER")]
        public int Iduser { get; set; }
        [Column("USER_RIGHT")]
        public int? UserRight { get; set; }
    }
}
