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

       
        public async Task<Usuario> GetUsuario(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task RegisterUsuario(Usuario usuario)
        {
            await _dbSet.AddAsync(usuario);
        }

    }

}
