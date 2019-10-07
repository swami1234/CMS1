using CMS1.Services.Security;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);

                newUser.Id = serializeModel.Id;
                newUser.UserName = serializeModel.UserName;
                newUser.Email = serializeModel.Email;
                newUser.Roles = serializeModel.Roles;

                HttpContext.Current.User = newUser;
            }
        }
    }
}
