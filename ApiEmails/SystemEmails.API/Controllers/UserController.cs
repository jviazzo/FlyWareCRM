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
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }




        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int id)
        {
            var response = new Response<List<UserDTO>>();

            try
            {
                response.Status = true;
                response.Value = await userService.List();
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
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {

            var response = new Response<SessionDTO>();

            try
            {
                response.Status = true;
                response.Value = await userService.ValidateToken(login.Email, login.Password);
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
        public async Task<IActionResult> Save([FromBody] UserDTO user)
        {

            var response = new Response<UserDTO>();

            try
            {
                response.Status = true;
                response.Value = await userService.CreateUser(user);
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
        public async Task<IActionResult> Edit([FromBody] UserDTO user)
        {

            var response = new Response<bool>();

            try
            {
                response.Status = true;
                response.Value = await userService.EditUser(user);
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
                response.Value = await userService.Delete(id);
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
