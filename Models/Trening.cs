
using System.ComponentModel.DataAnnotations;

public class Trening
{
    [Key] public int Id{get;set;}
    [Required] public string Naziv {get;set;} =string.Empty;
    public string? Opis{get;set;}
    public int? TrajanjeMinuta{get;set;}

    //VEZE
    [Required] public int TrenerId{get;set;}
    public Trener? Trener {get;set;}

    //dodati ICollection za VjezbaDodjela i KlijentTrening
    public ICollection<VjezbaDodjela> VjezbaDodjele = new List<VjezbaDodjela>();
    public ICollection<KlijentTrening> KlijentTreninzi = new List<KlijentTrening>();
}