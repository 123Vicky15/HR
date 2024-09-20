using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacitacionController : Controller
    {
        private readonly ICapacitacionService _capacitacionService;

        public CapacitacionController(ICapacitacionService capacitacionService)
        {
            _capacitacionService = capacitacionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CapacitacionDto>> GetCapacitacionById(int id)
        {
            var capacitacion = await _capacitacionService.GetCapacitacionByIdAsync(id);
            if (capacitacion == null)
            {
                return NotFound();
            }
            return Ok(capacitacion);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacitacionDto>>> GetAllCapacitaciones()
        {
            var capacitaciones = await _capacitacionService.GetCapacitacionListAsync();
            return Ok(capacitaciones);
        }

        [HttpPost]
        public async Task<ActionResult> AddCapacitacion(CapacitacionDto capacitacionDto)
        {
            await _capacitacionService.AddCapacitacionAsync(capacitacionDto);
            return CreatedAtAction(nameof(GetCapacitacionById), new { id = capacitacionDto.Id }, capacitacionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCapacitacion(int id, CapacitacionDto capacitacionDto)
        {
            if (id != capacitacionDto.Id)
            {
                return BadRequest();
            }

            await _capacitacionService.UpdateCapacitacionAsync(capacitacionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCapacitacion(int id)
        {
            await _capacitacionService.DeleteCapacitacionAsync(id);
            return NoContent();
        }
    }
}
