﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditFinanceViewModelValidator : EditFinanceViewModelValidator<AddEditFinanceViewModel>
    {
        public AddEditFinanceViewModelValidator()
            : base()
        {
            RuleFor(w => w.CustomerId)
                .NotEmpty()
                .WithMessage("Please select customer");

            
            RuleFor(w => w.MobilePrice)
                .NotEmpty()
                .WithMessage("Mobile Price is required");

            RuleFor(w => w.LoanAmount)
                .NotEmpty()
                .WithMessage("Loan amount is required");

            //RuleFor(w => w.DownPayment)
            //    .LessThanOrEqualTo(w => w.LoanAmount)
            //    .WithMessage("Down payment should be less than Loan amount");


            RuleFor(w => w.DownPayment)
                .LessThanOrEqualTo(w => w.MobilePrice)
                .WithMessage("Down payment should be less than mobile price");

            RuleFor(w => w.EMI)
                .NotEmpty()
                .WithMessage("EMI is required");

            RuleFor(w => w.Duration)
                .NotEmpty()
                .WithMessage("Loan duration is required");

            RuleFor(w => w.StartDate)
                .NotEmpty()
                .WithMessage("Loan start date is required");

            
            //RuleFor(w => w.Guarantor1)
            //   .NotEmpty()
            //   .WithMessage("Guarantor-1 is required");
        }
    }

    public class EditFinanceViewModelValidator<T> : AbstractValidator<T>
        where T : EditFinanceViewModel
    {
        public EditFinanceViewModelValidator()
        {
            RuleFor(w => w.BookNo)
                .NotEmpty()
                .WithMessage("Book Number is required");

            RuleFor(w => w.PageNo)
                .NotEmpty()
                .WithMessage("Page Number is required");

            RuleFor(w => w.ModelId)
                .NotEmpty()
                .WithMessage("Plese select model");

            RuleFor(w => w.IMEI)
                .NotEmpty()
                .WithMessage("IMEI number is required");

        }
    }
}