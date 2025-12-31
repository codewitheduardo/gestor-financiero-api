using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.DTOs.DTOs.DTOsTipoGasto;
using Sistema.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using Sistema.LogicaNegocio.CustomExceptions.CETipoGasto;
using Sistema.LogicaNegocio.CustomExceptions.CEUsuario;
using System.Security.Claims;

namespace Sistema.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoController : ControllerBase
    {
        private ICUAltaTipoGasto _cuAltaTipoGasto;
        private ICUEditarTipoGasto _cuEditarTipoGasto;
        private ICUEliminarTipoGasto _cuEliminarTipoGasto;
        private ICUObtenerTipoGasto _cuObtenerTipoGasto;
        private ICUObtenerTipoGastos _cuObtenerTipoGastos;
        private ICUObtenerTipoGastosActivos _cuObtenerTipoGastosActivos;

        public TipoGastoController(ICUAltaTipoGasto cuAltaTipoGasto, ICUEditarTipoGasto cuEditarTipoGasto, ICUEliminarTipoGasto cuEliminarTipoGasto, ICUObtenerTipoGasto cuObtenerTipoGasto, ICUObtenerTipoGastos cuObtenerTipoGastos, ICUObtenerTipoGastosActivos cuObtenerTipoGastosActivos)
        {
            _cuAltaTipoGasto = cuAltaTipoGasto;
            _cuEditarTipoGasto = cuEditarTipoGasto;
            _cuEliminarTipoGasto = cuEliminarTipoGasto;
            _cuObtenerTipoGasto = cuObtenerTipoGasto;
            _cuObtenerTipoGastos = cuObtenerTipoGastos;
            _cuObtenerTipoGastosActivos = cuObtenerTipoGastosActivos;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] DTOAltaTipoGasto dto)
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;
                dto.NombreUsuario = username;
                _cuAltaTipoGasto.AltaTipoGasto(dto);

                return Ok("Tipo de gasto creado exitosamente.");
            }
            catch (UsuarioNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoGastoExistenteException e)
            {
                return Conflict(e.Message);
            }
            catch (NombreNoValidoException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpPatch("Edit")]
        public IActionResult Edit([FromBody] DTOTipoGasto dto)
        {
            try
            {
                _cuEditarTipoGasto.Editar(dto);

                return Ok("Tipo de gasto editado exitosamente.");
            }
            catch (TipoGastoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoGastoExistenteException e)
            {
                return Conflict(e.Message);
            }
            catch (NombreNoValidoException e)
            {
                return BadRequest(e.Message);
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
                _cuEliminarTipoGasto.Eliminar(id);

                return Ok("Tipo de gasto eliminado exitosamente.");
            }
            catch (TipoGastoNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (TipoGastoConSalidasAsociadasException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                DTOTipoGasto retorno = _cuObtenerTipoGasto.ObtenerTipoGasto(id);

                return Ok(retorno);
            }
            catch (TipoGastoNoExisteException e)
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

                List<DTOTipoGasto> retorno = _cuObtenerTipoGastos.ObtenerTipoGastos(username);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAllActives")]
        public IActionResult GetAllActives()
        {
            try
            {
                var username = User.FindFirst(ClaimTypes.Name)?.Value;

                List<DTOTipoGasto> retorno = _cuObtenerTipoGastosActivos.ObtenerTipoGastosActivos(username);

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + e.Message);
            }
        }
    }
}
