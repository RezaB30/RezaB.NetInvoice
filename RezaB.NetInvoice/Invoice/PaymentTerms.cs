using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class PaymentTerms
        {
            public string Note { get; set; }

            public string PenaltySurchargePercent { get; set; }

            public AttributeValuePair PaymentTermsAmount { get; set; }
        }
    }
}
