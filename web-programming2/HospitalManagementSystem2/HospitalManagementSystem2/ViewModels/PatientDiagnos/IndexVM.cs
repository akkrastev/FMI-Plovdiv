using HospitalManagementSystem2.Entities;
using HospitalManagementSystem2.ViewModels.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.PatientDiagnos
{
    public class IndexVM
    {
        public PagerVM Pager { get; set; }
        public FilterVM Filter { get; set; }

        public List<PatientDiagnosis> Items { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}