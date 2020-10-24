using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RezaB.NetInvoice.Enums;

namespace RezaB.NetInvoice.Wrapper.InvoiceInfo
{
    public class TaxInfo
    {
        public TaxTypeCodes Type { get; set; }

        public decimal Percentage { get; set; }
    }
}
