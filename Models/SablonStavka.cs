using System.ComponentModel.DataAnnotations;

public class SablonStavka
{
    [Key] public int Id{get;set;}
    public int? BrojSetova{get;set;}
    public int? BrojPonavljanja{get;set;}
    public int? TrajanjeSekundi{get;set;}

    //VEZE
    [Required] public int SablonId{get;set;}
    [Required] public int VjezbaId{get;set;}
}