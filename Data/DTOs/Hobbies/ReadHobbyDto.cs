using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class ReadHobbyDto {

    public int Id {get;set;}
    public string? Nome {get;set;}
    public string? Descricao {get;set;}
}