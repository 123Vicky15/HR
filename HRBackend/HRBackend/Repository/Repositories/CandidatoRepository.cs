using HRBackend.Context;
using HRBackend.Models.Candidatos;
using HRBackend.Models.Empleado;
using HRBackend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRBackend.Repository.Repositories
{
    public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(HRBackendContext context) : base(context) { }
        public async Task<Candidato> GetEmpleadoByClaveAndNombreAsync(string nombre, string cedula)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Cedula == cedula && e.Nombre == nombre);
        }
        public string EncriptarClave(string clase)  
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encoding.GetBytes(clase));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public bool ValidaCedula(string cedula)
        {
            // Declaración de variables a nivel de método o función.
            int verificador = 0;
            int digito = 0;
            int digitoVerificador = 0;
            int digitoImpar = 0;
            int sumaPar = 0;
            int sumaImpar = 0;
            int longitud = cedula.Length;

            try
            {
                // Verificamos que la longitud del parámetro sea igual a 11.
                if (longitud == 11)
                {
                    digitoVerificador = Convert.ToInt32(cedula.Substring(10, 1));

                    // Recorremos en un ciclo for cada dígito de la cédula.
                    for (int i = 9; i >= 0; i--)
                    {
                        digito = Convert.ToInt32(cedula.Substring(i, 1));

                        // Si el índice es impar, multiplicamos el dígito por 2.
                        if ((i % 2) != 0)
                        {
                            digitoImpar = digito * 2;

                            // Si el dígito obtenido es mayor o igual a 10, restamos 9.
                            if (digitoImpar >= 10)
                            {
                                digitoImpar -= 9;
                            }

                            sumaImpar += digitoImpar;
                        }
                        else
                        {
                            // En los demás casos sumamos el dígito directamente.
                            sumaPar += digito;
                        }
                    }

                    // Obtenemos el verificador restándole a 10 el módulo 10 de la suma total.
                    verificador = 10 - ((sumaPar + sumaImpar) % 10);

                    // Si el verificador es 10 y el dígito verificador es 0, o ambos son iguales, es válido.
                    if ((verificador == 10 && digitoVerificador == 0) || (verificador == digitoVerificador))
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("La cédula debe contener once (11) dígitos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo validar la cédula: {ex.Message}");
            }

            return false;
        }

    }
}
