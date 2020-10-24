using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class AllowanceCharge
        {
            public bool ChargeIndicator { get; set; }

            public string AllowanceChargeReason { get; set; }

            public string MultiplierFactorNumeric { get; set; }

            public CurrencyAmountPair ChargeAmount { get; set; }
        }
    }
}
