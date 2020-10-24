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
        public class InvoiceInfo
        {
            public string InvoiceID { get; set; }

            public int LineCount { get; set; }

            public string Scenario { get; set; }

            public string IssueDate { get; set; }

            public string IssueTime { get; set; }

            public string InvoiceTypeCode { get; set; }

            public bool CopyIndicator { get; set; }

            public string UUID { get; set; }

            public AttributeValuePair Currency { get; set; }

            public InvoicePriod InvoicePeriod { get; set; }

            public PaymentMeans PaymentMeans { get; set; }

            public PaymentTerms PaymentTerms { get; set; }

            public string PaymentDueDate { get; set; }

            public InvoicePriod SettlementPeriod { get; set; }

            public string Alias { get; set; }

            public string SendingType { get; set; }
        }
    }
}
