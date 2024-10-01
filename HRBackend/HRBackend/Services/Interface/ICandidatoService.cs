using HRBackend.Dtos;

namespace HRBackend.Services.Interface
{
    public interface ICandidatoService
    {
        Task<CandidatoDto> GetCandidatoByIdAsync(int id);
        Task<IEnumerable<CandidatoDto>> GetAllCandidatosAsync();
        //Task AddCandidatoAsync(CandidatoDto candidatoDto);
        Task<CandidatoDto> UpdateCandidatoAsync(CandidatoDto candidatoDto);
        Task DeleteCandidatoAsync(int id);
        //Task AddCandidatoAsync(CandidatoDto candidatoDto);
        Task<List<CandidatoDto>> AddCandidatowithExAsync(CandidatoDto candidatoDto);
    }
}
