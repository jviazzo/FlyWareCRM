using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.DTO;


namespace SystemEmail.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        Task<EmailDTO> Save(EmailDTO model);

        Task<List<EmailDTO>> EmailLog(string searchBy, string email, string dateIni, string dateEnd);

        Task<List<ReportDTO>> Report(string dateIni, string dateEnd);



    }
}
