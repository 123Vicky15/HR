using HRBackend.Models.Empleado;

namespace HRBackend.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByNombre(string nombre);

        Task<Usuario> GetUsuario(string username);
        Task<Usuario> RegisterUsuario(Usuario usuario);
    }
}
