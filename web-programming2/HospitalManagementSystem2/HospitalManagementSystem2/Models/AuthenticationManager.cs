using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagementSystem2.Services;

namespace HospitalManagementSystem2.Models
{
    public static class AuthenticationManager
    {
        public static Doctor LoggedDoctor
        {
            get
            {
                AuthenticationService authenticationService = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedDoctor"] == null)
                    HttpContext.Current.Session["LoggedDoctor"] = new AuthenticationService();

                authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedDoctor"];
                return authenticationService.LoggedDoctor;
            }
        }
        public static Patient LoggedPatient
        {
            get
            {
                AuthenticationService authenticationService = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedPatient"] == null)
                    HttpContext.Current.Session["LoggedPatient"] = new AuthenticationService();

                authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedPatient"];
                return authenticationService.LoggedPatient;
            }
        }

        public static void AuthenticateDoctor(string username, string password)
        {
            AuthenticationService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedDoctor"] == null)
                HttpContext.Current.Session["LoggedDoctor"] = new AuthenticationService();

            authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedDoctor"];
            authenticationService.AuthenticateDoctor(username, password);
        }
        public static void AuthenticatePatient(string username, string password)
        {
            AuthenticationService authenticationService = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedPatient"] == null)
                HttpContext.Current.Session["LoggedPatient"] = new AuthenticationService();

            authenticationService = (AuthenticationService)HttpContext.Current.Session["LoggedPatient"];
            authenticationService.AuthenticatePatient(username, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedDoctor"] = null;
            HttpContext.Current.Session["LoggedPatient"] = null;

        }
    }
}