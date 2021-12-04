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
    [Table("LaboratoryOrder")]
    public class LaboratoryOrders
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(Customers))]
        public int CustomerID { get; set; }

        [ForeignKey(nameof(LaboratoryStaff))]
        public int StaffID { get; set; }

        [ForeignKey(nameof(Services))]
        public int ServiceId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Services Services { get; set; }
        [NotMapped]
        [JsonIgnore]

        public virtual LaboratoryStaff LaboratoryStaff { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Customer Customers { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} Date: {Date} Customer ID: {CustomerID} Personal ID: {StaffID} Service ID: {ServiceId}";
        }

    }
}
