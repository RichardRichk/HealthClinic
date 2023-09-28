using Microsoft.EntityFrameworkCore;
using webapi_HealthClinic.Domains;

namespace webapi_HealthClinic.Contexts
{
    public class HealthContext : DbContext
    {

        public DbSet<TiposUsuario> TiposUsuario { get; set; }


        public DbSet<Clinica> Clinica { get; set; }


        public DbSet<Especialidades> Especialidades { get; set; }


        public DbSet<Usuario> Usuario { get; set; }


        public DbSet<Paciente> Paciente { get; set; }


        public DbSet<Comentarios> Comentarios { get; set; }


        public DbSet<Medico> Medico { get; set; }


        public DbSet<Consulta> Consulta { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE09-S15; Database = HealthClinic_Manha; User Id = sa ; pwd = Senai@134; TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
