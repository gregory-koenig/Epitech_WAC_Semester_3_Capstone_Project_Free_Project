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
    public class ImagesController : ControllerBase
    {
        private IService<Image> _imageService;
        private IMapper _mapper;

        public ImagesController(IService<Image> imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var images =  _imageService.GetAll();
            var imageDtos = _mapper.Map<IList<ImageDto>>(images);
            return Ok(imageDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var image =  _imageService.Get(id);
            return Ok(image);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]ImageDto imageDto)
        {
            var image = _mapper.Map<Image>(imageDto);

            try
            {
                _imageService.Create(image);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ImageDto imageDto)
        {
            // map dto to entity and set id
            var image = _mapper.Map<Image>(imageDto);
            image.Id = id;

            try
            {
                // save
                _imageService.Update(image);
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
            _imageService.Delete(id);
            return Ok();
        }
    }
}