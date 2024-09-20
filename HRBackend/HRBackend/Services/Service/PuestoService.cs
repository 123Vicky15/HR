using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class PuestoService : IPuestoService
    {
        private readonly IPuestoRepository _puestoRepository;

        public PuestoService(IPuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
        }

        public async Task<PuestoDto> GetPuestoByIdAsync(int id)
        {
            var puesto = await _puestoRepository.GetByIdAsync(id);
            if (puesto == null)
            {
                throw new KeyNotFoundException($"El puesto con ID {id} no existe.");
            }

            return new PuestoDto
            {
                Id = puesto.Id,
                Nombre = puesto.Nombre,
                NivelRiesgo = puesto.NivelRiesgo,
                NivelMinimoSalario = puesto.NivelMinimoSalario,
                NivelMaximoSalario = puesto.NivelMaximoSalario,
                Estado = puesto.Estado
            };
        }

        public async Task<IEnumerable<PuestoDto>> GetAllPuestosAsync()
        {
            var puestos = await _puestoRepository.GetAllAsync();

            return puestos.Select(p => new PuestoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                NivelRiesgo = p.NivelRiesgo,
                NivelMinimoSalario = p.NivelMinimoSalario,
                NivelMaximoSalario = p.NivelMaximoSalario,
                Estado = p.Estado
            });
        }

        public async Task AddPuestoAsync(PuestoDto puestoDto)
        {
            var puesto = new Puesto
            {
                Nombre = puestoDto.Nombre,
                NivelRiesgo = puestoDto.NivelRiesgo,
                NivelMinimoSalario = puestoDto.NivelMinimoSalario,
                NivelMaximoSalario = puestoDto.NivelMaximoSalario,
                Estado = puestoDto.Estado
            };

            await _puestoRepository.AddAsync(puesto);
        }

        public async Task UpdatePuestoAsync(PuestoDto puestoDto)
        {
            var puesto = await _puestoRepository.GetByIdAsync(puestoDto.Id);
            if (puesto == null)
            {
                throw new KeyNotFoundException($"El puesto con ID {puestoDto.Id} no existe.");
            }

            // Actualizar los campos
            puesto.Nombre = puestoDto.Nombre;
            puesto.NivelRiesgo = puestoDto.NivelRiesgo;
            puesto.NivelMinimoSalario = puestoDto.NivelMinimoSalario;
            puesto.NivelMaximoSalario = puestoDto.NivelMaximoSalario;
            puesto.Estado = puestoDto.Estado;

             _puestoRepository.Update(puesto);
        }

        public async Task DeletePuestoAsync(int id)
        {
            var puesto = await _puestoRepository.GetByIdAsync(id);
            if (puesto == null)
            {
                throw new KeyNotFoundException($"El puesto con ID {id} no existe.");
            }
             _puestoRepository.Delete(puesto);
        }
    }
}
