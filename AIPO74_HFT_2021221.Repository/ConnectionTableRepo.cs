using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
    public class ConnectionTableRepo : Repository<ConnectionTable>, IConnectionRepository
    {
        public ConnectionTableRepo(DbContext context):base(context)
        {

        }
        public override ConnectionTable GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Insert(ConnectionTable entity)
        {
            this.Context.Set<ConnectionTable>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            ConnectionTable obj = this.GetOne(id);
            this.Context.Set<ConnectionTable>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
