using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCustomers(DataSourceRequest dataSourceRequest)
        {
            var data = _customerService.GetAll(dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            AddEditCustomerViewModel model = new AddEditCustomerViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddEditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _customerService.Insert(model);
            if (isSuccess)
                AddMessage("Customer added successfully");
            return Json(new { Status = isSuccess });
        }

        public ActionResult Edit(int id)
        {
            AddEditCustomerViewModel model = _customerService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AddEditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _customerService.Update(model);
            if (isSuccess)
                AddMessage("Customer updated successfully");
            return Json(new { Status = isSuccess });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _customerService.Delete(id);
            return Json(new { Status = isSuccess, Message = "Customer deleted successfully" });
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            return Json(_customerService.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}