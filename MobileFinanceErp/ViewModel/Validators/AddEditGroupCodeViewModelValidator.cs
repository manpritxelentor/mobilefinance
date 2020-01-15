using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditGroupCodeViewModelValidator : AbstractValidator<AddEditGroupCodeViewModel>
    {
        public AddEditGroupCodeViewModelValidator()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage("Name (Code) is required");

            RuleFor(w => w.DisplayName)
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}