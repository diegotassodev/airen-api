using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirenApi.Models;

public class Versao {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O nome não foi definido")]
    public string? Nome {get;set;}

    [Required (ErrorMessage = "O gênero não foi definido")]
    public Genero? Genero {get;set;}

    public string? UrlImagem {get;set;}

    [Required (ErrorMessage = "A idade inicial não foi definida")]
    public int IdadeInicial {get;set;}
    public int IdadeFinal {get;set;}

    [Required (ErrorMessage = "A descrição não foi definida")]
    public string? Descricao {get;set;}

    [Required (ErrorMessage = "A personalidade não foi definida")]
    public string? Personalidade {get;set;}

    [Required (ErrorMessage = "O ID do personagem não foi definido")]
    [ForeignKey(nameof(Personagem))]
    public int IdPersonagem {get;set;}
    public virtual Personagem? Personagem {get;set;}

    public virtual ICollection<Tecnica>? Tecnicas {get;set;}
    public virtual ICollection<Hobby>? Hobbies {get;set;}
    public virtual ICollection<Volume>? Volumes {get;set;}
    
}

public enum Genero {
    Masculino,
    Feminino,
    NaoBinario,
    GeneroFluido,
    Poligenero,
    Outro,
    NaoInformado
}