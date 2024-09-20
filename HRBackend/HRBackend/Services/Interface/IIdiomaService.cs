using HRBackend.Dtos;
using HRBackend.Models.Empleado;

namespace HRBackend.Services.Interface
{
    public interface IIdiomaService
    {
        Task<IdiomaDto> GetIdiomaByIdAsync(int id);
        Task<IEnumerable<IdiomaDto>> GetAllIdiomasAsync();
        Task AddIdiomaAsync(IdiomaDto idioma);
        Task UpdateIdiomaAsync(IdiomaDto idioma);
        Task DeleteIdiomaAsync(int id);
    }
}
