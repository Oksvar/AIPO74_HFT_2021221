using AIPO74_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
  public  class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        public CustomerRepo(DbContext context) : base(context)
        {

        }

        public void ChangeAddress(int id, string newAddress)
        {
            Customer customer = GetOne(id);
            customer.Address = newAddress;
            context.SaveChanges();
        }

        public void ChangePhone(int id, string phone)
        {
            Customer customer = GetOne(id);
            customer.Phone = phone;
            context.SaveChanges();
        }

        public void ChangeSecrecyStamp(int id, string newSecrecyStamp)
        {
            Customer customer = GetOne(id);
            customer.SecrecyStamp = newSecrecyStamp;
            context.SaveChanges();
        }

        public override Customer GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Remove(int id)
        {
            Customer customer = GetOne(id);
            context.Set<Customer>().Remove(customer);
            context.SaveChanges();
        }
    }
}
