using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditGuarantorViewModelValidator))]
    public class AddEditGuarantorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? CityId { get; set; }
        public string Pincode { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string WhatsappNumber { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public bool IsPopup { get; internal set; }
    }
}