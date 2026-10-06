namespace SistemaPizza.Models;
public sealed class Conta 
{
    public int Id {get; set;}

    //Aqui é o relacionamento com o cadastro do cliente
    public int IdCliente {get; set;} 
    public Cliente? cliente {get; set;}

    public string Email {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public DateTime criadoEm {get; set;} = DateTime.UtcNow;
}