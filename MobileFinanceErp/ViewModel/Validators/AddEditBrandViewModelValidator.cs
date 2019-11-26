using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditBrandViewModelValidator : AbstractValidator<AddEditBrandViewModel>
    {
        public AddEditBrandViewModelValidator()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage("Name is required");
            
        }
    }
}