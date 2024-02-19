using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMV_SYSTEM_MANAGEMENT.Models
{
    [Table("T_COM_SEQUENCE")]
    public partial class TComSequence
    {
        [Key]
        [Column("SEQNAME")]
        [StringLength(10)]
        public string Seqname { get; set; }
        [Column("SEQVALUE")]
        public int Seqvalue { get; set; }
    }
}
