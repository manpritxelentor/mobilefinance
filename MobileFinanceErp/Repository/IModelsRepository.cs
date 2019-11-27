using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.Repository
{
    public interface IModelsRepository : IBaseTenantRepository<ModelsModel>
    {

    }

    public class ModelsRepository : BaseTenantRepository<ModelsModel>, IModelsRepository
    {
        public ModelsRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper)
            : base(applicationDbContext, identityHelper)
        {

        }

    }
}
