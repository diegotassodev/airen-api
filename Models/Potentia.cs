using System.ComponentModel.DataAnnotations;

namespace AirenApi.Models;

public class Potentia {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    public int PersonagemId {get;set;}
    public virtual Personagem? Personagem {get;set;}
}