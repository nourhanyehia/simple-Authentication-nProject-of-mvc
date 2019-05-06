using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.Lab2.AuthLab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
