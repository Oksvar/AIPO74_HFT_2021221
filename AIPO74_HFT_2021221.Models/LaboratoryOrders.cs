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
        public DateTime Date { get; set; }

        [ForeignKey("Customers")]
        public int? CustomerID { get; set; }
        [ForeignKey("LaboratoryStaff")]
        public int? StaffID { get; set; }
        [ForeignKey("Services")]
        public int? ServiceId { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} Date: {Date} Customer ID: {CustomerID} Personal ID: {StaffID} Service ID: {ServiceId}";
        }

    }
}
