using HRBackend.Dtos;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HRBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomaController : Controller
    {
        private readonly IIdiomaService _idiomaService;

        public IdiomaController(IIdiomaService idiomaService)
        {
            _idiomaService = idiomaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdiomaDto>> GetIdiomaById(int id)
        {
            var idioma = await _idiomaService.GetIdiomaByIdAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }
            return Ok(idioma);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdiomaDto>>> GetAllIdiomas()
        {
            var idiomas = await _idiomaService.GetAllIdiomasAsync();
            return Ok(idiomas);
        }

        [HttpPost]
        public async Task<ActionResult> AddIdioma(IdiomaDto idiomaDto)
        {
            await _idiomaService.AddIdiomaAsync(idiomaDto);
            return CreatedAtAction(nameof(GetIdiomaById), new { id = idiomaDto.Id }, idiomaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIdioma(int id, IdiomaDto idiomaDto)
        {
            if (id != idiomaDto.Id)
            {
                return BadRequest();
            }

            await _idiomaService.UpdateIdiomaAsync(idiomaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIdioma(int id)
        {
            await _idiomaService.DeleteIdiomaAsync(id);
            return NoContent();
        }
    }
}
