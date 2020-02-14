using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebsite.Service.Customer_Report;
using ClientWebsite.ViewModel;
using ClientWebsite.ViewModel.CustomerReportModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReportController : ControllerBase
    {
        private CustomerReporService _customerReporService;
        public CustomerReportController(CustomerReporService customerReporService)
        {
            _customerReporService = customerReporService;
        }

        [HttpPost("InsertCustomerReport")]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]

        public IActionResult InsertCustomerReport(List<CustomerReportModel> input)
        {
            try
            {
                ResponseViewModel model = new ResponseViewModel();
                var Result = _customerReporService.InsertCustomerReport(input);
                if (Result == null)
                    return NotFound(new ResponseViewModel { Message = "No data found", StatusCode = 404, status = false }); ;
                model.StatusCode = 200;
                model.Message = "Success";
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