using System;

namespace Ccsrb.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Boolean Active { get; set; }
    }
}
