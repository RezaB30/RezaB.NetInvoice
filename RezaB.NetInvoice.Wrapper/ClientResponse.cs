using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper
{
    public class ClientResponse
    {
        public int ErrorCode { get; set; }

        public string ID { get; set; }

        public NetInvoiceTestService.Result Result { get; set; }

        public string ResultDescription { get; set; }

        public IEnumerable<EBillCompany> CompanyList { get; set; }

        public byte[] PDFData { get; set; }

        public class EBillCompany
        {
            public string MailUrn { get; set; }

            public DateTime RegistrationDate { get; set; }

            public string TaxNo { get; set; }

            public string Name { get; set; }
        }
    }
}
