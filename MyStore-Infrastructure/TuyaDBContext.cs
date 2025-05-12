using Microsoft.EntityFrameworkCore;
using MyStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Infrastructure
{
    public partial class TuyaDBContext : DbContext
    {
        public TuyaDBContext()
        {
        }

        public TuyaDBContext(DbContextOptions<TuyaDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SqlServerCS");

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(tb =>
            {
                tb.HasKey(tb => tb.Id);
                tb.Property(tb => tb.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(tb => tb.Cedula).IsRequired().HasMaxLength(15);
                tb.Property(tb => tb.Nombre).IsRequired().HasMaxLength(500);
                tb.Property(tb => tb.FechaRegistro).IsRequired();
                tb.Property(tb => tb.FechaActualizacion).IsRequired();
            });

            modelBuilder.Entity<Order>(tb =>
            {
                tb.HasKey(tb => tb.Id);
                tb.Property(tb => tb.Id).IsRequired().UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(tb => tb.FechaHora).IsRequired();
                tb.Property(tb => tb.CodAlmacen).IsRequired().HasMaxLength(10);
                tb.Property(tb => tb.CustomerId).IsRequired();
                tb.Property(tb => tb.ValorTotal).IsRequired().HasPrecision(11, 2);
                tb.Property(tb => tb.Estado).IsRequired().HasMaxLength(50);
                tb.Property(tb => tb.Activo).IsRequired();
                tb.Property(tb => tb.FechaRegistro).IsRequired();
                tb.Property(tb => tb.FechaActualizacion).IsRequired();

                tb.HasOne<Customer>().WithOne().HasForeignKey<Order>(o => o.CustomerId);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}