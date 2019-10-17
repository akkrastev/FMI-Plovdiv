using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Filters;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem2.Controllers
{
    [AuthenticationFilter]
    public class PatientsController : BaseController<Patient, PatientRepository, FilterVM, IndexVM, EditVM>
    {
        private static HospitalSystemDbContext context = new HospitalSystemDbContext();
        PatientRepository repo = new PatientRepository(context);
        public ActionResult Medicines(int id)
        {
            MedicineVM model = new MedicineVM();
            model.patient = repo.GetById(id);

            model.medicine = repo.GetMedicineByPatientId(id);
            context.SaveChanges();

            return View(model);

        }
    }
}