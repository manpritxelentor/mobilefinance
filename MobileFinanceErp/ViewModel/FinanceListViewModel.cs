using System;
using System.ComponentModel;

namespace MobileFinanceErp.ViewModel
{
    public class FinanceListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Book No. / Page No.")]
        public string BookNoPageNumber { get; set; }

        [DisplayName("Mobile Price")]
        public decimal MobilePrice { get; set; }

        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Down Payment")]
        public decimal DownPayment { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
    }
}