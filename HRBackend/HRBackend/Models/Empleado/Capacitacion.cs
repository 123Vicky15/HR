namespace HRBackend.Models.Empleado
{
    public class Capacitacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; } // Grado, Post-grado, Maestría, Doctorado, Técnico, Gestión
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Institucion { get; set; }
    }
}
