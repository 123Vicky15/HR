using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UserController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Los datos del usuario son requeridos.");
            }

            var user = await _usuarioService.Login(loginDto);

            if (user == null)
            {
                return Unauthorized("Nombre de usuario o contraseña incorrectos.");
            }

            return Ok(user); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Los datos del usuario son requeridos.");
            }

            try
            {
                var registeredUser = await _usuarioService.Register(usuarioDto);
                return CreatedAtAction(nameof(Login), new { username = registeredUser.UserName }, registeredUser);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message); // Manejo de conflictos, como nombre de usuario ya en uso
            }
        }

    }
}
