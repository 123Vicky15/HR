using HRBackend.Context;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;

namespace HRBackend.Repository.Repositories
{
    public class IdiomaRepository : GenericRepository<Idioma>, IIdiomaRepository
    {
        public IdiomaRepository(HRBackendContext context) : base (context)
        {
        }
    }
}
