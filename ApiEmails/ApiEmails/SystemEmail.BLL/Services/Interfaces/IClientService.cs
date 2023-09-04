using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DTO;
using SystemEmail.Model;

namespace SystemEmail.BLL.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> List();

        Task<ClientDTO> CreateClient(ClientDTO model);

        Task<bool> EditClient(ClientDTO model);

        Task<bool> Delete(int id);




    }
}
