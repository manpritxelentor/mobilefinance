using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditFinanceViewModelValidator : AbstractValidator<AddEditFinanceViewModel>
    {
        public AddEditFinanceViewModelValidator()
        {
            RuleFor(w => w.CustomerId)
                .NotEmpty()
                .WithMessage("Please select customer");

            RuleFor(w => w.BookNo)
                .NotEmpty()
                .WithMessage("Book Number is required");

            RuleFor(w => w.PageNo)
                .NotEmpty()
                .WithMessage("Page Number is required");

            RuleFor(w => w.ModelId)
                .NotEmpty()
                .WithMessage("Plese select model");

            RuleFor(w => w.MobilePrice)
                .NotEmpty()
                .WithMessage("Mobile Price is required");

            RuleFor(w => w.LoanAmount)
                .NotEmpty()
                .WithMessage("Loan amount is required");

            RuleFor(w => w.DownPayment)
                .LessThanOrEqualTo(w => w.LoanAmount)
                .WithMessage("Down payment should be less than Loan amount");

            RuleFor(w => w.EMI)
                .NotEmpty()
                .WithMessage("EMI is required");

            RuleFor(w => w.InterestRateId)
                .NotEmpty()
                .WithMessage("Plese select interest rate");

            RuleFor(w => w.DurationId)
                .NotEmpty()
                .WithMessage("Plese select loan duration");

            RuleFor(w => w.StartDate)
                .NotEmpty()
                .WithMessage("Loan start date is required");

            RuleFor(w => w.EndDate)
                .NotEmpty()
                .WithMessage("Loan end date is required");

            //RuleFor(w => w.Guarantor1)
            //    .NotEmpty()
            //    .When(w => !w.Guarantor2.HasValue)
            //    .WithMessage("Please select guarantor");
        }
    }
}