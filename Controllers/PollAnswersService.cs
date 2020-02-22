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
    public class PollAnswersController : ControllerBase
    {
        private IService<PollAnswer> _pollAnswerService;
        private IMapper _mapper;

        public PollAnswersController(IService<PollAnswer> pollAnswerService, IMapper mapper)
        {
            _pollAnswerService = pollAnswerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var pollAnswers =  _pollAnswerService.GetAll();
            var pollAnswerDtos = _mapper.Map<IList<PollAnswerDto>>(pollAnswers);
            return Ok(pollAnswerDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pollAnswer =  _pollAnswerService.Get(id);
            return Ok(pollAnswer);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]PollAnswerDto pollAnswerDto)
        {
            var pollAnswer = _mapper.Map<PollAnswer>(pollAnswerDto);

            try
            {
                _pollAnswerService.Create(pollAnswer);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]PollAnswerDto pollAnswerDto)
        {
            // map dto to entity and set id
            var pollAnswer = _mapper.Map<PollAnswer>(pollAnswerDto);
            pollAnswer.Id = id;

            try
            {
                // save
                _pollAnswerService.Update(pollAnswer);
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
            _pollAnswerService.Delete(id);
            return Ok();
        }
    }
}