using System.ComponentModel.DataAnnotations;

namespace AirenApi.Models;

public class Personagem {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A idade não foi definida.")]
    public int Idade {get;set;}

    public virtual Potentia? Potentia {get;set;}
}