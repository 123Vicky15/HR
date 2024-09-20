using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class IdiomaService : IIdiomaService
    {
        private readonly IIdiomaRepository _idiomaRepository;

        public IdiomaService(IIdiomaRepository idiomaRepository)
        {
            _idiomaRepository = idiomaRepository;
        }

        public async Task<IdiomaDto> GetIdiomaByIdAsync(int id)
        {
            var idioma = await _idiomaRepository.GetByIdAsync(id);
            if (idioma == null)
            {
                throw new KeyNotFoundException($"El idioma con ID {id} no existe.");
            }

            return new IdiomaDto
            {
                Id = idioma.Id,
                Nombre = idioma.Nombre,
                Estado = idioma.Estado
            };
        }

        public async Task<IEnumerable<IdiomaDto>> GetAllIdiomasAsync()
        {
            var idiomas = await _idiomaRepository.GetAllAsync();

            return idiomas.Select(i => new IdiomaDto
            {
                Id = i.Id,
                Nombre = i.Nombre,
                Estado = i.Estado
            });
        }

        public async Task AddIdiomaAsync(IdiomaDto idiomaDto)
        {
            var idioma = new Idioma
            {
                Nombre = idiomaDto.Nombre,
                Estado = idiomaDto.Estado
            };

            await _idiomaRepository.AddAsync(idioma);
        }

        public async Task UpdateIdiomaAsync(IdiomaDto idiomaDto)
        {
            var idioma = await _idiomaRepository.GetByIdAsync(idiomaDto.Id);
            if (idioma == null)
            {
                throw new KeyNotFoundException($"El idioma con ID {idiomaDto.Id} no existe.");
            }

            // Actualizar los campos
            idioma.Nombre = idiomaDto.Nombre;
            idioma.Estado = idiomaDto.Estado;

            _idiomaRepository.Update(idioma);
        }

        public async Task DeleteIdiomaAsync(int id)
        {
            var idioma = await _idiomaRepository.GetByIdAsync(id);
            if (idioma == null)
            {
                throw new KeyNotFoundException($"El idioma con ID {id} no existe.");
            }

            _idiomaRepository.Delete(idioma);
        }
    }
}
