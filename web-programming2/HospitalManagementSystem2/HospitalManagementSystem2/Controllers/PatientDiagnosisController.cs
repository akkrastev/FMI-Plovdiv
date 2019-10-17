using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.Filters;
using HospitalManagementSystem2.Repositories;
using HospitalManagementSystem2.ViewModels.PatientDiagnos;
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
    public class PatientDiagnosisController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            model.Filter.PatientId = model.PatientId;

            Expression<Func<PatientDiagnosis, bool>> filter = model.Filter.GenerateFilter();

            PatientDiagnosisRepository repo = new PatientDiagnosisRepository();
            model.Items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));

            PatientRepository contactsRepo = new PatientRepository();
            model.Patient = contactsRepo.GetById(model.PatientId);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id, int? patientId)
        {
            PatientDiagnosis item = null;

            PatientDiagnosisRepository repo = new PatientDiagnosisRepository();

            item = id == null ? new PatientDiagnosis() : repo.GetById(id.Value);

            EditVM model = item == null ? new EditVM() : new EditVM(item);

            if (model.Id <= 0)
            {
                model.PatientId = patientId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            PatientDiagnosisRepository repo = new PatientDiagnosisRepository();
            PatientDiagnosis item = new PatientDiagnosis();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "PatientDiagnosis", new { PatientId = item.PatientId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PatientDiagnosisRepository repo = new PatientDiagnosisRepository();
            PatientDiagnosis item = repo.GetById(id);

            repo.Delete(item);

            return RedirectToAction("Index", "PatientDiagnosis", new { PatientId = item.PatientId });
        }
    }
}