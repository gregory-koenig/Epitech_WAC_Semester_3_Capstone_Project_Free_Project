using System.Collections.Generic;
using AutoMapper;
using Ccsrb.Dtos;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services;
using Ccsrb.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ccsrb.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private IService<Answer> _answerService;
        private IMapper _mapper;

        public AnswersController(IService<Answer> answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var answers =  _answerService.GetAll();
            var answerDtos = _mapper.Map<IList<AnswerDto>>(answers);
            return Ok(answerDtos);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var answer =  _answerService.Get(id);
            return Ok(answer);
        }
        
        
        [HttpPost]
        public IActionResult Create([FromBody]AnswerDto answerDto)
        {
            var answer = _mapper.Map<Answer>(answerDto);

            try
            {
                _answerService.Create(answer);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]AnswerDto answerDto)
        {
            // map dto to entity and set id
            var answer = _mapper.Map<Answer>(answerDto);
            answer.Id = id;

            try
            {
                // save
                _answerService.Update(answer);
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
            _answerService.Delete(id);
            return Ok();
        }
    }
}