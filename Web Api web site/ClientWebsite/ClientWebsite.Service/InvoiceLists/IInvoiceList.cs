using ClientWebsite.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Service.InvoiceLists
{
    public interface IInvoiceList
    {
        Task<string> InsertInvoiceListRecord(List<InvoiceList> requestViewModel);
    }
}
