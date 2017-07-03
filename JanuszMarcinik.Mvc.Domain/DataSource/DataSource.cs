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
        public IEnumerable<TModel> Model { get; set; }

        public GridSortOrder SortOrder { get; set; } = GridSortOrder.ASC;
        public string OrderBy { get; set; }

        private GridModel GridModel { get; set; }

        private List<CustomPropertyInfo> Properties { get; set; }
        private List<GridRow> Rows { get; set; }

        protected ActionResult AddAction { get; set; }
        protected ActionResult BackAction { get; set; }
        protected ActionResult ListAction { get; set; }

        protected string PrimaryKeyName { get; set; } = "id";
        protected Task<ActionResult> EditAction { get; set; }

        protected string Title { get; set; }

        #region Initialize()
        public virtual void Initialize()
        {
            if (this.Model == null)
            {
                this.Model = new List<TModel>();
            }

            this.Properties = new List<CustomPropertyInfo>();
            if (this.Model.Count() > 0)
            {
                SetProperties(this.Model.First().GetType().GetProperties());
            }

            if (!string.IsNullOrEmpty(this.OrderBy))
            {
                this.Properties.SetSorting(this.OrderBy, this.SortOrder);
                if (this.SortOrder == GridSortOrder.ASC)
                {
                    this.Model = this.Model.OrderBy(x => x.GetType().GetProperty(this.OrderBy).GetValue(x, null));
                }
                else
                {
                    this.Model = this.Model.OrderByDescending(x => x.GetType().GetProperty(this.OrderBy).GetValue(x, null));
                }
            }

            SetRows(this.Model);

            if (this.EditAction != null)
            {
                foreach (var row in this.Rows)
                {
                    row.PrimaryKeyName = this.PrimaryKeyName;
                    row.EditActionAsync = this.EditAction;
                }
            }

            this.GridModel = new GridModel()
            {
                AddAction = this.AddAction,
                BackAction = this.BackAction,
                ListAction = this.ListAction,
                Properties = this.Properties,
                Rows = this.Rows,
                Title = this.Title
            };
        }
        #endregion

        #region SetProperties()
        private void SetProperties(PropertyInfo[] properties)
        {
            this.Properties = new List<CustomPropertyInfo>();

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
            this.Rows = new List<GridRow>();

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

        #region GetGridModel()
        public GridModel GetGridModel()
        {
            if (this.GridModel == null)
            {
                throw new Exception("Grid model was not initialized. Run Initialize() method after DataSource invoked.");
            }
            else
            {
                return this.GridModel;
            }
        }
        #endregion
    }
}