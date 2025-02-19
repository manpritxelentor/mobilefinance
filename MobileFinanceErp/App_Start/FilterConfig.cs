﻿using MobileFinanceErp.CustomFilters;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogCustomExceptionFilter());
        }
    }
}
