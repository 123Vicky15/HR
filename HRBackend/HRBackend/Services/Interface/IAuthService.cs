using HRBackend.Dtos;
using HRBackend.Models;

namespace HRBackend.Services.Interface
{
    public interface IAuthService
    {
        Task<EmpleadoDto> LoginEmpleado(LoginDto loginDto);
        Task<CandidatoDto> LoginCandidato(LoginDto loginDto);
        Task<CandidatoDto> RegisterCandidato(CandidatoDto candidatoDto);
    }
}
