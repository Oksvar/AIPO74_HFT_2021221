using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
   public interface IServices : IRepository<Services>
    {
        void ChangePrice(int id, int newPrice);

        void UpdateDangerous(int id, int newDangerous);
    }
}
