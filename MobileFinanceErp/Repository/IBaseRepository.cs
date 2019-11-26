using System.Linq;

namespace MobileFinanceErp.Repository
{
    public interface IBaseRepository<T> where T
        : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNoTracking();
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
        T GetById(object id);
        T Create();
    }
}