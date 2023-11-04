using Microsoft.AspNetCore.Mvc;
using TrabajadoresPrueba.BLL.Service.ServDepartamento;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Post([FromBody] VMDepartamento objeto)
        {
            try
            {
                Departamento NuevoModelo = new Departamento()
                {
                    Id = objeto.Id,
                    NombreDepartamento=objeto.NombreDepartamento
                };
                bool departamento = await _departamentoService.Insertar(NuevoModelo);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Departamento Guardado con exito", res = departamento });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] VMDepartamento objeto)
        {
            try
            {
                Departamento NuevoModelo = new Departamento()
                {
                    Id = objeto.Id,
                    NombreDepartamento = objeto.NombreDepartamento
                };
                bool departamento = await _departamentoService.Actualizar(NuevoModelo);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Departamento actualizado con exito", res = departamento });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete]
        [Route("Eliminar/{idDepartamento:int}")]
        public async Task<IActionResult> Eliminar(int idDepartamento)
        {
            try
            {
                bool departamento = await _departamentoService.Eliminar(idDepartamento);
                if (!departamento)
                {
                    return BadRequest("Departamento no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Departamento Eliminado con exito", res = departamento });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
