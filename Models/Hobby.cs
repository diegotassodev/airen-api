using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirenApi.Models;

public class Hobby {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    [ForeignKey(nameof(Versao))]
    public int IdVersao {get;set;}
    public virtual Versao? Versao {get;set;}
}
