using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiService
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        [Required]
        public string CarNumber { get; set; }
        public string CarModel { get; set; }
        public string CarDriverFIO { get; set; }
    }
}
