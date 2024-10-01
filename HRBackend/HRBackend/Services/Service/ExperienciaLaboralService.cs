using HRBackend.Dtos;
using HRBackend.Models.Candidatos;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class ExperienciaLaboralService : IExperienciaLaboralService
    {
        private readonly IExperienciaLaboralRepository _experienciaLaboralRepository;

        public ExperienciaLaboralService(IExperienciaLaboralRepository experienciaLaboralRepository)
        {
            _experienciaLaboralRepository = experienciaLaboralRepository;
        }

        public async Task<ExperienciaLaboralDto> GetExperienciaLaboralByIdAsync(int id)
        {
            var experienciaLaboral = await _experienciaLaboralRepository.GetByIdAsync(id);
            if (experienciaLaboral == null)
            {
                throw new KeyNotFoundException($"La experiencia laboral con ID {id} no existe.");
            }

            return new ExperienciaLaboralDto
            {
               // Id = experienciaLaboral.Id,
                Empresa = experienciaLaboral.Empresa,
                PuestoOcupado = experienciaLaboral.PuestoOcupado,
                FechaDesde = experienciaLaboral.FechaDesde,
                FechaHasta = experienciaLaboral.FechaHasta,
                Salario = experienciaLaboral.Salario
            };
        }

        public async Task<IEnumerable<ExperienciaLaboralDto>> GetAllExperienciaLaboralAsync()
        {
            var experiencias = await _experienciaLaboralRepository.GetAllAsync();

            return experiencias.Select(e => new ExperienciaLaboralDto
            {
                //Id = e.Id,
                Empresa = e.Empresa,
                PuestoOcupado = e.PuestoOcupado,
                FechaDesde = e.FechaDesde,
                FechaHasta = e.FechaHasta,
                Salario = e.Salario
            });//.OrderBy(x => x.Id);
        }

        public async Task AddExperienciaLaboralAsync(ExperienciaLaboralDto experienciaDto)
        {
            var experienciaLaboral = new ExperienciaLaboral
            {
                Empresa = experienciaDto.Empresa,
                PuestoOcupado = experienciaDto.PuestoOcupado,
                FechaDesde = experienciaDto.FechaDesde.ToUniversalTime(),
                FechaHasta = experienciaDto.FechaHasta.ToUniversalTime(),
                Salario = experienciaDto.Salario
            };

            await _experienciaLaboralRepository.AddAsync(experienciaLaboral);
        }

        //public async Task UpdateExperienciaLaboralAsync(ExperienciaLaboralDto experienciaDto)
        //{
        //    var experienciaLaboral = await _experienciaLaboralRepository.GetByIdAsync(experienciaDto.Id);
        //    if (experienciaLaboral == null)
        //    {
        //        throw new KeyNotFoundException($"La experiencia laboral con ID {experienciaDto.Id} no existe.");
        //    }

        //    // Actualizar los campos
        //    experienciaLaboral.Empresa = experienciaDto.Empresa;
        //    experienciaLaboral.PuestoOcupado = experienciaDto.PuestoOcupado;
        //    experienciaLaboral.FechaDesde = experienciaDto.FechaDesde.ToUniversalTime();
        //    experienciaLaboral.FechaHasta = experienciaDto.FechaHasta.ToUniversalTime();
        //    experienciaLaboral.Salario = experienciaDto.Salario;

        //    _experienciaLaboralRepository.Update(experienciaLaboral);
        //}

        public async Task DeleteExperienciaLaboralAsync(int id)
        {
            var experienciaLaboral = await _experienciaLaboralRepository.GetByIdAsync(id);
            if (experienciaLaboral == null)
            {
                throw new KeyNotFoundException($"La experiencia laboral con ID {id} no existe.");
            }

            _experienciaLaboralRepository.Delete(experienciaLaboral);
        }
    }
}
