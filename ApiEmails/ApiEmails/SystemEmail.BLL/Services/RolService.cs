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

namespace SystemEmail.BLL.Services
{
    public class RolService : IRolService
    {

        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;

        public RolService(IGenericRepository<Rol> rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        public async Task<List<RolDTO>> List()
        {
            try
            {
                var rolList = await _rolRepository.Query();

                return _mapper.Map<List<RolDTO>>(rolList.ToList());

            }
            catch (Exception)
            {
                throw;
            }







        }
    }
}
