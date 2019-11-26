using MobileFinanceErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface ITenantRepository : IBaseRepository<TenantModel>
    {

    }

    public class TenantRepository : BaseRepository<TenantModel>, ITenantRepository
    {
        public TenantRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
    }
}