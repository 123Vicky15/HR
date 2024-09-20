using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenciaController : Controller
    {
        private readonly ICompetenciaService _competenciaService;

        public CompetenciaController(ICompetenciaService competenciaService)
        {
            _competenciaService = competenciaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetenciaDto>> GetCompetenciaById(int id)
        {
            var competencia = await _competenciaService.GetCompetenciaByIdAsync(id);
            if (competencia == null)
            {
                return NotFound();
            }
            return Ok(competencia);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetenciaDto>>> GetAllCompetencias()
        {
            var competencias = await _competenciaService.GetAllCompetenciasAsync();
            return Ok(competencias);
        }

        [HttpPost]
        public async Task<ActionResult> AddCompetencia(CompetenciaDto competenciaDto)
        {
            await _competenciaService.AddCompetenciaAsync(competenciaDto);
            return CreatedAtAction(nameof(GetCompetenciaById), new { id = competenciaDto.Id }, competenciaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompetencia(int id, CompetenciaDto competenciaDto)
        {
            if (id != competenciaDto.Id)
            {
                return BadRequest();
            }

            await _competenciaService.UpdateCompetenciaAsync(competenciaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompetencia(int id)
        {
            await _competenciaService.DeleteCompetenciaAsync(id);
            return NoContent();
        }
    }
}
