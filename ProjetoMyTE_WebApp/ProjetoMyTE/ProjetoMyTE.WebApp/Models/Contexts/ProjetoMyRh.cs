using Microsoft.EntityFrameworkCore;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Models.Contexts
{
    public class MyRhContext : DbContext
    {
        //construtor da classe
        public MyRhContext(DbContextOptions<MyRhContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mapeamento das entidades para as tabelas
            modelBuilder.Entity<Area>().ToTable("TB_AREA");
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGO");
        }
    }
}
