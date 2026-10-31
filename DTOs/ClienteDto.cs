using System.ComponentModel.DataAnnotations;
using SistemaPizza.Models;
namespace SistemaPizza.DTOs;
public sealed class ClienteDto
{
    /// <summary>
    /// cadastro do cliente
    /// 
    /// </summary>
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

public sealed class LoginRequestDto
{
    [Required(ErrorMessage ="campo obrigatório")]
    public string Email {get; set;} = string.Empty;
    public string Senha {get; set;} = string.Empty;
}


public sealed class LoginResponseDto
{
    public string Email {get; set;} = string.Empty;
    public string Senha {get; set;} = string.Empty;
    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
}

public sealed class ClienteResponseDto
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string? Senha {get; set;}
    public string? Telefone {get; set;}
    public string SenhaHash {get; set;} = string.Empty;
    public string Endereco {get; set;} = string.Empty;
    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
    public string criadoEm {get; set;} = string.Empty;

    public int IdConta {get; set;}
}