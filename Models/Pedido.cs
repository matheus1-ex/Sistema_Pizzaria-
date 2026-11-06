using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaPizza.Models;
public sealed class Pedido
{
    public int Id {get; set;}

    //Relacionamento com o cliente
    public int? IdCliente {get; set;}
    public Cliente? cliente {get; set;}

    public decimal TaxaEntrega {get; set;}

    public ICollection<ItemVendido> Itens {get; set;} = new List<ItemVendido>(); 

    public FormaPagamento pagamento {get; set;}

    public decimal Total {get; set;}

    public string? criadoEm {get;set;}
}