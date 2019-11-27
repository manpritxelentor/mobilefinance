using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.ViewModel
{
    public class ModelsListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Brand Name")]
        public int BrandId { get; set; }

        [DisplayName("Model Name")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
