using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;

namespace AIPO74_HFT_2021221.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepo customerRepo;
        public CustomerLogic(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public void ChangeAddress(int id, string newAddress)
        {
            customerRepo.ChangeAddress(id, newAddress);
        }

        public void ChangePhone(int id, string phone)
        {
            customerRepo.ChangePhone(id, phone);
        }

        public void ChangeSecrecyStamp(int id, string newSecrecyStamp)
        {
            customerRepo.ChangeSecrecyStamp(id, newSecrecyStamp);
        }

        public void CreateCustomer(Customer customer)
        {
            if (customerRepo.GetOne(customer.CustomerID) !=null)
            {
                throw new InvalidOperationException("ERROR: This id alredy have in request ");
            }
            else if(customer.Name == null)
            {
                throw new InvalidOperationException("ERROR: You missed up something  ");
            }
            customerRepo.Add(customer);
        }
        public void DeleteCustomer(int id)
        {
            customerRepo.Remove(id);
        }

        public Customer GetCustomerID(int id)
        {
            return customerRepo.GetOne(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepo.GetAll();
        }


        public void NonCrude()
        {

        }
    }
}
