using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MobileFinanceErp.Helpers
{
    public static class KendoDatePickerHelper
    {
        public static KendoDatePickerBuilder KendoDatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            string id = htmlHelper.IdFor(expression).ToString();
            string value = htmlHelper.DisplayFor(expression).ToString();
            string html = htmlHelper.TextBoxFor(expression, htmlAttributes).ToString();
            return new KendoDatePickerBuilder(id, html, value);
        }
    }

    public class KendoDatePickerBuilder
    {
        private readonly string _controlHtml;
        private readonly string _controlName;
        private readonly string _controlValue;
        private string _dateFormat = "dd-MMM-yyyy";
        private string _changeEventHandler;

        public KendoDatePickerBuilder(string name, string createdHtml, string value)
        {
            _controlHtml = createdHtml;
            _controlName = name;
            _controlValue = value;
        }

        public KendoDatePickerBuilder Format(string dateFormat)
        {
            _dateFormat = dateFormat;
            return this;
        }

        public KendoDatePickerBuilder OnChange(string changeEventHandler)
        {
            _changeEventHandler = changeEventHandler;
            return this;
        }

        public MvcHtmlString Render()
        {
            StringBuilder controlBuilder = new StringBuilder(_controlHtml);
            controlBuilder.AppendLine("<script>");
            controlBuilder.AppendLine("$('#" + _controlName + "').kendoDatePicker({");

            if (!string.IsNullOrEmpty(_dateFormat))
            {
                controlBuilder.AppendLine($"format: '{_dateFormat}',");
            }

            if (!string.IsNullOrEmpty(_changeEventHandler))
            {
                controlBuilder.AppendLine($"change: {_changeEventHandler},");
            }

            controlBuilder.AppendLine("})");
            controlBuilder.AppendLine("</script>");

            return new MvcHtmlString(controlBuilder.ToString());
        }
    }
}