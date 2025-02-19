﻿using FluentValidation.Attributes;
using MobileFinanceErp.ViewModel.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    [Validator(typeof(AddEditCustomerViewModelValidator))]
    public class AddEditCustomerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer Identification Number")]
        public string CustomerIdentificationNumber { get; set; }
        public string PhotoUrl { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        public string Surname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [DisplayName("City")]
        public int? CityId { get; set; }

        public string Pincode { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public bool IsMobile1Whatsapp { get; set; }
        public bool IsMobile2Whatsapp { get; set; }

        [DisplayName("Adhaar Number")]
        public string AdhaarNumber { get; set; }
        public string CustomerPhotoPath { get; set; }
    }
}