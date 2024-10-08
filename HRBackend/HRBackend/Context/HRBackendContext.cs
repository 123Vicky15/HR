namespace HRBackend.Context;

using HRBackend.Models.Candidatos;
using HRBackend.Models.Empleado;
using Microsoft.EntityFrameworkCore;

public class HRBackendContext : DbContext 
{
    public HRBackendContext(DbContextOptions<HRBackendContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<ExperienciaLaboral> ExperienciaLaborals { get; set; }
    public DbSet<Competencia> Competencias { get; set; }
    public DbSet<Idioma> Idiomas { get; set; }
    public DbSet<Capacitacion> Capacitacions {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>()
            .HasMany(c => c.ExperienciaLaboral)
            .WithOne(e => e.Candidato)
            .HasForeignKey(e => e.CandidatoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=HumanResorces;Username= postgres;Password= MV2004");
        }
    }

}
