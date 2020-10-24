using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class PaymentMeans
        {
            public int PaymentMeansCode { get; set; }

            public string PaymentDueDate { get; set; }

            public string PaymentChannelCode { get; set; }

            public string InstructionNote { get; set; }
        }
    }
}
