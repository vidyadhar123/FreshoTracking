using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebsite.Data.Model;
using ClientWebsite.Service.InvoiceLists;
using ClientWebsite.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceListController : ControllerBase
    {
        private IInvoiceList _iInvoiceList;
        public InvoiceListController(IInvoiceList _IInvoiceList)
        {
            _iInvoiceList = _IInvoiceList;
        }

        [HttpPost("InsertInvoiceListReport")]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> InsertInvoiceListReport(List<InvoiceList> input)
        {
            try
            {
                ResponseViewModel model = new ResponseViewModel();
                var Result = await _iInvoiceList.InsertInvoiceListRecord(input);
                if (Result == null)
                    return NotFound(new ResponseViewModel { Message = "No data found", StatusCode = 404, status = false });
                model.StatusCode = 200;
                model.Message = "Your File Uploaded Successfully";
                model.status = true;
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new ResponseViewModel { Message = "Internal server error", StatusCode = 500, status = false });
            }
        }
    }
}