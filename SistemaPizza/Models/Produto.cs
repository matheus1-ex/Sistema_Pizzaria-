namespace SistemaPizza.Models;
public sealed class Produto
{
    public int IdProduto {get; set;}
    //Id da categoria é uma FK
    public int IdCategoria {get; set;}
    public Categoria? Categoria {get; set;}
    //Dados essenciais
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public decimal Preco {get; set;}

    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
}