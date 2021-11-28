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
            LaboratoryOrders orders = GetOne(id);
            orders.Date = newDate;
            context.SaveChanges();
        }

        public override LaboratoryOrders GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Remove(int id)
        {
            LaboratoryOrders orders = GetOne(id);
            context.Set<LaboratoryOrders>().Remove(orders);
            context.SaveChanges();
        }
    }
}
