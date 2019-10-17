using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Filters;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem2.Controllers
{
    [AuthenticationFilter]
    public class MedicinesController : BaseController<Medicine, MedicineRepository, FilterVM, IndexVM, EditVM>
    {
        private static HospitalSystemDbContext context = new HospitalSystemDbContext();
        MedicineRepository repo = new MedicineRepository(context);
        PatientRepository patientRepo = new PatientRepository(context);


        public ActionResult Details(int id)
        {
            DetailsVM model = new DetailsVM();
            model.medicines = repo.GetById(id);

            model.Patients = model.medicines.Patients.ToList();

            return View(model);
        }
        [HttpGet]
        public override ActionResult Edit(int? id)
        {
            Medicine item = null;

            item = id == null ? new Medicine() : repo.GetById(id.Value);

            EditVM model = new EditVM();
            model.PopulateModel(item);
            PopulateEditVM(model);
            if (id != null)
            {
                model.Medicines = repo.GetById((int)id);

                model.Patients = model.Medicines.Patients.ToList();

            }

            ViewBag.Patients = patientRepo.GetAll();
            //context.SaveChanges();
            return View(model);

        }
        [HttpPost]
        public override ActionResult Edit(EditVM model)
        {
            Medicine item = model.Id == 0 ? new Medicine() : repo.GetById(model.Id);
            if (model.PatientIds != null)
            {
                item.Patients = patientRepo.GetAll(c => model.PatientIds.Contains(c.Id));

            }


            context.SaveChanges();
            return base.Edit(model);

        }


    }
}