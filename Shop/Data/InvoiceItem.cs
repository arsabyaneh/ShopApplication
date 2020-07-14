using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class InvoiceItem
    {
        public long ID { get; set; }
        public int Quantity { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

        public ObjectState State { get; set; }

        public InvoiceItem()
        {
            State = ObjectState.New;
        }
    }
}
