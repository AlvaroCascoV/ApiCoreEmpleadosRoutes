using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options){}
        public DbSet<Models.Empleado> Empleados { get; set; }
    }
}
