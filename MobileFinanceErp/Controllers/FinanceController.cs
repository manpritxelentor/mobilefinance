using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class FinanceController : BaseController
    {
        private readonly IFinanceService _FinanceService;
        private readonly IGroupCodeService _groupCodeService;

        public FinanceController(IFinanceService FinanceService
            , IGroupCodeService groupCodeService)
        {
            _FinanceService = FinanceService;
            _groupCodeService = groupCodeService;
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

        public ActionResult Create()
        {
            AddEditFinanceViewModel model = new AddEditFinanceViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddEditFinanceViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            model.EMI = GetEmiCalculation(model.LoanAmount, model.DownPayment, Convert.ToInt32(_groupCodeService.GetCode(model.DurationId)), Convert.ToInt32(_groupCodeService.GetCode(model.InterestRateId)));

            bool isSuccess = _FinanceService.Insert(model);
            if (isSuccess)
                AddMessage("Finance added successfully");
            return Json(new { Status = isSuccess });
        }

        //public ActionResult Edit(int id)
        //{
        //    AddEditFinanceViewModel model = _FinanceService.GetById(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(AddEditFinanceViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return Json(new { Status = false, Error = ModelState });

        //    bool isSuccess = _FinanceService.Update(model);
        //    if (isSuccess)
        //        AddMessage("Finance updated successfully");
        //    return Json(new { Status = isSuccess });
        //}

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
        public ActionResult CalculateEMI(decimal? loanAmount, decimal? downPayment, int? duration, int? interest)
        {
            decimal result = 0;
            result = GetEmiCalculation(loanAmount, downPayment, duration, interest);
            return Json(new { EMI = result }, JsonRequestBehavior.AllowGet);
        }

        private decimal GetEmiCalculation(decimal? loanAmount, decimal? downPayment, int? duration, int? interest)
        {
            decimal result = 0;
            if (loanAmount.HasValue && duration.HasValue && interest.HasValue)
            {
                decimal remainingLoanAmount = loanAmount.Value - downPayment.GetValueOrDefault();
                decimal interestAmount = (remainingLoanAmount * interest.Value) / 100;
                decimal totalLoanAmount = remainingLoanAmount + interestAmount;

                result = totalLoanAmount / duration.Value;
            }
            return result;
        }
    }
}