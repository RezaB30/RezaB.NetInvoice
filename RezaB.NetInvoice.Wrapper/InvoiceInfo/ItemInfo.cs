using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.InvoiceInfo
{
    public class ItemInfo
    {
        public decimal Total { get; set; }

        public string Name { get; set; }

        public List<TaxInfo> Taxes { get; set; }

        public DiscountInfo Discount { get; set; }
    }
}
