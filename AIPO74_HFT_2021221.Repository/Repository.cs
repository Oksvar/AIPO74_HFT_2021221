using AIPO74_HFT_2021221.Data;
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
        protected readonly CepheusDbContext context;
        public Repository(CepheusDbContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
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
