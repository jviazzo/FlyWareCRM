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
    public class ClientController : ControllerBase
    {

        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }




        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int id)
        {
            var response = new Response<List<ClientDTO>>();

            try
            {
                response.Status = true;
                response.Value = await clientService.List();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] ClientDTO client)
        {
            var response = new Response<ClientDTO>();

            try
            {
                response.Status = true;
                response.Value = await clientService.CreateClient(client);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }


        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] ClientDTO client)
        {
            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await clientService.EditClient(client);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await clientService.Delete(id);
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
