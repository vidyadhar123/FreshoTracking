using ClientWebsite.Data.Model;
using ClientWebsite.ViewModel;
using ClientWebsite.ViewModel.CustomerReportModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientWebsite.Service.Customer_Report
{
  public  interface ICustomer_Report
    {
         Task<string> InsertCustomerReport(List<CustomerReport> requestViewModel);
    }
}
