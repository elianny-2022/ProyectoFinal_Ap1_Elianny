using Microsoft.EntityFrameworkCore;

public class LoteriasBLL
{
    private Contexto _contexto;

    public LoteriasBLL(Contexto contexto){
        _contexto =contexto;
    }
    public Loterias? Buscar(int Id)
    {
        var loteria = _contexto.Loterias.AsNoTracking()
        .FirstOrDefault(l => l.LoteriaId == Id);
        return loteria;
    }    
      public List<Loterias> LotoList()

    {

        return _contexto.Loterias.AsNoTracking().ToList();

    }
}