namespace SistemaPizza.Models;
public sealed class Cliente
{
    /// <summary>
    /// Aqui é o responsável pelo cliente cadastrado
    /// </summary>
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public string Endereco {get; set;} = string.Empty;
    public DateTime criadoEm {get; set;}

}