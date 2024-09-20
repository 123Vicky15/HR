using HRBackend.Context;
using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IAuthService _authService;
        public EmpleadosController(IEmpleadoService empleadoService, IAuthService authService)
        {
            _empleadoService = empleadoService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var empleado = await _authService.LoginEmpleado(loginDto);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
