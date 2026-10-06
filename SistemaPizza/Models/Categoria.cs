namespace SistemaPizza.Models;
public sealed class Categoria
{
    public int IdCategoria {get; set;}
    public string Nome {get; set;} = string.Empty;
    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;

}