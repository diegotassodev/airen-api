using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateAfiliacaoDto {

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    public string? Descricao {get;set;}

}