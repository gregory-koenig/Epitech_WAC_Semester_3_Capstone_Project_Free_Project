using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class ImageService : IService<Image>
    {
        private DataContext _context;

        public ImageService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Images;
        }

        public Image Get(int id)
        {
            var image = _context.Images.Find(id);

            if (image == null)
                return null;

            return image;
        }

        public Image Create(Image image)
        {
            _context.Images.Add(image);
            _context.SaveChanges();

            return image;
        }

        public Image Update(Image imageParam)
        {
            var image = _context.Images.Find(imageParam.Id);

            if (image == null)
                return null;

            image.Picture = imageParam.Picture;

            _context.SaveChanges();
            return image;
        }

        public void Delete(int id)
        {
            var image = _context.Images.Find(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                _context.SaveChanges();
            }
        }
    }
}