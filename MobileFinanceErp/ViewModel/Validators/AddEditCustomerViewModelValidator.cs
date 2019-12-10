using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditCustomerViewModelValidator : AbstractValidator<AddEditCustomerViewModel>
    {
        public AddEditCustomerViewModelValidator()
        {
            RuleFor(w => w.CustomerIdentificationNumber)
                .NotEmpty()
                .WithMessage("Customer identification number is required");

            RuleFor(w => w.FirstName)
                .NotEmpty()
                .WithMessage("Customer name is required");
        }
    }
}