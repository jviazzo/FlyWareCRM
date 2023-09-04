using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.DTO;


namespace SystemEmail.BLL.Services.Interfaces
{
    public interface IRolService
    {

        Task<List<RolDTO>> List();



    }
}
