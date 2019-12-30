using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditGuarantorViewModelValidator : AbstractValidator<AddEditGuarantorViewModel>
    {
        public AddEditGuarantorViewModelValidator()
        {
            RuleFor(w => w.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(w => w.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required");

            RuleFor(w => w.Address1)
                .NotEmpty()
                .WithMessage("Address line 1 is required");

            RuleFor(w => w.Address2)
                .NotEmpty()
                .WithMessage("Address line 2 is required");

            RuleFor(w => w.City)
               .NotEmpty()
               .WithMessage("City is required");

            RuleFor(w => w.Mobile1)
                .NotEmpty()
                .WithMessage("Mobile-1 is required");
        }
    }
}