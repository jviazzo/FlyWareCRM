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
    public class MenuService : IMenuService
    {

        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<MenuRol> _menuRolRepository;
        private readonly IGenericRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<User> userRepository, IGenericRepository<MenuRol> menuRolRepository, IGenericRepository<Menu> menuRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _menuRolRepository = menuRolRepository;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> List(int id)
        {
            IQueryable<User> tableUser = await _userRepository.Query(u => u.IdUser == id);
            IQueryable<MenuRol> tableMenuRol = await _menuRolRepository.Query();
            IQueryable<Menu> tableMenu = await _menuRepository.Query();


            try
            {

                IQueryable<Menu> tableResult = (from u in tableUser 
                                          join Mr in tableMenuRol on u.IdRol equals Mr.IdRol
                                          join m in tableMenu on Mr.IdMenu equals m.IdMenu
                                          select m).AsQueryable();

                var MenuList = tableResult.ToList();

                return _mapper.Map<List<MenuDTO>>(MenuList);
            }
            catch (Exception)
            {
                throw;
            }




        }



    }
}
