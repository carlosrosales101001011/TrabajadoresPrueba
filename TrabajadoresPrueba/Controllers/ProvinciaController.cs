using Microsoft.AspNetCore.Mvc;
using TrabajadoresPrueba.BLL.Service.ServDepartamento;
using TrabajadoresPrueba.BLL.Service.ServProvincia;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;
        public ProvinciaController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }


        // POST api/<DepartamentoController>
        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Post([FromBody] VMProvincia objeto)
        {
            try
            {
                Provincia NuevoModelo = new Provincia()
                {
                    Id = objeto.Id,
                    NombreProvincia=objeto.NombreProvincia
                };
                bool provincia = await _provinciaService.Insertar(NuevoModelo);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Provincia Guardado con exito", res = provincia });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] VMProvincia objeto)
        {
            try
            {
                Provincia NuevoModelo = new Provincia()
                {
                    Id = objeto.Id,
                    NombreProvincia = objeto.NombreProvincia
                };
                bool provincia = await _provinciaService.Actualizar(NuevoModelo);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Provincia actualizado con exito", res = provincia });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete]
        [Route("Eliminar/{idProvincia:int}")]
        public async Task<IActionResult> Eliminar(int idProvincia)
        {
            try
            {
                bool provincia = await _provinciaService.Eliminar(idProvincia);
                if (!provincia)
                {
                    return BadRequest("Departamento no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Provincia Eliminado con exito", res = provincia });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
