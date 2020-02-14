using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClientWebsite.Data;
using ClientWebsite.Data.Model;
using ClientWebsite.ViewModel;
using ClientWebsite.ViewModel.CustomerReportModels;

namespace ClientWebsite.Service.Customer_Report
{
   public  class CustomerReporService : ICustomer_Report
    {
        #region DI
        private readonly OrderManagementDbContext _orderManagementDbContext;
        private readonly ICustomer_Report _ICustomer_Report;


        public CustomerReporService(OrderManagementDbContext orderManagementDbContext, ICustomer_Report iCustomer_Report)
        {
            _orderManagementDbContext = orderManagementDbContext;
            _ICustomer_Report = iCustomer_Report;
        }
        #endregion
        public string InsertCustomerReport(List<CustomerReportModel> requestViewModel)
        {
            _orderManagementDbContext.Database.BeginTransaction();
            CustomerReport _CustomerReport = new CustomerReport();
            try
            {
                foreach (var item in requestViewModel)
                {
                    _CustomerReport.first_name = item.firstName;
                    _CustomerReport.last_name = item.lastName;
                    _CustomerReport.fee = item.fee;
                    _CustomerReport.method = item.method;
                    _CustomerReport.order_source = item.orderSource;
                    _CustomerReport.postage = item.postage;
                    _CustomerReport.qtys = item.qtys;
                    _CustomerReport.ship_date = item.shipDate;
                    _CustomerReport.skus = item.skus;
                    _CustomerReport.subtotals = item.subtotals;
                    _CustomerReport.total = item.total;
                    _CustomerReport.tracking = item.tracking;
                    _CustomerReport.txn_id = item.txnId;
                    _CustomerReport.weight = item.weight;
                }
                _orderManagementDbContext.Add(_CustomerReport);
                _orderManagementDbContext.SaveChanges();
                _orderManagementDbContext.Database.CurrentTransaction.Commit();
                return "Customer Added Successfully";
            }catch(Exception ex)
            {
                _orderManagementDbContext.Database.RollbackTransaction();
                throw ex;
            }
        }
    }
}
    

