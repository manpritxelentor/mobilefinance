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
                .WithMessage("Customer Name is required");

            RuleFor(w => w.AdhaarNumber)
                .NotEmpty()
                .WithMessage("Adhaar Number is required");

            RuleFor(w => w.Surname)
                .NotEmpty()
                .WithMessage("Customer Surname is required");

            RuleFor(w => w.Address1)
                .NotEmpty()
                .WithMessage("Address is required");


            RuleFor(w => w.CityId)
                .NotEmpty()
                .WithMessage("City is required");

            RuleFor(w => w.Mobile1)
                .NotEmpty()
                .WithMessage("Mobile Number is required");
        }
    }
}