using MobileFinanceErp.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    [LogCustomExceptionFilter]
    public class BaseController : Controller
    {
        public void AddMessage(string message)
        {
            TempData["PageLevelMessage"] = message;
        }
    }
}