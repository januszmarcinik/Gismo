using JanuszMarcinik.Mvc.Domain.DataSource.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.DataSource
{
    public abstract class DataSource<TModel> where TModel : class
    {
        #region DataSource()
        public DataSource()
        {
            this.UseAsyncActionMethods = true;
            this.Properties = new List<CustomPropertyInfo>();
            this.Rows = new List<GridRow>();
        }
        #endregion

        private List<CustomPropertyInfo> Properties { get; set; }
        private List<GridRow> Rows { get; set; }

        protected ActionResult AddAction { get; set; }
        protected ActionResult BackAction { get; set; }

        protected string Title { get; set; }

        protected bool UseAsyncActionMethods { get; set; }

        #region Initialize()
        public virtual void Initialize(IEnumerable<TModel> model)
        {
            if (model.Count() > 0)
            {
                SetProperties(model.First().GetType().GetProperties());
            }

            SetRows(model);
        }
        #endregion

        #region SetProperties()
        private void SetProperties(PropertyInfo[] properties)
        {
            foreach (var prop in properties)
            {
                var customProperty = new CustomPropertyInfo()
                {
                    DisplayName = prop.Name,
                    PropertyName = prop.Name
                };

                if (prop.Name == "Id")
                {
                    customProperty.IsPrimaryKey = true;
                    this.Properties.Add(customProperty);
                }
                else
                {
                    var gridAttribute = prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(GridAttribute));
                    if (gridAttribute != null)
                    {
                        var displayAttribute = prop.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DisplayAttribute));
                        if (displayAttribute != null)
                        {
                            customProperty.DisplayName = displayAttribute.NamedArguments.First().TypedValue.Value.ToString();
                        }

                        try
                        {
                            if ((bool)gridAttribute.NamedArguments.FirstOrDefault(x => x.MemberName == "IsImage").TypedValue.Value)
                            {
                                customProperty.IsImagePath = true;
                                customProperty.DisplayName = string.Empty;
                            }
                        }
                        catch
                        {
                            customProperty.IsImagePath = false;
                        }

                        this.Properties.Add(customProperty);
                    }
                }
            }

            if (properties.Count() > 1)
            {
                this.Properties = this.Properties.OrderBy(x => x.Order).ToList();
            }
        }
        #endregion

        #region SetRows()
        private void SetRows(IEnumerable<TModel> data)
        {
            foreach (var item in data)
            {
                var row = new GridRow();
                foreach (var prop in this.Properties)
                {
                    if (prop.IsPrimaryKey)
                    {
                        row.PrimaryKeyId = (int)item.GetType().GetProperty(prop.PropertyName).GetValue(item);
                    }
                    else if (prop.IsImagePath)
                    {
                        row.ImagePath = item.GetType().GetProperty(prop.PropertyName).GetValue(item).ToString();
                    }
                    else if (item.GetType().GetProperty(prop.PropertyName).GetValue(item).GetType().BaseType == typeof(Enum))
                    {
                        var enumValue = (Enum)item.GetType().GetProperty(prop.PropertyName).GetValue(item);
                        row.Values.Add(enumValue.GetDescription());
                    }
                    else
                    {
                        try
                        {
                            row.Values.Add(item.GetType().GetProperty(prop.PropertyName).GetValue(item).ToString());
                        }
                        catch
                        {
                            row.Values.Add(string.Empty);
                        }
                    }
                }

                this.Rows.Add(row);
            }
        }
        #endregion

        #region SetEditActions()
        protected void SetEditActions(Task<ActionResult> editAction, string primaryKeyName = "id")
        {
            foreach (var row in this.Rows)
            {
                row.PrimaryKeyName = primaryKeyName;
                row.EditActionAsync = editAction;
            }
        }
        #endregion

        #region GetGridModel()
        public GridModel GetGridModel()
        {
            return new GridModel()
            {
                AddAction = this.AddAction,
                BackAction = this.BackAction,
                Properties = this.Properties,
                Rows = this.Rows,
                Title = this.Title
            };
        }
        #endregion
    }
}