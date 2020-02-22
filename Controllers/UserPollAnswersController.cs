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
    public class UserPollAnswersController : ControllerBase
    {
        private IService<UserPollAnswer> _userPollAnswerService;
        private IMapper _mapper;

        public UserPollAnswersController(IService<UserPollAnswer> userPollAnswerService, IMapper mapper)
        {
            _userPollAnswerService = userPollAnswerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var userPollAnswers =  _userPollAnswerService.GetAll();
            var userPollAnswerDtos = _mapper.Map<IList<UserPollAnswerDto>>(userPollAnswers);
            return Ok(userPollAnswerDtos);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userPollAnswer =  _userPollAnswerService.Get(id);
            return Ok(userPollAnswer);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]UserPollAnswerDto userPollAnswerDto)
        {
            var userPollAnswer = _mapper.Map<UserPollAnswer>(userPollAnswerDto);

            try
            {
                _userPollAnswerService.Create(userPollAnswer);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserPollAnswerDto userPollAnswerDto)
        {
            // map dto to entity and set id
            var userPollAnswer = _mapper.Map<UserPollAnswer>(userPollAnswerDto);
            userPollAnswer.Id = id;

            try
            {
                // save
                _userPollAnswerService.Update(userPollAnswer);
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
            _userPollAnswerService.Delete(id);
            return Ok();
        }
    }
}