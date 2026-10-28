using System.ComponentModel.DataAnnotations;
using SistemaPizza.Models;
namespace SistemaPizza.DTOs;


public sealed class ItemVendidoRequestDto
{
    public int IdProduto {get; set;}
    public int IdEntregador {get; set;}
    public string NomePrduto {get; set;} = string.Empty;
    public decimal precoUnd {get; set;}
    public int Quantidade {get; set;}
    public string Observação {get; set;} = string.Empty;
}

public sealed class ItemVendidoResponseDto
{
    public int Id {get; set;}
    public int IdEntregador {get; set;}
   public int IdProduto {get; set;}
   public string NomeProduto {get; set;} = string.Empty;
   public int Qtd {get; set;}
   public decimal PrecoUnd {get; set;}
   public decimal SubTotal => Qtd * PrecoUnd;

}