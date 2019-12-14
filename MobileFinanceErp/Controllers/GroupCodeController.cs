using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class GroupCodeController : Controller
    {
        private readonly IGroupCodeService _groupCodeService;
        public GroupCodeController(IGroupCodeService groupCodeService)
        {
            _groupCodeService = groupCodeService;
        }
        
        [HttpPost]
        public ActionResult GetAll(string codeName)
        {
            return Json(_groupCodeService.GetAll(codeName), JsonRequestBehavior.AllowGet);
        }
    }
}