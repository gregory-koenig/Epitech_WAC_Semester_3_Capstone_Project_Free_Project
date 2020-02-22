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
    public class ArticleImagesController : ControllerBase
    {
        private IService<ArticleImage> _articleImageService;
        private IMapper _mapper;

        public ArticleImagesController(IService<ArticleImage> articleImageService, IMapper mapper)
        {
            _articleImageService = articleImageService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var articleImages =  _articleImageService.GetAll();
            var articleImageDtos = _mapper.Map<IList<ArticleImageDto>>(articleImages);
            return Ok(articleImageDtos);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var articleImage =  _articleImageService.Get(id);
            return Ok(articleImage);
        }
        
        
        [HttpPost]
        public IActionResult Create([FromBody]ArticleImageDto articleImageDto)
        {
            var articleImage = _mapper.Map<ArticleImage>(articleImageDto);

            try
            {
                _articleImageService.Create(articleImage);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ArticleImageDto articleImageDto)
        {
            // map dto to entity and set id
            var articleImage = _mapper.Map<ArticleImage>(articleImageDto);
            articleImage.Id = id;

            try
            {
                // save
                _articleImageService.Update(articleImage);
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
            _articleImageService.Delete(id);
            return Ok();
        }
    }
}