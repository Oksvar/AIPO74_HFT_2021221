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
        private readonly ILaboratoryOrderRepo orderRepo;
      
        public LaboratoryOrderLogic(ILaboratoryOrderRepo laboratoryOrder)
        {
            this.orderRepo = laboratoryOrder;
        }
        public void ChangeDate(int id, DateTime date)
        {
            orderRepo.ChangeDate(id, date);
        }

        public void CreateNewOrder(LaboratoryOrders laboratoryOrders)
        {
            if (orderRepo.GetOne(laboratoryOrders.Id) !=null)
            {
                throw new InvalidOperationException("Error: ERROR: This service already in database");
            }
            else if(laboratoryOrders.Customers == null || laboratoryOrders.Scientists ==null)
            {
                throw new InvalidOperationException("Error: Some ");
            }
            orderRepo.Add(laboratoryOrders);
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public LaboratoryOrders GetLaboratoryOrder(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LaboratoryOrders> GetLaboratoryOrders()
        {
            throw new NotImplementedException();
        }
    }
}
