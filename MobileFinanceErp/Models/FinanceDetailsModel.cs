using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models
{
    public class FinanceDetailsModel : BaseEntity
    {
        public int Id { get; set; }
        public int FinanceMasterId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string ReceivedBy { get; set; }
        public string Notes { get; set; }
        public decimal ReceivedAmount { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual FinanceModel Finance { get; set; }
    }
}