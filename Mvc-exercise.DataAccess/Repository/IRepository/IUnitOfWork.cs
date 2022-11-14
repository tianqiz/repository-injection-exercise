namespace Mvc_exercise.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
         ICategoryRepository  Category { get; }

         void Save();
    }
}