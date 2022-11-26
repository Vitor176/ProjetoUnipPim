using Microsoft.EntityFrameworkCore;
using ProjetoUnip.Models;

namespace ProjetoUnip.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<Telefone> Telefone { get; set; }

        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                    .HasOne(e => e.Endereco)
                    .WithMany(m => m.Pessoas)
                    .HasForeignKey(e => e.Id_Endereco)
                    .HasConstraintName("FK_PessoasEndereco");

            modelBuilder.Entity<Pessoa>()
                    .HasOne(e => e.Telefone)
                    .WithMany(m => m.Pessoas)
                    .HasForeignKey(e => e.Id_Telefone)
                    .HasConstraintName("FK_PessoasTelefone");

            modelBuilder.Entity<Telefone>()
                    .HasOne(e => e.TipoTelefone)
                    .WithMany(m => m.Telefones)
                    .HasForeignKey(e => e.Id_FKTipoTelefone)
                    .HasConstraintName("FK_TelefoneTipoTelefone");

            //modelBuilder.Entity<Endereco>()
            //    .HasData(
            //        new Endereco {  Id = 1, Logradouro = "Teste", Bairro = "Teste3", Cep = "111111", Cidade = "Testando", Estado = "SP"
            //        });

            //modelBuilder.Entity<Pessoa>()
            //        .HasData(
            //            new Pessoa { Id = 1, Nome = "José", CPF = "12547852", Id_Endereco = 1}
            //        );
        }

    }
}
