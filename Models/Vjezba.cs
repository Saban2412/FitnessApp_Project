namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;
using FitnessApp.Models.Enums;
using FitnessApp.Models;
public class Vjezba
{
    [Key] public int Id{get;set;}
    [Required,StringLength(100)] public string Naziv{get;set;} = string.Empty;
    [StringLength(1000)]public string? Opis {get;set;}

    //ENUM
    [Required] public TezinaVjezbe Tezina {get;set;} = TezinaVjezbe.Lako;
    [Required] public VrstaVjezbe Vrsta {get;set;} = VrstaVjezbe.Zagrijavanje;
    public bool JeVremenska{get;set;} = false;

    public ICollection<VjezbaMisic> VjezbaMisici { get; set; } = new List<VjezbaMisic>();
    public ICollection<SablonStavka> SablonStavke { get; set; } = new List<SablonStavka>();
    public ICollection<VjezbaDodjela> VjezbaDodjele { get; set; } = new List<VjezbaDodjela>();
}