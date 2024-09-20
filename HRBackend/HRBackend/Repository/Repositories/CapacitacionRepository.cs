using HRBackend.Context;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Repository.Repositories
{
    public class CapacitacionRepository : GenericRepository<Capacitacion>, ICapacitacionRepository
    {
        public CapacitacionRepository(HRBackendContext context) : base(context)
        {
        }
    }
}
