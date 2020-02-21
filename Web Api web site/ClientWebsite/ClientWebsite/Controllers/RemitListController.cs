using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebsite.Data.Model;
using ClientWebsite.Service.RemitLists;
using ClientWebsite.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemitListController : ControllerBase
    {
        private IRemitList _iRemitList;
        public RemitListController(IRemitList _IRemitList)
        {
            _iRemitList = _IRemitList;
        }

        [HttpPost("InsertRemitList")]
        [ProducesResponseType(typeof(ResponseViewModel), 200)]
        public async Task<IActionResult> InsertRemitList(List<RemitList> input)
        {
            try
            {
                ResponseViewModel model = new ResponseViewModel();
                var Result = await _iRemitList.InsertRemitListRecord(input);
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