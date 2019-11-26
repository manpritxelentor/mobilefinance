using MobileFinanceErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IBaseTenantRepository<T> : IBaseRepository<T>
        where T : BaseAuditableEntity
    {
    }
}