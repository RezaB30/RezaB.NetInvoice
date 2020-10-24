using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.ClientInfo
{
    public class CompanyInfo : ClientInfo
    {
        public string VKN { get; set; }

        public string CompanyTitle { get; set; }

        public string CompanyTaxRegion { get; set; }

        public string RegistrationNo { get; set; }

        public string CentralSystemNo { get; set; }
    }
}
