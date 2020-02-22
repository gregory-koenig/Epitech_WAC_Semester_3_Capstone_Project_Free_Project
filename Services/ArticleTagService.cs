using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class ArticleTagService : IService<ArticleTag>
    {
        private DataContext _context;

        public ArticleTagService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ArticleTag> GetAll()
        {
            return _context.ArticleTags;
        }

        public ArticleTag Get(int id)
        {
            var articleTag = _context.ArticleTags.Find(id);

            if (articleTag == null)
                return null;

            return articleTag;
        }

        public ArticleTag Create(ArticleTag articleTag)
        {
            _context.ArticleTags.Add(articleTag);
            _context.SaveChanges();

            return articleTag;
        }

        public ArticleTag Update(ArticleTag articleTagParam)
        {
            var articleTag = _context.ArticleTags.Find(articleTagParam.Id);

            if (articleTag == null)
                return null;

            articleTag.ArticleId = articleTagParam.ArticleId;

            _context.SaveChanges();
            return articleTag;
        }

        public void Delete(int id)
        {
            var articleTag = _context.ArticleTags.Find(id);
            if (articleTag != null)
            {
                _context.ArticleTags.Remove(articleTag);
                _context.SaveChanges();
            }
        }
    }
}