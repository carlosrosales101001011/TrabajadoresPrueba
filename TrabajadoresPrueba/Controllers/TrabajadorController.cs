using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.SqlClient;
using TrabajadoresPrueba.BLL.Service;
using TrabajadoresPrueba.DAL.DataContext;
using TrabajadoresPrueba.Model;

namespace TrabajadoresPrueba.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadoresService _trabajadoresService;
        public TrabajadorController(ITrabajadoresService trabajadoresService)
        {
            _trabajadoresService = trabajadoresService;

        }     
        [HttpGet]
        [Route("Lista")]
        public IActionResult Listar()
        {
            List < Trabajadores > lista = new List<Trabajadores>();

            try
            {
                lista = _trabajadoresService.ObtenerTodos();

            return StatusCode(StatusCodes.Status200OK, new {mensaje= "ok", res= lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, res = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idTrabajador:int}")]
        public async Task<IActionResult> Obtener(int idTrabajador)
        {

            try
            {
            Trabajadores trabajador = await _trabajadoresService.Obtener(idTrabajador);
                if (trabajador == null)
                {
                    return BadRequest("Trabajador no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", res = trabajador });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Insertar([FromBody] VMTrabajador objeto)
        {
            try
            {
                Trabajadores NuevoModelo = new Trabajadores()
                {
                    Nombres = objeto.Nombres,
                    Sexo=objeto.Sexo,
                    NumeroDocumento = objeto.NumeroDocumento,
                    TipoDocumento = objeto.TipoDocumento,
                    IdDepartamento = objeto.IdDepartamento,
                    IdDistrito = objeto.IdDistrito,
                    IdProvincia = objeto.IdProvincia
                };
                bool trabajador = await _trabajadoresService.Insertar(NuevoModelo);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Trabajador Guardado con exito", res = trabajador });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] VMTrabajador objeto)
        {
            try
            {
                Trabajadores NuevoModelo = new Trabajadores()
                {
                    Id= objeto.Id,
                    Nombres = objeto.Nombres,
                    Sexo = objeto.Sexo,
                    NumeroDocumento = objeto.NumeroDocumento,
                    TipoDocumento = objeto.TipoDocumento,
                    IdDepartamento = objeto.IdDepartamento,
                    IdDistrito = objeto.IdDistrito,
                    IdProvincia = objeto.IdProvincia
                };
                bool trabajador = await _trabajadoresService.Actualizar(NuevoModelo);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Trabajador actualizado con exito", res = trabajador });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idTrabajador:int}")]
        public async Task<IActionResult> Eliminar(int idTrabajador)
        {
            try
            {
                bool trabajador = await _trabajadoresService.Eliminar(idTrabajador);
                if (!trabajador)
                {
                    return BadRequest("Trabajador no encontrado");
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Trabajador Eliminado con exito", res = trabajador });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }
}
