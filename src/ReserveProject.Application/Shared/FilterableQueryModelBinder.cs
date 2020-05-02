using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using ReserveProject.Shared.PagingAndFilter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ReserveProject.Application.Shared
{
    public class FilterableQueryModelBinder<T> : IModelBinder where T : IPagedQuery, IFilterable, ISortable, new()
    {
        public System.Threading.Tasks.Task BindModelAsync(ModelBindingContext bindingContext)
        {
            List<SortItem> Items = new List<SortItem>()
            {
              new SortItem()
              {
                  Desc =true,
                  SortBy = "name"
              }
            };
            var jsonString = JsonConvert.SerializeObject(Items);


            var model = new T();

            var page = bindingContext.ValueProvider.GetValue("Page");
            var pageSize = bindingContext.ValueProvider.GetValue("PageSize");

            foreach (var item in bindingContext.HttpContext.Request.Query)
            {
                var property = model.GetType().GetProperties().FirstOrDefault(x => x.Name.ToLower() == item.Key.ToLower());
                if (property != null)
                {
                    var propertyType = property.PropertyType;
                    var value = item.Value.First();
                    if (value != null && value != "null")
                    {
                        try
                        {
                            TypeConverter typeConverter = TypeDescriptor.GetConverter(propertyType);
                            object propValue = typeConverter.ConvertFromString(value);
                            property.SetValue(model, propValue);
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }
                }
            }


            model.FilterModel = new FilterModel()
            {
                Json = bindingContext.ValueProvider.GetValue("FilterModel.Json").FirstValue
            };

            model.SortModel = new SortModel()
            {
                Json = bindingContext.ValueProvider.GetValue("SortModel.Json").FirstValue
            };

            model.Page = page.FirstValue == null ? null : (int?)Convert.ToInt32(page.FirstValue);
            model.PageSize = pageSize.FirstValue == null ? null : (int?)Convert.ToInt32(pageSize.FirstValue);

            bindingContext.Result = ModelBindingResult.Success(model);
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
