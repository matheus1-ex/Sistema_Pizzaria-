using SistemaPizza.DTOs;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Data;
using System.Globalization;
using SistemaPizza.Models;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaPizza.Services;

public class PedidoService : IPedidoService
{

    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public PedidoService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public async Task<Pedido?> AnalisarPedidoAsync(int id, CancellationToken cancellation)
    {
        return await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(
            order => order.Id == id,
            cancellation
        );

    }

    public async Task<PedidoResponseDto> RegistrarPedidoAsync(PedidoRequestDto dto, CancellationToken cancellation)
    {
        var hBr = new CultureInfo("pt-BR");
        DateTime agr = DateTime.UtcNow.AddHours(-3);
        
        decimal taxaEntrega = 5.00m;

        decimal SubTotal = dto.itens.Sum(i => i.precoUnd * i.Quantidade);

        decimal TotalCompleto = SubTotal + taxaEntrega;


        var pedido = new Pedido
        {
            IdCliente = dto.IdCliente,
            pagamento = dto.pagamento,
            TaxaEntrega = taxaEntrega,
            criadoEm = agr.ToString("g", hBr),
            Itens = dto.itens.Select(item => new ItemVendido
            {
                IdProduto = item.IdProduto,
                IdEntregador = item.IdEntregador,
                Qtd = item.Quantidade,
                TaxaEntrega = taxaEntrega,
                precoUnitario = item.precoUnd,
                PrecoSubTotal = SubTotal,
            }).ToList(),

        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync(cancellation);
        return new PedidoResponseDto
        {
            Id = pedido.Id,
            IdPedido = pedido.Id,
            IdCliente = dto.IdCliente,
            Pagamento = dto.pagamento,
            TaxaEntrega = pedido.TaxaEntrega,
            ValorTotal = TotalCompleto,
            criadoEm = agr.ToString("g", hBr),
            items = dto.itens.Select(item => new ItemVendidoResponseDto
            {
                IdPedido = item.IdPedido,
                IdProduto = item.IdProduto,
                IdEntregador = item.IdEntregador,
                NomeProduto = item.NomePrduto,
                Qtd = item.Quantidade,
                PrecoUnd = item.precoUnd,
                SubTotal = item.precoUnd * item.Quantidade
            
            }).ToList(),
        

        };
    }
}