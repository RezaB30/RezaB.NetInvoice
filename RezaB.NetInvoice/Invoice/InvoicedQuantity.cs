using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class InvoicedQuantity
        {
            public string UnitCode { get; set; }

            public int Quantity { get; set; }
        }
    }
}
