namespace SistemaPizza.Models;
public sealed class Pedido
{
    public int Id {get; set;}

    //Relacionamento com o cliente
    public int IdCliente {get; set;}
    public Cliente? cliente {get; set;}

    //Relacionamento com o produto
    public int IdProduto {get; set;}
    public string NomeProduto {get; set;} = string.Empty;
    public decimal precoProduto {get; set;}
    public Produto? produto {get; set;}

    //Relacionamento com o Entregador
    public int IdEntregador {get; set;}
    public Entregador? entregador {get; set;}

    public FormaPagamento pagamento {get; set;}

    public decimal TaxaEntrega {get; set;} = 5.0m;

    public DateTime criadoEm {get;set;}
}