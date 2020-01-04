using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IIdentityHelper _identityHelper;
        private readonly ICustomerService _customerService;
        private readonly IFinanceService _financeService;

        public HomeController(IIdentityHelper identityHelper
            , ICustomerService customerService
            , IFinanceService financeService)
        {
            _identityHelper = identityHelper;
            _customerService = customerService;
            _financeService = financeService;
        }
        public ActionResult Index()
        {

            ViewBag.CustomerCount = _customerService.GetCustomerCount();
            decimal collectedAmount = _financeService.GetMonthCollectedAmount(DateTime.Now.Month, DateTime.Now.Year);
            decimal totalAmount = _financeService.GetMonthTotalAmount(DateTime.Now.Month, DateTime.Now.Year);
            decimal pendingAmount = totalAmount - collectedAmount;
            //CultureInfo ci = new CultureInfo("en-IN");
            //ci.NumberFormat.CurrencySymbol = "₹";


            ViewBag.CollectedAmount = collectedAmount;
            ViewBag.PendingAmount = pendingAmount;
            ViewBag.TotalAmount =  totalAmount;

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