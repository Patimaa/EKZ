namespace EKZ
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<Аренда> Аренда { get; set; }
        public virtual DbSet<Арендаторы> Арендаторы { get; set; }
        public virtual DbSet<Павильон> Павильон { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<ТЦ> ТЦ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Арендаторы>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Арендаторы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Павильон>()
                .Property(e => e.стоимость_за_кв_м)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Павильон>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Павильон)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Сотрудники>()
                .HasMany(e => e.Аренда)
                .WithRequired(e => e.Сотрудники)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ТЦ>()
                .Property(e => e.стоимость_постройки)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ТЦ>()
                .HasMany(e => e.Павильон)
                .WithRequired(e => e.ТЦ1)
                .HasForeignKey(e => e.ТЦ)
                .WillCascadeOnDelete(false);
        }
    }
}
