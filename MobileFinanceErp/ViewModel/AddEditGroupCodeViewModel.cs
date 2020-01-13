using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System.ComponentModel;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditGroupCodeViewModelValidator))]
    public class AddEditGroupCodeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Name")]
        public string DisplayName { get; set; }
    }
}