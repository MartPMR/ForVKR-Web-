using System.Web.Mvc;

namespace Library.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Books", action = "Index", id = UrlParameter.Optional }, new[] { "Library.Web.Admin.Controllers" }
            );
        }
    }
}