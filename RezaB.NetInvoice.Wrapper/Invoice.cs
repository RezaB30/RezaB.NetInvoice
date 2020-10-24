using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RezaB.NetInvoice.Enums;
using System.Globalization;

namespace RezaB.NetInvoice.Wrapper
{
    public class Invoice
    {
        private const string currencyFormat = "########0.00";
        private const string percentageFormat = "#0.0###";
        private const string dateFormat = "yyyy-MM-dd";

        public string InvoiceID
        {
            get
            {
                return InvoiceInfo.InvoiceIDPrefix + (InvoiceInfo != null ? InvoiceInfo.IssueDate.ToString("yyyy") : DateTime.Now.ToString("yyyy")) + InvoiceInfo.InvoiceInternalID.ToString("000000000");
            }
        }

        public string ReferenceNo { get; private set; }

        public ClientInfo.ClientInfo ReceipentInfo { get; set; }

        public ClientInfo.CompanyInfo SenderInfo { get; set; }

        public InvoiceInfo.InvoiceInfo InvoiceInfo { get; set; }

        private Invoices GenerateNetInvoiceTicket()
        {
            var results = new Invoices()
            {
                Version = "2.1",
                InvoicesList = new List<Invoices.Invoice>()
            };
            // create invoice
            var invoiceTemp = new Invoices.Invoice();
            // setup receipent info
            var receipentInfoTemp = new Invoices.ReceipentInfo();
            receipentInfoTemp.Address = new Invoices.Address()
            {
                CountryName = ReceipentInfo.CountryName,
                CityName = ReceipentInfo.ProvinceName,
                CitySubdivisionName = ReceipentInfo.CityName,
                District = ReceipentInfo.NeighbourHoodName,
                StreetName = ReceipentInfo.StreetName,
                BuildingName = ReceipentInfo.BuildingName,
                BuildingNumber = ReceipentInfo.BuildingNumber,
                BlockName = ReceipentInfo.BlockName,
                PostalZone = ReceipentInfo.PostalCode,
                Room = ReceipentInfo.Room,
                ID = ReceipentInfo.BBK
            };
            receipentInfoTemp.CommunicationChannels = new Invoices.CommunicationChannels()
            {
                ElectronicMail = ReceipentInfo.Email,
                Telephone = ReceipentInfo.PhoneNo,
                Telefax = ReceipentInfo.FaxNo
            };
            if (ReceipentInfo is ClientInfo.PersonalInfo)
            {
                var personalInfo = ReceipentInfo as ClientInfo.PersonalInfo;
                receipentInfoTemp.Person = new Invoices.FirstNameFamilyNamePair()
                {
                    FirstName = personalInfo.FirstName,
                    FamilyName = personalInfo.LastName
                };
                receipentInfoTemp.Identifications = new List<Invoices.AttributeValuePair>()
                {
                    new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.TCKN.ToString(),
                        Value = personalInfo.TCKN
                    },
                    new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.ABONENO.ToString(),
                        Value = personalInfo.SubscriberNo
                    }
                };
                if (!string.IsNullOrEmpty(personalInfo.TTsubscriberNo))
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.HIZMETNO.ToString(),
                        Value = personalInfo.TTsubscriberNo
                    });
            }
            if (ReceipentInfo is ClientInfo.CompanyInfo)
            {
                var companyInfo = ReceipentInfo as ClientInfo.CompanyInfo;
                receipentInfoTemp.PartyName = companyInfo.CompanyTitle;
                receipentInfoTemp.PartyTaxScheme = companyInfo.CompanyTaxRegion;
                receipentInfoTemp.Identifications = new List<Invoices.AttributeValuePair>()
                {
                    new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.ABONENO.ToString(),
                        Value = companyInfo.SubscriberNo
                    }
                };
                if (companyInfo.VKN.Length == 11)
                {
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.TCKN.ToString(),
                        Value = companyInfo.VKN
                    });
                }
                else
                {
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.VKN.ToString(),
                        Value = companyInfo.VKN
                    });
                }
                if (!string.IsNullOrEmpty(companyInfo.TTsubscriberNo))
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.HIZMETNO.ToString(),
                        Value = companyInfo.TTsubscriberNo
                    });
                if (!string.IsNullOrEmpty(companyInfo.RegistrationNo))
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.TICARETSICILNO.ToString(),
                        Value = companyInfo.RegistrationNo
                    });
                if (!string.IsNullOrEmpty(companyInfo.CentralSystemNo))
                    receipentInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.MERSISNO.ToString(),
                        Value = companyInfo.CentralSystemNo
                    });
            }
            invoiceTemp.ReceipentInfo = receipentInfoTemp;
            // setup sender info
            var senderInfoTemp = new Invoices.ReceipentInfo()
            {
                Address = new Invoices.Address()
                {
                    CityName = SenderInfo.ProvinceName,
                    CitySubdivisionName = SenderInfo.CityName,
                    CountryName = SenderInfo.CountryName
                },
                CommunicationChannels = new Invoices.CommunicationChannels()
                {
                    ElectronicMail = SenderInfo.Email,
                    Telephone = SenderInfo.PhoneNo,
                    Telefax = SenderInfo.FaxNo
                },
                PartyName = SenderInfo.CompanyTitle,
                PartyTaxScheme = SenderInfo.CompanyTaxRegion,
                Identifications = new List<Invoices.AttributeValuePair>()
                {
                    new Invoices.AttributeValuePair()
                    {
                        Attribute = IdentificationAttributes.VKN.ToString(),
                        Value = SenderInfo.VKN
                    }
                }
            };
            if (!string.IsNullOrEmpty(SenderInfo.RegistrationNo))
                senderInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                {
                    Attribute = IdentificationAttributes.TICARETSICILNO.ToString(),
                    Value = SenderInfo.RegistrationNo
                });
            if (!string.IsNullOrEmpty(SenderInfo.CentralSystemNo))
                senderInfoTemp.Identifications.Add(new Invoices.AttributeValuePair()
                {
                    Attribute = IdentificationAttributes.MERSISNO.ToString(),
                    Value = SenderInfo.CentralSystemNo
                });
            invoiceTemp.SenderInfo = senderInfoTemp;
            // setup invoice
            ReferenceNo = Guid.NewGuid().ToString();
            var invoiceInfoTemp = new Invoices.InvoiceInfo()
            {
                InvoiceID = InvoiceInfo.InvoiceIDPrefix + InvoiceInfo.IssueDate.ToString("yyyy") + InvoiceInfo.InvoiceInternalID.ToString("000000000"),
                LineCount = InvoiceInfo.Items.Count,
                Scenario = "TEMELFATURA",
                IssueDate = InvoiceInfo.IssueDate.ToString(dateFormat),
                IssueTime = InvoiceInfo.IssueDate.ToString("HH:mm:ss"),
                InvoiceTypeCode = InvoiceTypeCodes.SATIS.ToString(),
                CopyIndicator = false,
                UUID = ReferenceNo,
                Currency = new Invoices.AttributeValuePair()
                {
                    Attribute = CurrencyAttributes.DocumentCurrencyCode.ToString(),
                    Value = InvoiceInfo.CurrencyCode.ToString()
                },
                InvoicePeriod = new Invoices.InvoicePriod()
                {
                    StartDate = InvoiceInfo.InvoiceStartDate.ToString(dateFormat),
                    EndDate = InvoiceInfo.InvoiceEndDate.ToString(dateFormat),
                    Duration = new Invoices.AttributeValuePair()
                    {
                        Attribute = DurationAttributes.HUR.ToString(),
                        Value = "1"
                    },
                    Description = "Saat"
                },
                PaymentMeans = new Invoices.PaymentMeans()
                {
                    PaymentMeansCode = (int)PaymentMeansCodes.DIGER,
                    PaymentChannelCode = PaymentChannelCodes.GetPaymentCode(PaymentChannelsEnum.Mutually_defined),
                    InstructionNote = "Ödemeler peşin yapılıcaktır.",
                    PaymentDueDate = InvoiceInfo.DueDate.ToString(dateFormat)
                },
                PaymentTerms = new Invoices.PaymentTerms()
                {
                    Note = string.Format("Faturanızın Son Ödeme Tarihinden sonra ödenmesi halinde günlük %{0} oranında gecikme bedeli uygulanır", (InvoiceInfo.PastDuePenaltyPercentage * 100).ToString(percentageFormat, CultureInfo.InvariantCulture)),
                    PaymentTermsAmount = new Invoices.AttributeValuePair()
                    {
                        Attribute = InvoiceInfo.CurrencyCode.ToString(),
                        Value = InvoiceInfo.PastDueFlatPenalty.ToString(currencyFormat, CultureInfo.InvariantCulture)
                    },
                    PenaltySurchargePercent = (InvoiceInfo.PastDuePenaltyPercentage * 100).ToString(percentageFormat, CultureInfo.InvariantCulture)
                },
                PaymentDueDate = InvoiceInfo.DueDate.ToString(dateFormat),
                SettlementPeriod = new Invoices.InvoicePriod()
                {
                    StartDate = InvoiceInfo.InvoiceEndDate.ToString(dateFormat),
                    EndDate = InvoiceInfo.DueDate.ToString(dateFormat),
                    Duration = new Invoices.AttributeValuePair()
                    {
                        Attribute = DurationAttributes.HUR.ToString(),
                        Value = "1"
                    },
                    Description = "Saat"
                }
            };
            if (InvoiceInfo.Type == InvoiceType.EBill)
            {
                invoiceInfoTemp.Alias = InvoiceInfo.EBillMailUrn;
            }
            if (InvoiceInfo.Type == InvoiceType.EArchive)
            {
                invoiceInfoTemp.SendingType = SendingTypes.ELEKTRONIK.ToString();
            }
            invoiceTemp.InvoiceInfo = invoiceInfoTemp;
            // setup invoice items
            var taxCalculations = new Dictionary<TaxTypeCodes, decimal>();
            var taxableAmounts = new Dictionary<TaxTypeCodes, decimal>();
            var basePricesTotal = 0m;
            var discountTotal = 0m;
            invoiceTemp.InvoiceLines = new Invoices.InvoiceLines()
            {
                Line = new List<Invoices.Line>()
            };
            for (int i = 0; i < InvoiceInfo.Items.Count; i++)
            {
                var currentItem = InvoiceInfo.Items[i];
                var lineTaxPercentage = currentItem.Taxes.Sum(t => t.Percentage);
                var lineDiscountAmount = 0m;
                decimal lineDiscountPercentage = 0m;
                var discountInfo = currentItem.Discount;
                if (discountInfo != null)
                {
                    if (discountInfo.Type == Wrapper.InvoiceInfo.DiscountTypes.Percent)
                    {
                        lineDiscountAmount = currentItem.Total * discountInfo.Amount;
                        lineDiscountPercentage = discountInfo.Amount;
                    }
                    if (discountInfo.Type == Wrapper.InvoiceInfo.DiscountTypes.Fixed)
                    {
                        lineDiscountAmount = discountInfo.Amount;
                        lineDiscountPercentage = discountInfo.Amount / currentItem.Total;
                    }

                    lineDiscountAmount = lineDiscountAmount / (lineTaxPercentage + 1m);
                    discountTotal += lineDiscountAmount;
                }
                var lineBasePrice = currentItem.Total / (lineTaxPercentage + 1);
                var taxBaseAmount = (lineBasePrice - lineDiscountAmount);
                basePricesTotal += lineBasePrice;
                var invoiceLineTemp = new Invoices.Line()
                {
                    ID = i,
                    InvoicedQuantity = new Invoices.InvoicedQuantity()
                    {
                        UnitCode = UnitCodes.C62.ToString(),
                        Quantity = 1
                    },
                    LineExtensionAmount = new Invoices.CurrencyAmountPair()
                    {
                        Currency = InvoiceInfo.CurrencyCode.ToString(),
                        Amount = lineBasePrice.ToString(currencyFormat, CultureInfo.InvariantCulture)
                    },
                    Item = new Invoices.Item()
                    {
                        Name = currentItem.Name
                    },
                    Price = new Invoices.CurrencyAmountPair()
                    {
                        Currency = InvoiceInfo.CurrencyCode.ToString(),
                        Amount = lineBasePrice.ToString(currencyFormat, CultureInfo.InvariantCulture)
                    }
                };
                // setup item discount
                if (discountInfo != null)
                {
                    invoiceLineTemp.AllowanceCharge = new Invoices.AllowanceCharge()
                    {
                        AllowanceChargeReason = discountInfo.Description,
                        ChargeIndicator = false,
                        MultiplierFactorNumeric = (lineDiscountPercentage).ToString(percentageFormat, CultureInfo.InvariantCulture),
                        ChargeAmount = new Invoices.CurrencyAmountPair()
                        {
                            Amount = (lineDiscountAmount).ToString(currencyFormat, CultureInfo.InvariantCulture),
                            Currency = InvoiceInfo.CurrencyCode.ToString()
                        }
                    };
                }
                // setup item taxes
                invoiceLineTemp.TaxTotal = new Invoices.TaxTotal()
                {
                    Withholding = false,
                    TaxAmount = new Invoices.CurrencyAmountPair()
                    {
                        Currency = InvoiceInfo.CurrencyCode.ToString(),
                        Amount = (taxBaseAmount * lineTaxPercentage).ToString(currencyFormat, CultureInfo.InvariantCulture)
                    },
                    TaxSubTotals = new List<Invoices.TaxSubTotal>()
                };
                for (int j = 0; j < currentItem.Taxes.Count; j++)
                {
                    var currentTax = currentItem.Taxes[j];
                    invoiceLineTemp.TaxTotal.TaxSubTotals.Add(new Invoices.TaxSubTotal()
                    {
                        CalculationSequenceNumeric = j,
                        Percent = (currentTax.Percentage * 100m).ToString(percentageFormat, CultureInfo.InvariantCulture),
                        TaxableAmount = new Invoices.CurrencyAmountPair()
                        {
                            Currency = InvoiceInfo.CurrencyCode.ToString(),
                            Amount = (taxBaseAmount).ToString(currencyFormat, CultureInfo.InvariantCulture)
                        },
                        TaxCategory = new Invoices.TaxCategory()
                        {
                            TaxScheme = new Invoices.TaxScheme()
                            {
                                Name = TaxTypeName.GetName(currentTax.Type),
                                TaxTypeCode = ((int)currentTax.Type).ToString("0000")
                            }
                        },
                        TaxAmount = new Invoices.CurrencyAmountPair()
                        {
                            Currency = InvoiceInfo.CurrencyCode.ToString(),
                            Amount = ((taxBaseAmount) * currentTax.Percentage).ToString(currencyFormat, CultureInfo.InvariantCulture)
                        }
                    });
                    if (!taxCalculations.ContainsKey(currentTax.Type))
                    {
                        taxCalculations.Add(currentTax.Type, (taxBaseAmount) * currentTax.Percentage);
                    }
                    else
                    {
                        taxCalculations[currentTax.Type] += (taxBaseAmount) * currentTax.Percentage;
                    }
                    if (!taxableAmounts.ContainsKey(currentTax.Type))
                    {
                        taxableAmounts.Add(currentTax.Type, (taxBaseAmount));
                    }
                    else
                    {
                        taxableAmounts[currentTax.Type] += (taxBaseAmount);
                    }
                }
                invoiceTemp.InvoiceLines.Line.Add(invoiceLineTemp);
            }
            // setup taxes
            invoiceTemp.Taxes = new Invoices.TaxTotal()
            {
                Withholding = false,
                TaxAmount = new Invoices.CurrencyAmountPair()
                {
                    Currency = InvoiceInfo.CurrencyCode.ToString(),
                    Amount = taxCalculations.Sum(t => t.Value).ToString(currencyFormat, CultureInfo.InvariantCulture)
                },
                TaxSubTotals = new List<Invoices.TaxSubTotal>()
            };
            for (int i = 0; i < taxCalculations.Count; i++)
            {
                var currentTaxAmount = taxCalculations.ToList()[i];
                var currentTaxableAmount = taxableAmounts[currentTaxAmount.Key];
                invoiceTemp.Taxes.TaxSubTotals.Add(new Invoices.TaxSubTotal()
                {
                    CalculationSequenceNumeric = i,
                    TaxAmount = new Invoices.CurrencyAmountPair()
                    {
                        Amount = currentTaxAmount.Value.ToString(currencyFormat, CultureInfo.InvariantCulture),
                        Currency = InvoiceInfo.CurrencyCode.ToString()
                    },
                    Percent = (InvoiceInfo.Items.SelectMany(item => item.Taxes).FirstOrDefault(tax => tax.Type == currentTaxAmount.Key).Percentage * 100).ToString(percentageFormat, CultureInfo.InvariantCulture),
                    TaxableAmount = new Invoices.CurrencyAmountPair()
                    {
                        Amount = currentTaxableAmount.ToString(currencyFormat, CultureInfo.InvariantCulture),
                        Currency = InvoiceInfo.CurrencyCode.ToString()
                    },
                    TaxCategory = new Invoices.TaxCategory()
                    {
                        TaxScheme = new Invoices.TaxScheme()
                        {
                            Name = TaxTypeName.GetName(currentTaxAmount.Key),
                            TaxTypeCode = ((int)currentTaxAmount.Key).ToString("0000")
                        }
                    }
                });
            }
            // setup invoice total
            var billTotal = (basePricesTotal + taxCalculations.Sum(t => t.Value) - discountTotal).ToString(currencyFormat, CultureInfo.InvariantCulture);
            var payableAmount = InvoiceInfo.Items.Sum(item => item.Total - ((item.Discount != null) ? item.Discount.Amount : 0m)).ToString(currencyFormat, CultureInfo.InvariantCulture);
            invoiceTemp.InvoiceTotals = new Invoices.InvoiceTotals()
            {
                LineExtensionAmount = new Invoices.CurrencyAmountPair()
                {
                    Amount = basePricesTotal.ToString(currencyFormat, CultureInfo.InvariantCulture),
                    Currency = InvoiceInfo.CurrencyCode.ToString()
                },
                PayableAmount = new Invoices.CurrencyAmountPair()
                {
                    Amount = payableAmount,
                    Currency = InvoiceInfo.CurrencyCode.ToString()
                },
                TaxInclusiveAmount = new Invoices.CurrencyAmountPair()
                {
                    Amount = billTotal,
                    Currency = InvoiceInfo.CurrencyCode.ToString()
                },
                TaxExclusiveAmount = new Invoices.CurrencyAmountPair()
                {
                    Amount = (basePricesTotal - discountTotal).ToString(currencyFormat, CultureInfo.InvariantCulture),
                    Currency = InvoiceInfo.CurrencyCode.ToString()
                },
                AllowanceTotalAmount = new Invoices.CurrencyAmountPair()
                {
                    Amount = discountTotal.ToString(currencyFormat, CultureInfo.InvariantCulture),
                    Currency = InvoiceInfo.CurrencyCode.ToString()
                }
            };
            // set output
            results.InvoicesList.Add(invoiceTemp);
            return results;
        }

        public string GetMessageXML()
        {
            var invoice = GenerateNetInvoiceTicket();
            return invoice.GetXml();
        }

        public byte[] GetMessageBytes()
        {
            var messageString = GetMessageXML();
            var bytes = default(byte[]);
            bytes = Encoding.UTF8.GetBytes(messageString);
            return bytes;
        }
    }
}
