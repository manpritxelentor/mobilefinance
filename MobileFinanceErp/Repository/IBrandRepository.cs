using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IBrandRepository : IBaseTenantRepository<BrandModel>
    {
    }

    public class BrandRepository : BaseTenantRepository<BrandModel>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper) 
            : base(applicationDbContext, identityHelper)
        {
        }
    }
}