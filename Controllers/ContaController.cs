using Microsoft.AspNetCore.Mvc;
using SistemaPizza.DTOs;
using SistemaPizza.Data;
using SistemaPizza.Models;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace SistemaPizza.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ContaController : ControllerBase
{
    private readonly IClienteService _clienteService;
    public ContaController(IClienteService cliente)
    {
        _clienteService = cliente;
    }
    [HttpPost("Conta")]
    public async  Task<ActionResult<ClienteResponseDto>> Conta(
        [FromBody] ClienteDto dto,
        CancellationToken cancellation
    )
    {
        var resposta = await _clienteService.LoginAsync(dto, cancellation);
        if (resposta.status == StatusAtivo.Desativado)
        {
            return Unauthorized(resposta);
        }
        return Ok(resposta);
    }

    [HttpPost("Cadastro")]
    public async Task<ActionResult<ClienteResponseDto>> Registro (
        [FromBody] ClienteDto dto,
        CancellationToken cancellation
    )
    {
        var resultado = await _clienteService.CriarAsync(dto, cancellation);
        if (resultado.status == StatusAtivo.Desativado)
        {
            return BadRequest(resultado);
        }
        return Ok(resultado);
    }

    //Buscar pelo id SE o cliente existe no banco
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClienteResponseDto>> Busca(
        int id,
        CancellationToken cancellation
    )
    {
        var busca = await _clienteService.ObterPorId(id, cancellation);
        if (busca == null)
        {
            return NotFound(new {mensagem = $"cliente com o id {id} não foi encontrado."});
        }
        return Ok(busca);
    }


    //Remover (aqui o cliente/usuário tem a opção de remover a conta dele(a))
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ClienteResponseDto>> Remover(
        int id,
        CancellationToken cancellation
    )
    {
        bool remove = await _clienteService.RemoveAsync(id, cancellation);
        if (!remove)
        {
            return NotFound(new{mensagem = "Não encontrado."});
        }
        return Ok(remove);
    }



}
