using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface ICustomerRepository : IBaseTenantRepository<CustomerModel>
    {
    }

    public class CustomerRepository : BaseTenantRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext
            , IIdentityHelper identityHelper) 
            : base(applicationDbContext, identityHelper)
        {
        }
    }
}