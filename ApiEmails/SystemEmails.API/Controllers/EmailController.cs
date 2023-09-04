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
    public class EmailController : ControllerBase
    {


        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] EmailDTO email)
        {
            var response = new Response<EmailDTO>();

            try
            {
                response.Status = true;
                response.Value = await _emailService.Save(email);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }

        [HttpGet]
        [Route("EmailLog")]
        public async Task<IActionResult> EmailLog(string searchBy, string? SpecialIdEmail, string? dateIni, string? dateEnd)
        {
            var response = new Response<List<EmailDTO>>();

            SpecialIdEmail = SpecialIdEmail is null ? "" : SpecialIdEmail;
            dateIni = dateIni is null ? "" : dateIni;
            dateEnd = dateEnd is null ? "" : dateEnd;

            

            try
            {
                response.Status = true;
                response.Value = await _emailService.EmailLog(searchBy, SpecialIdEmail, dateIni,dateEnd);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }
            return Ok(response);

        }

        [HttpGet]
        [Route("Report")]
        public async Task<IActionResult> Report(string? dateIni, string? dateEnd)
        {
            var response = new Response<List<ReportDTO>>();


            try
            {
                response.Status = true;
                response.Value = await _emailService.Report(dateIni, dateEnd);
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
