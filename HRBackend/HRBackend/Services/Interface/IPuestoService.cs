using HRBackend.Dtos;
using HRBackend.Models.Empleado;

namespace HRBackend.Services.Interface
{
    public interface IPuestoService
    {
        Task<PuestoDto> GetPuestoByIdAsync(int id);
        Task<IEnumerable<PuestoDto>> GetAllPuestosAsync();
        Task AddPuestoAsync(PuestoDto puesto);
        Task UpdatePuestoAsync(PuestoDto puesto);
        Task DeletePuestoAsync(int id);
    }
}
