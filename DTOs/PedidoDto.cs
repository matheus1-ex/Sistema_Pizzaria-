using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using SistemaPizza.Models;

namespace SistemaPizza.DTOs;
public sealed class PedidoRequestDto
{
    /// <summary>
    /// aqui assim que o cliente for digitar o id do produto
    /// automaticamente o sistema vai pegar o nome, endereco, preço
    /// </summary>
    [Required(ErrorMessage = "campo obrigatório.")]
    public int IdCliente {get; set;}
    public FormaPagamento pagamento {get; set;}


    //Os Campos da requisição de item vendido
    public List<ItemVendidoRequestDto> itens {get; set;} = new();

    public string? Observação {get; set;}
}

public sealed class PedidoResponseDto
{
    public int IdPedido {get; set;}

    public int IdCliente {get; set;}
    public int? IdEntregador {get; set;}
    public decimal TaxaEntrega {get; set;} = 5.00m;
    public FormaPagamento Pagamento {get; set;}

    public List<ItemVendidoResponseDto> items {get; set;} = new();

    public decimal ValorTotal => items.Sum(item => item.SubTotal) + TaxaEntrega;

    public DateTime criadoEm {get; set;}
}