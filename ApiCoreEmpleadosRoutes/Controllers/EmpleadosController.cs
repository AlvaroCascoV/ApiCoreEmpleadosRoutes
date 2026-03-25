using ApiCoreEmpleadosRoutes.Models;
using ApiCoreEmpleadosRoutes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreEmpleadosRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync();
            return empleados;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado(int id)
        {
            Empleado empleado = await this.repo.FindEmpleadoAsync(id);
            return empleado;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }
        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosByOficio(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }
        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosSalarioDepartamento(int salario, int iddepartamento)
        {
            return await this.repo.GetEmpleadosSalarioDepartamentoAsync(salario, iddepartamento);
        }
    }
}
