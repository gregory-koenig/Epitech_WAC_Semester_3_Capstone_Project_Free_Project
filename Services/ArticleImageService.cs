using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class ArticleImageService : IService<ArticleImage>
    {
        private DataContext _context;

        public ArticleImageService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ArticleImage> GetAll()
        {
            return _context.ArticleImages;
        }

        public ArticleImage Get(int id)
        {
            var articleImage = _context.ArticleImages.Find(id);

            if (articleImage == null)
                return null;

            return articleImage;
        }

        public ArticleImage Create(ArticleImage articleImage)
        {
            _context.ArticleImages.Add(articleImage);
            _context.SaveChanges();

            return articleImage;
        }

        public ArticleImage Update(ArticleImage articleImageParam)
        {
            var articleImage = _context.ArticleImages.Find(articleImageParam.Id);

            if (articleImage == null)
                return null;

            articleImage.ArticleId = articleImageParam.ArticleId;
            articleImage.ImageId = articleImageParam.ImageId;

            _context.SaveChanges();
            return articleImage;
        }

        public void Delete(int id)
        {
            var articleImage = _context.ArticleImages.Find(id);
            if (articleImage != null)
            {
                _context.ArticleImages.Remove(articleImage);
                _context.SaveChanges();
            }
        }
    }
}