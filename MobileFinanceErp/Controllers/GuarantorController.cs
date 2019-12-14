using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class GuarantorController : BaseController
    {
        private readonly IGuarantorService _guarantorService;

        public GuarantorController(IGuarantorService guarantorService)
        {
            _guarantorService = guarantorService;
        }

        // GET: Guarantor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetGuarantors(DataSourceRequest dataSourceRequest)
        {
            var data = _guarantorService.GetAll(dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            AddEditGuarantorViewModel model = new AddEditGuarantorViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddEditGuarantorViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _guarantorService.Insert(model);
            if (isSuccess)
                AddMessage("Guarantor added successfully");
            return Json(new { Status = isSuccess });
        }

        public ActionResult Edit(int id)
        {
            AddEditGuarantorViewModel model = _guarantorService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddEditGuarantorViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _guarantorService.Update(model);
            if (isSuccess)
                AddMessage("Guarantor updated successfully");
            return Json(new { Status = isSuccess });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _guarantorService.Delete(id);
            return Json(new { Status = isSuccess, Message = "Guarantor deleted successfully" });
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            return Json(_guarantorService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}