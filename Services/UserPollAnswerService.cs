using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class UserPollAnswerService : IService<UserPollAnswer>
    {
        private DataContext _context;

        public UserPollAnswerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserPollAnswer> GetAll()
        {
            return _context.UserPollAnswers;
        }

        public UserPollAnswer Get(int id)
        {
            var userPollAnswer = _context.UserPollAnswers.Find(id);

            if (userPollAnswer == null)
                return null;

            return userPollAnswer;
        }

        public UserPollAnswer Create(UserPollAnswer userPollAnswer)
        {
            _context.UserPollAnswers.Add(userPollAnswer);
            _context.SaveChanges();

            return userPollAnswer;
        }

        public UserPollAnswer Update(UserPollAnswer userPollAnswerParam)
        {
            var userPollAnswer = _context.UserPollAnswers.Find(userPollAnswerParam.Id);

            if (userPollAnswer == null)
                return null;

            userPollAnswer.UserId = userPollAnswerParam.UserId;
            userPollAnswer.AnswerId = userPollAnswerParam.AnswerId;
            userPollAnswer.PollId = userPollAnswerParam.PollId;

            _context.SaveChanges();
            return userPollAnswer;
        }

        public void Delete(int id)
        {
            var userPollAnswer = _context.UserPollAnswers.Find(id);
            if (userPollAnswer != null)
            {
                _context.UserPollAnswers.Remove(userPollAnswer);
                _context.SaveChanges();
            }
        }
    }
}