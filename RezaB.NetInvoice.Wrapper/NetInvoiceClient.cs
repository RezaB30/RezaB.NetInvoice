using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezaB.NetInvoice.Wrapper
{
    public class NetInvoiceClient
    {
        private string CompanyCode { get; set; }

        private string ApiUsername { get; set; }

        private string ApiPassword { get; set; }

        private NetInvoiceTestService.IntegrationServiceSoapClient client { get; set; }

        public NetInvoiceClient(string CompanyCode, string ApiUsername, string ApiPassword)
        {
            this.CompanyCode = CompanyCode;
            this.ApiUsername = ApiUsername;
            this.ApiPassword = ApiPassword;

            client = new NetInvoiceTestService.IntegrationServiceSoapClient();
        }

        public ClientResponse SendInvoice(Invoice invoice, string MapCode = "MAP1", bool useTimeoutRetry = false)
        {
            var loginTicket = client.GetFormsAuthenticationTicket(CompanyCode, ApiUsername, ApiPassword);
            var messageBytes = invoice.GetMessageBytes();
            ClientResponse response = new ClientResponse();

            var retries = useTimeoutRetry ? 0 : 3;
            //while (true)
            //{
                //try
                //{

                    if (invoice.InvoiceInfo.Type == InvoiceType.EArchive)
                    {

                        var results = client.SendEArchiveData(loginTicket, NetInvoiceTestService.File.Xml, messageBytes, CompanyCode, MapCode);
                        response = new ClientResponse()
                        {
                            ErrorCode = results.ErrorCode,
                            ID = results.InstanceIdentifier,
                            Result = results.ServiceResult,
                            ResultDescription = results.ServiceResultDescription
                        };
                    }
                    if (invoice.InvoiceInfo.Type == InvoiceType.EBill)
                    {
                        var results = client.SendInvoiceData(loginTicket, NetInvoiceTestService.File.Xml, messageBytes, CompanyCode, MapCode, invoice.InvoiceInfo.EBillMailUrn);

                        response = new ClientResponse()
                        {
                            ErrorCode = results.ErrorCode,
                            ID = results.InstanceIdentifier,
                            Result = results.ServiceResult,
                            ResultDescription = results.ServiceResultDescription
                        };
                    }
                    // if e-bill already exists (error code: 29)
                    //if (retries > 0 && response.ErrorCode == 29)
                    //{
                    //    response.ErrorCode = 0;
                    //}

                    return response;
                //}
                //catch (TimeoutException ex)
                //{
                //    if (retries >= 3)
                //    {
                //        throw ex;
                //    }
                //    retries++;
                //}
            //}
        }

        public ClientResponse GetECompaniesList(DateTime startDate)
        {
            var loginTicket = client.GetFormsAuthenticationTicket(CompanyCode, ApiUsername, ApiPassword);
            var response = client.GetTaxIdListbyDate(loginTicket, startDate);
            return new ClientResponse()
            {
                ErrorCode = response.ErrorCode,
                Result = response.ServiceResult,
                ResultDescription = response.ServiceResultDescription,
                CompanyList = response.CustomerInfoList.Select(company => new ClientResponse.EBillCompany()
                {
                    MailUrn = company.Alias,
                    Name = company.Name,
                    RegistrationDate = company.RegisterTime,
                    TaxNo = company.TaxIdOrPersonalId
                })
            };
        }

        public ClientResponse GetEArchivePDF(string referenceId)
        {
            var loginTicket = client.GetFormsAuthenticationTicket(CompanyCode, ApiUsername, ApiPassword);
            var response = client.GetEArchiveInvoice(loginTicket, referenceId, "UUID", "PDF");
            return new ClientResponse()
            {
                ErrorCode = response.ErrorCode,
                Result = response.ServiceResult,
                ResultDescription = response.ServiceResultDescription,
                PDFData = response.ReturnValue
            };
        }

        public ClientResponse CancelEArchive(string referenceId, decimal total, DateTime? cancellationDate = null)
        {
            cancellationDate = cancellationDate ?? DateTime.Now;
            total = Math.Round(total, 2);
            var loginTicket = client.GetFormsAuthenticationTicket(CompanyCode, ApiUsername, ApiPassword);
            var response = client.CancelEArchiveInvoice(loginTicket, referenceId, "UUID", total, cancellationDate.Value);
            return new ClientResponse()
            {
                ErrorCode = response.ErrorCode,
                Result = response.ServiceResult,
                ResultDescription = response.ServiceResultDescription
            };
        }

        public ClientResponse CancelEBill(string referenceId)
        {
            var loginTicket = client.GetFormsAuthenticationTicket(CompanyCode, ApiUsername, ApiPassword);
            var response = client.CancelInvoice(loginTicket, referenceId);
            return new ClientResponse()
            {
                ErrorCode = response.ErrorCode,
                Result = response.ServiceResult,
                ResultDescription = response.ServiceResultDescription
            };
        }
    }
}
