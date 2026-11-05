
namespace SistemaPizza.Models;
public sealed class Produto
{
    public int IdProduto {get; set;}
    
    //Ou seja, cada produto tem a sua respectiva categoria
    public Categoria? Categoria {get; set;}

    //Dados essenciais
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public decimal Preco {get; set;}

    //aqui vai receber o id do pedido na tabela DbSet
    public int IdPedido {get; set;}
    public ICollection<Pedido> Pedidos{get; set;} = new List<Pedido>();

    //Fabricado
    public DateTime dataFabricado {get; set;}

    //Validade
    public DateTime dataValidade {get; set;}

    //consumível
    public EmConsumo consumo {get; set;} = EmConsumo.Consumível;

    public ICollection<ItemVendido> itemVendidos {get; set;}= new List<ItemVendido>();

    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;

    public string mensagem {get; set;} = string.Empty;
}