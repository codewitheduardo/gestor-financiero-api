using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTOs.DTOs.DTOsUsuario;
using Sistema.LogicaAplicacion.ICasosUso.ICUUsuario;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;

namespace Sistema.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ICUAltaUsuario _cuAltaUsuario;

        public UsuarioController(ICUAltaUsuario cuAltaUsuario)
        {
            _cuAltaUsuario = cuAltaUsuario;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] DTOAltaUsuario dto)
        {
            try
            {
                _cuAltaUsuario.AltaUsuario(dto);

                return Ok("Usuario creado exitosamente.");
            }
            catch (ContrasenaNoValidaException e)
            {
                return BadRequest(e.Message);
            }
            catch (UsuarioYaExisteException e)
            {
                return Conflict(e.Message);
            }
            catch (NombreNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor.");

            }
        }
    }
}
