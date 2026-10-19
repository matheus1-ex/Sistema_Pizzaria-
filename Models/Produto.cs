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

    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
}