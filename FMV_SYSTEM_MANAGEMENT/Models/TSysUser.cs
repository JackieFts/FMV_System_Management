using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_SYS_USER")]
    public partial class TSysUser
    {
        [Key]
        [Column("IDUSER")]
        public int Iduser { get; set; }
        [Key]
        [Column("IDSTAFF")]
        public int Idstaff { get; set; }
        [Column("USERNAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; }
        [Column("PASSWD")]
        [StringLength(50)]
        [Unicode(false)]
        public string Passwd { get; set; }
        [Column("FULLNAME")]
        [StringLength(255)]
        public string Fullname { get; set; }
        [Column("LAST_PWD_CHANGED", TypeName = "datetime")]
        public DateTime? LastPwdChanged { get; set; }
        [Column("ISGROUP")]
        public bool? Isgroup { get; set; }
    }
}
