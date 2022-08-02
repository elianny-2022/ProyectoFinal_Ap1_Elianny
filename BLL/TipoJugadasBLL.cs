using Microsoft.EntityFrameworkCore;

public class TipoJugadasBLL
{
    private Contexto _contexto;

    public TipoJugadasBLL(Contexto contexto){
        _contexto =contexto;
    }
    public TipoJugadas? Buscar(int Id)
    {
        var tipo = _contexto.TipoJugadas.AsNoTracking()
        .FirstOrDefault(l => l.TipoId == Id);
        return tipo;
    }    
       public List<TipoJugadas> TipoList()

    {

        return _contexto.TipoJugadas.AsNoTracking().ToList();

    }
}