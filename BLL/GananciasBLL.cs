using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class GananciasBLL

{

    private Contexto _contexto;
    public GananciasBLL(Contexto contexto)

    {
        _contexto = contexto;

    }
    public bool Existe(int Id)

    {

        return _contexto.Ganancias.Any(c => c.GananciaId == Id);

    }

       public bool Guardar(Ganancias ganancia)

    {
        if (!Existe(ganancia.GananciaId))
         return Insertar(ganancia);

        else
         return Modificar(ganancia);
    }

    private bool Insertar(Ganancias ganancia)

    {

        _contexto.Ganancias.Add(ganancia);
        bool insertar = _contexto.SaveChanges() > 0;

        _contexto.Entry(ganancia).State = EntityState.Detached;

        return insertar;

    }




      public bool Modificar(Ganancias ganancia)
        {
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM GananciasDetalle WHERE GananciaId={ganancia.GananciaId};");

			foreach (var item in ganancia.Detalle)
			{
                _contexto.Entry(item).State = EntityState.Added;
			}

            _contexto.Entry(ganancia).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(ganancia).State = EntityState.Detached;
            return guardo;
        }
    public bool Eliminar(Ganancias ganancia)

    {

      _contexto.Ganancias.Add(ganancia);
        
        _contexto.Entry(ganancia).State = EntityState.Deleted;
     
        bool elimino = _contexto.SaveChanges() > 0;

        _contexto.Entry(ganancia).State = EntityState.Detached;
        return elimino;

    }
      public Ganancias? Buscar(int ganancia)

    {

        return _contexto.Ganancias
        .Include(c => c.Detalle)
        .Where(c => c.GananciaId == ganancia)
        .AsNoTracking()
        .SingleOrDefault();

    }
     public string? GetNombreTipo(int tipo)
          {
            var tip = _contexto.TipoJugadas
             .Where(c => c.TipoId ==tipo)
             .AsNoTracking()
            .SingleOrDefault();
             return tip?.NombreTipo;
          }
          public string? GetNombreLoteria(int loteria)
          {
            var lot = _contexto.Loterias
             .Where(c => c.LoteriaId ==loteria)
             .AsNoTracking()
            .SingleOrDefault();
             return lot?.NombreLoteria;
          }

 public List<Ganancias> GetList(Expression<Func<Ganancias, bool>> critero)
        {
            List<Ganancias> lista = new List<Ganancias>();

            try
            {
                lista = _contexto.Ganancias
                    .Include(x => x.Detalle)
                    .Where(critero)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

}