using SistemaPizza.DTOs;
using SistemaPizza.Models;

namespace SistemaPizza.Services;
public interface IItemVendidoService
{
    Task<ItemVendidoResponseDto> CriarAsync (ItemVendidoRequestDto dto, CancellationToken cancellation);
    Task<ItemVendido?> ConsultarAsync (int id, CancellationToken cancellation);
    Task<bool> Remover(int id, CancellationToken cancellation);
}