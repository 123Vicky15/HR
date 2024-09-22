using HRBackend.Dtos;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using HRBackend.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : Controller
    {
        private readonly ICandidatoService _candidatoService;
        private readonly IAuthService _authService;
        public CandidatosController(ICandidatoService candidatoService, IAuthService authService)
        {
            _candidatoService = candidatoService;
            _authService = authService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatoDto>>> GetAllCandidatos()
        {
            var candidatos = await _candidatoService.GetAllCandidatosAsync();
            return Ok(candidatos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidatoById(int id)
        {
            try
            {
                var candidato = await _candidatoService.GetCandidatoByIdAsync(id);
                return Ok(candidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var candidato = await _authService.LoginEmpleado(loginDto);
                return Ok(candidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarCandidato(CandidatoDto candidatoDto)
        {
            var resultado = await _candidatoService.RegistrarCandidatoAsync(candidatoDto);
            if (resultado)
            {
                return Ok(new { message = "Registro exitoso" });
            }
            return BadRequest(new { message = "Error en el registro" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            try
            {
                await _candidatoService.DeleteCandidatoAsync(id);
                return NoContent(); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
