using SistemaPizza.DTOs;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Data;
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
    public Task<Pedido?> AnalisarPedidoAsync(int id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task<PedidoResponseDto> RegistrarPedidoAsync(PedidoRequestDto dto, CancellationToken cancellation)
    {
        var pedido = new Pedido
        {
            IdCliente = dto.IdCliente,
            IdEntregador = dto.IdEntregador,
            pagamento = dto.pagamento        
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync(cancellation);
        return new PedidoResponseDto
        {
            IdCliente = dto.IdCliente,
            IdEntregador = dto.IdEntregador,
            Pagamento = dto.pagamento,
        };
    }
}