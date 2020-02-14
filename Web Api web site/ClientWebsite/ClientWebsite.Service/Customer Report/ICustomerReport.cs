using ClientWebsite.ViewModel;
using ClientWebsite.ViewModel.CustomerReportModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientWebsite.Service.Customer_Report
{
  public  interface ICustomer_Report
    {
        string InsertCustomerReport(List<CustomerReportModel> requestViewModel);
    }
}
