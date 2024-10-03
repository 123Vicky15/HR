using HRBackend.Dtos;
using HRBackend.Models.Candidatos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Repository.Repositories;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRBackend.Services.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly ICandidatoRepository _candidatoRepository; 
        public EmpleadoService(IEmpleadoRepository empleadoRepository, IPuestoRepository puestoRepository, ICandidatoRepository candidatoRepository)
        {
            _empleadoRepository = empleadoRepository;
            _puestoRepository = puestoRepository;
            _candidatoRepository = candidatoRepository;
        }

        public async Task<EmpleadoDto> GetEmpleadoByIdAsync(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null)
            {
                return null;
            }

            // Convertir la entidad Empleado a DTO
            return new EmpleadoDto
            {
                //Id = empleado.Id,
                Nombre = empleado.Nombre,
                Cedula = empleado.Cedula,
                FechaIngreso = empleado.FechaIngreso,
                Departamento = empleado.Departamento,
                Puesto = empleado.Puesto,
                SalarioMensual = empleado.SalarioMensual,
                Estado = empleado.Estado
            };
        }

        public async Task<IEnumerable<EmpleadoDto>> GetAllEmpleadosAsync()
        {
            var empleados = await _empleadoRepository.GetAllAsync();

            return empleados.Select(e => new EmpleadoDto
            {
                //Id = e.Id,
                Nombre = e.Nombre,
                Cedula = e.Cedula,
                FechaIngreso = e.FechaIngreso,
                Departamento = e.Departamento,
                Puesto = e.Puesto,
                SalarioMensual = e.SalarioMensual,
                Estado = e.Estado
            });
        }

        public async Task ConvertirCandidatoAEmpleado(ConvertirCandidatoRequest request)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(request.CandidatoId);
            var puesto = await _puestoRepository.GetByIdAsync(request.PuestoId);

            if (request.SalarioMensual <= 0)
            {
                throw new ArgumentException("El salario aspirado no puede ser menor o igual a 0.");
            }
            var empleado = new Empleado
            {
                Nombre = candidato.Nombre,
                Cedula = candidato.Cedula,
                Puesto = puesto.Nombre,
                SalarioMensual = request.SalarioMensual,
                Departamento = request.Departamento,
                FechaIngreso = request.FechaIngreso.ToUniversalTime(),
                Estado = request.Estado
            };
            try
            {

            await _empleadoRepository.AddAsync(empleado);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //public async Task AddEmpleadoNewAsync(Empleado empleado)
        //{
        //    await _empleadoRepository.AddAsync(empleado);
        //}
        //public async Task AddEmpleadoAsync(EmpleadoDto empleadoDto)
        //{
        //    // Mapear el EmpleadoDto a la entidad Empleado
        //    var empleado = new Empleado
        //    {
        //        Cedula = empleadoDto.Cedula,
        //        Nombre = empleadoDto.Nombre,
        //        FechaIngreso = empleadoDto.FechaIngreso,
        //        Departamento = empleadoDto.Departamento,
        //        Puesto = empleadoDto.Puesto,
        //        SalarioMensual = empleadoDto.SalarioMensual,
        //        Estado = empleadoDto.Estado,
        //       // Rol = empleadoDto.Rol
        //    };

        //    // Agregar el nuevo empleado a la base de datos
        //    await _empleadoRepository.AddAsync(empleado);
        //}

        //public async Task UpdateEmpleadoAsync(int id, EmpleadoDto empleadoDto)
        //{
        //    // Buscar el empleado por ID en la base de datos
        //    var empleado = await _empleadoRepository.GetByIdAsync(id);

        //    if (empleado == null)
        //    {
        //        throw new KeyNotFoundException($"Empleado con ID {id} no encontrado");
        //    }

        //    // Actualizar los campos del empleado
        //    empleado.Cedula = empleadoDto.Cedula;
        //    empleado.Nombre = empleadoDto.Nombre;
        //    empleado.FechaIngreso = empleadoDto.FechaIngreso;
        //    empleado.Departamento = empleadoDto.Departamento;
        //    empleado.Puesto = empleadoDto.Puesto;
        //    empleado.SalarioMensual = empleadoDto.SalarioMensual;
        //    empleado.Estado = empleadoDto.Estado;
        //    //empleado.Rol = empleadoDto.Rol;

        //    _empleadoRepository.Update(empleado);
        //}

        public async Task DeleteEmpleadoAsync(int id)
        {
            // Buscar el empleado por ID en la base de datos
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                throw new KeyNotFoundException($"Empleado con ID {id} no encontrado");
            }

            // Eliminar el empleado
            _empleadoRepository.Delete(empleado);

        }

    }
}
