using Microsoft.EntityFrameworkCore;
using ProjetoMyTE.WebApp.Models.Entities;

namespace ProjetoMyTE.WebApp.Models.Contexts
{
    public class MyTEContext : DbContext
    {
        //construtor da classe
        public MyTEContext(DbContextOptions<MyTEContext> options) : base(options) { }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<WBS> WBS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mapeamento das entidades para as tabelas
            modelBuilder.Entity<Area>().ToTable("TB_AREA");
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGO");
            modelBuilder.Entity<WBS>().ToTable("TB_WBS");

            modelBuilder.Entity<Cargo>()
             .Property(p => p.AreaId)
             .HasColumnName("ID_AREA");
        }
    }
}
