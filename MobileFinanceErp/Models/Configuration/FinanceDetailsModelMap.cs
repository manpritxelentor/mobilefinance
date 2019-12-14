using System.Data.Entity.ModelConfiguration;

namespace MobileFinanceErp.Models.Configuration
{
    public class FinanceDetailsModelMap : EntityTypeConfiguration<FinanceDetailsModel>
    {
        public FinanceDetailsModelMap()
        {
            HasRequired(w => w.Finance)
                .WithMany(w => w.FinanceDetails)
                .HasForeignKey(w => w.FinanceMasterId);

            ToTable("tbl_FinanceDetails");
        }
    }
}