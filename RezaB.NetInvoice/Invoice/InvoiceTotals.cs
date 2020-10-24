using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class InvoiceTotals
        {
            public CurrencyAmountPair LineExtensionAmount { get; set; }

            public CurrencyAmountPair AllowanceTotalAmount { get; set; }

            public CurrencyAmountPair TaxExclusiveAmount { get; set; }

            public CurrencyAmountPair TaxInclusiveAmount { get; set; }

            public CurrencyAmountPair PayableAmount { get; set; }
        }
    }
}
