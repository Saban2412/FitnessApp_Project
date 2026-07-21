namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class Sablon
{
    [Key] public int Id{get;set;}
    [Required,StringLength(100)] public string Naziv{get;set;}=string.Empty;
    [StringLength(1000)]public string? Opis{get;set;}

    //VEZA
    public int TrenerId{get;set;}
    public Trener? Trener{get;set;}
    public ICollection<SablonStavka> SablonStavke{get;set;} = new List<SablonStavka>();
}