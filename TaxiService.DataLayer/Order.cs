using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaxiService.DataLayer
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
        public int OrderStatus { get; set; }
        public Car Car { get; set; }
    }
}
