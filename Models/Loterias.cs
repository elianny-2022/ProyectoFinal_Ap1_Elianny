using System.ComponentModel.DataAnnotations;

public class Loterias
{
    [Key]
    public int LoteriaId { get; set; }
    public string? NombreLoteria { get; set; }
}