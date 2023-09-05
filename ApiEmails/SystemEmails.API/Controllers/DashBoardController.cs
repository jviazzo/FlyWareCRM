using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DTO;
using SystemEmail.API.Utility;
using SystemEmail.BLL.Services;


namespace SystemEmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {

        IDashBoardService _dashboardService;

        public DashBoardController(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }


        [HttpGet]
        [Route("Summary")]
        public async Task<IActionResult> Summary()
        {
            var response = new Response<DashBoardDTO>();

            try
            {
                response.Status = true;
                response.Value = await _dashboardService.Summary();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }

    }
}
