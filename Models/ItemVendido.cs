using SistemaPizza.Models;

public sealed class ItemVendido
{
    /// <summary>
    /// aqui é a nota fiscal de tudo (porem ainda, não tem como baixar em pdf, mas isso é em breve)
    /// </summary>
    public int Id {get; set;}
    
    //relacionamento com pedido
    public int IdPedido {get; set;}
    public Pedido? Pedido {get; set;}

    //relacionamento com produto
    public int IdProduto {get; set;}
    public Produto? produto {get; set;}

    public int IdEntregador {get; set;}
    public Entregador? Entregador {get; set;}

    public decimal precoUnitario {get; set;}

    public string Observação {get; set;} = string.Empty;

    public int Qtd {get; set;}
    public decimal PrecoSubTotal {get; set;}
}