using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.PatientDiagnos
{
    public class FilterVM
    {
        public int PatientId { get; set; }
        [DisplayName("Diagnosis Name:")]
        public string DiagnosisName { get; set; }

        public Expression<Func<PatientDiagnosis, bool>> GenerateFilter()
        {
            return i => (string.IsNullOrEmpty(DiagnosisName) || i.DiagnosisName.Contains(DiagnosisName)) &&
                        (i.PatientId == PatientId);
        }
    }
}