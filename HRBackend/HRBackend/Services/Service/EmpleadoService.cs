using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRBackend.Services.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
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
                Id = empleado.Id,
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
                Id = e.Id,
                Nombre = e.Nombre,
                Cedula = e.Cedula,
                FechaIngreso = e.FechaIngreso,
                Departamento = e.Departamento,
                Puesto = e.Puesto,
                SalarioMensual = e.SalarioMensual,
                Estado = e.Estado
            }).OrderBy(x => x.Id);
        }

        public async Task<Empleado> ConvertirCandidatoAEmpleado(CandidatoDto candidatoDto, EmpleadoDto empleadoDto)
        {
            // Crear un nuevo empleado con la información del candidato
            var empleado = new Empleado
            {
                Cedula = candidatoDto.Cedula,
                Nombre = candidatoDto.Nombre,
                Departamento = empleadoDto.Departamento ?? candidatoDto.Departamento,
                Puesto = empleadoDto.Puesto ?? candidatoDto.PuestoAspira,
                SalarioMensual = empleadoDto.SalarioMensual,
                FechaIngreso = DateTime.Now,
                Estado = empleadoDto.Estado,
               // Rol = empleadoDto.Rol
            };

            // Aquí puedes agregar lógica adicional como validaciones o registros
            return empleado;
        }
        public async Task AddEmpleadoNewAsync(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
        }
        public async Task AddEmpleadoAsync(EmpleadoDto empleadoDto)
        {
            // Mapear el EmpleadoDto a la entidad Empleado
            var empleado = new Empleado
            {
                Cedula = empleadoDto.Cedula,
                Nombre = empleadoDto.Nombre,
                FechaIngreso = empleadoDto.FechaIngreso,
                Departamento = empleadoDto.Departamento,
                Puesto = empleadoDto.Puesto,
                SalarioMensual = empleadoDto.SalarioMensual,
                Estado = empleadoDto.Estado,
               // Rol = empleadoDto.Rol
            };

            // Agregar el nuevo empleado a la base de datos
            await _empleadoRepository.AddAsync(empleado);

            // Guardar los cambios
        }

        public async Task UpdateEmpleadoAsync(int id, EmpleadoDto empleadoDto)
        {
            // Buscar el empleado por ID en la base de datos
            var empleado = await _empleadoRepository.GetByIdAsync(id);

            if (empleado == null)
            {
                throw new KeyNotFoundException($"Empleado con ID {id} no encontrado");
            }

            // Actualizar los campos del empleado
            empleado.Cedula = empleadoDto.Cedula;
            empleado.Nombre = empleadoDto.Nombre;
            empleado.FechaIngreso = empleadoDto.FechaIngreso;
            empleado.Departamento = empleadoDto.Departamento;
            empleado.Puesto = empleadoDto.Puesto;
            empleado.SalarioMensual = empleadoDto.SalarioMensual;
            empleado.Estado = empleadoDto.Estado;
            //empleado.Rol = empleadoDto.Rol;

            _empleadoRepository.Update(empleado);
        }

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
