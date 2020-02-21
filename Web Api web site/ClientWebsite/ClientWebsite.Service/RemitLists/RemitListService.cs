using ClientWebsite.Data;
using ClientWebsite.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Service.RemitLists
{
    public class RemitListService: IRemitList
    {
        #region DI
        private readonly OrderManagementDbContext _orderManagementDbContext;
        //private readonly ICustomer_Report _ICustomer_Report;

        public RemitListService(OrderManagementDbContext orderManagementDbContext)
        {
            _orderManagementDbContext = orderManagementDbContext;
        }
        #endregion

        public async Task<string> InsertRemitListRecord(List<RemitList> requestViewModel)
        {
            _orderManagementDbContext.Database.BeginTransaction();
            try
            {
                await _orderManagementDbContext.RemitLists.AddRangeAsync(requestViewModel);
                _orderManagementDbContext.SaveChanges();
                _orderManagementDbContext.Database.CurrentTransaction.Commit();

                return "Remit List Added Successfully";
            }
            catch (Exception ex)
            {
                _orderManagementDbContext.Database.RollbackTransaction();
                throw ex;
            }
        }
    }
}
