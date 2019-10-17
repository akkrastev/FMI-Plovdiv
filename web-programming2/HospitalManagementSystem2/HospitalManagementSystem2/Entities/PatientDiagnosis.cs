using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.Entities
{
    public class PatientDiagnosis : BaseEntity
    {
        public int PatientId { get; set; }
        public string DiagnosisName { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}