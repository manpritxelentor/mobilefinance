using MobileFinanceErp.Attributes;
using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class FinanceController : BaseController
    {
        private readonly IFinanceService _FinanceService;
        private readonly IGroupCodeService _groupCodeService;
        private readonly IIdentityHelper _identityHelper;

        public FinanceController(IFinanceService FinanceService
            , IGroupCodeService groupCodeService
            , IIdentityHelper identityHelper)
        {
            _FinanceService = FinanceService;
            _groupCodeService = groupCodeService;
            _identityHelper = identityHelper;
        }

        // GET: Finance
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetFinances(DataSourceRequest dataSourceRequest)
        {
            var data = _FinanceService.GetAll(dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int customerId = 0)
        {
            AddEditFinanceViewModel model = new AddEditFinanceViewModel()
            {
                CustomerId = customerId
            };
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            EditFinanceViewModel model = _FinanceService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditFinanceViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = GetModelErrors() });

            bool isPageNumberValid = _FinanceService.IsPageNumberValid(model.PageNo, model.BookNo, model.Id);
            if (!isPageNumberValid)
            {
                ModelState.AddModelError("PageNo", "Book Number & Page Number must be unique. Please enter another number.");
                return Json(new { Status = false, Error = GetModelErrors() });
            }
            
            var insertResult = _FinanceService.Update(model);
            if (insertResult)
                AddMessage("Finance saved successfully");
            return Json(new { Status = insertResult });
        }

        [HttpPost]
        public ActionResult Create(AddEditFinanceViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = GetModelErrors() });

            bool isPageNumberValid = _FinanceService.IsPageNumberValid(model.PageNo, model.BookNo);
            if (!isPageNumberValid)
            {
                ModelState.AddModelError("PageNo", "Book Number & Page Number must be unique. Please enter another number.");
                return Json(new { Status = false, Error = GetModelErrors() });
            }

            model.EMI = GetEmiCalculation(model.LoanAmount, model.Duration);

            var insertResult = _FinanceService.Insert(model);
            if (insertResult.Item1)
                AddMessage("Finance added successfully");
            return Json(new { Status = insertResult.Item1, Id = insertResult.Item2 });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _FinanceService.Delete(id);
            return Json(new { Status = isSuccess, Message = "Finance deleted successfully" });
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            return Json(_FinanceService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReceivePayment(int financeId)
        {
            ReceiveFinanceViewModel model = _FinanceService.GetReceiveModel(financeId);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveReceiveAmount(ReceiveFinanceViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isReceived = _FinanceService.ReceiveAmount(model, _identityHelper.UserId);
            return Json(new { Status = isReceived });
        }

        [HttpPost]
        public ActionResult FinanceDetails(int financeId)
        {
            List<ReceiveFinanceViewModel> data = _FinanceService.GetFinanceDetails(financeId);
            return Json(data);
        }

        private decimal GetEmiCalculation(decimal? loanAmount, int? duration)
        {
            decimal result = 0;
            if (loanAmount.HasValue && duration.HasValue)
            {
                result = loanAmount.Value / duration.Value;
            }
            return Math.Ceiling(result);
        }
    }
}