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
    public static class KendoNumericTextBoxHelper
    {
        public static KendoNumericTextBoxBuilder KendoNumericTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            string id = htmlHelper.IdFor(expression).ToString();
            string value = htmlHelper.DisplayFor(expression).ToString();
            string html = htmlHelper.TextBoxFor(expression, htmlAttributes).ToString();
            return new KendoNumericTextBoxBuilder(id, html, value);
        }
    }

    public class KendoNumericTextBoxBuilder
    {
        private readonly string _controlHtml;
        private readonly string _controlName;
        private readonly string _controlValue;
        private string _format = "n2";
        private int _minValue = default(int);
        private int _maxValue = int.MaxValue;
        private string _changeEventHandler;

        public KendoNumericTextBoxBuilder(string name, string createdHtml, string value)
        {
            _controlHtml = createdHtml;
            _controlName = name;
            _controlValue = value;
        }

        public KendoNumericTextBoxBuilder Format(string format)
        {
            _format = format;
            return this;
        }

        public KendoNumericTextBoxBuilder Min(int minValue)
        {
            _minValue = minValue;
            return this;
        }

        public KendoNumericTextBoxBuilder Max(int maxValue)
        {
            _maxValue = maxValue;
            return this;
        }

        public KendoNumericTextBoxBuilder OnChange(string changeEventHandler)
        {
            _changeEventHandler = changeEventHandler;
            return this;
        }

        public MvcHtmlString Render()
        {
            StringBuilder controlBuilder = new StringBuilder(_controlHtml);
            controlBuilder.AppendLine("<script>");
            controlBuilder.AppendLine("$('#" + _controlName + "').kendoNumericTextBox({");

            if (!string.IsNullOrEmpty(_format))
            {
                controlBuilder.AppendLine($"format: '{_format}',");
            }

            controlBuilder.AppendLine($"min: {_minValue},");
            controlBuilder.AppendLine($"max: {_maxValue},");
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