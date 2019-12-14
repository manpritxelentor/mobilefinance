using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models.Configuration
{
    public class GuarantorModelMap : EntityTypeConfiguration<GuarantorModel>
    {
        public GuarantorModelMap()
        {
            ToTable("tbl_Guarantor");
        }
    }
}