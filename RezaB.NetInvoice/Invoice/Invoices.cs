using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace RezaB.NetInvoice
{
    [XmlRoot(Namespace = "http://xmlns.digitlplanet.com.tr/NetInvoice", IsNullable = false)]
    public partial class Invoices
    {
        public string Version { get; set; }

        [XmlElement(ElementName = "Invoice")]
        public List<Invoice> InvoicesList { get; set; }

        public string GetXml()
        {
            var serializer = new XmlSerializer(typeof(Invoices));
            using (StringWriter writer = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                //ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, this, ns);

                return writer.ToString();
            }
        }
    }
}
