using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IGuarantorRepository : IBaseTenantRepository<GuarantorModel>
    {
    }

    public class GuarantorRepository : BaseTenantRepository<GuarantorModel>, IGuarantorRepository
    {
        public GuarantorRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper)
            : base(applicationDbContext, identityHelper)
        {
        }
    }
}