using Microsoft.AspNetCore.Mvc;
using SistemaPizza.DTOs;
using SistemaPizza.Data;
using SistemaPizza.Models;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace SistemaPizza.Controllers;

public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    //Registrar pedido
    [HttpPost("registrar-pedido")]
    public async Task<ActionResult<PedidoResponseDto>> FazerPedido (
        [FromBody] PedidoRequestDto dto,
        CancellationToken cancellation
    )
    {
        var pedidoRealizado = await _pedidoService.RegistrarPedidoAsync(dto, cancellation);
        if (pedidoRealizado == null)
        {
            return BadRequest(NotFound(new {mensagem = "Pedido não existe/inválido."}));
        }
        return Ok(pedidoRealizado);
    }

    //Analisar o pedido
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PedidoResponseDto>> Analise(
        int id,
        CancellationToken cancellation
    )
    {
        var analisar = await _pedidoService.AnalisarPedidoAsync(id, cancellation);
        if (analisar == null)
        {
            return BadRequest(
                NotFound(
                    new {mensagem = "O Pedido não existe/inválido"}
                )
            );
        }
        return Ok(analisar);
    }

}