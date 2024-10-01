using HRBackend.Context;
using HRBackend.Dtos;
using HRBackend.Services.Interface;
using HRBackend.Services.Service;
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
        private readonly ICandidatoService _candidatoService;
        public EmpleadosController(IEmpleadoService empleadoService, IAuthService authService, ICandidatoService candidatoService)
        {
            _empleadoService = empleadoService;
            _authService = authService;
            _candidatoService = candidatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAllEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
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

        [HttpPost("convertir")]
        public async Task<IActionResult> ConvertirCandidatoAEmpleado(int candidatoDto, EmpleadoDto empleadoDto)
        {

            if (candidatoDto == null || empleadoDto == null)
                return BadRequest("Datos del candidato o empleado no proporcionados.");

            // Llamada a la función existente para convertir el candidato a empleado
            try
            {
                await ConvertirCandidatoAEmpleado(candidatoDto, empleadoDto);
                return Ok(new { Message = "Candidato convertido a empleado exitosamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error: {ex.Message}");
            }
        }

    }
}
