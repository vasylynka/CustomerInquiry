using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Core.Infrastructure.Common;
using Newtonsoft.Json;

namespace CustomerInquiry.Api.Infrastructure.ParameterBinding
{
    public class JsonSearchQueryModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType.GetInterfaces().All(x => x != typeof(ISearchModel)))
                return false;

            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (val == null)
                return false;

            if (!(val.RawValue is string rawValue))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }

            try
            {
                bindingContext.Model = DeserializeObject(rawValue, bindingContext.ModelType);
                return true;
            }
            catch (Exception)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to SearchModel");
                return false;
            }
        }

        private object DeserializeObject(string jsonValue, Type objectType)
        {
            return JsonConvert.DeserializeObject(jsonValue, objectType, JsonSerializeSettingsExtensions.GetDefaultSettings());
        }
    }

    public class SearchQuery : ModelBinderAttribute
    {
        public SearchQuery() : base(typeof(JsonSearchQueryModelBinder)) { }
    }
}
