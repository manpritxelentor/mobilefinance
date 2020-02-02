using MobileFinanceErp.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    [LogCustomExceptionFilter]
    [Authorize]
    public class BaseController : Controller
    {
        public void AddMessage(string message)
        {
            TempData["PageLevelMessage"] = message;
        }

        public List<string> GetModelErrors()
        {
            List<string> result = new List<string>();
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    result.Add(error.ErrorMessage);
                }
            }
            return result;
        }
    }
}