using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIPO74_HFT_2021221.Repository;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
    public class ClientLogic : IClientLogic
    {
        private ILaboratoryOrderRepo orderRepo;

        private ICustomerRepo customerRepo;

        private IConnectionRepository connectionRepository;

        public ClientLogic(ILaboratoryOrderRepo orderRepo, ICustomerRepo customerRepo, IConnectionRepository connectionRepository)
        {
            this.orderRepo = orderRepo;
            this.customerRepo = customerRepo;
            this.connectionRepository = connectionRepository;
        }
        public void ChangeCustomerAddress(int id, string adress, string city, string country)
        {
            this.customerRepo.ChangeAddress(id, city, adress, country);
        }

        public void ChangeCustomerPhone(int id, string Phone)
        {
            this.customerRepo.ChangePhone(id, Phone);
        }

        public void ChangeOrderDate(int id, DateTime newDate)
        {
            this.orderRepo.ChangeDate(id, newDate);
        }

        public Customer InsertNewCustomer(string name, string address, string phone, string city, string country, string Secret)
        {
            Customer newCustomer = new Customer()
            {
                Name = name,
                Address = address,
                City = city,
                Phone = phone,
                Country = country,
                SecrecyStamp = Secret


            };
            this.customerRepo.Insert(newCustomer);
            return newCustomer;
        }
        public void DeleteCustomer(int id)
        {
            Customer customer = this.customerRepo.GetOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Error Customer type");
            }
            else
            {
                this.customerRepo.Remove(id);
            }
        }
        public LaboratoryOrders InsertNewOrder(int customerId, int scientistId, DateTime dateTime)
        {
            LaboratoryOrders newOrder = new LaboratoryOrders()
            {
                CustomerID = customerId,
                ScientistID = scientistId,
                DateTime = dateTime,
            };
            this.orderRepo.Insert(newOrder);
            return newOrder;
        }
        public void DeleteOrder(int id)
        {
            LaboratoryOrders laboratory = this.orderRepo.GetOne(id);
            if (laboratory == null)
            {
                throw new InvalidOperationException("Error order type");
            }
            else
            {
                this.orderRepo.Remove(id);
            }
        }
    }
}
