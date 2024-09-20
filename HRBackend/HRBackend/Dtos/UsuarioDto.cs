namespace HRBackend.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? URLFotoPerfil { get; set; }
        public string Clave { get; set; } = null!;
    }
}
