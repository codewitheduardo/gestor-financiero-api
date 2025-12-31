using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTOs.DTOs.DTOsTipoIngreso;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CETipoPago;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using System.Security.Claims;

namespace Sistema.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIngresoController : ControllerBase
    {
        private ICUAltaTipoIngreso _cuAltaTipoIngreso;
        private ICUEditarTipoIngreso _cuEditarTipoIngreso;
        private ICUEliminarTipoIngreso _cuEliminarTipoIngreso;
        private ICUObtenerTipoIngreso _cuObtenerTipoIngreso;
        private ICUObtenerTipoIngresos _cuObtenerTipoIngresos;
        private ICUObtenerTipoIngresosActivos _cuObtenerTipoIngresosActivos;

        public TipoIngresoController(
            ICUAltaTipoIngreso cuAltaTipoIngreso,
            ICUEditarTipoIngreso cuEditarTipoIngreso,
            ICUEliminarTipoIngreso cuEliminarTipoIngreso,
            ICUObtenerTipoIngreso cuObtenerTipoIngreso,
            ICUObtenerTipoIngresos cuObtenerTipoIngresos,
            ICUObtenerTipoIngresosActivos cuObtenerTipoIngresosActivos)
        {
            _cuAltaTipoIngreso = cuAltaTipoIngreso;
            _cuEditarTipoIngreso = cuEditarTipoIngreso;
            _cuEliminarTipoIngreso = cuEliminarTipoIngreso;
            _cuObtenerTipoIngreso = cuObtenerTipoIngreso;
            _cuObtenerTipoIngresos = cuObtenerTipoIngresos;
            _cuObtenerTipoIngresosActivos = cuObtenerTipoIngresosActivos;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] DTOAltaTipoIngreso dto)
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                dto.NombreUsuario = username;
                _cuAltaTipoIngreso.AltaTipoIngreso(dto);
                return Ok("Tipo de ingreso creado exitosamente.");
            }
            catch (UsuarioNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoIngresoExistenteException e)
            {
                return Conflict(e.Message);
            }
            catch (NombreNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

        [Authorize]
        [HttpPatch("Edit")]
        public IActionResult Edit([FromBody] DTOTipoIngreso dto)
        {
            try
            {
                _cuEditarTipoIngreso.Editar(dto);
                return Ok("Tipo de ingreso editado exitosamente.");
            }
            catch (TipoIngresoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoIngresoExistenteException e)
            {
                return Conflict(e.Message);
            }
            catch (NombreNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cuEliminarTipoIngreso.Eliminar(id);
                return Ok("Tipo de ingreso eliminado exitosamente.");
            }
            catch (TipoIngresoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoIngresoConEntradasAsociadasException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

        [Authorize]
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DTOTipoIngreso retorno =
                    _cuObtenerTipoIngreso.ObtenerTipoIngreso(id);

                return Ok(retorno);
            }
            catch (TipoIngresoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;

                List<DTOTipoIngreso> retorno =
                    _cuObtenerTipoIngresos.ObtenerTipoIngresos(username);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

        [Authorize]
        [HttpGet("GetAllActives")]
        public IActionResult GetAllActives()
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;

                List<DTOTipoIngreso> retorno =
                    _cuObtenerTipoIngresosActivos
                        .ObtenerTipoIngresosActivos(username);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error interno del servidor: " + e.Message
                );
            }
        }

    }
}
