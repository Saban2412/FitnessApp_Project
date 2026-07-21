namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class VjezbaDodjela
{
    [Key] public int Id{get;set;}
    public int? BrojSetova{get;set;}
    public int? BrojPonavljanja{get;set;}
    public int? TrajanjeSekundi{get;set;}
    public int Redoslijed{get;set;}

    //VEZE
    public int TreningId { get; set; }
    public Trening? Trening { get; set; }

    public int VjezbaId { get; set; }
    public Vjezba? Vjezba { get; set; }
}