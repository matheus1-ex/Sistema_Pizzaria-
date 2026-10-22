using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using SistemaPizza.Models;

namespace SistemaPizza.Models;
public sealed class PedidoRequestDto
{
    /// <summary>
    /// aqui assim que o cliente for digitar o id do produto
    /// automaticamente o sistema vai pegar o nome, endereco, preço
    /// </summary>
    [Required(ErrorMessage = "campo obrigatório.")]
    public int IdCliente {get; set;}
    public int IdEntregador {get; set;}

    public FormaPagamento pagamento {get; set;} = FormaPagamento.Pix;
}

public sealed class PedidoResponseDto
{
    public int IdPedido {get; set;}

    public int IdCliente {get; set;}
    public int IdEntregador {get; set;}

    public Produto? produto {get; set;}

    public FormaPagamento Pagamento {get; set;}

    public decimal TaxaEntrega {get; set;} = 5.00m;

    public decimal ValorTotal => (produto?.Preco ?? 0) + TaxaEntrega;

    public DateTime criadoEm {get; set;} 
    
}