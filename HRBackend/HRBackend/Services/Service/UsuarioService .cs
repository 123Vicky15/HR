using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Repository.Repositories;
using HRBackend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Services.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<LoginDto> Login(LoginDto loginDto)
        {
            // Obtener el usuario por nombre
            var usuario = await _usuarioRepository.GetUsuario(loginDto.UserName);

            // Verificar si el usuario no fue encontrado
            if (usuario == null || usuario.Password != loginDto.Password)
            {
                return null; // O lanzar una excepción según tu lógica
            }

            return loginDto; 
        }

        public async Task AddUser(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                UserName = usuarioDto.UserName,
                Password = usuarioDto.Password,
                Rol = "Candidato"

            };
            await _usuarioRepository.AddAsync(usuario);
            usuarioDto.Id = usuario.Id;

        }
        public async Task<UsuarioDto?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDto
            {
                Id = usuario.Id,
                UserName = usuario.UserName,
                Password = usuario.Password 
            };
        }
    }
}
