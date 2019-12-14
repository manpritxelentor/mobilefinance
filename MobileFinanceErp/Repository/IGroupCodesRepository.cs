using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IGroupCodesRepository : IBaseTenantRepository<GroupCodeModel>
    {
        IQueryable<GroupCodeModel> GetByGroup(string groupName);
    }

    public class GroupCodesRepository : BaseTenantRepository<GroupCodeModel>, IGroupCodesRepository
    {
        public GroupCodesRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper)
            : base(applicationDbContext, identityHelper)
        {
        }

        public IQueryable<GroupCodeModel> GetByGroup(string groupName)
        {
            return GetAllNoTracking().Where(w => w.Name == groupName);
        }
    }
}