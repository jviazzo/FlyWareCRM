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
    public class CategoryService : ICategoryService
    {

        private readonly IGenericRepository<Category> _categorylRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> categorylRepository, IMapper mapper)
        {
            _categorylRepository = categorylRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> List()
        {
            try
            {
                var categoryList = await _categorylRepository.Query();

                return _mapper.Map<List<CategoryDTO>>(categoryList.ToList());
            }
            catch (Exception)
            {
                throw;
            }



        }
    }
}
