using HRBackend.Dtos;
using HRBackend.Models.Candidatos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Services.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IExperienciaLaboralRepository _experienciaRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository, IExperienciaLaboralRepository experienciaRepository)
        {
            _candidatoRepository = candidatoRepository;
            _experienciaRepository = experienciaRepository;
        }
        public async Task<CandidatoDto> GetCandidatoByIdAsync(int id)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(id);
            if (candidato == null)
            {
                return null;
            }

            var experiencias = await _experienciaRepository.GetExperienciasByCandidatoIdAsync(candidato.Id);

            return new CandidatoDto
            {
                Id = candidato.Id,
                Nombre = candidato.Nombre,
                Cedula = candidato.Cedula,
                PuestoAspira = candidato.PuestoAspira,
                Departamento = candidato.Departamento,
                SalarioAspira = candidato.SalarioAspira,
                PrincipalesCompetencias = candidato.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidato.PrincipalesCapacitaciones,
                RecomendadoPor = candidato.RecomendadoPor,
                // Mapear experiencias
                ExperienciaLaboralDto = experiencias.Select(e => new ExperienciaLaboralDto
                {
                    Id = e.Id,
                    PuestoOcupado = e.PuestoOcupado,
                    Empresa = e.Empresa,
                    FechaDesde = e.FechaDesde.ToUniversalTime(),
                    FechaHasta = e.FechaHasta.ToUniversalTime(),
                    Salario = e.Salario
                }).ToList(),
            };
        }
        public async Task<IEnumerable<CandidatoDto>> GetAllCandidatosAsync()
        {
            var candidatos = await _candidatoRepository.GetAllAsync();

            return candidatos.Select(e => new CandidatoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Cedula = e.Cedula,
                PuestoAspira = e.PuestoAspira,
                Departamento = e.Departamento,
                SalarioAspira = e.SalarioAspira,
                PrincipalesCompetencias = e.PrincipalesCompetencias,
                PrincipalesCapacitaciones = e.PrincipalesCapacitaciones,
                //ExperienciaLaboral = e.ExperienciaLaboral,
                RecomendadoPor = e.RecomendadoPor
            }).OrderBy(x => x.Id);
        }
        //public async Task AddCandidatoAsync(CandidatoDto candidatoDto) { }
        //public async Task UpdateCandidatoAsync(int id, CandidatoDto candidatoDto){}
        public async Task DeleteCandidatoAsync(int id)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(id);
            if (candidato == null)
            {
                throw new KeyNotFoundException($"El candidato con ID {id} no existe.");
            }
            var experiencias = await _experienciaRepository.GetExperienciasByCandidatoIdAsync(id);
            foreach (var experiencia in experiencias)
            {
                 _experienciaRepository.Delete(experiencia);
            }
            _candidatoRepository.Delete(candidato);

        }
        public async Task<bool> RegistrarCandidatoAsync(CandidatoDto candidatoDto)
        {
            var candidato = new Candidato
            {
                Nombre = candidatoDto.Nombre,
                Cedula = candidatoDto.Cedula,
                PuestoAspira = candidatoDto.PuestoAspira,
                Departamento = candidatoDto.Departamento,
                SalarioAspira = candidatoDto.SalarioAspira,
                PrincipalesCompetencias = candidatoDto.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidatoDto.PrincipalesCapacitaciones,
                //ExperienciaLaboral = candidatoDto.ExperienciaLaboral,
                RecomendadoPor = candidatoDto.RecomendadoPor

            };
            await _candidatoRepository.AddAsync(candidato);
            foreach (var experienciaLaboralDto in candidatoDto.ExperienciaLaboralDto)
            {
                var experienciaLaboral = new ExperienciaLaboral
                {
                    PuestoOcupado = experienciaLaboralDto.PuestoOcupado,
                    Empresa = experienciaLaboralDto.Empresa,
                    FechaDesde = experienciaLaboralDto.FechaDesde,
                    FechaHasta = experienciaLaboralDto.FechaHasta,
                    Salario = experienciaLaboralDto.Salario,
                    Id = candidato.Id // Usar el ID del candidato recién creado
                };
                await _experienciaRepository.AddAsync(experienciaLaboral);
            }
            return true;

        }
    }
}
