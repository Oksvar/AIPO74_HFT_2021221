using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Logic
{
   public interface IClientLogic
    {
        void ChangeCustomerAddress(int id, string adress, string city, string Country);

        void ChangeOrderDate(int id, DateTime newDate);

        void ChangeCustomerPhone(int id, string Phone);
    }
}
