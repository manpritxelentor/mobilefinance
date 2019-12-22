using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models.Configuration
{
    public class PictureModelMap : EntityTypeConfiguration<PictureModel>
    {
        public PictureModelMap()
        {
            ToTable("tbl_Picture");
        }
    }
}