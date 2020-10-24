using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper.ClientInfo
{
    public abstract class ClientInfo
    {
        public string CountryName { get; set; }

        public string ProvinceName { get; set; }

        public string CityName { get; set; }

        public string NeighbourHoodName { get; set; }

        public string Room { get; set; }

        public string StreetName { get; set; }

        public string BlockName { get; set; }

        public string BuildingName { get; set; }

        public string BuildingNumber { get; set; }

        public string District { get; set; }

        public string PostalCode { get; set; }

        public string BBK { get; set; }

        public string PhoneNo { get; set; }

        public string FaxNo { get; set; }

        public string Email { get; set; }
        /// <summary>
        /// will be replaced later
        /// </summary>
        //[Obsolete("Will be changed to better address")]
        //public string _address { get; set; }

        public string SubscriberNo { get; set; }

        public string TTsubscriberNo { get; set; }
    }
}
