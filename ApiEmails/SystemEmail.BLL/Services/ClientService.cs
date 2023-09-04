using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DTO;
using SystemEmail.Model;

namespace SystemEmail.BLL.Services
{
    public class ClientService : IClientService
    {

        private readonly IGenericRepository<Client> _clientlRepository;
        private readonly IMapper _mapper;

        public ClientService(IGenericRepository<Client> clientlRepository, IMapper mapper)
        {
            _clientlRepository = clientlRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientDTO>> List()
        {
            try
            {
                var queryClient = await _clientlRepository.Query();

                var listClient = queryClient.Include(x => x.IdCategoryNavigation).ToList();

                return _mapper.Map<List<ClientDTO>>(listClient.ToList());

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ClientDTO> CreateClient(ClientDTO model)
        {
            try
            {
                var clientModel = _mapper.Map<Client>(model);    

                var createdClient = await _clientlRepository.Create(clientModel);

                if (createdClient.IdClient == 0)
                {
                    throw new TaskCanceledException("client could not be created");
                }

                return _mapper.Map<ClientDTO>(createdClient);   


            }
            catch (Exception)
            {
                throw;
            }




        }
        public async Task<bool> EditClient(ClientDTO model)
        {
            try
            {
                var clientModel = _mapper.Map<Client>(model);
                
                var foundClient = await _clientlRepository.Get(x => x.IdClient == clientModel.IdClient);


                if (foundClient == null)
                {
                    throw new TaskCanceledException("Client not found");
                }


                foundClient.Name = clientModel.Name;
                foundClient.Email = clientModel.Email;
                foundClient.Company = clientModel.Company;
                foundClient.DetailEmails = clientModel.DetailEmails;
                foundClient.IdCategory = clientModel.IdCategory;
                foundClient.IsActive = clientModel.IsActive;

                bool response = await _clientlRepository.Edit(foundClient);

                if (!response)
                    throw new TaskCanceledException("The client could not be edited.");

                return response;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var foundClient = await _clientlRepository.Get(x => x.IdClient == id);

                if (foundClient == null)
                {
                    throw new TaskCanceledException("Client not found");
                }

                var response = await _clientlRepository.Delete(foundClient);

                if (!response)
                    throw new TaskCanceledException("The Client could not be deleted.");

                return response;

            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}
