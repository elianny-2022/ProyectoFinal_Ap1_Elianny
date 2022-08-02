using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
public class TicketsBLL

{
    private Contexto _contexto;
    public TicketsBLL(Contexto contexto)

    {
        _contexto = contexto;

    }
    public bool Existe(int Id)

    {

        return _contexto.Tickets.Any(c => c.TicketId == Id);

    }

       public bool Guardar(Tickets ticket)

    {
        if (!Existe(ticket.TicketId))
         return Insertar(ticket);

        else
         return Modificar(ticket);
    }

    private bool Insertar(Tickets ticket)

    {

        _contexto.Tickets.Add(ticket);
        bool insertar = _contexto.SaveChanges() > 0;

        _contexto.Entry(ticket).State = EntityState.Detached;

        return insertar;

    }
     public bool Modificar(Tickets ticket)
        {
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM TicketsDetalle WHERE TicketId={ticket.TicketId};");

			foreach (var item in ticket.Detalle)
			{
                _contexto.Entry(item).State = EntityState.Added;
			}

            _contexto.Entry(ticket).State = EntityState.Modified;

            var guardo = _contexto.SaveChanges() > 0;
            _contexto.Entry(ticket).State = EntityState.Detached;
            return guardo;
        }
    public bool Eliminar(Tickets ticket)

    {

      _contexto.Tickets.Add(ticket);
        
        _contexto.Entry(ticket).State = EntityState.Deleted;
     
        bool elimino = _contexto.SaveChanges() > 0;

        _contexto.Entry(ticket).State = EntityState.Detached;
        return elimino;

    }
      public Tickets? Buscar(int ticket)

    {

        return _contexto.Tickets
        .Include(c => c.Detalle)
        .Where(c => c.TicketId == ticket)
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

    public List<Tickets> GetList(Expression<Func<Tickets, bool>> critero)
        {
            List<Tickets> lista = new List<Tickets>();

            try
            {
                lista = _contexto.Tickets
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