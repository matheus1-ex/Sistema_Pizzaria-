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
        DateTime agr = DateTime.Now;
        var pedido = new Pedido
        {
            IdCliente = dto.IdCliente,
            IdEntregador = null,
            pagamento = dto.pagamento,
            TaxaEntrega = 5.00m,
            criadoEm = agr.ToString("g", hBr)

        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync(cancellation);
        return new PedidoResponseDto
        {
            IdCliente = dto.IdCliente,
            items = dto.itens.Select(item => new ItemVendidoResponseDto
            {
                IdProduto = item.IdProduto,
                Qtd = item.Quantidade,

            }).ToList(),
            Pagamento = dto.pagamento,

        };
    }
}