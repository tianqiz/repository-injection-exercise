using Mvc_exercise.DataAccess.Repository.IRepository;

namespace Mvc_exercise.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext _db)
        {
            dbContext = _db;
            Category = new CategoryRepository(dbContext);
        }

        public ICategoryRepository Category { get; private set; }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}