using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext _db) : base(_db)
        {
            dbContext = _db;
        }

        public void Update(Product obj)
        {
            var objFromDB = dbContext.Products.FirstOrDefault(p => p.Id == obj.Id);

            if (objFromDB != null)
            {
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = obj.ISBN;
                objFromDB.Price = obj.Price;
                objFromDB.Price50 = obj.Price50;
                objFromDB.Price100 = obj.Price100;
                objFromDB.Description = obj.Description;
                objFromDB.CategoryId = obj.CategoryId;
                objFromDB.Author = obj.Author;
                objFromDB.CoverTypeId = obj.CoverTypeId;
                if (obj.ImageUrl != null)
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}