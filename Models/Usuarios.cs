using System.ComponentModel.DataAnnotations;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }
    public double  Ganado { get; set; }
    public double Jugado { get; set; }
    public string? UserApi { get; set; }

}