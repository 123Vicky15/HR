using HRBackend.Models.Candidatos;

namespace HRBackend.Repository.Interface
{
    public interface IExperienciaLaboralRepository : IGenericRepository<ExperienciaLaboral>
    {
        Task<IEnumerable<ExperienciaLaboral>> GetExperienciasByCandidatoIdAsync(int candidatoId);

    }
}
