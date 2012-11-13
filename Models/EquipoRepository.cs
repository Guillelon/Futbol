using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Futbol.Models
{ 
    public class EquipoRepository : IEquipoRepository
    {
        FutbolContext context = new FutbolContext();

        public IQueryable<Equipo> All
        {
            get { return context.Equipoes; }
        }

        public IQueryable<Equipo> AllIncluding(params Expression<Func<Equipo, object>>[] includeProperties)
        {
            IQueryable<Equipo> query = context.Equipoes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Equipo Find(int id)
        {
            
            return context.Equipoes.Find(id);
        }

        public bool Exists(string nombre) 
        {
            return context.Equipoes.Where(e => e.Nombre == nombre).Count() > 0;
        }

        public void InsertOrUpdate(Equipo equipo)
        {
            if (equipo.ID == default(int)) {
                // New entity
                context.Equipoes.Add(equipo);
            } else {
                // Existing entity
                context.Entry(equipo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var equipo = context.Equipoes.Find(id);
            context.Equipoes.Remove(equipo);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
  

    public interface IEquipoRepository
    {
        IQueryable<Equipo> All { get; }
        IQueryable<Equipo> AllIncluding(params Expression<Func<Equipo, object>>[] includeProperties);
        Equipo Find(int id);
        void InsertOrUpdate(Equipo equipo);
        void Delete(int id);
        void Save();
        bool Exists(string nombre);
    }
}