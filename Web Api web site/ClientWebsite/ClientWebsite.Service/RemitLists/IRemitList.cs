using ClientWebsite.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebsite.Service.RemitLists
{
    public interface IRemitList
    {
        Task<string> InsertRemitListRecord(List<RemitList> requestViewModel);
    }
}
