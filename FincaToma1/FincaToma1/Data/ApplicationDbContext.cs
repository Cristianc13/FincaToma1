using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FincaToma1.Models;

namespace FincaToma1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FincaToma1.Models.Empleado> Empleado { get; set; }
        public DbSet<FincaToma1.Models.Pago> Pago { get; set; }
        public DbSet<FincaToma1.Models.Ubicacion> Ubicacion { get; set; }
        public DbSet<FincaToma1.Models.PrecioLata> PrecioLata { get; set; }
        public DbSet<FincaToma1.Models.Corte> Corte { get; set; }
    }
}
