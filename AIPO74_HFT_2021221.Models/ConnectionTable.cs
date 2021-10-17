using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("ConnectionTable")]
   public class ConnectionTable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Orders))]
        public int? OrderID { get; set; }

        public virtual LaboratoryOrders Orders { get; set; }

        [ForeignKey(nameof(Services))]
        public int? ServeceID { get; set; }
        public virtual Services Services { get; set; }
       
    }
}
