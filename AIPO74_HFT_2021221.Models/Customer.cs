using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("Cepheus_Customers")]
   public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<LaboratoryOrders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(100)]
        [Required]
        public string Address { get; set; }

        [MaxLength(20)]
        [Required]
        public int Phone { get; set; }

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
       
    }
}

