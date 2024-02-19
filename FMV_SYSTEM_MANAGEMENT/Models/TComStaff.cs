using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_COM_STAFF")]
    public partial class TComStaff
    {
        [Key]
        [Column("IDSTAFF")]
        public int Idstaff { get; set; }
        [Column("STAFFNAME")]
        [StringLength(100)]
        public string Staffname { get; set; }
        [Column("DEPARTMENT")]
        [StringLength(10)]
        public string Department { get; set; }
        [Column("POSITION")]
        [StringLength(100)]
        public string Position { get; set; }
        [Column("CCCD")]
        [StringLength(20)]
        public string CCCD { get; set; }
        [Column("PHONE")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
