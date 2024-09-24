using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ICompetenciaRepository _competenciaRepository;

        public CompetenciaService(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public async Task<CompetenciaDto> GetCompetenciaByIdAsync(int id)
        {
            var competencia = await _competenciaRepository.GetByIdAsync(id);
            if (competencia == null)
            {
                throw new KeyNotFoundException($"La competencia con ID {id} no existe.");
            }

            return new CompetenciaDto
            {
                Id = competencia.Id,
                Descripcion = competencia.Descripcion,
                Estado = competencia.Estado
            };
        }

        public async Task<IEnumerable<CompetenciaDto>> GetAllCompetenciasAsync()
        {
            var competencias = await _competenciaRepository.GetAllAsync();

            return competencias.Select(c => new CompetenciaDto
            {
                Id = c.Id,
                Descripcion = c.Descripcion,
                Estado = c.Estado
            }).OrderBy(x => x.Id);
        }

        public async Task AddCompetenciaAsync(CompetenciaDto competenciaDto)
        {
            var competencia = new Competencia
            {
                Descripcion = competenciaDto.Descripcion,
                Estado = competenciaDto.Estado
            };

            await _competenciaRepository.AddAsync(competencia);
        }

        public async Task UpdateCompetenciaAsync(CompetenciaDto competenciaDto)
        {
            var competencia = await _competenciaRepository.GetByIdAsync(competenciaDto.Id);
            if (competencia == null)
            {
                throw new KeyNotFoundException($"La competencia con ID {competenciaDto.Id} no existe.");
            }

            // Actualizar los campos
            competencia.Descripcion = competenciaDto.Descripcion;
            competencia.Estado = competenciaDto.Estado;

             _competenciaRepository.Update(competencia);
        }

        public async Task DeleteCompetenciaAsync(int id)
        {
            var competencia = await _competenciaRepository.GetByIdAsync(id);
            if (competencia == null)
            {
                throw new KeyNotFoundException($"La competencia con ID {id} no existe.");
            }

            _competenciaRepository.Delete(competencia);
        }
    }
}
