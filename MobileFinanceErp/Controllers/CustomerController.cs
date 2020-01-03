using MobileFinanceErp.Attributes;
using MobileFinanceErp.Service;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        [BindCommandParameter("SaveAndRedirect", "isSaveContinue")]
        public ActionResult Create(bool isSaveContinue, AddEditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            var insertResult = _customerService.Insert(model);
            if (insertResult.Item1)
                AddMessage("Customer added successfully");
            return Json(new { Status = insertResult.Item1, IsSaveContinue = isSaveContinue, Id = insertResult.Item2 });
        }

        public ActionResult Edit(int id)
        {
            AddEditCustomerViewModel model = _customerService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [BindCommandParameter("SaveAndRedirect", "isSaveContinue")]
        public ActionResult Edit(bool isSaveContinue, AddEditCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { Status = false, Error = ModelState });

            bool isSuccess = _customerService.Update(model);
            if (isSuccess)
                AddMessage("Customer updated successfully");
            return Json(new { Status = isSuccess, IsSaveContinue = isSaveContinue, Id = model.Id });
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

        [HttpPost]
        public ActionResult UploadImage()
        {
            string _imgname = string.Empty;
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                    if (pic.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(pic.FileName);
                        string _ext = Path.GetExtension(pic.FileName);
                        string validExtension = @"^.*\.(jpg|JPG|png|PNG|JPEG|jpeg)$";
                        if (Regex.Match(_ext.TrimEnd('.'), validExtension).Success)
                        {
                            _imgname = Guid.NewGuid().ToString();
                            string _comPath = Server.MapPath("/ProfilePicture/") + _imgname + _ext;

                            // Saving Image in Original Mode
                            pic.SaveAs(_comPath);
                            string imagePath = "/ProfilePicture/" + _imgname + _ext;
                            return Json(imagePath, JsonRequestBehavior.AllowGet);
                        }
                        else
                            return Json("Invalid Image", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch(Exception ex)
            {
                //Log Exception
            }
            return Json("Failed to save image", JsonRequestBehavior.AllowGet);
        }
    }
}