using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tickets
{
    [Key]
    public int TicketId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Today;
    public int UsuarioId { get; set; }
    public decimal Monto { get; set; }
    public decimal Total { get; set; }

    [ForeignKey("TicketId")]
     public List<TicketsDetalle> Detalle { get; set; } = new List<TicketsDetalle>();
}