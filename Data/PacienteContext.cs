using Microsoft.EntityFrameworkCore;
using pacientes.Models;

namespace pacientes.Data
{
    //Contexto de cada objeto paciente para su manipulación en BD
    public class PacienteContext : DbContext
    {
        public PacienteContext(DbContextOptions<PacienteContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Especificación de nombre de tabla
            modelBuilder.Entity<Paciente>()
                .ToTable("PACIENTES");

            //Especificación de campos de tabla
            modelBuilder.Entity<Paciente>()
                .Property(t => t.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.Nombre)
                .HasColumnName("NOMBRE");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.FechaNacimiento)
                .HasColumnName("FEC_NAC");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.Email)
                .HasColumnName("EMAIL");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.Genero)
                .HasColumnName("GENERO");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.Direccion)
                .HasColumnName("DIRECCION");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.Telefono)
                .HasColumnName("TELEFONO");

            modelBuilder.Entity<Paciente>()
                .Property(t => t.FechaAdmision)
                .HasColumnName("FEC_ADM");
        }
    }
}
