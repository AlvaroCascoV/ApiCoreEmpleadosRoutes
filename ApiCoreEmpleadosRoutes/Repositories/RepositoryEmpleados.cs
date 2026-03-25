using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return await consulta.ToListAsync();

        }

        public async Task<List<Empleado>> GetEmpleadosSalarioDepartamentoAsync(int salario, int idDepartamento) 
        {
            return await this.context.Empleados.Where(x => x.Salario >= salario && x.IdDepartamento == idDepartamento).ToListAsync();
        }
    }
}
