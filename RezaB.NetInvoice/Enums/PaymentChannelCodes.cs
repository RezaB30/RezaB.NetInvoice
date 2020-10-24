using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Enums
{
    public class PaymentChannelCodes
    {
        public static string GetPaymentCode(PaymentChannelsEnum input)
        {
            if (input == 0)
                return "ZZ";
            return ((int)input).ToString();
        }
    }

    public enum PaymentChannelsEnum
    {
        Ordinary_post = 1,
        Air_mail = 2,
        Telegraph = 3,
        Telex = 4,
        SWIFT = 5,
        Other_transmission_networks = 6,
        Networks_not_defined = 7,
        Fedwire = 8,
        Personal = 9,
        Registered_air_mail = 10,
        Registered_mail = 11,
        Courier = 12,
        Messenge = 13,
        National_ACH = 14,
        Other_ACH = 15,
        Mutually_defined = 0
    }
}
