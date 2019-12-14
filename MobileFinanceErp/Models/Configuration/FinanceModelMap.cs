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

            HasRequired(w => w.Interest)
                .WithMany(w => w.InterestFinances)
                .HasForeignKey(w => w.InterestRateId);

            HasRequired(w => w.Duration)
                .WithMany(w => w.DurationFinances)
                .HasForeignKey(w => w.DurationId);

            HasRequired(w => w.Status)
                .WithMany(w => w.StatusFinances)
                .HasForeignKey(w => w.StatusId);

            ToTable("tbl_FinanceMaster");
        }
    }
}