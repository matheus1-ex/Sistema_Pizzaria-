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
        return await ProdutoRegistradoDto(dto, cancellation);
    }

    public Task<Produto?> ObterPorId(int id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remover(int id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task<ProdutoResponseDto> ProdutoRegistradoDto(ProdutoRequestDto dto, CancellationToken cancellation)
    {
       var consumo = await _context.Produtos.FirstOrDefaultAsync(consumo => consumo.Nome == dto.nome, cancellation);

        if (consumo == null)
        {
            return new ProdutoResponseDto
            {
                status = StatusAtivo.Desativado,
                consumo = EmConsumo.Não_consumível
            };
        }

        return new ProdutoResponseDto
        {
            nome = dto.nome,
            categoria = dto.categoria,
            descricao = dto.descricao,
            preco = dto.preco,
            consumo = dto.consumo
        };
    }
}