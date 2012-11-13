using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Futbol.Models
{ 
    public class JugadorRepository : IJugadorRepository
    {
        FutbolContext context = new FutbolContext();

        public IQueryable<Jugador> All
        {
            get { return context.Jugadors; }
        }

        public IQueryable<Jugador> AllIncluding(params Expression<Func<Jugador, object>>[] includeProperties)
        {
            IQueryable<Jugador> query = context.Jugadors;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Jugador Find(int id)
        {
            return context.Jugadors.Find(id);
        }

        public void InsertOrUpdate(Jugador jugador)
        {
            if (jugador.ID == default(int)) {
                // New entity
                context.Jugadors.Add(jugador);
            } else {
                // Existing entity
                context.Entry(jugador).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var jugador = context.Jugadors.Find(id);
            context.Jugadors.Remove(jugador);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IJugadorRepository
    {
        IQueryable<Jugador> All { get; }
        IQueryable<Jugador> AllIncluding(params Expression<Func<Jugador, object>>[] includeProperties);
        Jugador Find(int id);
        void InsertOrUpdate(Jugador jugador);
        void Delete(int id);
        void Save();
    }
}