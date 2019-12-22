using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.ViewModel
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Extension { get; set; }
        public string RelativePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}