using HRBackend.Dtos;
using HRBackend.Models.Candidatos;


namespace HRBackend.Models.Empleado
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; } 

    }
}
