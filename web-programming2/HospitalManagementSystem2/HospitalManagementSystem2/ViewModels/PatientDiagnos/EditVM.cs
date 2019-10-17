using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.PatientDiagnos
{
    public class EditVM
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        [DisplayName("Diagnosis Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string DiagnosisName { get; set; }

        public EditVM() { }

        public EditVM(PatientDiagnosis item)
        {
            Id = item.Id;
            PatientId = item.PatientId;
            DiagnosisName = item.DiagnosisName;
        }

        public void PopulateEntity(PatientDiagnosis item)
        {
            item.Id = Id;
            item.PatientId = PatientId;
            item.DiagnosisName = DiagnosisName;
        }
    }
}