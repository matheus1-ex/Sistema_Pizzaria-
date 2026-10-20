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

    [Required(ErrorMessage = "data do produto fabricado obrigatório.")]
    public DateTime dataFabricado {get; set;}

    [Required(ErrorMessage = "data de validade obrigatória.")]
    public DateTime dataValidade {get; set;}

    public StatusAtivo status {get; set;} = StatusAtivo.Ativado;

    public EmConsumo consumo {get; set;}

}

public sealed class ProdutoConsumoDto
{
        public EmConsumo consumo {get; set;}
        public DateTime diaValidade {get; set;}
        public DateTime diaFabricado {get; set;}

        public StatusAtivo status {get; set;} = StatusAtivo.Ativado;

        //Calculo onde o produto é vencido ou não em dias
        public int diaVencido => (diaValidade.Date - diaFabricado.Date).Days;

        // aqui retorna se é possivel ou não o produto consumivel
        public bool Cosumivel => diaVencido >= 0;
        public string mensagem
    {
        get
        {
            if (diaVencido > 0)
            {
                return $"O produto falta {diaVencido} para parar de ser vendido/consumido";
            }
            else if (diaVencido == 0)
            {
                return "O Produto vence hoje e pode parar de ser vendido/consumido";
            }
            return "O Produto já está vencido";
        }
    }
}

public sealed class ProdutoResponseDto
{

	public int Id {get; set;}
	public string nome {get; set;} = string.Empty;
	public Categoria? categoria {get; set;}
	public string descricao {get; set;} = string.Empty;
	public decimal preco {get; set;}
    public EmConsumo consumo {get; set;} = EmConsumo.Consumível;
	public StatusAtivo status {get; set;} = StatusAtivo.Ativado;
}
