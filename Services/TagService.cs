using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class TagService : IService<Tag>
    {
        private DataContext _context;

        public TagService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags;
        }

        public Tag Get(int id)
        {
            var tag = _context.Tags.Find(id);

            if (tag == null)
                return null;

            return tag;
        }

        public Tag Create(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();

            return tag;
        }

        public Tag Update(Tag tagParam)
        {
            var tag = _context.Tags.Find(tagParam.Id);

            if (tag == null)
                return null;

            tag.Name = tagParam.Name;

            _context.SaveChanges();
            return tag;
        }

        public void Delete(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
            }
        }
    }
}