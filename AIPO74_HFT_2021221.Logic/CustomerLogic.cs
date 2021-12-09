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
        ICustomerRepo customerRepo;
        ILaboratoryOrderRepo laboratoryOrderRepo;

        public CustomerLogic(ICustomerRepo customerRepo, ILaboratoryOrderRepo laboratoryOrderRepo)
        {
            this.customerRepo = customerRepo;
            this.laboratoryOrderRepo = laboratoryOrderRepo;

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
                throw new InvalidOperationException("ERROR: This customer already in database ");
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

        //non-crud 1
        public IEnumerable<GetCustomerByStaff> getCustomerByStaffs(int idOrder)
        {
            IQueryable<Customer> customers = customerRepo.GetAll();
            IQueryable<LaboratoryOrders> orders = laboratoryOrderRepo.GetAll();
            var quer = from Custom in customers
                       join order in orders on Custom.CustomerID 
                       equals order.CustomerID
                       where order.Id == idOrder
                       select new GetCustomerByStaff
                       {
                          orderId = idOrder,
                          CustomerFullName = Custom.Name
                           
                       };
            return quer.ToList();
        }

        

        public Customer GetCustomerID(int id)
        {
            return customerRepo.GetOne(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepo.GetAll();
        }

    }
}
