using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Filters;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem2.Controllers
{
    [AuthenticationFilter]
    public class DoctorsController : BaseController<Doctor, DoctorRepository, FilterVM, IndexVM, EditVM>
    {
        private static HospitalSystemDbContext context = new HospitalSystemDbContext();
        DoctorRepository repo = new DoctorRepository(context);
        public ActionResult Specialization(int id)
        {
            SpecializationVM model = new SpecializationVM();
            model.doctor = repo.GetById(id);

            model.specialization = repo.GetSpecializationsByDoctorId(id);
            context.SaveChanges();

            return View(model);

        }
        
    }
}