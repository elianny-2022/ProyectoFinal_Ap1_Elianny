using System.ComponentModel.DataAnnotations;

public class GananciasDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int GananciaId { get; set; }
    public int LoteriaId { get; set; }
    public int TipoId { get; set; }
    public decimal Monto { get; set; }
    public decimal Ganancia { get; set; }
    
}