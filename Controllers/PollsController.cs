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
    public class PollsController : ControllerBase
    {
        private IService<Poll> _pollService;
        private IMapper _mapper;

        public PollsController(IService<Poll> pollService, IMapper mapper)
        {
            _pollService = pollService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var polls =  _pollService.GetAll();
            var pollDtos = _mapper.Map<IList<Poll>>(polls);
            return Ok(pollDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll=  _pollService.Get(id);
            return Ok(poll);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]PollDto pollDto)
        {
            var poll = _mapper.Map<Poll>(pollDto);

            try
            {
                _pollService.Create(poll);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]PollDto pollDto)
        {
            // map dto to entity and set id
            var poll = _mapper.Map<Poll>(pollDto);
            poll.Id = id;

            try
            {
                // save
                _pollService.Update(poll);
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
            _pollService.Delete(id);
            return Ok();
        }
    }
}