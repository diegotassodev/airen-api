using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class ReadVolumeDto {

    public int Id {get;set;}
    public int Numero {get;set;}
    public string? Nome {get;set;}
    public DateTime? DataLancamento {get;set;}
    public string? MensagemVolume {get;set;}
    public string? UrlCapa {get;set;}
    public virtual ICollection<Capitulo>? Capitulos {get;set;}
}