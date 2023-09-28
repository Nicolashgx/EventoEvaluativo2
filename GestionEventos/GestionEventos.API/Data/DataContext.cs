using Microsoft.EntityFrameworkCore;
using GestionEventos.Shared.Entities;




namespace GestionEventos.API.Data
{
    public class DataContext : DbContext
    {

       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }

        public DbSet<EventoAcademico> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Participantes> Participante { get; set; }

        public DbSet<ProgramaEvento> Programa { get; set; }

      
    }


}