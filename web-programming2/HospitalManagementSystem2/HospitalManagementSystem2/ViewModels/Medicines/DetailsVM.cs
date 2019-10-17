using HospitalManagementSystem2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem2.ViewModels.Medicines
{
    public class DetailsVM
    {
        public Medicine medicines { get; set; }

        public List<Patient> Patients { get; set; }
    }
}