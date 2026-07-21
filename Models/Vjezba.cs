using System.ComponentModel.DataAnnotations;
using FitnessApp.Models.Enums;
using FitnessApp.Models;
public class Vjezba
{
    [Key] public int Id{get;set;}
    [Required] public string Naziv{get;set;} = string.Empty;
    public string? Opis {get;set;}

    //ENUM
    [Required] public Tezina Tezina {get;set;} = Tezina.Lako;
    [Required] public Vrsta Vrsta {get;set;} = Vrsta.Zagrijavanje;

    //veza preko VjezbaMisic
}