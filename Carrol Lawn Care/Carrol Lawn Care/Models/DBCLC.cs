namespace Carrol_Lawn_Care.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBCLC : DbContext
    {
        public DBCLC()
            : base("name=DBCLC")
        {
        }

        public virtual DbSet<Customers> TblCusts { get; set; }
        public virtual DbSet<Employees> TblEmps { get; set; }
        public virtual DbSet<Equip> TblEquips { get; set; }
        public virtual DbSet<MaintenanceRecords> TblMaintRecs { get; set; }
        public virtual DbSet<Person> TblPers { get; set; }
        public virtual DbSet<Property> TblProps { get; set; }
        public virtual DbSet<Tools> TblTools { get; set; }
        public virtual DbSet<Vehicles> TblVehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equip>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Equip>()
                .Property(e => e.fuelType)
                .IsUnicode(false);

            modelBuilder.Entity<Equip>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Equip>()
                .HasMany(e => e.TblMaintRecs)
                .WithRequired(e => e.TblEquip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equip>()
                .HasMany(e => e.TblProps)
                .WithOptional(e => e.TblEquip)
                .HasForeignKey(e => e.equipId);

            modelBuilder.Entity<Equip>()
                .HasMany(e => e.TblTools)
                .WithRequired(e => e.TblEquip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equip>()
                .HasMany(e => e.TblVehicles)
                .WithRequired(e => e.TblEquip)
                .HasForeignKey(e => e.equpId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equip>()
                .HasOptional(e => e.TblEquip1)
                .WithMany(e => e.TblEquips);

            modelBuilder.Entity<MaintenanceRecords>()
                .Property(e => e.maintType)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblCusts)
                .WithRequired(e => e.TblPer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblEmps)
                .WithRequired(e => e.TblPer)
                .HasForeignKey(e => e.managedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblEmps1)
                .WithRequired(e => e.TblPer1)
                .HasForeignKey(e => e.perId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblProps)
                .WithOptional(e => e.TblPer)
                .HasForeignKey(e => e.perId);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblPers1)
                .WithMany(e => e.TblPers)
                .Map(m => m.ToTable("TblManages").MapLeftKey("empId").MapRightKey("manId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TblProps1)
                .WithMany(e => e.TblPers)
                .Map(m => m.ToTable("TblOwns").MapLeftKey("perId").MapRightKey("propID"));

            modelBuilder.Entity<Property>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .Property(e => e.services)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .Property(e => e.recurrence)
                .IsUnicode(false);

            modelBuilder.Entity<Property>()
                .HasOptional(e => e.TblEquip1)
                .WithMany(e => e.TblProps1);

            modelBuilder.Entity<Vehicles>()
                .Property(e => e.licPlate)
                .IsUnicode(false);
        }
    }
}
