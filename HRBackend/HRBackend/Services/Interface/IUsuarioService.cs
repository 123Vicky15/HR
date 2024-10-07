using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;

namespace HRBackend.Services.Interface
{
    public interface IUsuarioService
    {
        Task<LoginDto> Login(LoginDto loginDto);
        Task AddUser(UsuarioDto usuarioDto);
        Task<UsuarioDto?> GetUsuarioByIdAsync(int id);

    }
}
