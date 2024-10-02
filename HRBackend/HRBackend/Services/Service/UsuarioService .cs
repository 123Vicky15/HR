using HRBackend.Dtos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using HRBackend.Repository.Repositories;
using HRBackend.Services.Interface;

namespace HRBackend.Services.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> Login(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.GetUsuarioByNombre(usuarioDto.UserName);
            if (usuario == null || usuario.Password != usuarioDto.Password)
                return null;

            // Mapea los datos del Usuario a UsuarioDto antes de retornarlo
            var usuarionew = new Usuario
            {
                UserName = usuarioDto.UserName,
                Password = usuarioDto.Password,
            };
            return usuarioDto;
        }


        public async Task<UsuarioDto> Register(UsuarioDto usuarioDto)
        {
            // Crea una entidad Usuario a partir del UsuarioDto
            var usuario = new Usuario
            {
                UserName = usuarioDto.UserName,
                Password = usuarioDto.Password,
            };

            var usuarioRegistrado = await _usuarioRepository.RegisterUsuario(usuario);

            // Mapea de nuevo a UsuarioDto para retornar
            return new UsuarioDto
            {
                UserName = usuarioRegistrado.UserName,
                Password = usuarioRegistrado.Password
            };
        }
    }
}
