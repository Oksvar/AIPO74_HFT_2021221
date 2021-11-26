using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
   public interface IRepository<T>
        where T : class
    {
        T GetOne(int id);

        IQueryable<T> GetAll();

        void Insert(T entity);

        void Remove(int id);
        void Add(T entity);
    }
}
