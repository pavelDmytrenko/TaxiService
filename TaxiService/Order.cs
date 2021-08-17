using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderComplateDate { get; set; }
        [Required]
        public string OrderAddressSource { get; set; }
        [Required]
        public string OrderAddressDestination { get; set; }
        public string OrderStatus { get; set; }
        public Car Car { get; set; }
    }
}
