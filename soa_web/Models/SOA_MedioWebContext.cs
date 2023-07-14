using System;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace soa_web.Models
{
    public partial class SOA_MedioWebContext : DbContext
    {
        public SOA_MedioWebContext()
        {
        }

        public SOA_MedioWebContext(DbContextOptions<SOA_MedioWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activo> Activos { get; set; } = null!;

       

        public virtual DbSet<ActivosEmpleado> ActivosEmpleados { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=MSI\\MSSQLSERVER01; database=SOA_MedioWeb; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activo>(entity =>
            {
                entity.HasIndex(e => e.IdEmpleado, "IX_Activos_IdEmpleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Activos)
                    .HasForeignKey(d => d.IdEmpleado);
            });

            modelBuilder.Entity<ActivosEmpleado>(entity =>
            {
                entity.ToTable("Activos_Empleados");

                entity.Property(e => e.FechaAsignacion).HasColumnName("Fecha_Asignacion");

                entity.Property(e => e.FechaEntrega).HasColumnName("Fecha_Entrega");

                entity.Property(e => e.FechaLiberacion).HasColumnName("Fecha_Liberacion");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password")
                    .HasDefaultValueSql("(N'')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
