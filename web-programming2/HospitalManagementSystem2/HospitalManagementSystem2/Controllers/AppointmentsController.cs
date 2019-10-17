using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Filters;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.Appointments;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem2.Controllers
{
    [AuthenticationFilter]
    public class AppointmentsController : Controller
    {
        DoctorRepository doctorRepo = new DoctorRepository();
        PatientRepository patientRepo = new PatientRepository();
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            model.Filter.PatientId = model.PatientId;
            model.Filter.DoctorId = model.DoctorId;
            model.Filter.AppointmentDate = model.AppointmentDate;

            Expression<Func<Appointment, bool>> filter = model.Filter.GenerateFilter();

            AppointmentRepository repo = new AppointmentRepository();
            model.items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));

            PatientRepository patientsRepo = new PatientRepository();
            //model.PatientOne = patientsRepo.GetById(model.PatientId);
            model.PatientList = patientRepo.GetAll();
            DoctorRepository doctorsRepo = new DoctorRepository();
            //model.DoctorOne = doctorsRepo.GetById(model.DoctorId);
            model.DoctorList = doctorRepo.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id, int? doctorId)
        {
            Appointment item = null;

            AppointmentRepository repo = new AppointmentRepository();
            
            item = id == null ? new Appointment() : repo.GetById(id.Value);
            EditVM model = item == null ? new EditVM() : new EditVM(item);

            PatientRepository pRepo = new PatientRepository();
            List<Patient> allPatients = pRepo.GetAll();

            model.PatientsList = new List<SelectListItem>();
            foreach (Patient patient in allPatients)
            {
                model.PatientsList.Add(
                    new SelectListItem()
                    {
                        Value = patient.Id.ToString(),
                        Text = patient.FirstName + " " + patient.LastName,
                        Selected = patient.Id == model.SelectedPatient
                    }
                    );
            }

            if (model.Id <= 0)
            {
                model.DoctorId = doctorId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit (EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppointmentRepository repo = new AppointmentRepository();
            Appointment item = new Appointment();
            
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Appointments", new { PatientId = item.PatientId , DoctorId = item.DoctorId});

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AppointmentRepository repo = new AppointmentRepository();
            Appointment item = repo.GetById(id);

            repo.Delete(item);

            return RedirectToAction("Index", "Appointments", new { DoctorId = item.DoctorId });

        }

    }
}