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

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }
        public async Task<CandidatoDto> GetCandidatoByIdAsync(int id)
        {
            var candidato = await _candidatoRepository.GetByIdWithExperienciaLaboralAsync(id);
            if (candidato == null)
            {
                return null;
            }

            return new CandidatoDto
            {
                Nombre = candidato.Nombre,
                Cedula = candidato.Cedula,
                PuestoAspira = candidato.PuestoAspira,
                Departamento = candidato.Departamento,
                SalarioAspira = candidato.SalarioAspira,
                PrincipalesCompetencias = candidato.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidato.PrincipalesCapacitaciones,
                RecomendadoPor = candidato.RecomendadoPor,
                ExperienciaLaboralDto = candidato.ExperienciaLaboral.Select(ex => new ExperienciaLaboralDto
                {
                    Empresa = ex.Empresa,
                    PuestoOcupado = ex.PuestoOcupado,
                    FechaDesde = ex.FechaDesde,
                    FechaHasta = ex.FechaHasta,
                    Salario = ex.Salario
                }).ToList()
            };
        }
        public async Task<IEnumerable<CandidatoDto>> GetAllCandidatosAsync()
        {
            var candidatos = await _candidatoRepository.GetAllWithExperienciaLaboralAsync();

            return candidatos.Select(c => new CandidatoDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Cedula = c.Cedula,
                PuestoAspira = c.PuestoAspira,
                Departamento = c.Departamento,
                SalarioAspira = c.SalarioAspira,
                PrincipalesCompetencias = c.PrincipalesCompetencias,
                PrincipalesCapacitaciones = c.PrincipalesCapacitaciones,
                RecomendadoPor = c.RecomendadoPor,
                ExperienciaLaboralDto = c.ExperienciaLaboral.Select(ex => new ExperienciaLaboralDto
                {
                    Empresa = ex.Empresa,
                    PuestoOcupado = ex.PuestoOcupado,
                    FechaDesde = ex.FechaDesde,
                    FechaHasta = ex.FechaHasta,
                    Salario = ex.Salario
                }).ToList()
            }).ToList();
        }
        //public async Task AddCandidatoAsync(CandidatoDto candidatoDto) { }
        public async Task<CandidatoDto> UpdateCandidatoAsync(CandidatoDto candidatoDto)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(candidatoDto.Id);
            if (candidato == null)
            {
                throw new KeyNotFoundException($"El candidato con ID {candidatoDto.Id} no existe.");
            }
            var cedula = _candidatoRepository.ValidaCedula(candidatoDto.Cedula);
            if (!cedula)
            {
                throw new ArgumentException("Cédula inválida.");
            }

            candidato.Nombre = candidatoDto.Nombre;
            candidato.Cedula = candidatoDto.Cedula;
            candidato.PuestoAspira = candidatoDto.PuestoAspira;
            candidato.Departamento = candidatoDto.Departamento;
            candidato.SalarioAspira = candidatoDto.SalarioAspira;
            candidato.PrincipalesCompetencias = candidatoDto.PrincipalesCompetencias;
            candidato.PrincipalesCapacitaciones = candidatoDto.PrincipalesCapacitaciones;
            //ExperienciaLaboral = candidatoDto.ExperienciaLaboral,
            candidato.RecomendadoPor = candidatoDto.RecomendadoPor;

            candidato.ExperienciaLaboral = candidatoDto.ExperienciaLaboralDto.Select(e => new ExperienciaLaboral
            {
                Empresa = e.Empresa,
                PuestoOcupado = e.PuestoOcupado,
                FechaDesde = e.FechaDesde,
                FechaHasta = e.FechaHasta,
                Salario = e.Salario,
                Candidato = candidato  // Relacionar la experiencia con el candidato
            }).ToList();

            _candidatoRepository.Update(candidato);

            return new CandidatoDto
            {
                Nombre = candidato.Nombre,
                Cedula = candidato.Cedula,
                PuestoAspira = candidato.PuestoAspira,
                Departamento = candidato.Departamento,
                SalarioAspira = candidato.SalarioAspira,
                PrincipalesCompetencias = candidato.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidato.PrincipalesCapacitaciones,
                RecomendadoPor = candidato.RecomendadoPor,
                ExperienciaLaboralDto = candidato.ExperienciaLaboral.Select(ex => new ExperienciaLaboralDto
                {
                    Empresa = ex.Empresa,
                    PuestoOcupado = ex.PuestoOcupado,
                    FechaDesde = ex.FechaDesde,
                    FechaHasta = ex.FechaHasta,
                    Salario = ex.Salario
                }).ToList()
            };
        }
        public async Task DeleteCandidatoAsync(int id)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(id);
            if (candidato == null)
            {
                throw new KeyNotFoundException($"El candidato con ID {id} no existe.");
            }

            _candidatoRepository.Delete(candidato);

        }

        //public async Task AddCandidatoAsync(CandidatoDto candidatoDto)
        //{

        //    var cedula = _candidatoRepository.ValidaCedula(candidatoDto.Cedula);
        //    if (!cedula)
        //    {
        //        throw new ArgumentException("Cédula inválida.");
        //    } 

        //    var candidato = new Candidato
        //    {
        //        Nombre = candidatoDto.Nombre,
        //        Cedula = candidatoDto.Cedula,
        //        PuestoAspira = candidatoDto.PuestoAspira,
        //        Departamento = candidatoDto.Departamento,
        //        SalarioAspira = candidatoDto.SalarioAspira,
        //        PrincipalesCompetencias = candidatoDto.PrincipalesCompetencias,
        //        PrincipalesCapacitaciones = candidatoDto.PrincipalesCapacitaciones,
        //        //ExperienciaLaboral = candidatoDto.ExperienciaLaboral,
        //        RecomendadoPor = candidatoDto.RecomendadoPor

        //    };

        //    await _candidatoRepository.AddAsync(candidato);

        //}
        public async Task<List<CandidatoDto>> AddCandidatowithExAsync(CandidatoDto candidatoDto)
        {
            // Validación de cédula
            var cedulaValida = _candidatoRepository.ValidaCedula(candidatoDto.Cedula);
            if (!cedulaValida)
            {
                throw new ArgumentException("Cédula inválida.");
            }

            // Creación de la entidad Candidato
            var candidato = new Candidato
            {
                Nombre = candidatoDto.Nombre,
                Cedula = candidatoDto.Cedula,
                PuestoAspira = candidatoDto.PuestoAspira,
                Departamento = candidatoDto.Departamento,
                SalarioAspira = candidatoDto.SalarioAspira,
                PrincipalesCompetencias = candidatoDto.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidatoDto.PrincipalesCapacitaciones,
                RecomendadoPor = candidatoDto.RecomendadoPor
            };

            // Mapeo de la experiencia laboral desde el DTO
            var experienciasLaborales = candidatoDto.ExperienciaLaboralDto.Select(e => new ExperienciaLaboral
            {
                Empresa = e.Empresa,
                PuestoOcupado = e.PuestoOcupado,
                FechaDesde = e.FechaDesde,
                FechaHasta = e.FechaHasta,
                Salario = e.Salario,
                Candidato = candidato  // Relacionar la experiencia con el candidato
            }).ToList();

            // Asignación de la experiencia laboral al candidato
            candidato.ExperienciaLaboral = experienciasLaborales;

            // Guardar el candidato en la base de datos
            await _candidatoRepository.AddAsync(candidato);

            // Obtener la lista actualizada de candidatos junto con sus experiencias laborales
            var candidatosConExperiencia = await _candidatoRepository.GetAllWithExperienciaLaboralAsync();

            // Convertir los candidatos en DTO para el retorno
            var candidatosDto = candidatosConExperiencia.Select(c => new CandidatoDto
            {
                Nombre = c.Nombre,
                Cedula = c.Cedula,
                PuestoAspira = c.PuestoAspira,
                Departamento = c.Departamento,
                SalarioAspira = c.SalarioAspira,
                PrincipalesCompetencias = c.PrincipalesCompetencias,
                PrincipalesCapacitaciones = c.PrincipalesCapacitaciones,
                RecomendadoPor = c.RecomendadoPor,
                ExperienciaLaboralDto = c.ExperienciaLaboral.Select(ex => new ExperienciaLaboralDto
                {
                    Empresa = ex.Empresa,
                    PuestoOcupado = ex.PuestoOcupado,
                    FechaDesde = ex.FechaDesde,
                    FechaHasta = ex.FechaHasta,
                    Salario = ex.Salario
                }).ToList()
            }).ToList();

            return candidatosDto;
        }

    }
}
