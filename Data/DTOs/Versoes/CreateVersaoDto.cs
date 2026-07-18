using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateVersaoDto {

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "O gênero não foi definido")]
    public Genero? Genero {get;set;}

    public string? UrlImagem {get;set;}

    [Required (ErrorMessage = "A idade inicial não foi definida")]
    public int IdadeInicial {get;set;}
    public int IdadeFinal {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    [Required (ErrorMessage = "A personalidade não foi definida")]
    public string? Personalidade {get;set;}

    [Required (ErrorMessage = "O ID do personagem não foi definido")]
    public int IdPersonagem {get;set;}

}