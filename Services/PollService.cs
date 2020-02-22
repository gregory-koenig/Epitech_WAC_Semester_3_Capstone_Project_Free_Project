using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class PollService : IService<Poll>
    {
        private DataContext _context;

        public PollService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Poll> GetAll()
        {
            return _context.Polls;
        }

        public Poll Get(int id)
        {
            var poll = _context.Polls.Find(id);

            if (poll == null)
                return null;

            return poll;
        }

        public Poll Create(Poll poll)
        {
            _context.Polls.Add(poll);
            _context.SaveChanges();

            return poll;
        }

        public Poll Update(Poll pollParam)
        {
            var poll = _context.Polls.Find(pollParam.Id);

            if (poll == null)
                return null;

            poll.Title = pollParam.Title;
            poll.Date = pollParam.Date;
            poll.Active = pollParam.Active;

            _context.SaveChanges();
            return poll;
        }

        public void Delete(int id)
        {
            var poll = _context.Polls.Find(id);
            if (poll != null)
            {
                _context.Polls.Remove(poll);
                _context.SaveChanges();
            }
        }
    }
}