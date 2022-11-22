
using Mvc_exercise.Models;

namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
         void Update(CoverType obj);
    }
}