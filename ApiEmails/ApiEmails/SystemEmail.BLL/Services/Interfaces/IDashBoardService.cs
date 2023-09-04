using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEmail.BLL.Services.Interfaces
{
    public interface IDashBoardService
    {
        Task<int> TotalEmails();
        Task<string> TotalClientsLastWeek();
        Task<int> TotalClients();
        Task<Dictionary<string, int>> EmailsLastWeek();

    }
}