using System;
using System.ComponentModel;

namespace MobileFinanceErp.ViewModel
{
    public class FinanceListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("Book/Page")]
        public string BookNoPageNumber { get; set; }

        //[DisplayName("Mobile Price")]
        //public decimal MobilePrice { get; set; }

        [DisplayName("Loan")]
        public decimal LoanAmount { get; set; }

        [DisplayName("DP")]
        public decimal DownPayment { get; set; }

        [DisplayName("Guarantor")]
        public string GuarantorName { get; set; }

        [DisplayName("Mobile")]
        public string CustomerMobileNumber { get; set; }
        //[DisplayName("Start Date")]
        //public DateTime StartDate { get; set; }
    }
}