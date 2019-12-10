using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models.Configuration
{
    public class CustomerModelMap : EntityTypeConfiguration<CustomerModel>
    {
        public CustomerModelMap()
        {
            ToTable("tbl_Customer");
        }
    }
}