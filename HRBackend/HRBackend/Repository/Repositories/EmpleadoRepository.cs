using HRBackend.Context;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRBackend.Repository.Repositories
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(HRBackendContext context) : base(context){}
        public async Task<Empleado> GetEmpleadoByClaveAndNombreAsync(string nombre, string clave)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Clave == clave && e.Nombre == nombre);
        }
        public string EncriptarClave(string clase)
        {
            StringBuilder sb = new StringBuilder();
            using(SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(clase));
                foreach(byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
