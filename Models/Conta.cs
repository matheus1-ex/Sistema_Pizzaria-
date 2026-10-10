namespace SistemaPizza.Models;
public sealed class Conta 
{
    /// <summary>
    /// Aqui é responsável de 'Cadastrar' o cliente da pizzaria
    /// </summary>
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public string Endereco {get; set;} = string.Empty;

    //Aqui é o relacionamento com o cadastro do cliente
    public int IdCliente {get; set;} 
    public Cliente? cliente {get; set;}

    public string Email {get; set;} = string.Empty;
    public string Senha {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
    public DateTime criadoEm {get; set;} = DateTime.UtcNow;
}