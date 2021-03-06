﻿using ClientWebsite.Data;
using ClientWebsite.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Service.InvoiceLists
{
    public class InvoiceListService: IInvoiceList
    {
        #region DI
        private readonly OrderManagementDbContext _orderManagementDbContext;
        //private readonly ICustomer_Report _ICustomer_Report;

        public InvoiceListService(OrderManagementDbContext orderManagementDbContext)
        {
            _orderManagementDbContext = orderManagementDbContext;
        }
        #endregion

        public async Task<string> InsertInvoiceListRecord(List<InvoiceList> requestViewModel)
        {
            _orderManagementDbContext.Database.BeginTransaction();
            try
            {
                await _orderManagementDbContext.InvoiceList.AddRangeAsync(requestViewModel);
                _orderManagementDbContext.SaveChanges();
                _orderManagementDbContext.Database.CurrentTransaction.Commit();

                return "Invoice List Added Successfully";
            }
            catch (Exception ex)
            {
                _orderManagementDbContext.Database.RollbackTransaction();
                throw ex;
            }
        }
    }
}
