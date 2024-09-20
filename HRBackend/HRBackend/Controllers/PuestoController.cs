using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : Controller
    {
        private readonly IPuestoService _puestoService;

        public PuestoController(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PuestoDto>> GetPuestoById(int id)
        {
            var puesto = await _puestoService.GetPuestoByIdAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            return Ok(puesto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuestoDto>>> GetAllPuestos()
        {
            var puestos = await _puestoService.GetAllPuestosAsync();
            return Ok(puestos);
        }

        [HttpPost]
        public async Task<ActionResult> AddPuesto(PuestoDto puestoDto)
        {
            await _puestoService.AddPuestoAsync(puestoDto);
            return CreatedAtAction(nameof(GetPuestoById), new { id = puestoDto.Id }, puestoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePuesto(int id, PuestoDto puestoDto)
        {
            if (id != puestoDto.Id)
            {
                return BadRequest();
            }

            await _puestoService.UpdatePuestoAsync(puestoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePuesto(int id)
        {
            await _puestoService.DeletePuestoAsync(id);
            return NoContent();
        }
    }
}
