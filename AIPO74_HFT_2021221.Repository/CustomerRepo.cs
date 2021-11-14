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

        public void ChangeAddress(int id, string newCity, string newAddress, string newCountry)
        {
            var customer = this.GetOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Cannot find customer");
            }
            customer.City = newCity;
            customer.Address = newAddress;
            this.Context.SaveChanges();
        }

        public void ChangePhone(int id, string phone)
        {
            var customer = this.GetOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Cannot find customer");
            }
            customer.Phone = phone;
            this.Context.SaveChanges();
        }

        public void ChangeSecrecyStamp(int id, string newSecrecyStamp)
        {
            var customer = this.GetOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Cannot find customer");

            }
            customer.SecrecyStamp = newSecrecyStamp;
            this.Context.SaveChanges();
        }

        public override Customer GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Insert(Customer entity)
        {
            this.Context.Set<Customer>().Add(entity);
            this.Context.SaveChanges();
        }

        public override void Remove(int id)
        {
            Customer obj = this.GetOne(id);
            this.Context.Set<Customer>().Remove(obj);
            this.Context.SaveChanges();
        }
    }
}
