namespace HRBackend.Dtos
{
    public class ConvertirCandidatoRequest
    {
        public int CandidatoId { get; set; }
        public int PuestoId { get; set; }
        public decimal SalarioMensual { get; set; }
        public required string Departamento { get; set; } 
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
        ///.... empleados
    }
}
