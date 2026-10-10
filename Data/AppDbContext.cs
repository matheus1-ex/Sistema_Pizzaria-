using SistemaPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPizza.Data;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Conta> Contas => Set<Conta>();

    public DbSet<Cliente> Clientes {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Conta>(
            entidade =>
            {
                entidade.ToTable("Contas");
                entidade.HasKey(account => account.Id);
                entidade.Property(account => account.Nome).IsRequired().HasMaxLength(250);
                entidade.Property(account => account.Email).HasMaxLength(250).IsRequired();
                entidade.Property(account => account.Senha).HasMaxLength(250).IsRequired();
                entidade.HasOne(account => account.cliente).WithMany().HasForeignKey(account => account.IdCliente);
                entidade.Property(account => account.SenhaHash).HasMaxLength(250).IsRequired();
                entidade.Property(account => account.criadoEm).IsRequired();
                
            }
        );

    }
}