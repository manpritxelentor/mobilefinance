using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditBrandViewModelValidator))]
    public class AddEditBrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPopup { get; set; }
    }
}