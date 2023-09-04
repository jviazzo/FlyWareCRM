using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.DTO;

namespace SystemEmail.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> List();

        Task<SessionDTO> ValidateToken(string email, string password);

        Task <UserDTO> CreateUser(UserDTO model);
        
        Task<bool> EditUser(UserDTO model);

        Task<bool> Delete(int id); 


    }
}
