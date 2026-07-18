using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateTecnicaDto {

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    [Required (ErrorMessage = "A categoria não foi definida")]
    public string? Categoria {get;set;}

    public int IdVersao {get;set;}
}