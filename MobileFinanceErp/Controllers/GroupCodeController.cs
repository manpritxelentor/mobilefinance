using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System.Web.Mvc;

namespace MobileFinanceErp.Controllers
{
    public class GroupCodeController : BaseController
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

        [HttpPost]
        public ActionResult CreateGroupCode(string code)
        {
            var model = new AddEditGroupCodeViewModel { Name = code };
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveGroupCode(AddEditGroupCodeViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = false;
            if (model.Id > 0)
            {
                // Update logic
                isSuccess = _groupCodeService.Update(model);
            }
            else
            {
                // Insert logic
                isSuccess = _groupCodeService.Insert(model);
            }
            return Json(new { Status = isSuccess });
        }

        [HttpPost]
        public ActionResult GetGroupCodeData(string code, DataSourceRequest dataSourceRequest)
        {
            DataSourceResult data = _groupCodeService.GetAll(code, dataSourceRequest);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}