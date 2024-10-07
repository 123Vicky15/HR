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
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpPost("register")]
        public async Task<ActionResult> AddUsuario(UsuarioDto usuarioDto)
        {
            // Llama al servicio para agregar el usuario
            await _usuarioService.AddUser(usuarioDto);

            // Retorna la respuesta Created con el nuevo usuario y su ID
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuarioDto.Id }, usuarioDto);
        }

    }
}
