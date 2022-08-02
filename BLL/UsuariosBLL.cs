 using System.Linq.Expressions;
 using Microsoft.EntityFrameworkCore;
 public class UsuariosBLL

 {
     private Contexto _contexto;
     public UsuariosBLL(Contexto contexto)

     {
        _contexto = contexto;

     }
     public bool Existe(int Id)

     {

         return _contexto.Usuarios.Any(c => c.UsuarioId == Id);

     }

        public bool Guardar(Usuarios usuario)

     {
         if (!Existe(usuario.UsuarioId))
         return Insertar(usuario);

         else
          return Modificar(usuario);
     }

     private bool Insertar(Usuarios usuario)

     {

         _contexto.Usuarios.Add(usuario);
         bool insertar = _contexto.SaveChanges() > 0;

         _contexto.Entry(usuario).State = EntityState.Detached;

         return insertar;

     }
      public bool Modificar(Usuarios usuario)
         {

             _contexto.Entry(usuario).State = EntityState.Modified;

             var guardo = _contexto.SaveChanges() > 0;
             _contexto.Entry(usuario).State = EntityState.Detached;
             return guardo;
         }
     public bool Eliminar(Usuarios usuario)

     {

       _contexto.Usuarios.Add(usuario);
        
         _contexto.Entry(usuario).State = EntityState.Deleted;
     
         bool elimino = _contexto.SaveChanges() > 0;

         _contexto.Entry(usuario).State = EntityState.Detached;
         return elimino;

     }
        public Usuarios? Buscar(int Id)
     {
         var usuario = _contexto.Usuarios.AsNoTracking()
         .FirstOrDefault(l => l.UsuarioId == Id);
         return usuario;
     }  
        public Usuarios? BuscarUser(string Id)
     {
         var usuario = _contexto.Usuarios.AsNoTracking()
         .FirstOrDefault(l => l.UserApi == Id);
         return usuario;
     }  
   
   
       public List<Usuarios> UsuarioList()

     {

         return _contexto.Usuarios.AsNoTracking().ToList();

     }
   
 }