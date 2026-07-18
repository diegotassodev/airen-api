using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class ReadParentescoDto {

    public int Id {get;set;}
    public virtual ReadPersonagemDto? Personagem {get;set;}
    public virtual ReadPersonagemDto? Parente {get;set;}
    public TipoParentesco? TipoParentesco {get;set;}
}