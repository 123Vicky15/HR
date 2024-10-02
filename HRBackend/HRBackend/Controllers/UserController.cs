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
        public async Task<IActionResult> Login([FromBody] UsuarioDto usuarioDto)
        {
            var result = await _usuarioService.Login(usuarioDto);
            if (result == null)
                return Unauthorized();

            // Retornar información del usuario o token según tu implementación.
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDto usuarioDto)
        {
            var result = await _usuarioService.Register(usuarioDto);
            return CreatedAtAction(nameof(Register), result);
        }

    }
}
