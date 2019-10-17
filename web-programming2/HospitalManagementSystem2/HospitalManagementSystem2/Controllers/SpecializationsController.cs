using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem2.ViewModels.Specializations;
using HospitalManagementSystem2.Filters;

namespace HospitalManagementSystem2.Controllers
{
    [AuthenticationFilter]
    public class SpecializationsController : BaseController<Specialization, SpecializationRepository,FilterVM, IndexVM, EditVM>
    {
        private static HospitalSystemDbContext context = new HospitalSystemDbContext();
        SpecializationRepository repo = new SpecializationRepository(context);
        DoctorRepository doctorRepo = new DoctorRepository(context);


        public ActionResult Details(int id)
        {
            DetailsVM model = new DetailsVM();
            model.specialization = repo.GetById(id);

            model.Doctors = model.specialization.Doctors.ToList();

            return View(model);
        }
        [HttpGet]
        public override ActionResult Edit(int? id)
        {
            Specialization item = null;

            item = id == null ? new Specialization() : repo.GetById(id.Value);

            EditVM model = new EditVM();
            model.PopulateModel(item);
            PopulateEditVM(model);
            if (id != null)
            {
                model.specialization = repo.GetById((int)id);

                model.Doctors = model.specialization.Doctors.ToList();
                
            }
            
            ViewBag.Doctors = doctorRepo.GetAll();
            //context.SaveChanges();
            return View(model);

        }
        [HttpPost]
        public override ActionResult Edit(EditVM model)
        {
            Specialization item = model.Id == 0 ? new Specialization() : repo.GetById(model.Id);
            if (model.DoctorIds != null )
            {
                item.Doctors = doctorRepo.GetAll(c => model.DoctorIds.Contains(c.Id));
                
            }
            

            context.SaveChanges();
            return base.Edit(model);

        }


    }
}