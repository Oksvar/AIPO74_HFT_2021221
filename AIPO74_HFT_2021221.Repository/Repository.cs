using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }
        public abstract T GetOne(int id);


        public  void Insert(T entity)
        {
            context.Set<T>().Attach(entity);
            context.SaveChanges();
        }


        public abstract void Remove(int id);

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
       
    }
}
