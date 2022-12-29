
using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
         void Update(Product obj);
    }
}