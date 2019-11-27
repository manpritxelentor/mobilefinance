using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.Models.Configuration
{
    public class ModelsModelMap : EntityTypeConfiguration<ModelsModel>
    {
        public ModelsModelMap()
        {
            ToTable("tbl_Model");
        }
    }
}
