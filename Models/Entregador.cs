namespace SistemaPizza.Models;
public sealed class Entregador
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public TipoDeVeiculo veiculo {get; set;} = TipoDeVeiculo.Moto;
    public Disponivel disponivel {get; set;} = Disponivel.Disponivel;
    public StatusPedido status {get; set;} = StatusPedido.Nenhuma_Entrega;
    public string Aviso {get; set;} = string.Empty;
    public DateTime? DataAtualizada {get; set;}

    public Pedido? Pedidos {get; set;} 
}