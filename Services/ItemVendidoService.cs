using SistemaPizza.DTOs;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Data;
using System.Globalization;
using SistemaPizza.Models;
using System.Linq.Expressions;
using System.Security.Cryptography;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Http.HttpResults;

public sealed class ItemVendidoService : IItemVendidoService
{

    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public ItemVendidoService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ItemVendido?> ConsultarAsync(int id, CancellationToken cancellation)
    {
        return await _context.Vendidos.AsTracking().FirstOrDefaultAsync(
            sell => sell.Id == id,
            cancellation
        );
    }

    public async Task<ItemVendidoResponseDto> CriarAsync(ItemVendidoRequestDto dto, CancellationToken cancellation)
    {
        var itemVendido = new ItemVendido
        {
            IdPedido = dto.IdPedido,
            IdProduto = dto.IdProduto,
            IdEntregador = dto.IdEntregador,
            precoUnitario = dto.precoUnd,
            Qtd = dto.Quantidade,
            Observação = dto.Observação,
        };
        _context.Vendidos.Add(itemVendido);
        await _context.SaveChangesAsync(cancellation);
        return new ItemVendidoResponseDto
        {
            Id = itemVendido.Id,
            IdPedido = itemVendido.IdPedido,
            IdEntregador = itemVendido.IdEntregador,
            IdProduto = itemVendido.IdProduto,
            NomeProduto = dto.NomePrduto,
            PrecoUnd = dto.precoUnd,
            Qtd = dto.Quantidade,
            SubTotal = dto.precoUnd * dto.Quantidade
        };
    }

    public async Task<bool> Remover(int id, CancellationToken cancellation)
    {
        ItemVendido? item = await _context.Vendidos.FirstOrDefaultAsync(
            sell => sell.Id == id,
            cancellation
        );

        if (item == null)
        {
            return false;
        }
        _context.Vendidos.Remove(item);
        await _context.SaveChangesAsync(cancellation);
        return true;
    }
}