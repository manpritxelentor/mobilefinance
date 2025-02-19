﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Models
{
    public class BrandModel : BaseAuditableEntity
    {
        public BrandModel()
        {
            Models = new List<ModelsModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ModelsModel> Models { get; set; }
    }
}