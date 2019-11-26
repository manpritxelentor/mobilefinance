using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Linq;

namespace MobileFinanceErp.Repository
{
    public class BaseTenantRepository<T> : BaseRepository<T>
        where T : BaseAuditableEntity
    {

        private readonly IIdentityHelper _identityHelper;

        public BaseTenantRepository(ApplicationDbContext applicationDbContext
            , IIdentityHelper identityHelper)
            : base(applicationDbContext)
        {
            _identityHelper = identityHelper;
        }

        public override IQueryable<T> GetAll()
        {
            return base.GetAll().Where(w => w.TenantId == _identityHelper.TenantId);
        }

        public override IQueryable<T> GetAllNoTracking()
        {
            return base.GetAllNoTracking().Where(w => w.TenantId == _identityHelper.TenantId);
        }

        public override void Insert(T entity)
        {
            entity.CreatedBy = _identityHelper.UserId;
            entity.CreatedOn = DateTime.Now;
            entity.TenantId = _identityHelper.TenantId;
            base.Insert(entity);
        }

        public override void Update(T entity)
        {
            entity.ModifiedBy = _identityHelper.UserId;
            entity.ModifiedOn = DateTime.Now;
            entity.TenantId = _identityHelper.TenantId;
            base.Update(entity);
        }
    }
}