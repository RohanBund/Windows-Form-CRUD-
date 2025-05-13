using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Models
{
    public class CustomerProduct
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price => Rate * Quantity;
        public string MobileNo { get; set; }
    }
}
