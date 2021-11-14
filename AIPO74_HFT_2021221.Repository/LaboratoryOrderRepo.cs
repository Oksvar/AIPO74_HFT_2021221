using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
    public class LaboratoryOrderRepo : Repository<LaboratoryOrders>, ILaboratoryOrderRepo
    {
        public LaboratoryOrderRepo(DbContext context): base(context)
        {

        }
        public void ChangeDate(int id, DateTime newDate)
        {
            var order = this.GetOne(id);
            if (order == null)
            {
                throw new InvalidOperationException("Cannot find order");

            }
            order.DateTime = newDate;
            this.Context.SaveChanges();
        }

        public override LaboratoryOrders GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Insert(LaboratoryOrders entity)
        {
            this.Context.Set<LaboratoryOrders>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            LaboratoryOrders obj = this.GetOne(id);
            this.Context.Set<LaboratoryOrders>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
