using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Attributes
{
    public class BindCommandParameterAttribute : FilterAttribute, IActionFilter
    {
        private readonly string _name;
        private readonly string _actionParameterName;

        public BindCommandParameterAttribute(string name, string actionParameterName)
        {
            _name = name;
            _actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.ActionParameters[_actionParameterName] = filterContext.RequestContext.HttpContext.Request.Form.AllKeys.Contains(_name);
        }
    }
}