using System.Collections.Generic;
using System.Linq;
using UESTicketsProject.Data.Repositories.Interfaces;

namespace UESTicketsProject.Data.Repositories.Impl
{
    public class Repository<T>:IRepository<T> where T : class
    {
        public DBContextUesTickets context;

        public Repository()
        {
            context=new DBContextUesTickets();
        }
        
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Save(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Update(T entity,int id)
        {
            T existing = context.Set<T>().Find(id);
            if (existing == null) return;
            context.Entry(existing).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }


        public ICollection<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
