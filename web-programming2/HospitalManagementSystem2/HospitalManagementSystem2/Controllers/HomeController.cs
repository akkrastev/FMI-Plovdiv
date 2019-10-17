using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Models;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalManagementSystem2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.AccountType.ToString() == "Doctor")
            {
                DoctorRepository repo = new DoctorRepository();
                AuthenticationManager.AuthenticateDoctor(model.Username, model.Password);
            }
            else
            {
                PatientRepository repo = new PatientRepository();
                AuthenticationManager.AuthenticatePatient(model.Username, model.Password);
            }

            if (AuthenticationManager.LoggedDoctor == null && AuthenticationManager.LoggedPatient==null)
                ModelState.AddModelError("AuthenticationFailed", "Authentication failed!");

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            if(model.AccountType.ToString() == "Doctor")
            {
                DoctorRepository repo = new DoctorRepository();
                if(repo.GetAll().FirstOrDefault(m => m.Username == model.Username) != null)
                {
                    ModelState.AddModelError("RegistrationFailed", "Username already exists");
                    return View(model);
                }
                Doctor item = new Doctor();
                item.Username = model.Username;
                item.Password = model.Password;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.AccountType = model.AccountType.ToString();
                repo.Insert(item);
            }
            else
            {
                PatientRepository repo = new PatientRepository();
                Patient item = new Patient();
                item.Username = model.Username;
                item.Password = model.Password;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.AccountType = model.AccountType.ToString();
                repo.Insert(item);
            }
            return RedirectToAction("Index", "Home");
        }

        
    }
}