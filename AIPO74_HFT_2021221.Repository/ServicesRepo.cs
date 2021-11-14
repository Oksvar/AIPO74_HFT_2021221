using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
    public class ServicesRepo : Repository<Services>, IServices
    {

        public ServicesRepo(DbContext dbcontext) : base(dbcontext)
        {

        }

        public void ChangePrice(int id, int newPrice)
        {
            var service = this.GetOne(id);
            if (service == null)
            {
                throw new InvalidOperationException("This service cannot be found");
            }
            service.Price = newPrice;
            this.Context.SaveChanges();
        }

        public override Services GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Insert(Services entity)
        {
            this.Context.Set<Services>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Services obj = this.GetOne(id);
            this.Context.Set<Services>().Remove(obj);
            this.Context.SaveChanges();
        }

        public void UpdateDangerous(int id, int newDangerous)
        {
            this.GetOne(id).Dangerous = newDangerous;
            this.Context.SaveChanges();
        }

     
    }
}
