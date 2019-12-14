using System;
using System.Collections.Generic;

namespace MobileFinanceErp.Models
{
    public class FinanceModel : BaseAuditableEntity
    {
        public FinanceModel()
        {
            FinanceDetails = new List<FinanceDetailsModel>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string BookNo { get; set; }
        public string PageNo { get; set; }
        public int ModelId { get; set; }
        public decimal MobilePrice { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal DownPayment { get; set; }
        public decimal EMI { get; set; }
        public int InterestRateId { get; set; }
        public int DurationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Guarantor1 { get; set; }
        public int? Guarantor2 { get; set; }
        public int StatusId { get; set; }


        public virtual CustomerModel Customer { get; set; }
        public virtual ModelsModel Model { get; set; }
        public virtual GroupCodeModel Interest { get; set; }
        public virtual GroupCodeModel Duration { get; set; }
        public virtual GroupCodeModel Status { get; set; }

        public virtual ICollection<FinanceDetailsModel> FinanceDetails { get; set; }
    }
}