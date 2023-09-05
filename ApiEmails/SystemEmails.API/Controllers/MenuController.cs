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
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }



        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int id)
        {
            var response = new Response<List<MenuDTO>>();

            try
            {
                response.Status = true;
                response.Value = await _menuService.List(id);
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
