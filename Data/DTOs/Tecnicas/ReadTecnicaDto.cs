using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class ReadTecnicaDto {

    public int Id {get;set;}
    public string? Nome {get;set;}
    public string? Descricao {get;set;}
    public string? Categoria {get;set;}
}