namespace SistemaPizza.Models;
public sealed class Pedido
{
    public int Id {get; set;}

    public Produto? produto {get; set;}

    //Relacionamento com o cliente
    public int IdCliente {get; set;}
    public Cliente? cliente {get; set;}

    //Relacionamento com o Entregador (1 ---- 0...*)
    public int IdEntregador {get; set;}
    public Entregador? entregador {get; set;}

    public decimal TaxaEntrega {get; set;} = 5.0m;

    public decimal ValorTotal => (produto?.Preco ?? 0) + TaxaEntrega;

    public FormaPagamento pagamento {get; set;}

    public DateTime criadoEm {get;set;}
}