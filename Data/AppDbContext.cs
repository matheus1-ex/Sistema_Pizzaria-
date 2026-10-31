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

    public DbSet<Pedido> Pedidos {get; set;}

    public DbSet<ItemVendido> Vendidos {get; set;}

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
                entidade.Property(delivery => delivery.disponivel).HasConversion<string>();
                entidade.Property(delivery => delivery.status).IsRequired().HasConversion<string>();
                entidade.Property(delivery => delivery.DataAtualizada);
            }
        );

        /// =============
        /// Produto
        /// =============

	modelBuilder.Entity<Produto>(
		entidade =>
		{
			entidade.ToTable("Produtos");
			entidade.HasKey(product => product.IdProduto);
            entidade.Property(product => product.Categoria).HasConversion<string>();
			entidade.HasIndex(product => product.Nome).IsUnique();
			entidade.Property(product => product.Descricao).IsRequired().HasMaxLength(250);
			entidade.Property(product => product.Preco).IsRequired();
            entidade.Property(product => product.dataFabricado).IsRequired();
            entidade.Property(product => product.dataValidade).IsRequired();
            entidade.Property(product => product.consumo).HasConversion<string>().IsRequired();
			entidade.Property(product => product.status).HasConversion<string>().IsRequired();
		}
    );

    /// ==============
    /// Pedidos
    /// ==============
    modelBuilder.Entity<Pedido>(
        entidade =>
        {
            entidade.ToTable("Pedidos");
            entidade.HasKey(order => order.Id);

            entidade.HasOne(pedido => pedido.cliente)
            .WithMany(client => client.Pedidos)
            .HasForeignKey(clientId => clientId.IdCliente);

            entidade.HasOne(delivery => delivery.entregador)
            .WithMany()
            .HasForeignKey(deliveryId => deliveryId.IdEntregador);

            entidade.Property(delivery => delivery.pagamento).HasConversion<string>().IsRequired();

            entidade.Property(order => order.TaxaEntrega).IsRequired();

            entidade.Property(order => order.criadoEm);

        }
    );

    /// =========
    /// Item vendido (aqui vai mostrar o total de tudo)
    /// =========
    modelBuilder.Entity<ItemVendido>(
        ent =>
        {
            ent.ToTable("Vendidos");

            ent.HasKey(sell => sell.Id);
            ent.HasOne(sell => sell.produto)
            .WithMany(pedidos => pedidos.itemVendidos)
            .HasForeignKey(order => order.IdProduto)
            .OnDelete(DeleteBehavior.Restrict);

            ent.HasOne(sell => sell.Pedido)
            .WithMany(itens => itens.Itens)
            .HasForeignKey(i => i.IdPedido);

            ent.Property(quanty => quanty.Qtd).IsRequired();

            ent.Property(unity => unity.precoUnitario).IsRequired();

            ent.Property(total => total.PrecoSubTotal).HasComputedColumnSql("[Qtd] * [precoUnitario]");

        }
    );
    }
}
