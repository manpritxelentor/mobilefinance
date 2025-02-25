﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MobileFinanceErp.Helpers
{
    public static class DataTableGrid
    {
        public static DataTableGridBuilder<T> DataTable<T>(this HtmlHelper htmlHelper)
        {
            return new DataTableGridBuilder<T>();
        }
    }

    public class DataTableGridBuilder<T>
    {
        private string _gridName;
        private string _readUrl;
        private string _cssClass;
        private int _pageLength = 100;
        private bool _searchable = true;
        private string _detailGridTemplate;
        private List<DataGridColumnDetail> _columns;
        private bool _scrollable = false;
        private string _scrollHeight; 

        public DataTableGridBuilder<T> Name(string name)
        {
            _gridName = name;
            return this;
        }

        public DataTableGridBuilder<T> Read(string readUrl)
        {
            _readUrl = readUrl;
            return this;
        }

        public DataTableGridBuilder<T> CssClass(string cssClass)
        {
            _cssClass = cssClass;
            return this;
        }

        public DataTableGridBuilder<T> Columns(Action<DataGridColumnBuilder<T>> columns)
        {
            DataGridColumnBuilder<T> param = new DataGridColumnBuilder<T>();
            columns(param);
            _columns = param.Columns;
            return this;
        }

        public DataTableGridBuilder<T> PageLength(int pageLength)
        {
            _pageLength = pageLength;
            return this;
        }

        public DataTableGridBuilder<T> Searchable(bool searchable)
        {
            _searchable = searchable;
            return this;
        }

        public DataTableGridBuilder<T> Scrollable(string scrollHeight)
        {
            _scrollable = true;
            _scrollHeight = scrollHeight;
            return this;
        }

        public DataTableGridBuilder<T> DetailTemplate(string detailGridTemplate)
        {
            _detailGridTemplate = detailGridTemplate;
            return this;
        }

        public MvcHtmlString Render()
        {
            TagBuilder tableBuilder = new TagBuilder("table");
            if (!string.IsNullOrEmpty(_cssClass))
                tableBuilder.AddCssClass(_cssClass);
            tableBuilder.Attributes.Add("id", _gridName);

            // Table Head
            StringBuilder headBuilder = new StringBuilder("<thead><tr>");

            if (!string.IsNullOrEmpty(_detailGridTemplate))
            {
                headBuilder.AppendLine("<th></th>");
            }

            foreach (var column in _columns)
            {
                headBuilder.AppendLine("<th>");
                headBuilder.AppendLine(column.DisplayName);
                headBuilder.AppendLine("</th>");
            }

            headBuilder.AppendLine("</tr></thead>");

            // Datatable script
            StringBuilder scriptBuilder = new StringBuilder("<script>");
            scriptBuilder.Append("$(document).ready(function () {");
            scriptBuilder.Append("$('#" + _gridName + "').DataTable({");

            if (!_searchable)
            {
                scriptBuilder.Append("'searching': false,");
            }

            if (_scrollable)
            {
                scriptBuilder.Append("'scrollCollapse': true,");
                scriptBuilder.Append($"'scrollY': '{_scrollHeight}',");
            }

            scriptBuilder.Append("'responsive': true,");
            scriptBuilder.Append("'processing': true,");
            scriptBuilder.Append("'serverSide': true,");
            scriptBuilder.Append("'pageLength': " + _pageLength + ",");

            scriptBuilder.Append("'columns': [");
            if (!string.IsNullOrEmpty(_detailGridTemplate))
            {
                _columns.Insert(0, new DataGridColumnDetail(Guid.NewGuid())
                {
                    ClassName = "details-control",
                    Orderable = false,
                    RemoveDefaultContent = true
                });
            }

            foreach (var column in _columns)
            {
                scriptBuilder.Append("{'data': " + (string.IsNullOrEmpty(column.ColumnName) ? "null" : "'" + column.ColumnName + "'"));

                if (string.IsNullOrEmpty(column.ColumnName) && string.IsNullOrEmpty(column.ClassName))
                {
                    column.Searchable = false;
                    column.Orderable = false;
                    scriptBuilder.Append(", 'className': 'center-content'");
                }
                if (!string.IsNullOrEmpty(column.ClassName))
                {
                    scriptBuilder.Append(", 'className': '" + column.ClassName + "'");
                }

                if (!column.Searchable)
                    scriptBuilder.Append(", 'searchable': false");
                if (!column.Orderable)
                    scriptBuilder.Append(", 'orderable': false");
                if (!string.IsNullOrEmpty(column.RenderCallback))
                    scriptBuilder.Append(", 'mRender': " + column.RenderCallback + "");
                if (column.IsDateFormat)
                {
                    scriptBuilder.Append(", 'format': 'M/D/YYYY'");
                    scriptBuilder.Append(", 'type': 'datetime'");
                }
                if(column.RemoveDefaultContent)
                    scriptBuilder.Append(", 'defaultContent': ''");

                scriptBuilder.Append("},");
            }

            scriptBuilder.Append("],");
            scriptBuilder.Append("'ajax':{'url': '" + _readUrl + "', 'type': 'POST'}");

            if (!string.IsNullOrEmpty(_detailGridTemplate))
                scriptBuilder.Append(", 'order': [[1, 'asc']]");

            scriptBuilder.Append("});");

            if (!string.IsNullOrEmpty(_detailGridTemplate))
            {
                scriptBuilder.Append("$('#" + _gridName + " tbody').on('click', 'td.details-control', " + _detailGridTemplate + ")");
            }

            scriptBuilder.Append("})");


            scriptBuilder.AppendLine("</script>");

            // Insert to table
            tableBuilder.InnerHtml = headBuilder.ToString();

            return new MvcHtmlString(tableBuilder.ToString() + scriptBuilder.ToString());
        }
    }


    public class DataGridColumnBuilder<T>
    {
        private Guid _uniqueId;

        public List<DataGridColumnDetail> Columns { get; set; }
        public DataGridColumnBuilder()
        {
            Columns = new List<DataGridColumnDetail>();
        }

        public DataGridColumnBuilder<T> Bound<TResult>(Expression<Func<T, TResult>> column)
        {
            var expression = (MemberExpression)column.Body;
            var member = expression.Member;
            string name = member.Name;
            _uniqueId = Guid.NewGuid();
            var columnObj = new DataGridColumnDetail(_uniqueId)
            {
                ColumnName = name
            };

            if (member.CustomAttributes.Count() > 0)
            {
                var displayNameAttr = member.GetCustomAttribute<DisplayNameAttribute>();
                if (displayNameAttr != null)
                {
                    columnObj.DisplayName = displayNameAttr.DisplayName;
                }
            }

            if (string.IsNullOrEmpty(columnObj.DisplayName))
            {
                columnObj.DisplayName = columnObj.ColumnName;
            }

            Columns.Add(columnObj);
            return this;
        }

        public DataGridColumnBuilder<T> Searchable(bool isSearchable)
        {
            var columnObj = GetByUniqueId(_uniqueId);
            columnObj.Searchable = isSearchable;
            return this;
        }

        public DataGridColumnBuilder<T> Orderable(bool isOrderable)
        {
            var columnObj = GetByUniqueId(_uniqueId);
            columnObj.Orderable = isOrderable;
            return this;
        }

        public DataGridColumnBuilder<T> RenderCallback(string renderCallback)
        {
            var columnObj = GetByUniqueId(_uniqueId);
            columnObj.RenderCallback = renderCallback;
            return this;
        }

        public DataGridColumnBuilder<T> Template()
        {
            _uniqueId = Guid.NewGuid();
            var columnObj = new DataGridColumnDetail(_uniqueId);
            Columns.Add(columnObj);
            return this;
        }

        public DataGridColumnBuilder<T> Title(string title)
        {
            var columnObj = GetByUniqueId(_uniqueId);
            columnObj.DisplayName = title;
            return this;
        }

        public DataGridColumnBuilder<T> DateFormat()
        {
            var columnObj = GetByUniqueId(_uniqueId);
            columnObj.IsDateFormat = true;
            return this;
        }

        private DataGridColumnDetail GetByUniqueId(Guid id)
        {
            return Columns.Single(w => w.UniqueId == id);
        }
    }

    public class DataGridColumnDetail
    {
        public DataGridColumnDetail(Guid uniqueId)
        {
            UniqueId = uniqueId;
        }
        public Guid UniqueId { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public bool IsDateFormat { get; set; }
        public bool Searchable { get; set; } = true;
        public bool Orderable { get; set; } = true;
        public string RenderCallback { get; set; }
        public string ClassName { get; set; }
        public bool RemoveDefaultContent { get; set; }
    }
}