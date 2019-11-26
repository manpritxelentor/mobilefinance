using System;
using System.Collections.Generic;
using System.Text;

namespace MobileFinanceErp.ViewModel
{
    public class DataSourceResult
    {
        public object data { get; set; }
        public int draw { get; set; }
        public int recordsFiltered { get; set; }
        public int recordsTotal { get; set; }
    }
}
