using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IIdentityHelper _identityHelper;

        public HomeController(IIdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}