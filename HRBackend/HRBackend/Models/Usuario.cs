namespace HRBackend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;

    }
}
