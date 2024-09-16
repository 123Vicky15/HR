namespace HRBackend.Models.Empleado
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public decimal SalarioMensual { get; set; }
        public bool Estado { get; set; } // Activo, Inactivo, etc.
    }
}
