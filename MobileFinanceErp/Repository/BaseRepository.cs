using MobileFinanceErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _applicationDbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAllNoTracking()
        {
            return _applicationDbContext.Set<T>().AsNoTracking();
        }

        public virtual T GetById(object id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public virtual void Insert(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
        }

        public virtual void Remove(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _applicationDbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public T Create()
        {
            return _applicationDbContext.Set<T>().Create<T>();
        }
    }
}