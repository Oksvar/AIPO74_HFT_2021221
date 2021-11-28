using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("Customers")]
   public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<LaboratoryOrders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Required]
        public string City { get; set; }

        [MaxLength(100)]
        [Required]
        public string Country { get; set; }

        [MaxLength(50)]
        [Required]
        public string SecrecyStamp { get; set; }

        [NotMapped]
        public virtual ICollection<LaboratoryOrders> Orders { get; }

        public override string ToString()
        {
            return $"Custumer ID:{this.CustomerID} Name: {this.Name} Adress: {Address} Phone: {Phone} City: {City} Country: {Country} Secret Stamp: {this.SecrecyStamp}";
        }

    }
}

