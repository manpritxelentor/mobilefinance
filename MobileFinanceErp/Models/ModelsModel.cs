using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.Models
{
    public class ModelsModel : BaseAuditableEntity
    {
        public ModelsModel()
        {
            Finances = new List<FinanceModel>();
        }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual BrandModel Brand { get; set; }
        public virtual ICollection<FinanceModel> Finances { get; set; }
    }
}
