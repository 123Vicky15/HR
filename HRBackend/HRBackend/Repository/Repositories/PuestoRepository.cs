using HRBackend.Context;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;

namespace HRBackend.Repository.Repositories
{
    public class PuestoRepository : GenericRepository<Puesto>, IPuestoRepository
    {
        public PuestoRepository(HRBackendContext context) : base(context)
        {
        }
    }
}
