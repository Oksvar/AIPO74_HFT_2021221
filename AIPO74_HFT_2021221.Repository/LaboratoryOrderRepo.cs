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
            throw new NotImplementedException();
        }

        public override LaboratoryOrders GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public override void Insert(LaboratoryOrders entity)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
