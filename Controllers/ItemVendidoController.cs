using Microsoft.AspNetCore.Mvc;
using SistemaPizza.DTOs;
using SistemaPizza.Data;
using SistemaPizza.Models;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaPizza.Controllers;
[ApiController]
[Route("api/[controller]")]

public sealed class ItemVendidoController : ControllerBase
{
    private readonly IItemVendidoService _itemVendidoService;
    public ItemVendidoController(IItemVendidoService itemVendidoService)
    {
        _itemVendidoService = itemVendidoService;
    }

    [HttpPost("registrar_nota")]
    public async Task<ActionResult<ItemVendidoResponseDto>> registrar(
        [FromBody] ItemVendidoRequestDto dto,
        CancellationToken cancellation
    )
    {
        var item = await _itemVendidoService.CriarAsync(dto, cancellation);
        if (item == null)
        {
            return BadRequest(NotFound(new {mesagem = "não existe."}));
        }
        return Ok(item);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemVendidoResponseDto>> Buscar (
        int id,
        CancellationToken cancellation
    )
    {
        var itemValido = await _itemVendidoService.ConsultarAsync(id, cancellation);
        if (itemValido == null)
        {
            return BadRequest(false);
        }
        return Ok(itemValido);
    }

    [HttpDelete("Remover")]
    public async Task<ActionResult> Remover(
        int id,
        CancellationToken cancellation
    )
    {
        var itemRemovido = await _itemVendidoService.Remover(id, cancellation);
        if (!itemRemovido)
        {
            return BadRequest(false);
        }
        return Ok(itemRemovido);
    }
}