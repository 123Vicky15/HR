using HRBackend.Dtos;
using HRBackend.Models.Empleado;

namespace HRBackend.Services.Interface
{
    public interface IExperienciaLaboralService
    {
        Task<ExperienciaLaboralDto> GetExperienciaLaboralByIdAsync(int id);
        Task<IEnumerable<ExperienciaLaboralDto>> GetAllExperienciaLaboralAsync();
        Task AddExperienciaLaboralAsync(ExperienciaLaboralDto capacitacion);
        //Task UpdateExperienciaLaboralAsync(ExperienciaLaboralDto capacitacion);
        Task DeleteExperienciaLaboralAsync(int id);

    }
}
