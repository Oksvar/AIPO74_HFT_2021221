using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;


namespace AIPO74_HFT_2021221.Logic
{
    public class LaboratoryServiceLogic : ILaboratoryServiceLogic
    {
        private ILaboratoryOrderRepo OrderRepo;
        private ILaboratoryStaffRepo LaboratoryStaffRepo;
        private IConnectionRepository ConnectionRepository;
        private ICustomerRepo CustomerRepo;
        private IServices ServicesRepo;

        public LaboratoryServiceLogic(ILaboratoryOrderRepo orderRepo, ICustomerRepo customerRepo, ILaboratoryStaffRepo laboratoryStaffRepo, IServices services, IConnectionRepository connectionRepository)
        {
            this.OrderRepo = orderRepo;
            this.LaboratoryStaffRepo = laboratoryStaffRepo;
            this.ServicesRepo = services;
            this.ConnectionRepository = connectionRepository;
            this.CustomerRepo = customerRepo;
        }
        
        public void ChangeAccesslvl(int id, string newAcSlvl)
        {
            this.LaboratoryStaffRepo.ChangeAccessLevel(id, newAcSlvl);
        }

        public void ChangePosition(int id, string newPosition)
        {
            this.LaboratoryStaffRepo.ChangePosition(id, newPosition);
        }   

        public void ChangeYearExpirience(int id, int yearXP)
        {
            this.LaboratoryStaffRepo.ChangeYearExpirience(id, yearXP);
        }
   

        public IList<Customer> GetAllCustomers()
        {
            return this.CustomerRepo.GetAll().ToList();
        }

        public IList<LaboratoryOrders> GetAllOrders()
        {
            return this.OrderRepo.GetAll().ToList();
        }

        public Customer GetOneCustomer(int id)
        {
            Customer customer = this.CustomerRepo.GetOne(id);
            if (customer == null)
            {
                throw new InvalidOperationException("Error get one customer");
            }
            return this.CustomerRepo.GetOne(id);
        }

        public LaboratoryOrders GetOneOrder(int id)
        {
            LaboratoryOrders laboratoryOrders = this.OrderRepo.GetOne(id);
            if (laboratoryOrders == null)
            {
                throw new InvalidOperationException("Error Bad record");

            }
            return this.OrderRepo.GetOne(id);
        }

        public LaboratoryStaff InsertNewStaff(string name, string position, string AccessLevel, int YearExpirience, int minPrice)
        {
            LaboratoryStaff newlaboratoryStaff = new LaboratoryStaff()
            {
                FullName = name,
                Position = position,
                AccessLevel = AccessLevel,
                MinPrice = minPrice,
                YearExpirience = YearExpirience,
            };
            this.LaboratoryStaffRepo.Insert(newlaboratoryStaff);
            return newlaboratoryStaff;
        }
        public void DeleteStaff(int id)
        {
            LaboratoryStaff laboratoryStaff = this.LaboratoryStaffRepo.GetOne(id);
            if (laboratoryStaff == null)
            {
                throw new InvalidOperationException("Error Staff delete");

            }
            else
            {
                this.LaboratoryStaffRepo.Remove(id);
            }
        }
        public Services InsertNewService(string name, int price, int devTime, int dangerous)
        {
            Services newservices = new Services()
            {
                Name = name,
                Price = price,
                DevelopmentTime = devTime,
                Dangerous = dangerous,
            };
            this.ServicesRepo.Insert(newservices);
            return newservices;
        }

        public void DeleteService(int id)
        {
            Services newservices = this.ServicesRepo.GetOne(id);
            if (newservices == null)
            {
                throw new InvalidOperationException("Error Service delete");

            }
            else
            {
                this.ServicesRepo.Remove(id);
            }
        }
        public IList<CustomerOrderResults> OrderResults()
        {
            IList<LaboratoryOrders> laboratoryOrders = this.OrderRepo.GetAll().ToList();
            IList<LaboratoryStaff> laboratoryStaffs = this.LaboratoryStaffRepo.GetAll().ToList();
            IList<Services> services = this.ServicesRepo.GetAll().ToList();
            IList<ConnectionTable> connections = this.ConnectionRepository.GetAll().ToList();
            IList<Customer> customers = this.CustomerRepo.GetAll().ToList();

            var rest = from customer in customers
                       join orders in from order in from order in from orders in laboratoryOrders
                                                                  join servicess in from conn in connections
                                                                                    join serv in services
                                                                                    on conn.ServeceID equals serv.Id
                                                                                    select new
                                                                                    {
                                                                                        ConnnectorID = conn.Id,
                                                                                        OrderID = conn.OrderID,
                                                                                        ServicePrice = serv.Price,
                                                                                    }
                                                                               on orders.Id equals servicess.OrderID
                                                                  group servicess by servicess.OrderID into order
                                                                  select new
                                                                  {
                                                                      OrderID = order.Key,
                                                                      TotalPrice = order.Sum(x => x.ServicePrice),
                                                                  }
                                                    join cust in laboratoryOrders
                                                    on order.OrderID equals cust.Id
                                                    select new
                                                    {
                                                        CustomerID = cust.CustomerID,
                                                        order.OrderID,
                                                        order.TotalPrice,
                                                    }
                                      join scien in from order in laboratoryOrders
                                                    join scien in laboratoryStaffs

                                                    on order.CustomerID equals scien.Id
                                                    select new
                                                    {
                                                        orderID = order.Id,
                                                        WorkPrice = scien.MinPrice,
                                                    }
                                      on order.OrderID equals scien.orderID
                                      select new
                                      {
                                          order.OrderID,
                                          order.CustomerID,
                                          TotalPrice = order.TotalPrice + scien.WorkPrice,

                                      }
                                    on customer.Id equals orders.CustomerID
                       group orders by orders.CustomerID.Value into prices
                       let total = prices.Sum(x => x.TotalPrice)
                       orderby total descending
                       select new CustomerOrderResults()
                       {
                           CustomerID = prices.Key,
                           CustomreName = this.CustomerRepo.GetOne(prices.Key).Name,
                           TotalAmount = total,
                       };
            return rest.ToList();

                                                                        
        }
    }
}
