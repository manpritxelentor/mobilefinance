using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models.Configuration
{
    public class TenantModelMap : EntityTypeConfiguration<TenantModel>
    {
        public TenantModelMap()
        {
            ToTable("tbl_Tenant");
        }
    }
}