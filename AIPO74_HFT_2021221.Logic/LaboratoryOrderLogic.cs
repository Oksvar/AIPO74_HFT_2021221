using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Repository;

namespace AIPO74_HFT_2021221.Logic
{
    public class LaboratoryOrderLogic : ILaboratoryOrderLogic
    {
        ILaboratoryOrderRepo orderRepo;
        ILaboratoryStaffRepo StaffRepo;
        IServices servicesRepo;
        ICustomerRepo customerRepo;
      
        public LaboratoryOrderLogic(ILaboratoryOrderRepo laboratoryOrder, ILaboratoryStaffRepo laboratoryStaffRepo, IServices servicesRepo, ICustomerRepo customerRepo)
        {
            this.orderRepo = laboratoryOrder;
            this.StaffRepo = laboratoryStaffRepo;
            this.servicesRepo = servicesRepo;
            this.customerRepo = customerRepo;
        }
        public void ChangeDate(int id, DateTime date)
        {
            orderRepo.ChangeDate(id, date);
        }

        public void CreateNewOrder(LaboratoryOrders laboratoryOrders)
        {
            if (orderRepo.GetOne(laboratoryOrders.Id) !=null)
            {
                throw new InvalidOperationException("Error: ERROR: This order already in database");
            }
            orderRepo.Add(laboratoryOrders);
        }

        public void DeleteOrder(int id)
        {
            orderRepo.Remove(id);
        }
        // 2cnd non-crud method get all information about order from  other tables
        public IEnumerable<AlIinformationAboutOrder> GetAllInfoaboutOrder(int id)
        {
            IQueryable<Customer> customers = customerRepo.GetAll();
            IQueryable<Services> services = servicesRepo.GetAll();
            IQueryable<LaboratoryStaff> staffs = StaffRepo.GetAll();
            IQueryable<LaboratoryOrders> orders = orderRepo.GetAll();
            var quer = from order in orders
                       join Custm in customers on order.CustomerID 
                       equals Custm.CustomerID
                       join serv in services on order.ServiceId 
                       equals serv.ServiceId
                       join Staf in staffs on order.StaffID 
                       equals Staf.StaffID
                       where order.Id == id
                       select new AlIinformationAboutOrder
                       {
                           orderId = order.Id,
                           CustomerName = Custm.Name,
                           ServiceName = serv.Name,
                           Price = serv.Price,
                           StaffName = Staf.FullName,
                           positionname = Staf.Position

                       };

            return quer.ToList();
        }
        public LaboratoryOrders GetLaboratoryOrder(int id)
        {
            return orderRepo.GetOne(id);
        }

        public IEnumerable<LaboratoryOrders> GetLaboratoryOrders()
        {
            return orderRepo.GetAll();
        }
    }
}
