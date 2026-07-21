namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class Trening
{
    [Key] public int Id{get;set;}
    [Required, StringLength(100)] public string Naziv {get;set;} =string.Empty;
    [StringLength(1000)] public string? Opis{get;set;}
    public int TrajanjeMinuta{get;set;}

    //VEZE
    public int TrenerId{get;set;}
    public Trener? Trener {get;set;}

    //dodati ICollection za VjezbaDodjela i KlijentTrening
    public ICollection<VjezbaDodjela> VjezbaDodjele {get;set;}= new List<VjezbaDodjela>();
    public ICollection<KlijentTrening> KlijentTreninzi {get;set;} = new List<KlijentTrening>();
}