namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class Trener : Osoba
{
    [StringLength(1000)]public string? Opis{get;set;}
    [StringLength(200)]public string? Certifikat {get;set;}

    //VEZE
    public ICollection<Klijent> Klijenti {get;set;} = new List<Klijent>();
    public ICollection<Trening> Treninzi{get;set;} = new List<Trening>(); 
    //dodati IColection za  Sablon
    public ICollection<Sablon> Sabloni{get;set;} = new List<Sablon>();
    
}