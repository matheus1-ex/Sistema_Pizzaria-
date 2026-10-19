using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using SistemaPizza.Models;

namespace SistemaPizza.DTOs;
public sealed class ProdutoRequestDto
{
    [Required(ErrorMessage = "esse campo é obrigatório")]
    public string nome {get; set;} = string.Empty;

    [Required(ErrorMessage = "categoria obrigatória.")]
    public Categoria categoria {get; set;}

    [Required(ErrorMessage = "campo obrigatório.")]
    [StringLength(250, ErrorMessage ="até 250 caracteres, uma descrição direta.")]
    public string descricao {get; set;} = string.Empty;

    [Required(ErrorMessage = "preço obrigatório.")]
    public decimal preco {get; set;}

}

public sealed class ProdutoResponseDto
{

	public int Id {get; set;}
	public string nome {get; set;} = string.Empty;
	public Categoria? categoria {get; set;}
	public string descricao {get; set;} = string.Empty;
	public decimal preco {get; set;}
	public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
}
