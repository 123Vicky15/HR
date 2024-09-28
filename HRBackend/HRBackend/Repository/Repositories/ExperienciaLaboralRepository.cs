using HRBackend.Context;
using HRBackend.Models.Candidatos;
using HRBackend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Repository.Repositories
{
    public class ExperienciaLaboralRepository : GenericRepository<ExperienciaLaboral>, IExperienciaLaboralRepository
    {
        public ExperienciaLaboralRepository(HRBackendContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExperienciaLaboral>> GetExperienciasByCandidatoIdAsync(int candidatoId)
        {
            return await _dbSet.Where(e => e.CandidatoId == candidatoId).ToListAsync();
        }
    }
}
