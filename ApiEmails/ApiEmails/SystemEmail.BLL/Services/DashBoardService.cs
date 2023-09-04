using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DTO;
using SystemEmail.Model;

namespace SystemEmail.BLL.Services
{
    public class DashBoardRepositorio : IDashBoardService
    {

        private readonly IGenericRepository<Client> _clientlRepository;
        private readonly IMapper _mapper;

        public DashBoardRepositorio(IGenericRepository<Client> clientlRepository, IMapper mapper)
        {
            _clientlRepository = clientlRepository;
            _mapper = mapper;
        }

        public async Task<string> TotalClientsLastWeek()
        {
            throw new NotImplementedException();

        }
        public async Task<int> TotalEmails()
        {
            throw new NotImplementedException();    
        }
        public async Task<int> TotalClients()
        {
            throw new NotImplementedException();

        }

        public async Task<Dictionary<string, int>> EmailsLastWeek()
        {
            throw new NotImplementedException();

        }


    }
}
