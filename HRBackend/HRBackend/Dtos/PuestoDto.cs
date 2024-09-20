namespace HRBackend.Dtos
{
    public class PuestoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NivelRiesgo { get; set; } // Alto, Medio, Bajo
        public decimal NivelMinimoSalario { get; set; }
        public decimal NivelMaximoSalario { get; set; }
        public bool Estado { get; set; } // Activo, Inactivo, etc.
    }
}
