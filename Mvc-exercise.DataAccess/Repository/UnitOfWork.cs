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
            CoverType = new CoverTypeRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; set; }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}