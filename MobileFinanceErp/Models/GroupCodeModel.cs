using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models
{
    public class GroupCodeModel : BaseAuditableEntity
    {
        public GroupCodeModel()
        {
            InterestFinances = new List<FinanceModel>();
            DurationFinances = new List<FinanceModel>();
            StatusFinances = new List<FinanceModel>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<FinanceModel> InterestFinances { get; set; }
        public virtual ICollection<FinanceModel> DurationFinances { get; set; }
        public virtual ICollection<FinanceModel> StatusFinances { get; set; }
    }
}