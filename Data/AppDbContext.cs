using SistemaPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPizza.Data;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Conta> Contas => Set<Conta>();

    public DbSet<Cliente> Clientes {get; set;}

    public DbSet<Entregador> Entregadores {get; set;}

	public DbSet<Produto> Produtos {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Conta>(
            entidade =>
            {
                entidade.ToTable("Contas");
                entidade.HasKey(account => account.Id);
                entidade.HasIndex(account => account.Nome).IsUnique();
                entidade.HasIndex(account => account.Email).IsUnique();
                entidade.HasIndex(account => account.Senha).IsUnique();
                entidade.HasOne(account => account.cliente).WithMany().HasForeignKey(account => account.IdCliente);
                entidade.Property(account => account.SenhaHash).HasMaxLength(250).IsRequired();
                entidade.Property(account => account.status).IsRequired().HasConversion<string>();
                entidade.Property(account => account.criadoEm).IsRequired();
                
            }
        );

        // ==============
        // Cliente
        // ==============
        modelBuilder.Entity<Cliente>(
            entidade =>
            {
                entidade.ToTable("Clientes");
                entidade.HasKey(cliente => cliente.Id);
                entidade.HasIndex(cliente => cliente.Nome).IsUnique();
                entidade.HasIndex(cliente => cliente.Email).IsUnique();
                entidade.Property(cliente => cliente.SenhaHash);
                entidade.HasIndex(cliente => cliente.Telefone).IsUnique();
                entidade.Property(cliente => cliente.Endereco).IsRequired().HasMaxLength(250);
                entidade.Property(cliente => cliente.status).IsRequired().HasConversion<string>();
                entidade.Property(cliente => cliente.criadoEm);
            }
        );

        /// ================
        /// Entregador
        /// ================
        modelBuilder.Entity<Entregador>(
            entidade =>
            {
                entidade.ToTable("Entregadores");
                entidade.HasKey(delivery => delivery.Id);
                entidade.HasIndex(delivery => delivery.Nome).IsUnique();
                entidade.HasIndex(delivery => delivery.Telefone).IsUnique();
                entidade.Property(delivery => delivery.veiculo).IsRequired().HasConversion<string>();
                entidade.Property(delivery => delivery.disponivel).IsRequired().HasConversion<string>();
                entidade.Property(delivery => delivery.status).IsRequired().HasConversion<string>();
                entidade.Property(delivery => delivery.DataAtualizada);
            }
        );

	modelBuilder.Entity<Produto>(
		entidade =>
		{
			entidade.ToTable("Produtos");
			entidade.HasKey(product => product.Id).IsUnique();
			entidade.HasIndex(product => product.Nome).IsUnique();
			entidade.Property(product => product.Descricao).IsRequired().HasMaxLength(250);
			entidade.Property(product => product.Preco).IsRequired();
			entidade.Property(product => product.status).HasConversion<string>().IsRequired();
		}

    }
}
