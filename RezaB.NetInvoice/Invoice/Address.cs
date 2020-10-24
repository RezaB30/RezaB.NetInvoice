using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice
{
    public partial class Invoices
    {
        public class Address
        {
            public string CountryName { get; set; }

            public string CityName { get; set; }

            public string CitySubdivisionName { get; set; }

            public string Room { get; set; }

            public string StreetName { get; set; }

            public string BlockName { get; set; }

            public string BuildingName { get; set; }

            public string BuildingNumber { get; set; }

            public string District { get; set; }

            public string ID { get; set; }

            public string PostalZone { get; set; }
        }
    }
}
