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
    public static class KendoDropdownHelper
    {
        public static KendoDropdownBuilder KendoDropdownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            string id = htmlHelper.IdFor(expression).ToString();
            string value = htmlHelper.DisplayFor(expression).ToString();
            string html = htmlHelper.TextBoxFor(expression, htmlAttributes).ToString();
            return new KendoDropdownBuilder(id, html, value);
        }
    }

    public class KendoDropdownBuilder
    {
        private readonly string _controlHtml;
        private readonly string _controlName;
        private readonly string _controlValue;
        private string _dataTextField;
        private string _dataValueField;
        private string _readUrl;
        private string _readType;
        private bool _filterable = true;
        private string _optionLabel;
        private string _cascadeFrom;
        private string _changeEventHandler;
        private string _dataBoundEventHandler;

        public KendoDropdownBuilder(string name, string createdHtml, string value)
        {
            _controlHtml = createdHtml;
            _controlName = name;
            _controlValue = value;
        }

        public KendoDropdownBuilder DataTextField(string dataTextField)
        {
            _dataTextField = dataTextField;
            return this;
        }

        public KendoDropdownBuilder DataValueField(string dataValueField)
        {
            _dataValueField = dataValueField;
            return this;
        }

        public KendoDropdownBuilder OptionLabel(string optionLabel)
        {
            _optionLabel = optionLabel;
            return this;
        }

        public KendoDropdownBuilder CascadeFrom(string cascadeFrom)
        {
            _cascadeFrom = cascadeFrom;
            return this;
        }

        public KendoDropdownBuilder Read(string url)
        {
            _readUrl = url;
            _readType = "POST";
            return this;
        }

        public KendoDropdownBuilder Read(string url, string readType)
        {
            _readUrl = url;
            _readType = readType;
            return this;
        }

        public KendoDropdownBuilder Filterable(bool isEnabled)
        {
            _filterable = true;
            return this;
        }

        public KendoDropdownBuilder OnChange(string changeEventHandler)
        {
            _changeEventHandler = changeEventHandler;
            return this;
        }

        public KendoDropdownBuilder OnDataBound(string dataBoundEventHandler)
        {
            _dataBoundEventHandler = dataBoundEventHandler;
            return this;
        }

        public MvcHtmlString Render()
        {
            StringBuilder controlBuilder = new StringBuilder(_controlHtml);
            controlBuilder.AppendLine("<script>");
            controlBuilder.AppendLine("$('#" + _controlName + "').kendoDropDownList({");

            if (!string.IsNullOrEmpty(_dataTextField))
            {
                controlBuilder.AppendLine($"dataTextField: '{_dataTextField}',");
            }

            if (!string.IsNullOrEmpty(_dataValueField))
            {
                controlBuilder.AppendLine($"dataValueField: '{_dataValueField}',");
            }

            if (!string.IsNullOrEmpty(_controlValue))
            {
                controlBuilder.AppendLine($"value: '{_controlValue}',");
            }

            if (!string.IsNullOrEmpty(_cascadeFrom))
            {
                controlBuilder.AppendLine($"cascadeFrom: '{_cascadeFrom}',");
            }

            if (_filterable)
            {
                controlBuilder.AppendLine($"filter: 'contains',");
            }

            if (!string.IsNullOrEmpty(_optionLabel))
            {
                controlBuilder.AppendLine($"optionLabel: '{_optionLabel}',");
            }

            if (!string.IsNullOrEmpty(_changeEventHandler))
            {
                controlBuilder.AppendLine($"change: {_changeEventHandler},");
            }

            if (!string.IsNullOrEmpty(_changeEventHandler))
            {
                controlBuilder.AppendLine($"dataBound: {_dataBoundEventHandler},");
            }

            if (!string.IsNullOrEmpty(_readUrl))
            {
                controlBuilder.AppendLine("dataSource: { serverFiltering: false, transport: { read: {");
                controlBuilder.AppendLine($"url: '{_readUrl}',");
                controlBuilder.AppendLine($"type: '{_readType}',");
                controlBuilder.AppendLine("}}}");
            }

            controlBuilder.AppendLine("})");
            controlBuilder.AppendLine("</script>");

            return new MvcHtmlString(controlBuilder.ToString());
        }
    }
}