using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaLaboralController : Controller
    {
        private readonly IExperienciaLaboralService _experienciaLaboralService;

        public ExperienciaLaboralController(IExperienciaLaboralService experienciaLaboralService)
        {
            _experienciaLaboralService = experienciaLaboralService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienciaLaboralDto>> GetExperienciaLaboralById(int id)
        {
            var experiencia = await _experienciaLaboralService.GetExperienciaLaboralByIdAsync(id);
            if (experiencia == null)
            {
                return NotFound();
            }
            return Ok(experiencia);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienciaLaboralDto>>> GetAllExperienciaLaboral()
        {
            var experiencias = await _experienciaLaboralService.GetAllExperienciaLaboralAsync();
            return Ok(experiencias);
        }

        [HttpPost]
        public async Task<ActionResult> AddExperienciaLaboral(ExperienciaLaboralDto experienciaDto)
        {
            await _experienciaLaboralService.AddExperienciaLaboralAsync(experienciaDto);
            return CreatedAtAction(nameof(GetExperienciaLaboralById), new { id = experienciaDto.Id }, experienciaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExperienciaLaboral(int id, ExperienciaLaboralDto experienciaDto)
        {
            if (id != experienciaDto.Id)
            {
                return BadRequest();
            }

            await _experienciaLaboralService.UpdateExperienciaLaboralAsync(experienciaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExperienciaLaboral(int id)
        {
            await _experienciaLaboralService.DeleteExperienciaLaboralAsync(id);
            return NoContent();
        }
    }
}
