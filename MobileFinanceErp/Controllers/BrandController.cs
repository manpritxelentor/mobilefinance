using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBrands(DataSourceRequest dataSourceRequest)
        {
            var data = _brandService.GetAll(dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            AddEditBrandViewModel model = new AddEditBrandViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddEditBrandViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _brandService.Insert(model);
            if (isSuccess)
                AddMessage("Brand added successfully");
            return Json(new { Status = isSuccess });
        }

        public ActionResult Edit(int id)
        {
            AddEditBrandViewModel model = _brandService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddEditBrandViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _brandService.Update(model);
            if (isSuccess)
                AddMessage("Brand updated successfully");
            return Json(new { Status = isSuccess });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _brandService.Delete(id);
            return Json(new { Status = isSuccess, Message = "Brand deleted successfully" });
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            return Json(_brandService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}