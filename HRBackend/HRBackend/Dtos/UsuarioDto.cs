namespace HRBackend.Dtos
{
    public class UsuarioDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Rol { get; set; }

    }
}
