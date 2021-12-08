using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
   public class AlIinformationAboutOrder
    {
        public int orderId { get; set; }

        public string CustomerName { get; set; }

        public string ServiceName { get; set; }

        public int Price { get; set; }

        public string StaffName { get; set; }
        public string positionname { get; set; }

        public override string ToString()
        {
            return "Name: " + CustomerName + " |Name of the service: " + ServiceName + " |Service Price: " + Price + " |Laboratory Staff Name: " + StaffName + " |Staff Position: " +positionname;
        }
    }
}
