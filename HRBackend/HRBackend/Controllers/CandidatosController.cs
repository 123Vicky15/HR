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
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCapacitacion(int id, CandidatoDto candidatoDto)
        {
            if (id != candidatoDto.Id)
            {
                return BadRequest();
            }

            await _candidatoService.UpdateCandidatoAsync(candidatoDto);
            return NoContent();
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

        [HttpPost("re")]
        public async Task<IActionResult> RegistrarCandidatoAsync(CandidatoDto candidatoDto)
        {
            try
            {
                await _candidatoService.AddCandidatoAsync(candidatoDto);
                return NoContent();

            }
            catch(KeyNotFoundException ex) { return BadRequest(ex.Message); }
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
