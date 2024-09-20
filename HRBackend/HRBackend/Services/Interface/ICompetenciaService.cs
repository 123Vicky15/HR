using HRBackend.Dtos;
using HRBackend.Models.Empleado;

namespace HRBackend.Services.Interface
{
    public interface ICompetenciaService
    {
        Task<CompetenciaDto> GetCompetenciaByIdAsync(int id);
        Task<IEnumerable<CompetenciaDto>> GetAllCompetenciasAsync();
        Task AddCompetenciaAsync(CompetenciaDto competencia);
        Task UpdateCompetenciaAsync(CompetenciaDto competencia);
        Task DeleteCompetenciaAsync(int id);
    }
}
