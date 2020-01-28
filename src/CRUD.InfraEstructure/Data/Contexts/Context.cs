using CRUD.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD.InfraEstructure.Data.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cliente
            modelBuilder.Entity<Cliente>(c =>
            {
                c.ToTable("Clientes");
                c.HasKey(e => e.Id);
                c.Property(e => e.Id).ValueGeneratedOnAdd();
                c.Property(e => e.Id).IsRequired();

                c.Property(e => e.Nome).IsRequired();
                c.Property(e => e.Nome).HasMaxLength(30);

                c.Property(e => e.CpfCnpj).IsRequired();
                c.Property(e => e.DataNascimento).IsRequired();
                c.HasMany(e => e.Enderecos).WithOne(e => e.Cliente).HasForeignKey(e => e.ClienteId);

                c.HasData(
                    new Cliente { Id = 100, Nome = "Teste do GIL1", CpfCnpj = "00876916043", DataNascimento = new DateTime(1978, 11, 7), IsValid = true },
                    new Cliente { Id = 101, Nome = "Teste do GIL2", CpfCnpj = "00742187004", DataNascimento = new DateTime(1978, 10, 6), IsValid = true }
                    );
            });

            modelBuilder.Entity<Endereco>(l =>
            {
                l.ToTable("Enderecos");
                l.HasKey(e => e.Id);
                l.Property(e => e.Id).ValueGeneratedOnAdd();

                l.Property(e => e.Logradouro).IsRequired();
                l.Property(e => e.Logradouro).HasMaxLength(50);

                l.Property(e => e.Bairro).IsRequired();
                l.Property(e => e.Bairro).HasMaxLength(40);

                l.Property(e => e.Cidade).IsRequired();
                l.Property(e => e.Cidade).HasMaxLength(40);

                l.Property(e => e.Estado).IsRequired();
                l.Property(e => e.Estado).HasMaxLength(40);
            });
        }
    }
}
