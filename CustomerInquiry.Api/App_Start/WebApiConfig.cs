using System.Web.Http;
using CustomerInquiry.Api.Infrastructure;

namespace CustomerInquiry.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.UseJsonCamelCaseResolver();
        }
    }
}
