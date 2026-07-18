using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirenApi.Models;

public class Habilidade {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    public string? Descricao {get;set;}

    [Required]
    [ForeignKey(nameof(Potentia))]
    public int IdPotentia {get;set;}
    public virtual Potentia? Potentia {get;set;}
}