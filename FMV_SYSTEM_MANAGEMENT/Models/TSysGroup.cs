using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_SYS_GROUP")]
    public partial class TSysGroup
    {
        [Key]
        [Column("GROUP")]
        public int Group { get; set; }
        [Key]
        [Column("MEMBER")]
        public int Member { get; set; }
    }
}
