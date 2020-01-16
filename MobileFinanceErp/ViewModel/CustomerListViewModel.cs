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

        [DisplayName("CIN")]
        public string CustomerIdentificationNumber { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        
        [DisplayName("Last Name")]
        public string Surname { get; set; }
        
        public string City { get; set; }
        public string Mobile1 { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
    }
}