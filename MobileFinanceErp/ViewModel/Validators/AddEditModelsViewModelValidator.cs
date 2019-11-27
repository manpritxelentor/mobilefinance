using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.ViewModel.Validators
{
    public class AddEditModelsViewModelValidator : AbstractValidator<AddEditModelsViewModel>
    {
        public AddEditModelsViewModelValidator()
        {
            RuleFor(w => w.BrandId)
               .NotEmpty()
               .WithMessage("Brand is required.");

            RuleFor(w => w.Name)
                .NotEmpty()
                .WithMessage("Name is required.");


        }
    }
}
