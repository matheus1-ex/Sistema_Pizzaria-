using SistemaPizza.Models;

public sealed class ItemVendido
{
    public int Id {get; set;}
    
    //relacionamento com pedido
    public int IdPedido {get; set;}
    public Pedido? pedido {get; set;}
    public ICollection<Pedido> Pedidos {get; set;} = new List<Pedido>();

    //relacionamento com produto
    public int IdProduto {get; set;}
    public Produto? produto {get; set;}
    public ICollection<Produto> Produtos {get; set;} = new List<Produto>(); 

    //relacionamento com o entregador
    public StatusPedido situacaoEntrega {get; set;}
    public Entregador? Entregador {get; set;}
    public ICollection<Entregador> Entregadores {get; set;} = new List<Entregador>();

    public int Qtd {get; set;}
    public decimal PrecoSubTotal {get; set;}
}