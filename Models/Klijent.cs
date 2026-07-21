namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;
using FitnessApp.Models.Enums;
public class Klijent : Osoba
{
    [Range(20, 400)] public int? KilazaPocetna{get;set;}
    [Range(50, 250)] public int? Visina{get;set;}
    [Required] public DateTime DatumPocetka{get;set;} = DateTime.Now; 

    //VEZE
    public int TrenerId {get;set;}
    public Trener? Trener {get;set;}
    public ICollection<KlijentTrening> KlijentTreninzi{get;set;} = new List<KlijentTrening>();
    public ICollection<ProgressRecord> ProgressZapisi{get;set;} = new List<ProgressRecord>();
    //ENUM
    [Required] public Cilj Cilj{get;set;} = Cilj.Nepoznat;
}