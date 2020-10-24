using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class TaxCategory
        {
            public TaxScheme TaxScheme { get; set; }
        }

        public class TaxScheme
        {
            public string Name { get; set; }

            public string TaxTypeCode { get; set; }
        }
    }
}
