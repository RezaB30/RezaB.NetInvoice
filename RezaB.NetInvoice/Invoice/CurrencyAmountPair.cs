using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class CurrencyAmountPair
        {
            public string Currency { get; set; }

            public string Amount { get; set; }
        }
    }
}
