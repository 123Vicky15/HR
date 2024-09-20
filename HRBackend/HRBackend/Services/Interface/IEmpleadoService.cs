using HRBackend.Dtos;

namespace HRBackend.Services.Interface
{
    public interface IEmpleadoService
    {
        Task<EmpleadoDto> GetEmpleadoByIdAsync(int id);
        Task<IEnumerable<EmpleadoDto>> GetAllEmpleadosAsync();
        //Task AddEmpleadoAsync(EmpleadoDto empleadoDto);
        //Task UpdateEmpleadoAsync(int id, EmpleadoDto empleadoDto);
        //Task DeleteEmpleadoAsync(int id);
    }
}
