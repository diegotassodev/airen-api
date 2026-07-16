using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class ReadPersonagemDto {

    public string? Nome {get;set;}
    public int Idade {get;set;}

    public virtual ReadPotentiaDto? Potentia {get;set;}
}