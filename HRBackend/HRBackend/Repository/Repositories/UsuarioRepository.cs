using HRBackend.Context;
using HRBackend.Models.Candidatos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Repository.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HRBackendContext context) : base(context) { }

        public async Task<Usuario> GetUsuarioByNombre(string nombre)
        {
            return await _dbSet.Include(u => u.Empleado)
                                          .Include(u => u.Candidato)
                                          .FirstOrDefaultAsync(u => u.UserName == nombre);
        }

        public async Task<Usuario> RegisterUsuario(Usuario usuario)
        {
            await _dbSet.AddAsync(usuario);
            return usuario;
        }
    }

}
