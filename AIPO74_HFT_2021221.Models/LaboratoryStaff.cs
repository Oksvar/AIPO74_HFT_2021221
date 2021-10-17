using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("LaboratoryStaff")]
    public class LaboratoryStaff
    {
        public LaboratoryStaff()
        {
            this.Orders = new HashSet<LaboratoryOrders>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(100)]
        [Required]
        public string Position { get; set; }

        [Range(1,10)]
        [Required]
        public string AccessLevel { get; set; }

        [Required]
        public int YearExpirience { get; set; }

        public virtual ICollection<LaboratoryOrders> Orders { get; }
    }
}
