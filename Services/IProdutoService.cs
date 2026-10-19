using SistemaPizza.Models;
using SistemaPizza.Data;

namespace SistemaPizza.Services;
public Interface IProdutoService
{
	Task<ProdutoResponseDto> LoginAsync(ProdutoRequestDto dto, CancelllationToken cancellation);
	Task<ProdutoResponseDto> CriarAsync(ProdutoResquestDto dto, CancellationToken cancellation);
	Task<Produto?> ObterPorId(int id, CancellationToken cancellation);
	Task<bool> Remover(int id, CancellationToken cancellation);
}
