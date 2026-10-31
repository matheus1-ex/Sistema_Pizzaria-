using SistemaPizza.Models;
using SistemaPizza.DTOs;
using System.Linq.Expressions;

namespace SistemaPizza.Services;
public interface IClienteService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto login, CancellationToken cancellation);
    Task<ClienteResponseDto> CriarAsync(ClienteDto dto, CancellationToken cancellation);
    Task<Cliente?> ObterPorId(int id, CancellationToken cancellation);
    Task<bool> RemoveAsync(int id, CancellationToken cancellation);
}