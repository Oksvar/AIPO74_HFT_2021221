using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPO74_HFT_2021221.Models;

namespace AIPO74_HFT_2021221.Logic
{
   public interface ILaboratoryServiceLogic
    {
        LaboratoryOrders GetOneOrder(int id);

        Customer GetOneCustomer(int id);

        IList<LaboratoryOrders> GetAllOrders();

        IList<Customer> GetAllCustomers();

        void ChangeAccesslvl(int id, string newAcSlvl);

        void ChangeYearExpirience(int id, int yearXP);

        void ChangePosition(int id, string newPosition);
        IList<CustomerOrderResults> OrderResults();
    }
}
