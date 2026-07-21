using System.ComponentModel.DataAnnotations;

public class Misic
{
    [Key] public int Id{get;set;}
    [Required] public string Naziv {get;set;} = string.Empty;
    public string? Opis {get;set;}

    //veza preko VjezbaMisic klase
}