using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaPizza.Models;
public sealed class Pedido
{
    public int Id {get; set;}

    public int IdProduto {get; set;}
    public Produto? produto {get; set;}

    //Relacionamento com o cliente
    public int IdCliente {get; set;}
    public Cliente? cliente {get; set;}

    //Relacionamento com o Entregador (1 ---- 0...*)
    public int? IdEntregador {get; set;}
    public Entregador? entregador {get; set;}

    public decimal TaxaEntrega {get; set;} = 5.0m;

    public ICollection<ItemVendido> Itens {get; set;} = new List<ItemVendido>(); 

    public FormaPagamento pagamento {get; set;}

    public decimal SubTotal {get; set;}

    public string? criadoEm {get;set;}
}