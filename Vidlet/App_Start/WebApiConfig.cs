using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vidlet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //WEB API Configuration
            //This is used to control API Routes && Also converts API JSON Properties to CamelCase
            //The conversion is done to help with Javascript / jquery use of JSON API Data.


            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
