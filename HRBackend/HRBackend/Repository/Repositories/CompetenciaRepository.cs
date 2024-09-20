using HRBackend.Context;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;

namespace HRBackend.Repository.Repositories
{
    public class CompetenciaRepository : GenericRepository<Competencia>, ICompetenciaRepository
    {
        public CompetenciaRepository(HRBackendContext context) : base(context)
        {
        }
    }
}
