using HRBackend.Models.Empleado;

namespace HRBackend.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByNombre(string nombre);
        Task<Usuario> RegisterUsuario(Usuario usuario);
    }
}
