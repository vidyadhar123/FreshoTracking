using ClientWebsite.Data;
using ClientWebsite.Data.Model;
using ClientWebsite.ViewModel.CustomerReportModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ClientWebsite.ViewModel;

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

        public List<GetUserDetailsModel> GetUsersDetails() {
            try
            {


                var lst = (from cus in _orderManagementDbContext.CustomerReport
                              //join inv in _orderManagementDbContext.InvoiceList on cus.txn_id equals inv.InvoiceNumber
                          join rem in _orderManagementDbContext.RemitLists on cus.txn_id equals rem.refOrderNumber
                          select new { cus, rem }).Select(x => new GetUserDetailsModel
                          {
                              TxnId = x.cus.txn_id,
                              Date = x.cus.date,
                              CustomerName = x.cus.name,
                              TotalQtyShipped = x.cus.quantity,
                              TotalInvoiced = x.cus.subtotal,
                              CheckNumber = x.rem.checkNumber,
                              Skus1 = x.cus.item_sku,
                              Skus2 = x.cus.item_sku,
                              ShipDate = x.cus.ship_date,
                              TrackingID = x.cus.tracking,
                              DiscountAmount = x.rem.refInvoiceDiscAmount,
                              WarehouseFee = 0.5 * x.cus.quantity
                          }).ToList();
                return lst;
                
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
