using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Enums
{
    public enum TaxTypeCodes
    {
        KDV = 0015,
        OIV = 4081
    }

    public class TaxTypeName
    {
        public static string GetName(TaxTypeCodes code)
        {
            switch (code)
            {
                case TaxTypeCodes.KDV:
                    return "KDV";
                case TaxTypeCodes.OIV:
                    return "ÖİV";
                default:
                    break;
            }

            return null;
        }
    }
}
