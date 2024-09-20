using HRBackend.Dtos;
using HRBackend.Models.Empleado;

namespace HRBackend.Services.Interface
{
    public interface ICapacitacionService
    {
        Task<CapacitacionDto> GetCapacitacionByIdAsync(int id);
        Task<IEnumerable<CapacitacionDto>> GetCapacitacionListAsync();
        Task AddCapacitacionAsync(CapacitacionDto capacitacionDto);
        Task UpdateCapacitacionAsync(CapacitacionDto capacitacionDto);
        Task DeleteCapacitacionAsync(int id);
    }
}
