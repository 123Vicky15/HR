using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
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

    }
}
