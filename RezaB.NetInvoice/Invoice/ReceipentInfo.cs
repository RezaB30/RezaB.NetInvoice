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
        public class ReceipentInfo
        {
            [XmlArrayItem(ElementName = "Identification")]
            public List<AttributeValuePair> Identifications { get; set; }

            public string PartyName { get; set; }

            public FirstNameFamilyNamePair Person { get; set; }

            public Address Address { get; set; }

            public CommunicationChannels CommunicationChannels { get; set; }

            public string PartyTaxScheme { get; set; }
        }
    }
}
