using System.ComponentModel.DataAnnotations;

public class VjezbaDodjela
{
    [Key] public int Id{get;set;}
    public int? BrojSetova{get;set;}
    public int? BrojPonavljanja{get;set;}
    public int? TrajanjeSekundi{get;set;}
    public bool JeVremenska{get;private set;} = false;

    //VEZE
    [Required] public int TreningId{get;set;}
    [Required] public int VjezbaId{get;set;}
}