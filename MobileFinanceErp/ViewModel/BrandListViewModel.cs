using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    public class BrandListViewModel 
    {
        public int Id { get; set; }

        [DisplayName("Brand Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}