using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.ClientInfo
{
    public class PersonalInfo: ClientInfo
    {
        public string TCKN { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
