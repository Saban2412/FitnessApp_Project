
using System.ComponentModel.DataAnnotations;

public abstract class Osoba
{
    [Key] public int Id {get;set;}
    [Required, StringLength(50)] public string Ime {get;set;} = string.Empty;
    [Required,StringLength(50)] public string Prezime{get;set;} = string.Empty;
    [Required] public DateOnly DatumRodjenja {get;set;}

    public virtual string PunoIme()=>$"Puno Ime: {Ime} {Prezime}";
}