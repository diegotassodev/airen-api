using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateCapituloDto {

    [Required (ErrorMessage = "O número do capítulo não foi definido")]
    public int Numero {get;set;}

    [Required (ErrorMessage = "O título do capítulo não foi definido")]
    public string? Titulo {get;set;}

    [Required (ErrorMessage = "O resumo do capítulo não foi definido.")]
    public string? Resumo {get;set;}

    [Required (ErrorMessage = "O número de páginas do capítulo não foi definido.")]
    public int NumeroPaginas {get;set;}

}