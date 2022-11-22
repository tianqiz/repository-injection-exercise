using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext dbContext;

        public CoverTypeRepository(ApplicationDbContext _db) : base(_db)
        {
            dbContext = _db;
        }

        public void Update(CoverType obj)
        {
            dbContext.CoverTypes.Update(obj);
        }
    }
}