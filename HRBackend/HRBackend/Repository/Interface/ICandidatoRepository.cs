using HRBackend.Models.Candidatos;

namespace HRBackend.Repository.Interface
{
    public interface ICandidatoRepository : IGenericRepository<Candidato>
    {
        Task<Candidato> GetEmpleadoByClaveAndNombreAsync(string nombre, string cedula);
        string EncriptarClave(string clase);
    }
}
