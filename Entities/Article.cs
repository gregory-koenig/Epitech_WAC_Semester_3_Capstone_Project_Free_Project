using System;

namespace Ccsrb.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Active { get; set; }
    }
}