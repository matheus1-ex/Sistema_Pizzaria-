using SistemaPizza.Models;
using SistemaPizza.Data;
using SistemaPizza.DTOs;
using BCryptNet;
using System.Globalization;
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
        var culturaBr = new CultureInfo("pt-BR");
        DateTime agr = DateTime.UtcNow.AddHours(-3);

        string PassWordHash = BCrypt.HashPassword(dto.Senha);

        var novoCliente = new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = dto.Senha,
            Endereco = dto.Endereco,
            Telefone = dto.Telefone,
            SenhaHash = PassWordHash,
            criadoEm = agr.ToString("g", culturaBr),
        };

        _context.Clientes.Add(novoCliente);
        await _context.SaveChangesAsync(cancellation);

        var novaConta = new Conta
        {
            IdCliente = novoCliente.Id,
            Nome = novoCliente.Nome,
            Email = novoCliente.Email,
            Senha = novoCliente.Senha,
            SenhaHash = PassWordHash,
            Endereco = novoCliente.Endereco,
            Telefone = novoCliente.Telefone,
            criadoEm = agr.ToString("g", culturaBr),

        };

        _context.Contas.Add(novaConta);
        await _context.SaveChangesAsync(cancellation);
        return new ClienteResponseDto
        {
            Id = novoCliente.Id,
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = dto.Senha,
            SenhaHash = PassWordHash,
            Telefone = dto.Telefone,
            Endereco = dto.Endereco,
            IdConta = novaConta.Id,
            criadoEm = agr.ToString("g", culturaBr)
        };
    }

    //Login
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto login,CancellationToken cancellation)
    {
        var culturaBr = new CultureInfo("pt-BR");
        DateTime agr = DateTime.UtcNow.AddHours(-3);
        var usuarioLogin = await _context.Contas.Include(conta => conta.cliente).FirstOrDefaultAsync(usr => usr.Email == login.Email, cancellation);

        //Seo o email esta cadastrado ou não
        if (usuarioLogin == null)
        {
            return new LoginResponseDto
            {
                status = StatusAtivo.Desativado
            };
        }

        return new LoginResponseDto
        {
            Email = usuarioLogin.Email,
            Senha = usuarioLogin.Senha,
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