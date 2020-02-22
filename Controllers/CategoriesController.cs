using System.Collections.Generic;
using AutoMapper;
using Ccsrb.Dtos;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ccsrb.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private IService<Category> _categoryService;
        private IMapper _mapper;

        public CategoriesController(IService<Category> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
    
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories =  _categoryService.GetAll();
            var categoryDtos = _mapper.Map<IList<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }
    
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category =  _categoryService.Get(id);
            return Ok(category);
        }
    
        [HttpPost]
        public IActionResult Create([FromBody]CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            try
            {
                _categoryService.Create(category);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]CategoryDto categoryDto)
        {
            // map dto to entity and set id
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;

            try
            {
                // save
                _categoryService.Update(category);
                return Ok();
            }
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}