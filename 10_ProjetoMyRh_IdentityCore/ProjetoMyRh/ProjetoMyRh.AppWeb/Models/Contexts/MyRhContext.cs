using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.AppWeb.Models.Entities;

namespace ProjetoMyRh.AppWeb.Models.Contexts
{
    public class MyRhContext : DbContext
    {
        //construtor
        public MyRhContext(DbContextOptions<MyRhContext> options) : base(options) { }

        public DbSet<Area> MyProperty { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapeamento das entidades para as tabelas
            modelBuilder.Entity<Area>().ToTable("TB_AREAS");
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGOS");

            //mapeamento das propriedades para as colunas
            //entidade area
            modelBuilder.Entity<Area>()
                .Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);

            //entidade cargo
            modelBuilder.Entity<Cargo>()
                .Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);

            modelBuilder.Entity<Cargo>()
                .Property(p => p.AreaId)
                .HasColumnName("ID_AREA");

            modelBuilder.Entity<Cargo>()
                .Property(p => p.TipoSalario)
                .HasColumnName("TP_SALARIO");
        }
    }
}
