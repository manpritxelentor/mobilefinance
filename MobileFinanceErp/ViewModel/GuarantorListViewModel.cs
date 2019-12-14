using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    public class GuarantorListViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        public string Identification { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
    }
}