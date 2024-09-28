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

        [HttpPost("convertir-candidato-empleado")]
        public async Task<IActionResult> ConvertirCandidatoEmpleado([FromBody] ConvertirCandidatoRequest request)
        {
            if (request == null || request.EmpleadoDto == null || request.CandidatoId <= 0)
                return BadRequest("Datos inválidos");

            // Obtener el candidato de la base de datos
            var candidato = await _candidatoService.GetCandidatoByIdAsync(request.CandidatoId);

            if (candidato == null)
                return NotFound("Candidato no encontrado");

            // Convertir candidato a empleado
            var empleado = await _empleadoService.ConvertirCandidatoAEmpleado(candidato, request.EmpleadoDto);

            // Guardar el nuevo empleado
            await _empleadoService.AddEmpleadoNewAsync(empleado);

            return Ok(empleado);
        }
    }
}
