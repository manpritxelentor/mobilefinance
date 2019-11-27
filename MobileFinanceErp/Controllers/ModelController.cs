using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class ModelController : BaseController
    {
        private readonly IModelsService _modelsService;

        public ModelController(IModelsService modelsService)
        {
            _modelsService = modelsService;
        }
        // GET: Models
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetModels(DataSourceRequest dataSourceRequest)
        {
            var data = _modelsService.GetAll(dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            AddEditModelsViewModel model = new AddEditModelsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddEditModelsViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _modelsService.Insert(model);
            if (isSuccess)
                AddMessage("Model added successfully");
            return Json(new { Status = isSuccess });
        }

        public ActionResult Edit(int id)
        {
            AddEditModelsViewModel model = _modelsService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddEditModelsViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _modelsService.Update(model);
            if (isSuccess)
                AddMessage("Model updated successfully");
            return Json(new { Status = isSuccess });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _modelsService.Delete(id);
            return Json(new { Status = isSuccess, Message = "Model deleted successfully" });
        }
    }
}