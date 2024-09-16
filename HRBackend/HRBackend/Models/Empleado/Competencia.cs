namespace HRBackend.Models.Empleado
{
    public class Competencia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } // Activo, Inactivo, etc.
    }
}
