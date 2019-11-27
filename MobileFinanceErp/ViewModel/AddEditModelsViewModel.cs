using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditModelsViewModelValidator))]
    public class AddEditModelsViewModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BrandName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
