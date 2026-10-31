using SistemaPizza.DTOs;
using SistemaPizza.Models;
using SistemaPizza.Services;
public interface IEntregadorService

{
    Task<EntregadorResponseDto> LoginAsync(EntregadorRequestDto dto, CancellationToken cancellation);
    Task<EntregadorResponseDto> CriarAsync(EntregadorRequestDto dto, CancellationToken cancellation);
    Task<Entregador?> ObterPorIdAsync(int id, CancellationToken cancellation);
    Task<EntregadorResponseDto> AtualizarDisponivelAsync(int id, AtualizarEntregadorDto atualizar, CancellationToken cancellation);
    Task<bool> RemoverAsync(int id, CancellationToken cancellation);
}