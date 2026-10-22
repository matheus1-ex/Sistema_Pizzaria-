using SistemaPizza.DTOs;
using SistemaPizza.Models;
using SistemaPizza.Services;

public interface IPedidoService
{
    Task<PedidoResponseDto> RegistrarPedidoAsync(PedidoRequestDto dto, CancellationToken cancellation);
    Task<Pedido?> AnalisarPedidoAsync(int id, CancellationToken cancellation);

}