using HRBackend.Dtos;
using HRBackend.Models;
using HRBackend.Models.Candidatos;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace HRBackend.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ICandidatoRepository _candidatoRepository;

        public AuthService(IEmpleadoRepository empleadoRepository, ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
            _empleadoRepository = empleadoRepository;
        }


        public async Task<CandidatoDto> RegisterCandidato(CandidatoDto candidatoDto)
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
                RecomendadoPor = candidatoDto.RecomendadoPor,
                //Correo = candidatoDto.Correo,
                //Clave = _candidatoRepository.EncriptarClave(candidatoDto.Clave)
            };

            await _candidatoRepository.AddAsync(candidato);
            return candidatoDto;

        }
        //public async Task<EmpleadoDto> LoginEmpleado(LoginDto loginDto)
        //{
        //    var empleado = await _empleadoRepository.GetEmpleadoByClaveAndNombreAsync(loginDto.Nombre, _empleadoRepository.EncriptarClave(loginDto.Clave));
            
        //    if (empleado == null)
        //        throw new Exception("Empleado no encontrado");
        //    return new EmpleadoDto
        //    {
        //        //Id = empleado.Id,
        //        Nombre = empleado.Nombre,
        //        Cedula = empleado.Cedula,
        //        //Correo = empleado.Correo,
        //        //Clave = empleado.Clave,
        //        FechaIngreso = empleado.FechaIngreso,
        //        Departamento = empleado.Departamento,
        //        Puesto = empleado.Puesto,
        //        SalarioMensual = empleado.SalarioMensual,
        //        Estado = empleado.Estado,
        //        //Rol = empleado.Rol
        //    };
        // }

        public async Task<CandidatoDto> LoginCandidato(LoginDto loginDto)
        {
            var candidato = await _candidatoRepository.GetEmpleadoByClaveAndNombreAsync(loginDto.Nombre, _candidatoRepository.EncriptarClave(loginDto.Clave));
            if (candidato == null)
                throw new Exception("Candidato no encontrado");

            return new CandidatoDto
            {
                Nombre = candidato.Nombre,
                Cedula = candidato.Cedula,
                PuestoAspira = candidato.PuestoAspira,
                Departamento = candidato.Departamento,
                SalarioAspira = candidato.SalarioAspira,
                PrincipalesCompetencias = candidato.PrincipalesCompetencias,
                PrincipalesCapacitaciones = candidato.PrincipalesCapacitaciones,
                //ExperienciaLaboral = candidato.ExperienciaLaboral,
                RecomendadoPor = candidato.RecomendadoPor,
                //Correo = candidato.Correo,
                //Clave = candidato.Clave
            };
        } 
    }
}
