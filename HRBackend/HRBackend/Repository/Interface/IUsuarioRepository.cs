using HRBackend.Models.Empleado;

namespace HRBackend.Repository.Interface
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        //Task<Usuario> GetUsuarioByNombre(string nombre);

        Task<Usuario> GetUsuario(string username);
        Task RegisterUsuario(Usuario usuario);
    }
}
