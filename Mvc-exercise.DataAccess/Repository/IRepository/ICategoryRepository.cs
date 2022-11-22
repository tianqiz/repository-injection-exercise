
using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
         void Update(Category obj);
    }
}