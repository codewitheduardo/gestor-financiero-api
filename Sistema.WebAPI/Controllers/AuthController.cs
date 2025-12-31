using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sistema.DTOs.DTOs.DTOsUsuario;
using Sistema.LogicaAplicacion.CasosUso.CUUsuario;
using Sistema.LogicaAplicacion.ICasosUso.ICUUsuario;
using Sistema.LogicaNegocio.CustomExceptions.CECompartidos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _cuLogin;
        private IConfiguration _Config;

        public AuthController(ICULogin cuLogin, IConfiguration config)
        {
            _cuLogin = cuLogin;
            _Config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin dto)
        {
            try
            {
                DTOUsuario u = _cuLogin.VerificarExistencia(dto);

                var claims = new List<Claim>
                {
                // Usuario logueado
                new Claim(ClaimTypes.Name, u.NombreUsuario),

                // Id único del token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = _Config["Jwt:Key"]!;

                var signingKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key)
                );

                var credentials = new SigningCredentials(
                    signingKey,
                    SecurityAlgorithms.HmacSha512
                );

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddYears(1),
                    signingCredentials: credentials
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    NombreUsuario = u.NombreUsuario,
                    Token = jwt
                });
            }
            catch (DatosNoValidosException e)
            {
                return Unauthorized(e.Message);
            } 
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
