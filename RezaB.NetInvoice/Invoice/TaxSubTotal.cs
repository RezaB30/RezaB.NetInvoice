using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class TaxSubTotal
        {
            public CurrencyAmountPair TaxableAmount { get; set; }

            public CurrencyAmountPair TaxAmount { get; set; }

            public int CalculationSequenceNumeric { get; set; }

            public string Percent { get; set; }

            public TaxCategory TaxCategory { get; set; }
        }
    }
}
