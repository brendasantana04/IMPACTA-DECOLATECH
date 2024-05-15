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
        public DbSet<Colaborador> Colaborador{ get; set; }
        public DbSet<RegistroHoras> RegistroHoras{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //mapeamento das entidades para as tabelas
            modelBuilder.Entity<Area>().ToTable("TB_AREA");
            modelBuilder.Entity<Cargo>().ToTable("TB_CARGO");
            modelBuilder.Entity<WBS>().ToTable("TB_WBS");
            modelBuilder.Entity<Colaborador>().ToTable("TB_COLABORADORES");
            modelBuilder.Entity<RegistroHoras>().ToTable("TB_REGISTRO_HORAS");

            modelBuilder.Entity<Cargo>()
             .Property(p => p.AreaId)
             .HasColumnName("ID_AREA");

            modelBuilder.Entity<WBS>()
             .Property(p => p.Id)
             .HasColumnName("ID");

            modelBuilder.Entity<WBS>()
             .Property(p => p.Codigo)
             .HasColumnName("CODIGO");

            modelBuilder.Entity<WBS>()
             .Property(p => p.Descricao)
             .HasColumnName("DESCRICAO");

            modelBuilder.Entity<WBS>()
             .Property(p => p.Tipo)
             .HasColumnName("TIPO");

            modelBuilder.Entity<Colaborador>()
             .Property(p => p.CargoId)
             .HasColumnName("ID_CARGO");

            modelBuilder.Entity<Colaborador>()
             .Property(p => p.NumMatricula)
             .HasColumnName("NM_MATRICULA");

            modelBuilder.Entity<Colaborador>()
             .Property(p => p.Email)
             .HasColumnName("EMAIL");

            modelBuilder.Entity<RegistroHoras>()
             .Property(p => p.QtdHoras)
             .HasColumnName("QTD_HORAS");

            modelBuilder.Entity<RegistroHoras>()
             .Property(p => p.ColaboradorId)
             .HasColumnName("ID_COLABORADOR");

            modelBuilder.Entity<RegistroHoras>()
             .Property(p => p.WBSId)
             .HasColumnName("ID_WBS");
        }
    }
}
