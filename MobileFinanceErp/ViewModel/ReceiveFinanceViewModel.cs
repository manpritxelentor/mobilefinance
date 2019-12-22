using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(ReceiveFinanceViewModelValidator))]
    public class ReceiveFinanceViewModel
    {
        public int FinanceMasterId { get; set; }

        [DisplayName("Received Date")]
        public DateTime ReceivedDate { get; set; }
        public string Notes { get; set; }

        [DisplayName("Emi Amount")]
        public decimal ActualEmiAmount { get; set; }

        [DisplayName("Received Amount")]
        public decimal EMIAmount { get; set; }

        [DisplayName("Remaining Amount")]
        public decimal RemainingAmount { get; set; }

        [DisplayName("Remaining Amount After Payment")]
        public decimal RemainingAmountAfterEMI { get; set; }

        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }


        public decimal CarryForwardAmount { get; set; }
    }
}