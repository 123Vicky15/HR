using HRBackend.Models.Candidatos;

namespace HRBackend.Dtos
{
    public class EmpleadoDto //: UsuarioDto
    {
        //public int Id { get; set; }
        public string Cedula { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public decimal SalarioMensual { get; set; }
        public bool Estado { get; set; }
        public string PrincipalesCompetencias { get; set; }
        public string PrincipalesCapacitaciones { get; set; }
        public List<ExperienciaLaboral> ExperienciaLaboral { get; set; }
        public string RecomendadoPor { get; set; }
        //public string Rol { get; set; }

    }
}
