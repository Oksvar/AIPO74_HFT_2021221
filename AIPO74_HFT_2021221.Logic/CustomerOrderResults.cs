using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Logic
{
  public class CustomerOrderResults
    {
        public int CustomerID { get; set; }
        public string CustomreName { get; set; }

        public int TotalAmount { get; set; }

        public override string ToString()
        {
            return $"Customer's ID = {this.CustomerID}, Customer's name {this.CustomreName}, order price: {this.TotalAmount} usd ";
        }
        public override bool Equals(object obj)
        {
            if (obj is CustomerOrderResults)
            {
                CustomerOrderResults orderResults = obj as CustomerOrderResults;
                return this.CustomerID == orderResults.CustomerID &&
                    this.CustomreName == orderResults.CustomreName &&
                    this.TotalAmount == orderResults.TotalAmount;
            }
            else
            {
                return false;
            }           
        }
        public override int GetHashCode()
        {
            return this.CustomerID.GetHashCode() + this.CustomreName.GetHashCode();
        }

    }
}
