using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IFinanceRepository : IBaseTenantRepository<FinanceModel>
    {
    }

    public class FinanceRepository : BaseTenantRepository<FinanceModel>, IFinanceRepository
    {
        public FinanceRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper)
            : base(applicationDbContext, identityHelper)
        {
        }
    }
}