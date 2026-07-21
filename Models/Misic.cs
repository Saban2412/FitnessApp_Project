namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class Misic
{
    [Key] public int Id{get;set;}
    [Required,StringLength(50)] public string Naziv {get;set;} = string.Empty;
    [StringLength(500)]public string? Opis {get;set;}

    public ICollection<VjezbaMisic> VjezbaMisici { get; set; } = new List<VjezbaMisic>();
}