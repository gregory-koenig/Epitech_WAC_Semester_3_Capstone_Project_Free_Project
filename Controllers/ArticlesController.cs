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
    public class ArticlesController : ControllerBase
    {
        private IService<Article> _articleService;
        private IMapper _mapper;

        public ArticlesController(IService<Article> articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var articles =  _articleService.GetAll();
            var articleDtos = _mapper.Map<IList<ArticleDto>>(articles);
            return Ok(articleDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article =  _articleService.Get(id);
            return Ok(article);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);

            try
            {
                _articleService.Create(article);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ArticleDto articleDto)
        {
            // map dto to entity and set id
            var article = _mapper.Map<Article>(articleDto);
            article.Id = id;

            try
            {
                // save
                _articleService.Update(article);
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
            _articleService.Delete(id);
            return Ok();
        }
    }
}