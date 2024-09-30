using HRBackend.Dtos;

namespace HRBackend.Services.Interface
{
    public interface ICandidatoService
    {
        Task<CandidatoDto> GetCandidatoByIdAsync(int id);
        Task<IEnumerable<CandidatoDto>> GetAllCandidatosAsync();
        //Task AddCandidatoAsync(CandidatoDto candidatoDto);
        Task UpdateCandidatoAsync(CandidatoDto candidatoDto);
        Task DeleteCandidatoAsync(int id);
        Task AddCandidatoAsync(CandidatoDto candidatoDto);
    }
}
