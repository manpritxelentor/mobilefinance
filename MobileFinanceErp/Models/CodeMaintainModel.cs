using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models
{
    public class CodeMaintainModel : BaseAuditableEntity
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public int LastNumber { get; set; }
        public string Prefix { get; set; }
        public string Separator { get; set; }
        public int Padding { get; set; }
    }
}