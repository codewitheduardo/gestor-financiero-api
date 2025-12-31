using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTOs.DTOs.DTOsMovimiento;
using Sistema.LogicaAplicacion.ICasosUso.ICUMovimiento;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CEMovimiento;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CETipoIngreso;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using System.Security.Claims;

namespace Sistema.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private ICUAltaMovimiento _cuAltaMovimiento;
        private ICUObtenerMovimientos _cuObtenerMovimientos;
        private ICUObtenerMovimientosPorMesAnio _cuObtenerMovimientosPorMesAnio;
        private ICUEliminarMovimieno _cuEliminarMovimiento;

        public MovimientoController(ICUAltaMovimiento cuAltaMovimiento, ICUObtenerMovimientos cuObtenerMovimientos, ICUObtenerMovimientosPorMesAnio cUObtenerMovimientosPorMesAnio, ICUEliminarMovimieno cUEliminarMovimieno)
        {
            _cuAltaMovimiento = cuAltaMovimiento;
            _cuObtenerMovimientos = cuObtenerMovimientos;
            _cuObtenerMovimientosPorMesAnio = cUObtenerMovimientosPorMesAnio;
            _cuEliminarMovimiento = cUEliminarMovimieno;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] DTOAltaMovimiento dto)
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                dto.NombreUsuario = username;
                _cuAltaMovimiento.AltaMovimiento(dto);

                return Ok("Movimiento creado exitosamente.");
            }
            catch (UsuarioNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (FechaNoValidaException e)
            {
                return BadRequest(e.Message);
            }
            catch (MontoNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (DescripcionNoValidaException e)
            {
                return BadRequest(e.Message);
            }
            catch (TipoGastoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoIngresoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;

                List<DTOMovimiento> retorno = _cuObtenerMovimientos.ObtenerMovimientosAsync(username).Result;

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpGet("GetByMonthYear")]
        public IActionResult GetByMonthYear([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;

                List<DTOMovimiento> retorno = _cuObtenerMovimientosPorMesAnio.ObtenerMovimientosPorMesAnioAsync(username, month, year).Result;

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cuEliminarMovimiento.EliminarMovimiento(id);

                return Ok("Movimiento eliminado exitosamente.");
            }
            catch (MovimientoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }
    }
}
