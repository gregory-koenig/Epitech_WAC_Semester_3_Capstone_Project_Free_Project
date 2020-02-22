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
    public class TagsController : ControllerBase
    {
        private IService<Tag> _tagService;
        private IMapper _mapper;

        public TagsController(IService<Tag> tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var tags =  _tagService.GetAll();
            var tagDtos = _mapper.Map<IList<TagDto>>(tags);
            return Ok(tagDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tag =  _tagService.Get(id);
            return Ok(tag);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]TagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);

            try
            {
                _tagService.Create(tag);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TagDto tagDto)
        {
            // map dto to entity and set id
            var tag = _mapper.Map<Tag>(tagDto);
            tag.Id = id;

            try
            {
                // save
                _tagService.Update(tag);
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
            _tagService.Delete(id);
            return Ok();
        }
    }
}