using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
   public interface ILaboratoryOrderLogic
    {
        IEnumerable<LaboratoryOrders> GetLaboratoryOrders();

        LaboratoryOrders GetLaboratoryOrder(int id);
        void CreateNewOrder(LaboratoryOrders laboratoryOrders);
        void ChangeDate(int id, DateTime date);
        void DeleteOrder(int id);

        IEnumerable <AlIinformationAboutOrder> GetAllInfoaboutOrder(int id);
        
    }
}
