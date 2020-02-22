using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class ArticleService : IService<Article>
    {
        private DataContext _context;

        public ArticleService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }

        public Article Get(int id)
        {
            var article = _context.Articles.Find(id);

            if (article == null)
                return null;

            return article;
        }

        public Article Create(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();

            return article;
        }

        public Article Update(Article articleParam)
        {
            var article = _context.Articles.Find(articleParam.Id);

            if (article == null)
                return null;

            article.Title = articleParam.Title;
            article.Body = articleParam.Body;
            article.Date = articleParam.Date;
            article.Active = articleParam.Active;

            _context.SaveChanges();
            return article;
        }

        public void Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}