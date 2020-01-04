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
            HasOptional(w => w.CustomerImage)
                .WithMany(w => w.CustomerImages)
                .HasForeignKey(w => w.PictureId);

            HasOptional(w => w.CustomerCity)
                .WithMany(w => w.CityCustomers)
                .HasForeignKey(w => w.CityId);

            ToTable("tbl_Customer");
        }
    }
}