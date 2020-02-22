using System;

namespace Ccsrb.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public int categoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Active { get; set; }
    }
}