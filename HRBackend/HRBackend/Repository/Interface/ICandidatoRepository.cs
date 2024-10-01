using HRBackend.Models.Candidatos;

namespace HRBackend.Repository.Interface
{
    public interface ICandidatoRepository : IGenericRepository<Candidato>
    {
        Task<Candidato> GetEmpleadoByClaveAndNombreAsync(string nombre, string cedula);
        string EncriptarClave(string clase);
        bool ValidaCedula(string cedula);
        Task<IEnumerable<Candidato>> GetAllWithExperienciaLaboralAsync();
        Task<Candidato> GetByIdWithExperienciaLaboralAsync(int id);
    }
}
