using Microsoft.AspNetCore.Mvc;
using SistemaPizza.DTOs;
using SistemaPizza.Data;
using SistemaPizza.Models;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace SistemaPizza.Controllers;
[ApiController]
[Route("api/[controller]")]

public class EntregadorController : ControllerBase
{
    private readonly IEntregadorService _entregadorService;
    public EntregadorController(IEntregadorService entregador)
    {
        _entregadorService = entregador;
    }

    //Registrar o entregador
    [HttpPost("registro")]
    public async Task<ActionResult<EntregadorResponseDto>> Registro (
        [FromBody] EntregadorRequestDto dto,
        CancellationToken cancellation
    )
    {
        var resultado = await _entregadorService.CriarAsync(dto, cancellation);
        if (resultado.disponivel == Disponivel.Indisponivel)
        {
            return BadRequest(resultado);
        }
        return Ok(resultado);
    }

    //Login para o entregador
    [HttpPost("Login")]
    public async Task<ActionResult<EntregadorResponseDto>> Login(
        [FromBody] EntregadorRequestDto dto,
        CancellationToken cancellation
    )
    {
        var resultado = await _entregadorService.LoginAsync(dto, cancellation);
        if (resultado == null)
        {
            return BadRequest(resultado);
        }
        return Ok(resultado);
    }

    //Buscar entregador pelo Id
    [HttpGet("{id:int}")]
    public async Task<ActionResult<EntregadorResponseDto>> Buscar(
        int id,
        CancellationToken cancellation
    )
    {
        var resultado = await _entregadorService.ObterPorIdAsync(id, cancellation);
        if (resultado == null)
        {
            return NotFound(new {mensagem = $"entregador com o id {id} não foi encontrado."});
        }
        return Ok(resultado);
    }

    //Atualizar a situação do entregador
    [HttpPatch("{id}/status")]
    public async Task<ActionResult> AtualizarDisponivel (
        [FromRoute] int id,
        [FromBody] AtualizarEntregadorDto dto,
        CancellationToken cancellation
    )
    {
        var resultado = await _entregadorService.AtualizarDisponivelAsync(id, dto, cancellation);
        if (resultado == null)
        {
            return NotFound(new {mensagem = "entregador não atualizado"});
        }
        return Ok(resultado);
    }

    //Remover (entregador tem o poder de excluir sua conta)
    [HttpDelete("Remover")]
    public async Task<ActionResult> RemoverEntregador(
        int id,
        CancellationToken cancellation
    )
    {
        var remover = await _entregadorService.RemoverAsync(id, cancellation);
        if (!remover)
        {
            return NotFound(new {mensagem = "Entregador não encontrad/Inválido"});
        }
        return Ok(remover);
    }



}