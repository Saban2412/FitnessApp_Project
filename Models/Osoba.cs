namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public abstract class Osoba
{
    [Key] public int Id {get;set;}
    [Required, StringLength(50)] public string Ime {get;set;} = string.Empty;
    [Required,StringLength(50)] public string Prezime{get;set;} = string.Empty;
    [Required] public DateTime DatumRodjenja {get;set;}
    public int Godine => DateTime.Today.Year - DatumRodjenja.Year - 
    (DateTime.Today.DayOfYear < DatumRodjenja.DayOfYear ? 1 : 0);

    public virtual string PunoIme()=>$"Puno Ime: {Ime} {Prezime}";
}