﻿using AIPO74_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Repository
{
   public interface ILaboratoryOrderRepo : IRepository<LaboratoryOrders>
    {
        void ChangeDate(int id, DateTime newDate);

        
    }
}
