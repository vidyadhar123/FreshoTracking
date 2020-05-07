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
                               join inv in _orderManagementDbContext.InvoiceList on cus.txn_id equals inv.InvoiceNumber
                               //join rem in _orderManagementDbContext.RemitLists on inv.InvoiceNumber equals rem.refOrderNumber
                               select new { cus, inv }).Select(x => new GetUserDetailsModel
                               {
                               OrderSource = x.cus.order_source,
                               Date=x.cus.date,
                               FirstName=x.cus.first_name,
                                LastName=x.cus.last_name,
                                Total=x.cus.total,
                                Fee=x.cus.fee,
                                ShipDate=x.cus.ship_date,
                                Carrier=x.cus.carrier,
                                Method =x.cus.method,
                                Weight=x.cus.weight,
                                Tracking=x.cus.tracking,
                                Postage=x.cus.postage,
                                Items=x.cus.items,
                                 Qtys=x.cus.qtys,
                                Skus=x.cus.skus,
                                Subtotals=x.cus.subtotals,
                                InvoiceNumber=x.inv.InvoiceNumber,
                                InvoiceDate=x.inv.InvoiceDate,
                                InvoiceAmount=x.inv.InvoiceAmount,
                                PoNumber=x.inv.PoNumber,
                                CheckNumber=x.inv.CheckNumber,
                                CheckAmount=x.inv.CheckAmount,
                                CheckDate=x.inv.CheckDate,
                                Discount =x.inv.Discount,
                                   //BalanceDue = x.rem.balanceDue,
                                   //PaymentDate = x.rem.paymentDate,
                                   //CheckNumberInvoice = x.rem.checkNumber,
                                   //RefInvoiceAmount = x.rem.refInvoiceAmount,
                                   //RefOrderNumber = x.rem.refOrderNumber,
                                   //ItemBalanceDue = x.rem.itemBalanceDue,
                                   //RefInvoiceNumber = x.rem.refInvoiceNumber,
                                   //RefInvoiceDate = x.rem.refInvoiceDate,
                                   //RefInvoiceDiscAmount = x.rem.refInvoiceDiscAmount,
                                   //RefInvoiceAdjNumber = x.rem.refInvoiceAdjNumber
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
