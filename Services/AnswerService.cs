using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class AnswerService : IService<Answer>
    {
        private DataContext _context;

        public AnswerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers;
        }

        public Answer Get(int id)
        {
            var answer = _context.Answers.Find(id);

            if (answer == null)
                return null;

            return answer;
        }

        public Answer Create(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();

            return answer;
        }

        public Answer Update(Answer answerParam)
        {
            var answer = _context.Answers.Find(answerParam.Id);

            if (answer == null)
                return null;

            answer.Name = answerParam.Name;

            _context.SaveChanges();
            return answer;
        }

        public void Delete(int id)
        {
            var answer = _context.Answers.Find(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
            }
        }
    }
}