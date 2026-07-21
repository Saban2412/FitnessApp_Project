using System.ComponentModel.DataAnnotations;
using FitnessApp.Models.Enums;
public class KlijentTrening
{
    [Key] public int Id{get;set;}
    [Required] public DateTime DatumDodjele{get;set;}=DateTime.Now;
    public DateTime? DatumZavrsetka{get;set;}
    [Required] public Status Status{get;set;} = Status.UIzradi;

    //VEZE
    public int KlijentId{get;set;}
    public int TreningId{get;set;}
}