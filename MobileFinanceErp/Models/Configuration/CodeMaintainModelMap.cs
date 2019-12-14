using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models.Configuration
{
    public class CodeMaintainModelMap : EntityTypeConfiguration<CodeMaintainModel>
    {
        public CodeMaintainModelMap()
        {
            ToTable("tbl_CodeMaintain");
        }
    }
}