using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Product
    {
        public ObjectState State { get; set; }

        public Product()
        {
            State = ObjectState.New;
        }

        public long ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public long BrandID { get; set; }
        public decimal SellPrice { get; set; }
    }
}
