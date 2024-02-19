using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FMV_SYSTEM_MANAGEMENT.Models;

namespace FMV_SYSTEM_MANAGEMENT.Repository
{
    public partial class Entities : DbContext
    {
        public Entities()
        {
        }

        public Entities(DbContextOptions<Entities> options)
            : base(options)
        {
        }

        public virtual DbSet<TComCustomer> TComCustomers { get; set; }
        public virtual DbSet<TComSequence> TComSequences { get; set; }
        public virtual DbSet<TComStaff> TComStaffs { get; set; }
        public virtual DbSet<THisPartin> THisPartins { get; set; }
        public virtual DbSet<THisPartout> THisPartouts { get; set; }
        public virtual DbSet<TInfoJig> TInfoJigs { get; set; }
        public virtual DbSet<TInfoPart> TInfoParts { get; set; }
        public virtual DbSet<TSlogan> TSlogans { get; set; }
        public virtual DbSet<TSysFunc> TSysFuncs { get; set; }
        public virtual DbSet<TSysGroup> TSysGroups { get; set; }
        public virtual DbSet<TSysRight> TSysRights { get; set; }
        public virtual DbSet<TSysUser> TSysUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=123.24.143.156;Initial Catalog=MyStockDB;User ID=sa;Password=Tai@1234;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TComCustomer>(entity =>
            {
                entity.HasKey(e => e.Idcustomer)
                    .HasName("PK_tb_CUSTOMER");
            });

            modelBuilder.Entity<TComStaff>(entity =>
            {
                entity.HasKey(e => e.Idstaff)
                    .HasName("PK_T_ENGINEER");

                entity.Property(e => e.Department).IsFixedLength();
            });

            modelBuilder.Entity<TSlogan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TSysFunc>(entity =>
            {
                entity.HasKey(e => new { e.FuncCode, e.Sort });
            });

            modelBuilder.Entity<TSysGroup>(entity =>
            {
                entity.HasKey(e => new { e.Group, e.Member });
            });

            modelBuilder.Entity<TSysRight>(entity =>
            {
                entity.HasKey(e => new { e.FuncCode, e.Iduser });
            });

            modelBuilder.Entity<TSysUser>(entity =>
            {
                entity.HasKey(e => new { e.Iduser, e.Idstaff });

                entity.Property(e => e.Iduser).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
