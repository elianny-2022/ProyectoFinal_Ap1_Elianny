using System.ComponentModel.DataAnnotations;

public class TicketsDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int TicketId { get; set; }
    public int LoteriaId { get; set; }
    public int TipoId { get; set; }
    public decimal  Monto { get; set; }
}