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
        private DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        protected DbContext Context { get => this.context; set => this.context = value; }

        public abstract T GetOne(int id);


        public abstract void Insert(T entity);


        public abstract void Remove(int id);
       
    }
}
