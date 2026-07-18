using System.ComponentModel.DataAnnotations;
using AirenApi.Models;

namespace AirenApi.Data.DTOs;

public class CreateVolumeDto {

    [Required (ErrorMessage = "O número do volume não foi definido")]
    public int Numero {get;set;}

    [Required (ErrorMessage = "O nome do volume não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A data de lançamento do volume não foi definida")]
    public DateTime? DataLancamento {get;set;}

    public string? MensagemVolume {get;set;}
    
    public string? UrlCapa {get;set;}
}