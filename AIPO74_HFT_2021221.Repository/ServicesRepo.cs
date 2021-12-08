using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Data;

namespace AIPO74_HFT_2021221.Repository
{
    public class ServicesRepo : Repository<Services>, IServices
    {

        public ServicesRepo(CepheusDbContext dbcontext) : base(dbcontext)
        {

        }

        public void ChangeName(int id, string newName)
        {
            var services = GetOne(id);
            services.Name = newName;
            context.SaveChanges();
            
        }

        public void ChangePrice(int id, int newPrice)
        {
            Services services = GetOne(id);
            services.Price = newPrice;
            context.SaveChanges();

        }

        public override Services GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.ServiceId == id);
        }

        public override void Remove(int id)
        {
            Services services = GetOne(id);
            context.Set<Services>().Remove(services);
            context.SaveChanges();
        }

        public void UpdateDangerous(int id, int newDangerous)
        {
            Services services = GetOne(id);
            services.Dangerous = newDangerous;
            context.SaveChanges();
        }
    }
}
