using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_SLOGAN")]
    public partial class TSlogan
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("SLOGAN")]
        [StringLength(500)]
        public string Slogan { get; set; }
    }
}
