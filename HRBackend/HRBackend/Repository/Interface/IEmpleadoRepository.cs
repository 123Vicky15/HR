using HRBackend.Models.Empleado;

namespace HRBackend.Repository.Interface
{
    public interface IEmpleadoRepository : IGenericRepository<Empleado>
    {
        Task<Empleado> GetEmpleadoByClaveAndNombreAsync(string nombre, string cedula);
        string EncriptarClave(string clase);
    }
}
