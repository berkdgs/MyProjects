using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace PASTR_Intranet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("tr-TR");
            FluentValidationModelValidatorProvider.Configure();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                Response.Redirect("Error/Page404");
            else
                Response.Redirect("~/Error/PageError");
        }

    }
}
