using System.Web;
using System.Web.Mvc;

namespace Vidlet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Global filters potentially for authorization
            filters.Add(new HandleErrorAttribute());

            //Requires Login for all actions unless AllowAnonymous attribute is used.
            filters.Add(new AuthorizeAttribute());

            //Cant access site from not HTTPS link
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
