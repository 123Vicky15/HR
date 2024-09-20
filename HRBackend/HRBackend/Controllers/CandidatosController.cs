using HRBackend.Dtos;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace HRBackend.Controllers
{
    public class CandidatosController : Controller
    {
        private readonly ICandidatoService _candidatoService;
        private readonly IAuthService _authService;
        public CandidatosController(ICandidatoService candidatoService, IAuthService authService)
        {
            _candidatoService = candidatoService;
            _authService = authService;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllCandidatos()
        {
            try
            {
                var candidatos = await _candidatoService.GetAllCandidatosAsync();
                return Ok(candidatos);
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
