using Microsoft.EntityFrameworkCore;
using NugetApiModelsACV.Models;
namespace ApiCoreEmpleadosRoutes.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options){}
        public DbSet<Empleado> Empleados { get; set; }
    }
}
