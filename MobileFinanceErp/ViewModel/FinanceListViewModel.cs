using System;

namespace MobileFinanceErp.ViewModel
{
    public class FinanceListViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string BookNo { get; set; }
        public string PageNo { get; set; }
        public decimal MobilePrice { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal DownPayment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}