using SistemaPizza.Models;
using SistemaPizza.DTOs;
using SistemaPizza.Data;

namespace SistemaPizza.Services;
public interface IProdutoService
{
	Task<ProdutoResponseDto> CriarAsync(ProdutoRequestDto dto, CancellationToken cancellation);
	Task<ProdutoConsumoDto?> ProdutoRegistradoDto(ProdutoRequestDto dto, CancellationToken cancellation);
	Task<Produto?> ObterPorId(int id, CancellationToken cancellation);
	Task<bool> Remover(int id, CancellationToken cancellation);
}
