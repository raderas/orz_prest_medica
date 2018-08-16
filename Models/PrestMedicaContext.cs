using Microsoft.EntityFrameworkCore;

namespace PrestacionMedicaMvc.Models
{
    public class PrestMedicaContext : DbContext
    {
        public PrestMedicaContext(DbContextOptions<PrestMedicaContext> options) : base(options)
        { }

        public DbSet<Empresa> Empresa {get;set;}

        public DbSet<Banco> Banco{get;set;}

        public DbSet<Empleado> Empleado{get;set;}

        public DbSet<Expediente> Expediente{get;set;}

        public DbSet<Factura> Factura{get;set;}

        public DbSet<Planilla> Planilla{get;set;}

        public DbSet<Proveedor> Proveedor{get;set;}

        public DbSet<Reclamo> Reclamo{get;set;}
    }
}