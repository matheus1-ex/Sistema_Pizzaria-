using SistemaPizza.DTOs;
using Microsoft.EntityFrameworkCore;
using SistemaPizza.Data;
using SistemaPizza.Models;
using System.Linq.Expressions;
using System.Globalization;
using System.Security.Cryptography;
namespace SistemaPizza.Services;
public sealed class EntregadorService : IEntregadorService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public EntregadorService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<EntregadorResponseDto> AtualizarDisponivelAsync(int id, AtualizarEntregadorDto atualizar, CancellationToken cancellation)
    {
        var culturaBr = new CultureInfo("pt-BR");
        DateTime agr = DateTime.UtcNow.AddHours(-3);
        var status = await _context.Entregadores.FirstOrDefaultAsync(entregador => entregador.Id == id, cancellation);
        if (status == null)
        {
            return new EntregadorResponseDto
            {
                disponivel = Disponivel.Indisponivel
            };
        }
        status.disponivel = Disponivel.Disponivel;

        /// Independentemente se o pedido for entrege ou não
        /// O Entregador estiver disponivel ou não  pra entrega a data sempre vai se atualziar
        if (atualizar.pedido == StatusPedido.Entregue || atualizar.pedido == StatusPedido.Cancelado)
        {
            status.DataAtualizada = agr.ToString("g",culturaBr);
        }

        if (atualizar.disponivel == Disponivel.Disponivel || atualizar.disponivel == Disponivel.Indisponivel)
        {
            status.DataAtualizada = agr.ToString("g", culturaBr);
        }

        _context.Entregadores.Add(status);
        await _context.SaveChangesAsync(cancellation);
        return new EntregadorResponseDto
        {
            Id = status.Id,
            Nome = atualizar.Nome,
            disponivel = atualizar.disponivel,
        };

    }

    public async Task<EntregadorResponseDto> CriarAsync(EntregadorRequestDto dto, CancellationToken cancellation)
    {
        var entregador = new Entregador
        {
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            veiculo = TipoDeVeiculo.Moto,
            disponivel = Disponivel.Disponivel,
            Aviso = dto.aviso
        };
        
        _context.Entregadores.Add(entregador);
        await _context.SaveChangesAsync(cancellation);
        return new EntregadorResponseDto
        {
            Id = entregador.Id,
            Nome = entregador.Nome,
            Telefone = entregador.Telefone,
            veiculo = TipoDeVeiculo.Moto,
            disponivel = Disponivel.Disponivel,
            aviso = entregador.Aviso
        };
        
    }

    public async Task<EntregadorResponseDto> LoginAsync(EntregadorRequestDto dto, CancellationToken cancellation)
    {
        var valido = await _context.Entregadores.FirstOrDefaultAsync(delivery => delivery.Nome == dto.Nome, cancellation);
        if (valido == null)
        {
            return new EntregadorResponseDto
            {
                disponivel = Disponivel.Indisponivel,
            };
        }
        return new EntregadorResponseDto
        {
            Id = valido.Id,
            Nome = valido.Nome,
            Telefone = valido.Telefone,
            veiculo = valido.veiculo,
            disponivel = valido.disponivel,
            IdPedido = valido.IdPedido,
        };
    }

    public async Task<Entregador?> ObterPorIdAsync(int id, CancellationToken cancellation)
    {
        return await _context.Entregadores.AsTracking().FirstOrDefaultAsync(
            delivery => delivery.Id == id,
            cancellation
        );
    }

    public async Task<bool> RemoverAsync(int id, CancellationToken cancellation)
    {
        Entregador? entregador = await _context.Entregadores.FirstOrDefaultAsync(
            delivery => delivery.Id == id, cancellation
        );

        if (entregador == null)
        {
            return false;
        }

        _context.Entregadores.Remove(entregador);
        await _context.SaveChangesAsync(cancellation);
        return true;
    }
}