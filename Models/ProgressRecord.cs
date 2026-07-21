namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;

public class ProgressRecord
{
    [Key] public int Id{get;set;}
    [Range(20, 400)] public double Tezina{get;set;}
    public DateOnly Datum {get;set;}

    //VEZA
    public int KlijentId { get; set; }
    public Klijent? Klijent { get; set; }
}