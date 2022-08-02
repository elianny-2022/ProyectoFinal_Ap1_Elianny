using System.ComponentModel.DataAnnotations;

public class TipoJugadas
{
    [Key]
    public int TipoId { get; set; }
    public string? NombreTipo { get; set; }
}