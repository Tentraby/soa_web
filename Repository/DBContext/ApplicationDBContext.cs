using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository.DBContext
{
    public class ApplicationDBContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Persona> personas { get; set; }
        public DbSet<Empleado> empleados{ get; set; }

        public DbSet<Activo> activos { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
