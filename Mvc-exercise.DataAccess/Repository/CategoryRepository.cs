using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext _db) : base(_db)
        {
            dbContext = _db;
        }

        public void Update(Category obj)
        {
            dbContext.Categories.Update(obj);
        }
    }
}