namespace SistemaPizza.Models;
public sealed class Entregador
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public string Veiculo {get; set;} = string.Empty;
    public Disponivel disponivel {get; set;} = Disponivel.Disponivel;
}