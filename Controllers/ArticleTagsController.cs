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
    public class ArticleTagsController : ControllerBase
    {
        private IService<ArticleTag> _articleTagService;
        private IMapper _mapper;

        public ArticleTagsController(IService<ArticleTag> articleTagService, IMapper mapper)
        {
            _articleTagService = articleTagService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var articleTags =  _articleTagService.GetAll();
            var articleTagDtos = _mapper.Map<IList<ArticleTagDto>>(articleTags);
            return Ok(articleTagDtos);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var articleTag =  _articleTagService.Get(id);
            return Ok(articleTag);
        }
        
        
        [HttpPost]
        public IActionResult Create([FromBody]ArticleTagDto articleTagDto)
        {
            var articleTag = _mapper.Map<ArticleTag>(articleTagDto);

            try
            {
                _articleTagService.Create(articleTag);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ArticleTagDto articleTagDto)
        {
            // map dto to entity and set id
            var articleTag = _mapper.Map<ArticleTag>(articleTagDto);
            articleTag.Id = id;

            try
            {
                // save
                _articleTagService.Update(articleTag);
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
            _articleTagService.Delete(id);
            return Ok();
        }
    }
}