using System.ComponentModel.DataAnnotations;

namespace AirenApi.Models;

public class Personagem {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "O nome original não foi definido")]
    public string? NomeOriginal {get;set;}

    [Required (ErrorMessage = "A biografia não foi definida")]
    public string? Biografia {get;set;}

    [Required (ErrorMessage = "A data de nascimento não foi definida")]
    public DateTime? DataNascimento {get;set;}

    public bool EstaVivo {get;set;}
    
    public virtual Potentia? Potentia {get;set;}
    public virtual ICollection<Versao>? Versoes {get;set;}

    public virtual ICollection<Afiliacao>? Afiliacoes {get;set;}

    public virtual ICollection<Parentesco>? Parentes {get;set;}
}