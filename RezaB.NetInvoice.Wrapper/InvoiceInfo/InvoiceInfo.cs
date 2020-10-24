using RezaB.NetInvoice.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.InvoiceInfo
{
    public class InvoiceInfo
    {
        public InvoiceType Type { get; set; }

        public int InvoiceInternalID { get; set; }

        public string InvoiceIDPrefix { get; set; }

        public DateTime IssueDate { get; set; }

        public CurrencyCodes CurrencyCode { get; set; }

        public DateTime InvoiceStartDate { get; set; }

        public DateTime InvoiceEndDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal PastDuePenaltyPercentage { get; set; }

        public decimal PastDueFlatPenalty { get; set; }

        public string EBillMailUrn { get; set; }

        public List<ItemInfo> Items { get; set; }
    }
}
