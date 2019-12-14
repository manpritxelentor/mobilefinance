using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MobileFinanceErp.Helpers
{
    public static class RequiredLabelHelper
    {
        public static MvcHtmlString RequiredLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string labelHtml = html.LabelFor(expression).ToString();

            TagBuilder builder = new TagBuilder("span");
            builder.AddCssClass("required-label");
            builder.SetInnerText("*");

            return new MvcHtmlString(labelHtml + builder.ToString());
        }
    }
}