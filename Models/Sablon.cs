using System.ComponentModel.DataAnnotations;

public class Sablon
{
    [Key] public int Id{get;set;}
    [Required] public string Naziv{get;set;}=string.Empty;
    public string? Opis{get;set;}

    //VEZA
    [Required] public int TrenerId{get;set;}
    public ICollection<SablonStavka> SablonStavke = new List<SablonStavka>();
}