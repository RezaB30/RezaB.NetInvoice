using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.InvoiceInfo
{
    public class DiscountInfo
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DiscountTypes Type { get; set; }
    }
}
