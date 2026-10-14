namespace SistemaPizza.Models;
public sealed class Entregador
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public TipoDeVeiculo veiculo {get; set;} = TipoDeVeiculo.Moto;
    public Disponivel disponivel {get; set;} = Disponivel.Disponivel;
}