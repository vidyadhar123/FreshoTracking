using ClientWebsite.Data;
using ClientWebsite.Data.Model;
using ClientWebsite.ViewModel.CustomerReportModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Service.Customer_Report
{
    public class CustomerReportService : ICustomer_Report
    {
        #region DI
        private readonly OrderManagementDbContext _orderManagementDbContext;
        //private readonly ICustomer_Report _ICustomer_Report;

        public CustomerReportService(OrderManagementDbContext orderManagementDbContext)
        {
            _orderManagementDbContext = orderManagementDbContext;
        }
        #endregion
        public async Task<string> InsertCustomerReport(List<CustomerReport> requestViewModel)
        {
            _orderManagementDbContext.Database.BeginTransaction();
            try
            {
                await _orderManagementDbContext.CustomerReport.AddRangeAsync(requestViewModel);
                _orderManagementDbContext.SaveChanges();
                _orderManagementDbContext.Database.CurrentTransaction.Commit();
               
                return "Customer Added Successfully";
            }
            catch (Exception ex)
            {
                _orderManagementDbContext.Database.RollbackTransaction();
                throw ex;
            }
        }

    }
}
