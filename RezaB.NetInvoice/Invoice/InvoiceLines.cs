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
        public class InvoiceLines
        {
            [XmlElement(ElementName = "Line")]
            public List<Line> Line { get; set; }
        }

        public class Line
        {
            public int ID { get; set; }

            public InvoicedQuantity InvoicedQuantity { get; set; }

            public CurrencyAmountPair LineExtensionAmount { get; set; }

            public TaxTotal TaxTotal { get; set; }

            public Item Item { get; set; }

            public CurrencyAmountPair Price { get; set; }

            public AllowanceCharge AllowanceCharge { get; set; }
        }
    }
}
