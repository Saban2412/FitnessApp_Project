using System.ComponentModel.DataAnnotations;

public class ProgressRecord
{
    [Key] public int Id{get;set;}
    public int Tezina{get;set;}
    public DateOnly Datum {get;set;}

    //VEZA
    public int KlijentId{get;set;}
}