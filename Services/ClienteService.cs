using SistemaPizza.Models;
using SistemaPizza.Data;
using SistemaPizza.DTOs;
using BCryptNet;
using Microsoft.EntityFrameworkCore;

namespace SistemaPizza.Services;

public sealed class ClienteService : IClienteService
{
    private readonly AppDbContext _context;
    private IConfiguration _configuration;

    public ClienteService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    //Serviço de criar uma conta
    public async Task<ClienteResponseDto> CriarAsync(ClienteDto dto, CancellationToken cancellation)
    {
        var usuarioValido = await _context.Contas.AnyAsync(usr => usr.Email == dto.Email, cancellation);

        if(usuarioValido)
        {
            return new ClienteResponseDto
            {
              status = StatusAtivo.Desativado,
            };
        }

        string PassWordHash = BCrypt.HashPassword(dto.Senha);

        var novoCliente = new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Endereco = dto.Endereco,
            Telefone = dto.Telefone,
            SenhaHash = PassWordHash,
            criadoEm = DateTime.UtcNow,
        };

        var novaConta = new Conta
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Senha = dto.Senha,
            Endereco = dto.Endereco,
            SenhaHash = PassWordHash,
            cliente = novoCliente
        };

        _context.Contas.Add(novaConta);
        await _context.SaveChangesAsync(cancellation);
        return await LoginAsync(dto, cancellation);
    }

    //Login
    public async Task<ClienteResponseDto> LoginAsync(ClienteDto dto, CancellationToken cancellation)
    {
        var usuarioLogin = await _context.Contas.Include(conta => conta.cliente).FirstOrDefaultAsync(usr => usr.Email == dto.Email, cancellation);

        if (usuarioLogin == null)
        {
            return new ClienteResponseDto
            {
                status = StatusAtivo.Desativado,
            };
        }

        return new ClienteResponseDto
        {
            Id = usuarioLogin.Id,
            Nome = usuarioLogin.Nome,
            Email = usuarioLogin.Email,
            SenhaHash = usuarioLogin.SenhaHash,
            Telefone = usuarioLogin.Telefone,
            criadoEm = usuarioLogin.criadoEm
        };

    }
    //Serviço de busca o usuario pelo id
    public async Task<Cliente?> ObterPorId(int id, CancellationToken cancellation)
    {
        return await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(
            account => account.Id == id,
            cancellation
        );
    }

    //Serviço de remover o usuário
    public async Task<bool> RemoveAsync(int id, CancellationToken cancellation)
    {
        Cliente? cliente = await _context.Clientes.FirstOrDefaultAsync(
            cliente => cliente.Id == id
        );

        if (cliente == null)
        {
            return false;
        }
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync(cancellation);
        return true;
    }
}