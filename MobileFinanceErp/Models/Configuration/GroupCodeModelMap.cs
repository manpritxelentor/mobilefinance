using System.Data.Entity.ModelConfiguration;

namespace MobileFinanceErp.Models.Configuration
{
    public class GroupCodeModelMap : EntityTypeConfiguration<GroupCodeModel>
    {
        public GroupCodeModelMap()
        {
            ToTable("tbl_GroupCode");
        }
    }
}