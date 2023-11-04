using Microsoft.AspNetCore.Mvc;
using TrabajadoresPrueba.BLL.Service.ServDepartamento;
using TrabajadoresPrueba.BLL.Service.ServDistrito;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {


        private readonly IDistritoService _distritoService;
        public DistritoController(IDistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Post([FromBody] VMDistrito objeto)
        {
            try
            {
                Distrito NuevoModelo = new Distrito()
                {
                    Id = objeto.Id,
                    NombreDistrito = objeto.NombreDistrito
                };
                bool distrito = await _distritoService.Insertar(NuevoModelo);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Distrito Guardado con exito", res = distrito });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] VMDistrito objeto)
        {
            try
            {
                Distrito NuevoModelo = new Distrito()
                {
                    Id = objeto.Id,
                    NombreDistrito = objeto.NombreDistrito
                };
                bool distrito = await _distritoService.Actualizar(NuevoModelo);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Distrito actualizado con exito", res = distrito });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete]
        [Route("Eliminar/{idDistrito:int}")]
        public async Task<IActionResult> Eliminar(int idDistrito)
        {
            try
            {
                bool distrito = await _distritoService.Eliminar(idDistrito);
                if (!distrito)
                {
                    return BadRequest("Distrito no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Distrito Eliminado con exito", res = distrito });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
