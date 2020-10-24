using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class TaxTotal
        {
            public bool Withholding { get; set; }

            public CurrencyAmountPair TaxAmount { get; set; }

            [XmlElement(ElementName = "TaxSubTotals")]
            public List<TaxSubTotal> TaxSubTotals { get; set; }
        }
    }
}
