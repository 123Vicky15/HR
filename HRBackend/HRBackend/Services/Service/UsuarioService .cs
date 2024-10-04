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
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IEmpleadoRepository _empleadoRepository;


        public UsuarioService(IUsuarioRepository usuarioRepository, ICandidatoRepository candidatoRepository, IEmpleadoRepository empleadoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _candidatoRepository = candidatoRepository;
            _empleadoRepository = empleadoRepository;
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

        public async Task<UsuarioDto> Register(UsuarioDto usuarioDto)
        {
            // Verifica si el nombre de usuario ya existe
            var existingUser = await _usuarioRepository.GetUsuarioByNombre(usuarioDto.UserName);
            if (existingUser != null)
            {
                throw new Exception("El nombre de usuario ya está en uso.");
            }

            var usuario = new Usuario
            {
                UserName = usuarioDto.UserName,
                Password = usuarioDto.Password, // Considera encriptar la contraseña
                Rol = "Candidato" // Asignamos rol de Candidato
            };

            var usuarioRegistrado = await _usuarioRepository.RegisterUsuario(usuario);

            return new UsuarioDto
            {
                UserName = usuarioRegistrado.UserName,
                Password = usuarioRegistrado.Password, // Considera no retornar la contraseña
                Rol = "Candidato" // Retorna el rol asignado
            };
        }
    }
}
