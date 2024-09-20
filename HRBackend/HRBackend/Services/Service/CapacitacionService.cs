using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class CapacitacionService : ICapacitacionService
    {
        private readonly ICapacitacionRepository _capacitacionRepository;

        public CapacitacionService(ICapacitacionRepository capacitacionRepository)
        {
            _capacitacionRepository = capacitacionRepository;
        }

        // Agregar una nueva capacitación
        public async Task AddCapacitacionAsync(CapacitacionDto capacitacionDto)
        {
            var capacitacion = new Capacitacion
            {
                Descripcion = capacitacionDto.Descripcion,
                Nivel = capacitacionDto.Nivel,
                FechaDesde = capacitacionDto.FechaDesde,
                FechaHasta = capacitacionDto.FechaHasta,
                Institucion = capacitacionDto.Institucion
            };

            await _capacitacionRepository.AddAsync(capacitacion);

            // Retornar el DTO en caso de necesitarlo después de guardar
        }

        // Eliminar capacitación por ID
        public async Task DeleteCapacitacionAsync(int id)
        {
            var capacitacion = await _capacitacionRepository.GetByIdAsync(id);
            if (capacitacion == null)
            {
                throw new KeyNotFoundException($"La capacitación con ID {id} no existe.");
            }

            _capacitacionRepository.Delete(capacitacion);
        }

        // Obtener capacitación por ID
        public async Task<CapacitacionDto> GetCapacitacionByIdAsync(int id)
        {
            var capacitacion = await _capacitacionRepository.GetByIdAsync(id);
            if (capacitacion == null)
            {
                throw new KeyNotFoundException($"La capacitación con ID {id} no existe.");
            }

            // Mapear la entidad a DTO
            return new CapacitacionDto
            {
                Id = capacitacion.Id,
                Descripcion = capacitacion.Descripcion,
                Nivel = capacitacion.Nivel,
                FechaDesde = capacitacion.FechaDesde,
                FechaHasta = capacitacion.FechaHasta,
                Institucion = capacitacion.Institucion
            };
        }

        // Obtener lista de capacitaciones
        public async Task<IEnumerable<CapacitacionDto>> GetCapacitacionListAsync()
        {
            var capacitaciones = await _capacitacionRepository.GetAllAsync();

            // Mapear la lista de entidades a una lista de DTOs
            return capacitaciones.Select(e => new CapacitacionDto
            {
                Id = e.Id,
                Descripcion = e.Descripcion,
                Nivel = e.Nivel,
                FechaDesde = e.FechaDesde,
                FechaHasta = e.FechaHasta,
                Institucion = e.Institucion
            });
        }

        // Actualizar una capacitación existente
        public async Task UpdateCapacitacionAsync(CapacitacionDto capacitacionDto)
        {
            var capacitacion = await _capacitacionRepository.GetByIdAsync(capacitacionDto.Id);
            if (capacitacion == null)
            {
                throw new KeyNotFoundException($"La capacitación con ID {capacitacionDto.Id} no existe.");
            }

            // Actualizar los campos de la entidad
            capacitacion.Descripcion = capacitacionDto.Descripcion;
            capacitacion.Nivel = capacitacionDto.Nivel;
            capacitacion.FechaDesde = capacitacionDto.FechaDesde;
            capacitacion.FechaHasta = capacitacionDto.FechaHasta;
            capacitacion.Institucion = capacitacionDto.Institucion;

             _capacitacionRepository.Update(capacitacion);
        }
    }
}
