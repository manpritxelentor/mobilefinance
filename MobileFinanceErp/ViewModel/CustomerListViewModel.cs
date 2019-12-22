using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    public class CustomerListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Customer Identification Number")]
        public string CustomerIdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string AdhaarNumber { get; set; }
    }
}