using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface ICodeMaintainRepository : IBaseTenantRepository<CodeMaintainModel>
    {
    }

    public class CodeMaintainRepository : BaseTenantRepository<CodeMaintainModel>, ICodeMaintainRepository
    {
        public CodeMaintainRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper) 
            : base(applicationDbContext, identityHelper)
        {
        }
    }
}