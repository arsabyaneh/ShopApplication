using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Price
    {
        public DateTime Date { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
        public Product Product { get; set; }
    }
}
