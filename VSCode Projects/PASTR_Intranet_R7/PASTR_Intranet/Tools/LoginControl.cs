using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PASTR_Intranet.Tools
{
    public class LoginControl : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Int32 rolid = Convert.ToInt32(httpContext.User.Identity.Name);

            return base.AuthorizeCore(httpContext);
        }
    }
}