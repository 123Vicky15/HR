using HRBackend.Context;
using HRBackend.Models.Candidatos;
using HRBackend.Repository.Interface;

namespace HRBackend.Repository.Repositories
{
    public class ExperienciaLaboralRepository : GenericRepository<ExperienciaLaboral>, IExperienciaLaboralRepository
    {
        public ExperienciaLaboralRepository(HRBackendContext context) : base(context)
        {
        }
    }
}
