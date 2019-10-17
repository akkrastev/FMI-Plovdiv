using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem2.Models;

namespace HospitalManagementSystem2.Filters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Models.AuthenticationManager.LoggedDoctor == null && Models.AuthenticationManager.LoggedPatient==null)
                filterContext.Result = new RedirectResult("/Home/Login");
        }
    }
}