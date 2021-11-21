using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;
using AIPO74_HFT_2021221.Models;

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

        public LaboratoryStaff InsertNewStaff(string name, string position, string AccessLevel, int YearExpirience)
        {
            LaboratoryStaff newlaboratoryStaff = new LaboratoryStaff()
            {
                FullName = name,
                Position = position,
                AccessLevel = AccessLevel,
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

    }
}
