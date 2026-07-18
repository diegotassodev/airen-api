using System.ComponentModel.DataAnnotations;

namespace AirenApi.Models;

public class Parentesco {

    [Key]
    [Required]
    public int Id {get;set;}

    [Required (ErrorMessage = "O id do personagem não foi definido")]
    public int IdPersonagem {get;set;}
    public virtual Personagem? Personagem {get;set;}

    [Required (ErrorMessage = "O id do parente não foi definido")]
    public int IdParente {get;set;}
    public virtual Personagem? Parente {get;set;}

    public TipoParentesco? TipoParentesco {get;set;}

}

public enum TipoParentesco {
    Pai,
    Mae,
    Filho,
    Filha,
    Irmao,
    Irma,
    Primo,
    Prima,
    Tio,
    Tia,
    Esposa,
    Marido,
    Mestre,
    Aprendiz
}