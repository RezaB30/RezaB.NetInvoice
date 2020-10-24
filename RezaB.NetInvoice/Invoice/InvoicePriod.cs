using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class InvoicePriod
        {
            public string StartDate { get; set; }

            public string EndDate { get; set; }

            public AttributeValuePair Duration { get; set; }

            public string Description { get; set; }
        }
    }
}
