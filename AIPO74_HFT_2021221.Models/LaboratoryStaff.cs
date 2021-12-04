using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIPO74_HFT_2021221.Models
{
    [Table("Staff")]
    public class LaboratoryStaff
    {
        public LaboratoryStaff()
        {
            LaboratoryOrders = new HashSet<LaboratoryOrders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }

        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(100)]
        [Required]
        public string Position { get; set; }

        [Range(1, 10)]
        [Required]
        public string AccessLevel { get; set; }   

        [Required]
        public int YearExpirience { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<LaboratoryOrders> LaboratoryOrders { get; set; }


        public override string ToString()
        {
            return $"ID: {this.StaffID} Full Name: {this.FullName} Position: {this.Position} Access level: {this.AccessLevel} Year Expirience: {this.YearExpirience}";
        }
    }
}
