using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.Models
{
    public class TenantModel : BaseEntity
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string LogoPath { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
