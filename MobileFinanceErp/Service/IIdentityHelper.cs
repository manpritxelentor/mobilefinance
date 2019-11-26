using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MobileFinanceErp.Service
{
    public interface IIdentityHelper
    {
        string UserId { get; }
        int TenantId { get; }
    }

    public class IdentityHelper : IIdentityHelper
    {
        public string UserId => HttpContext.Current.User.Identity.GetUserId<string>();

        public int TenantId
        {
            get
            {
                var userWithClaims = (ClaimsPrincipal)HttpContext.Current.User;
                var tenantId = userWithClaims.Claims.First(c => c.Type == "TenantId");
                return Convert.ToInt32(tenantId.Value);
            }
        }
    }
}