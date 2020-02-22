using System.Collections.Generic;
using Ccsrb.Entities;
using Ccsrb.Helpers;
using Ccsrb.Services.Interface;

namespace Ccsrb.Services
{
    public class CategoryService : IService<Category>
        {
            private DataContext _context;

            public CategoryService(DataContext context)
            {
                _context = context;
            }

            public IEnumerable<Category> GetAll()
            {
                return _context.Categories;
            }

            public Category Get(int id)
            {
                var category = _context.Categories.Find(id);

                if (category == null)
                    return null;

                return category;
            }

            public Category Create(Category category)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return category;
            }

            public Category Update(Category categoryParam)
            {
                var category = _context.Categories.Find(categoryParam.Id);

                if (category == null)
                    return null;

//                category.Picture = CategoryParam.Picture;

                _context.SaveChanges();
                return category;
            }

            public void Delete(int id)
            {
                var category = _context.Categories.Find(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                }
            }
        }
    
}