using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;
using SistemaPizza.Models;

namespace SistemaPizza.DTOs;
public sealed class EntregadorRequestDto
{
    /// <summary>
    /// Aqui é a situação do entregador (nome, disponivel ou não para entrega, status do pedido)
    /// </summary>
    [StringLength(maximumLength: 250, ErrorMessage = "Tamanho de caracter ultrapassado.")]
    [Required(ErrorMessage = "campo obrigatório.")]
    public string Nome {get; set;} = string.Empty;

    [Phone(ErrorMessage = "Tipo de telefone inválido.")]
    [Required(ErrorMessage = "campo obrigatório.")]
    public string Telefone {get; set;} = string.Empty;

    public TipoDeVeiculo veiculo {get; set;} = TipoDeVeiculo.Moto;

    public StatusPedido statusPedido {get; set;} = StatusPedido.Nenhuma_Entrega;

    public Disponivel disponivel {get; set;} = Disponivel.Disponivel;
}

public sealed class EntregadorResponseDto
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public TipoDeVeiculo veiculo {get; set;} = TipoDeVeiculo.Moto;
    public StatusPedido statusPedido {get; set;} = StatusPedido.Nenhuma_Entrega;
    public Disponivel disponivel {get; set;} = Disponivel.Disponivel; 
}