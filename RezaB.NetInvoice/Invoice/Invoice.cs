using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class Invoice
        {
            public ReceipentInfo ReceipentInfo { get; set; }

            public ReceipentInfo SenderInfo { get; set; }

            public InvoiceInfo InvoiceInfo { get; set; }

            public InvoiceLines InvoiceLines { get; set; }

            public TaxTotal Taxes { get; set; }

            public InvoiceTotals InvoiceTotals { get; set; }
        }
    }
}
