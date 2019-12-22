using System.Data.Entity.ModelConfiguration;

namespace MobileFinanceErp.Models.Configuration
{
    public class FinanceModelMap : EntityTypeConfiguration<FinanceModel>
    {
        public FinanceModelMap()
        {
            HasRequired(w => w.Customer)
                .WithMany(w => w.Finances)
                .HasForeignKey(w => w.CustomerId);

            HasRequired(w => w.Model)
                .WithMany(w => w.Finances)
                .HasForeignKey(w => w.ModelId);

            HasRequired(w => w.Status)
                .WithMany(w => w.StatusFinances)
                .HasForeignKey(w => w.StatusId);

            ToTable("tbl_FinanceMaster");
        }
    }
}