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
    public class RolController : ControllerBase
    {

        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int id)
        {
            var response = new Response<List<RolDTO>>();

            try
            {
                response.Status = true;
                response.Value = await _rolService.List();
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
