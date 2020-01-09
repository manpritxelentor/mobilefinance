using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditFinanceViewModelValidator))]
    public class AddEditFinanceViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer")]
        public int CustomerId { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Mobile")]
        public string CustomerMobile { get; set; }

        [DisplayName("Address")]
        public string CustomerAddress { get; set; }

        [DisplayName("Book Number")]
        public string BookNo { get; set; }

        [DisplayName("Page Number")]
        public string PageNo { get; set; }

        [DisplayName("Brand")]
        public int BrandId { get; set; }

        [DisplayName("Model")]
        public int ModelId { get; set; }

        [DisplayName("Mobile Price")]
        public decimal? MobilePrice { get; set; }

        [DisplayName("Loan Amount")]
        public decimal? LoanAmount { get; set; }

        [DisplayName("Down Payment")]
        public decimal? DownPayment { get; set; }

        [DisplayName("EMI")]
        public decimal? EMI { get; set; }

        [DisplayName("Duration")]
        public int? Duration { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Guarantor 1")]
        public int? Guarantor1 { get; set; }

        [DisplayName("IMEI")]
        public string IMEI { get; set; }

        [DisplayName("Guarantor 2")]
        public int? Guarantor2 { get; set; }
    }
}