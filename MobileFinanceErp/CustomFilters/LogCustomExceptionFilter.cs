using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.CustomFilters
{
    public class LogCustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {

                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var actionName = filterContext.RouteData.Values["action"].ToString();

                string message = "Error occurred in Controller: " + controllerName + " and Action:" + actionName + " on Date :" + DateTime.Now.ToString();

                Logger _logger = LogManager.GetLogger(controllerName);
                
                _logger.Error(filterContext.Exception, message);

                if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { Status = false, Message = "Something went wrong." }
                    };
                    filterContext.ExceptionHandled = true;
                }
                else
                {
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Error"
                    };
                }
            }
        }
    }
}