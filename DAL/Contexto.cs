using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Contexto : IdentityDbContext
{
    public DbSet<Ganancias> Ganancias { get; set; } = null!;
    public DbSet<Tickets> Tickets { get; set; }=null!;
    public DbSet<Loterias> Loterias { get; set; }=null!;
    public DbSet<TipoJugadas> TipoJugadas { get; set; }=null!;
    public DbSet <Usuarios> Usuarios { get; set; }=null!;
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Loterias>().HasData(

            new Loterias{
                LoteriaId = 1,
                NombreLoteria="Loteria Nacional",
                
            },
            new Loterias{
                LoteriaId =2,
                NombreLoteria = "Loteria Leidsa",
                
            },
            new Loterias{
                LoteriaId = 3,
                NombreLoteria ="Loteria Real",
              
            },
            new Loterias{
                LoteriaId = 4,
                NombreLoteria = "Loteria Loteka",
                
            },
            new Loterias{
                LoteriaId =5,
                NombreLoteria = "Loteria La Suerte",
               
            },
            new Loterias{
                LoteriaId =6,
                NombreLoteria ="Loteria La Primera",
                
            },
            new Loterias{
                LoteriaId =7,
                NombreLoteria ="Loteria LoteDom",
               
            }
            
        );
        modelBuilder.Entity<TipoJugadas>().HasData(
            new TipoJugadas{
                TipoId= 1,
                NombreTipo="Juega Mas",
               
            },
            new TipoJugadas{
                TipoId =2,
                NombreTipo="Ganas mas",
                
            },
            new TipoJugadas{
                TipoId = 3,
                NombreTipo ="Loto Pool",
               
            },
            new TipoJugadas{
                TipoId =4,
                NombreTipo ="Kino Tv",
                
            },
            new TipoJugadas{
                TipoId =5,
                NombreTipo ="Quiniela Pale",
                
            },
            new TipoJugadas{
                TipoId =6,
                NombreTipo ="Lotto Real",
               
            },
            new TipoJugadas{
                TipoId =7,
                NombreTipo ="Quiniela Loteka",
                
            },
            new TipoJugadas{
                TipoId =8,
                NombreTipo = "Mega Chance",
               
            },
            new TipoJugadas{
                TipoId =9,
                NombreTipo="La Primera",
                
            },
            new TipoJugadas{
                TipoId= 10,
                NombreTipo ="El Quemaito Mayor",
               
            },
            new TipoJugadas{
                TipoId =11,
                NombreTipo ="Lotto Pool",
                
            }
        );
}
}
