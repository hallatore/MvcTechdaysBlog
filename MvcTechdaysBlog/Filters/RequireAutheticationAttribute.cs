using System.Web.Mvc;

namespace MvcTechdaysBlog.Filters
{
    public class RequireAutheticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                                    filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                        typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}