using SistemaPizza.DTOs;
using SistemaPizza.Services;
public interface IEntregador

{
    Task<EntregadorResponseDto> LoginAsync(EntregadorRequestDto dto, CancellationToken cancellation);
    Task<EntregadorResponseDto> CriarAsync(EntregadorRequestDto dto, CancellationToken cancellation);
    Task<EntregadorResponseDto> ObterPorIdAsync(int id, CancellationToken cancellation);
    Task<bool> RemoverAsync(int id, CancellationToken cancellation);
}