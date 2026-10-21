using SistemaPizza.DTOs;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Data;
using SistemaPizza.Models;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaPizza.Services;

public sealed class ProdutoService : IProdutoService
{

    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public ProdutoService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<ProdutoResponseDto> CriarAsync(ProdutoRequestDto dto, CancellationToken cancellation)
    {
        var produto = new Produto
        {
            Nome = dto.nome,
            Categoria = dto.categoria,
            Preco = dto.preco,
            Descricao = dto.descricao,
            dataFabricado = dto.dataFabricado,
            dataValidade = dto.dataValidade,
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync(cancellation);
        return new ProdutoResponseDto
        {
            nome = dto.nome,
            categoria = dto.categoria,
            descricao = dto.descricao,
            preco = dto.preco,
            consumo = dto.consumo,
            status = dto.status
        };
    }

    public async Task<Produto?> ObterPorId(int id, CancellationToken cancellation)
    {
        return await _context.Produtos.AsTracking().FirstOrDefaultAsync(
            products => products.IdProduto == id,
            cancellation
        );
    }

    public async Task<bool> Remover(int id, CancellationToken cancellation)
    {
        Produto? product = await _context.Produtos.FirstOrDefaultAsync
        (
            product => product.IdProduto == id
        );

        if (product == null)
        {
            return false;
        }
        _context.Produtos.Remove(product);
        await _context.SaveChangesAsync(cancellation);
        return true;
    }

    public async Task<ProdutoConsumoDto?> ProdutoRegistradoDto(ProdutoRequestDto dto, CancellationToken cancellation)
    {
       var consumo = await _context.Produtos.FirstOrDefaultAsync(consumo => consumo.Nome == dto.nome, cancellation);

        if (consumo == null)
        {
            return null;
        }

        int diasRestantes = (consumo.dataValidade - consumo.dataFabricado).Days;

        return new ProdutoConsumoDto
        {
            consumo = dto.consumo,
            diasValido = diasRestantes,
        };
    }
}