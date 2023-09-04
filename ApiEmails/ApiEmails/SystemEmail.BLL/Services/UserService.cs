using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DTO;
using SystemEmail.Model;


namespace SystemEmail.BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> ListUserDTO()
        {

            try
            {
                var userQuery= await _userRepository.Query();
                var listUsers = userQuery.Include(rol => rol.IdRolNavigation).ToList(); 

                return _mapper.Map<List<UserDTO>>(listUsers);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<SessionDTO> ValidateToken(string email, string password)
        {
            try
            {
                var userQuery = await _userRepository.Query(x => x.Email == email && x.Password == password);

                if (userQuery.FirstOrDefault() == null)
                {
                    throw new TaskCanceledException("Username does not exist");
                }

                User returnUser = userQuery.Include(rol => rol.IdRolNavigation).First();    

                return _mapper.Map<SessionDTO>(returnUser);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDTO> CreateUser(UserDTO model)
        {

            try
            {
                var userMap = _mapper.Map<User>(model);
                var createdUser = await _userRepository.Create(userMap);

                if (createdUser.IdUser == 0)
                {
                    throw new TaskCanceledException("user could not be created");
                }

                var queryUser = await _userRepository.Query(x => x.IdUser == createdUser.IdUser);

                createdUser = queryUser.Include(x => x.IdRolNavigation).First();

                return _mapper.Map<UserDTO>(createdUser);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<bool> EditUser(UserDTO model)
        {
            try
            {
                var modelUser = _mapper.Map<User>(model);
                var foundUser = await _userRepository.Get(x => x.IdUser == modelUser.IdUser);
                
                if (foundUser == null)
                {
                    throw new TaskCanceledException("User not found");
                }

                foundUser.FullName = modelUser.FullName;
                foundUser.IdRol= modelUser.IdRol;
                foundUser.Email = modelUser.Email;
                foundUser.Password = modelUser.Password;
                foundUser.IsActive = modelUser.IsActive;
                
                bool response = await _userRepository.Edit(foundUser);

                if(!response)
                    throw new TaskCanceledException("The user could not be edited.");

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
                var foundUser = await _userRepository.Get(x => x.IdUser == id);

                if (foundUser == null)
                {
                    throw new TaskCanceledException("User not found");
                }

                var response = await _userRepository.Delete(foundUser);

                if (!response)
                    throw new TaskCanceledException("The user could not be deleted.");

                return response;

            }
            catch (Exception)
            {
                throw;
            }

        }

      


    }
}
