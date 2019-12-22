using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class UploadController : BaseController
    {
        private readonly IPictureService _pictureService;
        public UploadController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost]
        public ActionResult Upload()
        {


            return Json(new { });
        }
    }
}