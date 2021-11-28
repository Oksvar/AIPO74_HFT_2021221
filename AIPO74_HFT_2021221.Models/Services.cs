using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("Services")]
    public class Services
    {
        public Services()
        {
            OrdersServices = new HashSet<LaboratoryOrders>();
        }
          
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int DevelopmentTime { get; set; }

        [Range(1, 10)]
        public int Dangerous { get; set; }
        [NotMapped]
        public virtual ICollection<LaboratoryOrders> OrdersServices { get; }
        public override string ToString()
        {
            return $" ID: {this.ServiceId} Name: {this.Name} Price: {this.Price} Development Time: {this.DevelopmentTime}";
        }




    }
}
