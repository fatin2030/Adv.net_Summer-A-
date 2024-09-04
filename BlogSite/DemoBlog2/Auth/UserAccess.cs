using DemoBlog2.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBlog2.Auth
{
//    public class Customer : AuthorizeAttribute
//    {
//        public override bool AuthorizeCore(HttpContextBase httpContext)
//        {
//            var user = (User)httpContext.Session["user"];
//            if (user != null && user.Type.Equals("user"))
//            {
//                return true;
//            }
//            return false;
//        }


//    }
//}


public class UserAccess : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var user = (User)httpContext.Session["user"];
        if (user != null && user.Type.Equals("user"))
        {
            return true;
        }
        return false;
    }
}
}