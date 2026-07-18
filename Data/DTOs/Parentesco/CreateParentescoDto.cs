using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateParentescoDto {

    [Required (ErrorMessage = "O id do personagem não foi definido")]
    public int IdPersonagem {get;set;}

    [Required (ErrorMessage = "O id do parente não foi definido")]
    public int IdParente {get;set;}

    public TipoParentesco? TipoParentesco {get;set;}
}