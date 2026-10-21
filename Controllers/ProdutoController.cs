using Microsoft.AspNetCore.Mvc;
using SistemaPizza.DTOs;
using SistemaPizza.Data;
using SistemaPizza.Models;
using SistemaPizza.Services;
using Microsoft.AspNetCore.Identity.Data;

namespace SistemaPizza.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    //Criar Produto
    [HttpPost("criar-produto")]
    public async Task<ActionResult<ProdutoResponseDto>> Criar(
        [FromBody] ProdutoRequestDto dto,
        CancellationToken cancellation
    )
    {
        var resultado = await _produtoService.CriarAsync(dto, cancellation);
        if (resultado.status == StatusAtivo.Desativado)
        {
            return BadRequest(resultado.status = StatusAtivo.Desativado);
        }
        return Ok(resultado);
    }

    //Verificar o produto registrado
    [HttpPost("verificar-produto")]
    public async Task<ActionResult<ProdutoConsumoDto>> Produto_Registrado(
        [FromBody] ProdutoRequestDto dto,
        CancellationToken cancellation
    )
    {
        var registrado = await _produtoService.ProdutoRegistradoDto(dto, cancellation);
        if (registrado == null || registrado.consumo == EmConsumo.Não_consumível)
        {
            return BadRequest(new {mensagem = "Produto não existe/não pode ser consumível"});
        }
        return Ok(registrado);
    }

    //Buscar o produto por o identificador
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoResponseDto>> Buscar
    (
        int id,
        CancellationToken cancellation
    )
    {
        var buscar = await _produtoService.ObterPorId(id, cancellation);
        if (buscar == null)
        {
            return BadRequest(new {mensagem = "Não possível encontrar esse produto, porque ele não existe."});
        }
        return Ok(buscar);
    }

    //Remover o Produto
    public async Task<ActionResult> Remover(
        int id,
        CancellationToken cancellation
    )
    {
        var remove = await _produtoService.Remover(id, cancellation);
        if (!remove)
        {
            return BadRequest(new {msg="impossível de remover esse produto, porque ele não existe"});
        }
        return Ok(remove);
    }

}
