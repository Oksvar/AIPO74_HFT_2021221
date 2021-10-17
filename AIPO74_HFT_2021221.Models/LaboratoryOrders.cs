using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("Orders")]
   public class LaboratoryOrders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [NotMapped]
        public virtual Customer Customers { get; set; }

        [ForeignKey(nameof(Customers))]
        public int? CustomerID { get; set; }

        [NotMapped]
        public virtual LaboratoryStaff Scientists { get; set; }

        [ForeignKey(nameof(Scientists))]
        public int? ScientistID { get; set; }
    }
}
