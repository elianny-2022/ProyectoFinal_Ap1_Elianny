using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ganancias
{
    [Key]
    public int GananciaId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public int UsuarioId { get; set; }
    public decimal Monto { get; set; }
    public decimal Ganancia { get; set; }
    
    [ForeignKey("GananciaId")]
    public List<GananciasDetalle> Detalle { get; set; } = new List<GananciasDetalle>();
}