namespace FitnessApp.Models;
using System.ComponentModel.DataAnnotations;
using FitnessApp.Models.Enums;
public class KlijentTrening
{
    [Key] public int Id{get;set;}
    public DateTime DatumDodjele{get;set;}=DateTime.Now;
    public DateTime? DatumZavrsetka{get;set;}
    [Required] public StatusKlijentTreninga Status{get;set;} = StatusKlijentTreninga.UIzradi;

    //VEZE
    public int KlijentId { get; set; }
    public Klijent? Klijent { get; set; }

    public int TreningId { get; set; }
    public Trening? Trening { get; set; }
}