using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
   public interface ICustomerRepo : IRepository<Customer>
    {
        void ChangeAddress(int id, string newCity, string newAddress, string newCountry);

        void ChangePhone(int id, string phone);

        void ChangeSecrecyStamp(int id, string newSecrecyStamp);
    }
}
