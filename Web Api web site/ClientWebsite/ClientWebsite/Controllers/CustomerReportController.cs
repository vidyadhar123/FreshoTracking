using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebsite.Data.Model;
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
        private ICustomer_Report _customerReporService;
        public CustomerReportController(ICustomer_Report customerReporService)
        {
            _customerReporService = customerReporService;
        }

        [HttpPost("InsertCustomerReport")]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> InsertCustomerReport(List<CustomerReport> input)
        {
            try
            {
                ResponseViewModel model = new ResponseViewModel();
                var Result = await _customerReporService.InsertCustomerReport(input);
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

        [HttpGet("GetUsersDetails")]
        public List<GetUserDetailsModel> GetUsersDetails()
        {
            return _customerReporService.GetUsersDetails();
        }
    }
}