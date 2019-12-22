using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models
{
    public class PictureModel : BaseEntity
    {
        public PictureModel()
        {
            CustomerImages = new List<CustomerModel>();
        }
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Extension { get; set; }
        public string RelativePath { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<CustomerModel> CustomerImages { get; set; }
    }
}