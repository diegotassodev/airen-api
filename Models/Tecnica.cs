using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirenApi.Models;

public class Tecnica {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    [Required (ErrorMessage = "A categoria não foi definida")]
    public string? Categoria {get;set;}

    [ForeignKey(nameof(Versao))]
    public int IdVersao {get;set;}
    public virtual Versao? Versao {get;set;}
}