namespace FitnessApp.Models;
public class VjezbaMisic
{
    public int VjezbaId { get; set; }
    public Vjezba? Vjezba { get; set; }

    public int MisicId { get; set; }
    public Misic? Misic { get; set; }
}