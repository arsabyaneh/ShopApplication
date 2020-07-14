using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Brand
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public List<Product> Products { get; set; }
    }
}
