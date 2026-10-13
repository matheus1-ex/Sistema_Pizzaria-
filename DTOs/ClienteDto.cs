using System.ComponentModel.DataAnnotations;
using SistemaPizza.Models;
namespace SistemaPizza.DTOs;
public sealed class ClienteDto
{
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome {get; set;} = string.Empty;

    [Required(ErrorMessage = "Email obrigatório")]
    [EmailAddress(ErrorMessage = "Tipo de email inválido")]
    public string Email {get; set;} = string.Empty;

    [Required(ErrorMessage = "Senha obrigatória")]
    public string Senha {get; set;} = string.Empty;

    [Required(ErrorMessage = "Telefone inválido.")]
    [Phone(ErrorMessage = "Tipo de telefone inválido")]
    public string Telefone {get; set;} = string.Empty;

    [Required(ErrorMessage = "O Endereço é obrigatório")]
    public string Endereco {get; set;} = string.Empty;
}

public sealed class ClienteResponseDto
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Telefone {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public string Endereco {get; set;} = string.Empty;
    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
    public DateTime criadoEm {get; set;} = DateTime.UtcNow;

    //Relacionamento com o id do cliente
    public int IdCliente {get; set;}
    public Cliente? cliente {get; set;}
}