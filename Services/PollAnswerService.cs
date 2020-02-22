using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class PollAnswerService : IService<PollAnswer>
    {
        private DataContext _context;

        public PollAnswerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<PollAnswer> GetAll()
        {
            return _context.PollAnswers;
        }

        public PollAnswer Get(int id)
        {
            var pollAnswer = _context.PollAnswers.Find(id);

            if (pollAnswer == null)
                return null;

            return pollAnswer;
        }

        public PollAnswer Create(PollAnswer pollAnswer)
        {
            _context.PollAnswers.Add(pollAnswer);
            _context.SaveChanges();

            return pollAnswer;
        }

        public PollAnswer Update(PollAnswer pollAnswerParam)
        {
            var pollAnswer = _context.PollAnswers.Find(pollAnswerParam.Id);

            if (pollAnswer == null)
                return null;

            pollAnswer.AnswerId = pollAnswerParam.AnswerId;
            pollAnswer.PollId = pollAnswerParam.PollId;

            _context.SaveChanges();
            return pollAnswer;
        }

        public void Delete(int id)
        {
            var pollAnswer = _context.PollAnswers.Find(id);
            if (pollAnswer != null)
            {
                _context.PollAnswers.Remove(pollAnswer);
                _context.SaveChanges();
            }
        }
    }
}