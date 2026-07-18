using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateHobbyDto {

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    public int IdVersao {get;set;}
}