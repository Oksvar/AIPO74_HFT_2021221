using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    public class Services
    {
        public Services()
        {
            this.ConnectionTables = new HashSet<ConnectionTable>(); 
        }
          
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public virtual ICollection<ConnectionTable> ConnectionTables { get; }


    }
}
