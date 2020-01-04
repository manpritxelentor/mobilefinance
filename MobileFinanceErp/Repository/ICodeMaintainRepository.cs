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
        string GetNewCustomerIdentityNumber();
        void BurnCustomerNumber();
    }

    public class CodeMaintainRepository : BaseTenantRepository<CodeMaintainModel>, ICodeMaintainRepository
    {
        public CodeMaintainRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper) 
            : base(applicationDbContext, identityHelper)
        {
        }

        public void BurnCustomerNumber()
        {
            var customerCode = GetAll().FirstOrDefault(w => w.Module == DataConstants.CodeMaintain.Customer);
            customerCode.LastNumber = customerCode.LastNumber + 1;
            Update(customerCode);
        }

        public string GetNewCustomerIdentityNumber()
        {
            var customerCodeManage = GetAllNoTracking()
                .FirstOrDefault(w => w.Module == DataConstants.CodeMaintain.Customer);

            int newNumber = customerCodeManage.LastNumber + 1;
            return $"{Convert.ToString(customerCodeManage.Prefix)}{Convert.ToString(customerCodeManage.Separator)}{newNumber.ToString().PadLeft(customerCodeManage.Padding, '0')}";
        }
    }
}