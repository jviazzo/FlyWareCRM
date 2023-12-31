﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DTO;
using SystemEmail.API.Utility;
using SystemEmail.BLL.Services;


namespace SystemEmail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly ILogger<ICategoryService> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<ICategoryService> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(int id)
        {
            _logger.LogWarning("Method invoked");
            var response = new Response<List<CategoryDTO>>();

            try
            {
                response.Status = true;
                response.Value = await _categoryService.List();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                throw;
            }

            return Ok(response);

        }

    }
}
